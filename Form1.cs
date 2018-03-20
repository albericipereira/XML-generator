using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Threading;
using System.IO;
using System.Configuration;
using System.Collections;

namespace KMLGenerator
{
    public enum DocumentType
    {
        MajorCrimes,
        CivilUnrest,
        WeaponSeizure,
        GenericFile
    }
    public partial class Form1 : Form
    {
        private List<Point> _ListaPontos;

        public Form1()
        {
            InitializeComponent();
            _ListaPontos = new List<Point>();

            this.comboBox1.DisplayMember = "Value";
            this.comboBox1.ValueMember = "Key";
            comboBox1.Items.Add(new KeyValuePair<DocumentType, string>(DocumentType.CivilUnrest, "Civil Unrest"));
            comboBox1.Items.Add(new KeyValuePair<DocumentType, string>(DocumentType.MajorCrimes, "Major Crimes"));
            comboBox1.Items.Add(new KeyValuePair<DocumentType, string>(DocumentType.WeaponSeizure, "Weapon Seizure"));
            comboBox1.Items.Add(new KeyValuePair<DocumentType, string>(DocumentType.GenericFile, "Generic File"));
        }

        public struct Columns
        {
            public string ColumnName;
            public string ColumnValue;
            public Eventype EventType;
            public CivilEventype CivEventType;
            public int Action;

            public Columns(string _ColumnName, string _ColumnValue, Eventype _EventType, int _Action)
            {
                ColumnName = _ColumnName;
                ColumnValue = _ColumnValue;
                this.EventType = _EventType;
                Action = _Action;
                CivEventType = CivilEventype.None;
            }
            public Columns(string _ColumnName, string _ColumnValue, CivilEventype _EventType, int _Action)
            {
                ColumnName = _ColumnName;
                ColumnValue = _ColumnValue;
                this.EventType = Eventype.None;
                Action = _Action;
                CivEventType = _EventType;
            }
            public Columns(string _ColumnName, int _Action)
            {
                ColumnName = _ColumnName;
                ColumnValue = "";
                this.EventType = Eventype.None;
                Action = _Action;
                CivEventType = CivilEventype.Unknown;
            }
        }

        public static class MapAttributes
        {
            public static List<Columns> MapaColunas;
            public static List<Columns> MapaCivUnrest;
            public static Columns MapaMoto;
            public static Columns MapaRape;

            static MapAttributes()
            {
                MapaColunas = new List<Columns>();
                MapaCivUnrest = new List<Columns>();
                MapaMoto = new Columns();
                MapaRape = new Columns();

                MapaColunas.Add(new Columns("Crime Number", 1));
                MapaColunas.Add(new Columns("Latitude", 2));
                MapaColunas.Add(new Columns("Longitude", 3));
                MapaColunas.Add(new Columns("Information on Crime", 4));
                MapaColunas.Add(new Columns("Date of Crime", 5));

                MapaColunas.Add(new Columns("Crime Type", "Assault", Eventype.Assault, 0));
                MapaColunas.Add(new Columns("Crime Type", "Attempt to Rape", Eventype.AttemptRape, 0));
                MapaColunas.Add(new Columns("Crime Type", "Homicide", Eventype.Homicide, 0));
                MapaColunas.Add(new Columns("Crime Type", "Kidnapping", Eventype.Kidnapping, 0));
                MapaColunas.Add(new Columns("Crime Type", "Robbery", Eventype.Robbery, 0));
                MapaColunas.Add(new Columns("Crime Type", "Possession/Traffickin of narcotics", Eventype.Narcotics, 0));
                MapaColunas.Add(new Columns("Bank Related", "TRUE", Eventype.BankRelated, 0));
                MapaColunas.Add(new Columns("Firearm Used", "TRUE", Eventype.FirearmIncidents, 0));
                MapaColunas.Add(new Columns("HNP Wounded", "TRUE", Eventype.HNPWounded, 0));
                MapaColunas.Add(new Columns("HNP Killed", "TRUE", Eventype.HNPKilled, 0));

                MapaColunas.Add(new Columns("Motorcycle Crime", "TRUE", Eventype.MotorcycleNonMurder, 7));
                MapaMoto = new Columns("Crime Type", "Homicide", Eventype.MotorcycleMurder, 0);

                MapaColunas.Add(new Columns("Icon Location type", "Red Square", Eventype.RapeDay, 6));
                MapaColunas.Add(new Columns("Icon Location type", "Blue Square", Eventype.RapeNight, 6));
                MapaColunas.Add(new Columns("Icon Location type", "White Square", Eventype.RapeUnknown, 6));
                MapaRape = new Columns("Crime Type", "Rape", Eventype.MotorcycleMurder, 0);

                // Map for civil unrest
                MapaCivUnrest.Add(new Columns("Event Number", 1));
                MapaCivUnrest.Add(new Columns("Latitude", 2));
                MapaCivUnrest.Add(new Columns("Longitude", 3));
                MapaCivUnrest.Add(new Columns("Description of Event", 4));
                MapaCivUnrest.Add(new Columns("Start Date", 5));

                MapaCivUnrest.Add(new Columns("Primary Trigger", "Commemoration", CivilEventype.Commemoration, 0));
                MapaCivUnrest.Add(new Columns("Primary Trigger", "Justice", CivilEventype.Justice, 0));
                MapaCivUnrest.Add(new Columns("Primary Trigger", "Political", CivilEventype.Political, 0));
                MapaCivUnrest.Add(new Columns("Primary Trigger", "Security", CivilEventype.Security, 0));
                MapaCivUnrest.Add(new Columns("Primary Trigger", "Socioeconomic", CivilEventype.Socioeconomic, 0));
                MapaCivUnrest.Add(new Columns("Primary Trigger", "Unknown", CivilEventype.Unknown, 0));

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Equals(string.Empty) || !textBox1.Text.ToLower().Contains(".xls"))
                {
                    MessageBox.Show("Please inform Excel file name.");
                    return;
                }
                else if (textBox2.Text.Equals(string.Empty) || !textBox2.Text.ToLower().Contains(".kmz"))
                {
                    MessageBox.Show("Please inform KMZ file name.");
                    return;
                }
                else if (comboBox1.SelectedIndex < 0)
                {
                    MessageBox.Show("Please inform file type.");
                    return;
                }

                label4.Visible = true;

                // Start the BackgroundWorker.
                if (!Directory.Exists("Compact"))
                    Directory.CreateDirectory("Compact");

                if (File.Exists(textBox2.Text))
                    CompactFile.Uncompress(textBox2.Text, "Compact");

                GeraXML.GerarXML(leArquivo(), (KeyValuePair<DocumentType, string>)comboBox1.SelectedItem, Convert.ToInt16(numericUpDown1.Value), "Compact\\doc.kml");

                CompactFile.Compress("Compact", textBox2.Text);

                MessageBox.Show("File succesfully generated!");
            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show("ERROR: Some attributes were not found in file. Please verify the file you are trying to import is a " + ((KeyValuePair<DocumentType, string>)comboBox1.SelectedItem).Value + " file");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
            finally
            {
                CompactFile.CleanDirectory("Compact");
                label4.Visible = false;
            }
        }

        private void leArquivoWeapon(Map map, Dictionary<string, int> _listColumns, Range range)
        {
            try
            {
                int rCnt = 0;
                string id = null;
                string Latitude = null;
                string Longitude = null;
                string Description = null;

                for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
                {
                    try
                    {
                        id = (string)(range.Cells[rCnt, _listColumns["Event Number"]] as Range).Value2;
                        Latitude = (string)(range.Cells[rCnt, _listColumns["Latitude"]] as Range).Value2;
                        Longitude = (string)(range.Cells[rCnt, _listColumns["Longitude"]] as Range).Value2;
                        Description = (string)(range.Cells[rCnt, _listColumns["Relevant Information"]] as Range).Value2;

                        Double db = (Double)(range.Cells[rCnt, _listColumns["Date of Seizure"]] as Range).Value2;
                        DateTime conv = DateTime.FromOADate(db);
                        string date = conv.ToShortDateString();

                        map._pointWeapon.Add(new PointWeapon(id, Latitude, Longitude, Description, date));
                    }
                    catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
                    {
                        if (id == null && Latitude == null && Longitude == null)
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void leArquivoGenerico(Map map, Dictionary<string, int> _listColumns, Range range)
        {
            try
            {
                int rCnt = 0;
                string id = null;
                string Latitude = null;
                string Longitude = null;

                for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
                {
                    try
                    {
                        string Directory1 = "";
                        string Directory2 = "";
                        string Icon = "YellowPushpin";
                        string Picture = "";
                        string Description = "";

                        id = (string)(range.Cells[rCnt, _listColumns["ID"]] as Range).Value2;
                        Latitude = (string)(range.Cells[rCnt, _listColumns["Latitude"]] as Range).Value2;
                        Longitude = (string)(range.Cells[rCnt, _listColumns["Longitude"]] as Range).Value2;

                        if (_listColumns.ContainsKey("Description"))
                            Description = (string)(range.Cells[rCnt, _listColumns["Description"]] as Range).Value2;

                        if (map._Directory1 == true)
                            Directory1 = (string)(range.Cells[rCnt, _listColumns["Directory1"]] as Range).Value2;
                        if (map._Directory2 == true)
                            Directory2 = (string)(range.Cells[rCnt, _listColumns["Directory2"]] as Range).Value2;

                        if (_listColumns.ContainsKey("Icon"))
                            Icon = (string)(range.Cells[rCnt, _listColumns["Icon"]] as Range).Value2;
                        
                        if(_listColumns.ContainsKey("Picture"))
                            Picture = (string)(range.Cells[rCnt, _listColumns["Picture"]] as Range).Value2;

                        map._pointsGeneric.Add(new PointGeneric(id, Latitude, Longitude, Description, Directory1, Directory2, Icon, Picture));
                    }
                    catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
                    {
                        if (id == null && Latitude == null && Longitude == null)
                        {
                            continue;
                        }
                        else {
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void leArquivoCivUnr(Map map, Dictionary<string, int> _listColumns, Range range)
        {
            try
            {
                int rCnt = 0;
                int cCnt = 0;

                for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
                {
                    string[] varString = new string[5];
                    try
                    {
                        foreach (Columns c in MapAttributes.MapaCivUnrest)
                        {
                            cCnt = _listColumns[c.ColumnName];

                            if (c.Action > 0 && c.Action < 5)
                            {
                                varString[c.Action - 1] = (string)(range.Cells[rCnt, cCnt] as Range).Value2;
                            }
                            else if (c.Action == 5)
                            {
                                Double db = (Double)(range.Cells[rCnt, cCnt] as Range).Value2;
                                DateTime conv = DateTime.FromOADate(db);
                                varString[c.Action - 1] = conv.ToShortDateString();
                            }
                            else if ((string)(range.Cells[rCnt, cCnt] as Range).Value2 == c.ColumnValue)
                            {
                                Boolean violent;
                                //Add new points to the map if the contend of the column corresponds to the civil event
                                try
                                {
                                    violent = ((Boolean)(range.Cells[rCnt, _listColumns["Violent"]] as Range).Value2);
                                }
                                catch
                                {
                                    violent = Convert.ToBoolean((range.Cells[rCnt, _listColumns["Violent"]] as Range).Value2);
                                }

                                map._pointsCivEvt.Add(new PointCivilEv(c.CivEventType, varString[0], varString[1], varString[2], varString[3], varString[4], violent));
                            }

                        }
                    }
                    catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
                    {
                        if (varString[0] == null && varString[1] == null && varString[1] == null)
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void leArquivoCrime(Map map, Dictionary<string, int> _listColumns, Range range)
        {
            try
            {
                int rCnt = 0;
                int cCnt = 0;

                for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
                {

                    string[] varString = new string[5];

                    try
                    {
                        foreach (Columns c in MapAttributes.MapaColunas)
                        {
                            cCnt = _listColumns[c.ColumnName];

                            if (c.Action > 0 && c.Action < 5)
                            {
                                varString[c.Action - 1] = (string)(range.Cells[rCnt, cCnt] as Range).Value2;
                            }
                            else if (c.Action == 5)
                            {

                                Double db = (Double)(range.Cells[rCnt, cCnt] as Range).Value2;
                                DateTime conv = DateTime.FromOADate(db);
                                varString[c.Action - 1] = conv.ToShortDateString();

                            }
                            else if (c.Action == 7)
                            {
                                // Verify if it is a homicide and motorcycle crime 
                                if ((string)(range.Cells[rCnt, _listColumns[MapAttributes.MapaMoto.ColumnName]] as Range).Value2 ==
                                    MapAttributes.MapaMoto.ColumnValue &&
                                    ((Boolean)(range.Cells[rCnt, cCnt] as Range).Value2).ToString().ToUpper() == c.ColumnValue)
                                {
                                    map._points.Add(new Point(MapAttributes.MapaMoto.EventType, varString[0], varString[1], varString[2], varString[3], varString[4]));
                                }
                                else if (((Boolean)(range.Cells[rCnt, cCnt] as Range).Value2).ToString().ToUpper() == c.ColumnValue) // Check if it is only motorcycle crime
                                {
                                    map._points.Add(new Point(c.EventType, varString[0], varString[1], varString[2], varString[3], varString[4]));
                                }
                            }
                            else if (c.Action == 6)
                            { //Check if rape and icon is according to rape hours
                                if ((string)(range.Cells[rCnt, _listColumns[MapAttributes.MapaRape.ColumnName]] as Range).Value2 ==
                                    MapAttributes.MapaRape.ColumnValue &&
                                    (string)(range.Cells[rCnt, cCnt] as Range).Value2 == c.ColumnValue)
                                {
                                    map._points.Add(new Point(c.EventType, varString[0], varString[1], varString[2], varString[3], varString[4]));
                                }
                            }
                            else
                            {
                                try
                                {
                                    //Add new points to the map if the contend of the column corresponds to the crime type
                                    if ((string)(range.Cells[rCnt, cCnt] as Range).Value2 == c.ColumnValue)
                                    {
                                        map._points.Add(new Point(c.EventType, varString[0], varString[1], varString[2], varString[3], varString[4]));
                                    }
                                }
                                catch (Exception)
                                {
                                    //Add new points to the map if the contend of the column corresponds to the crime type
                                    string str = ((Boolean)(range.Cells[rCnt, cCnt] as Range).Value2).ToString().ToUpper();
                                    if (str == c.ColumnValue)
                                    {
                                        map._points.Add(new Point(c.EventType, varString[0], varString[1], varString[2], varString[3], varString[4]));
                                    }
                                }
                            }
                        }
                    }
                    catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
                    {
                        if (varString[0] == null && varString[1] == null && varString[1] == null)
                        {
                            continue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Map leArquivo()
        {
            Microsoft.Office.Interop.Excel.Application xlApp;
            Workbook xlWorkBook;
            Worksheet xlWorkSheet;
            Dictionary<string, int> _listColumns = new Dictionary<string, int>();
            Map map = new Map();
            Range range;

            int cCnt = 0;
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(textBox1.Text, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);

            try
            {
                range = xlWorkSheet.UsedRange;

                for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                {
                    if (!_listColumns.ContainsKey((string)(range.Cells[1, cCnt] as Range).Value2))
                        _listColumns.Add((string)(range.Cells[1, cCnt] as Range).Value2, cCnt);
                }

                if (((KeyValuePair<DocumentType, string>)comboBox1.SelectedItem).Key == DocumentType.CivilUnrest)
                {
                    leArquivoCivUnr(map, _listColumns, range);
                }
                else if (((KeyValuePair<DocumentType, string>)comboBox1.SelectedItem).Key == DocumentType.WeaponSeizure)
                {
                    leArquivoWeapon(map, _listColumns, range);
                }
                else if (((KeyValuePair<DocumentType, string>)comboBox1.SelectedItem).Key == DocumentType.GenericFile)
                {
                    if (!_listColumns.ContainsKey("Directory1"))
                        map._Directory1 = false;
                    if (!_listColumns.ContainsKey("Directory2"))
                        map._Directory2 = false;
                    leArquivoGenerico(map, _listColumns, range);
                }
                else
                {
                    leArquivoCrime(map, _listColumns, range);
                }

                return map;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                xlWorkBook.Close(0);
                xlApp.Quit();
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                //releaseObject(xlApp);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = "D:\\";
            openFileDialog1.DefaultExt = ".xls";
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = "D:\\";
            openFileDialog1.DefaultExt = ".xml";
            openFileDialog1.ShowDialog();
            textBox2.Text = openFileDialog1.FileName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = DateTime.Now.Year;
        }

    }
}
