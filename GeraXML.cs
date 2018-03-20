using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Globalization;
using System.Xml.Linq;
using System.IO;

namespace KMLGenerator
{
    public static class GeraXML
    {

        #region atributos
        public static XmlDocument xmldoc;
        private static XmlElement TagRaiz;
        private static XmlElement TagNome;
        private static string typenodestr = "<!ELEMENT Folder ANY><!ELEMENT name ANY><!ELEMENT Placemark ANY><!ELEMENT Style ANY><!ELEMENT StyleMap ANY><!ELEMENT Document ANY><!ELEMENT open ANY><!ATTLIST Folder id ID #REQUIRED><!ATTLIST Document id ID #REQUIRED><!ATTLIST Placemark id ID #REQUIRED>";
        #endregion

        public static void GerarXML(Map _map, KeyValuePair<DocumentType, string> kmz_type, int _year, string filename)
        {
            XmlWriter writer = null;
            try
            {
                // cria o objeto xmldocument
                xmldoc = new XmlDocument();
                if (File.Exists(filename))
                {
                    xmldoc.Load(filename);
                    XmlNode kml = xmldoc.FirstChild;
                    try
                    {
                        XmlDocumentType typeNode = xmldoc.CreateDocumentType("kml", null, null, typenodestr);
                        xmldoc.InsertAfter(typeNode, kml);
                        xmldoc.LoadXml(xmldoc.InnerXml);
                    }
                    catch (InvalidOperationException ex) { }

                    string tagRaizName = kmz_type.Value.Replace(" ", "") + _year.ToString();
                    if (kmz_type.Key == DocumentType.WeaponSeizure)
                        tagRaizName = "MajorCrimes" + _year.ToString();
                    TagRaiz = xmldoc.GetElementById(tagRaizName);
                }
                else
                {
                    //cria um nodo do documento xml
                    xmldoc.AppendChild(xmldoc.CreateXmlDeclaration("1.0", "UTF-8", null));

                    XmlDocumentType typeNode = xmldoc.CreateDocumentType("kml", null, null, typenodestr);
                    xmldoc.AppendChild(typeNode);

                    XmlElement kmlNode = xmldoc.CreateElement("kml", "http://www.opengis.net/kml/2.2");
                    kmlNode.SetAttribute("xmlns:gx", @"http://www.google.com/kml/ext/2.2");
                    kmlNode.SetAttribute("xmlns:kml", @"http://www.opengis.net/kml/2.2");
                    kmlNode.SetAttribute("xmlns:atom", @"http://www.w3.org/2005/Atom");
                    xmldoc.AppendChild(kmlNode);

                    //cria uma tag chamada ecf
                    TagRaiz = xmldoc.CreateElement("Folder");
                    TagRaiz.SetAttribute("id", kmz_type.Value.Replace(" ", "") + _year.ToString());
                    //da um append da tag no documento
                    kmlNode.AppendChild(TagRaiz);

                    //cria a tag e adiciona no nó raiz
                    TagNome = xmldoc.CreateElement("name");
                    TagNome.InnerText = kmz_type.Value + " " + _year.ToString();
                    TagRaiz.AppendChild(TagNome);

                    //cria a tag abre cupom
                    XmlElement filho1 = xmldoc.CreateElement("open");
                    filho1.InnerText = "1";
                    TagRaiz.AppendChild(filho1);
                }

                if (kmz_type.Key == DocumentType.CivilUnrest)
                {
                    CriaMapaCivUnrest(_map, _year);
                }
                else if (kmz_type.Key == DocumentType.WeaponSeizure)
                {
                    CriaMapaWeapons(_map, _year);
                }
                else if (kmz_type.Key == DocumentType.GenericFile)
                {
                    CriaGenerico(_map);
                }
                else
                {
                    CriaMapa(_map, _year);
                }

                writer = XmlWriter.Create(filename);
                xmldoc.Save(writer);
                writer.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                xmldoc = null;
                writer = null;
            }
        }

        # region XML
        private static void CriaMapaCivUnrest(Map _map, int _year)
        {
            try
            {
                foreach (CivilEventype CivEv in _map._CivilEvTypes)
                {
                    string CivEvt = _map.getParentFolder(CivEv);

                    XmlElement TagFolderCivilEv = xmldoc.GetElementById(CivEvt);

                    if (TagFolderCivilEv == null)
                    {
                        TagFolderCivilEv = xmldoc.CreateElement("Folder");
                        TagFolderCivilEv.SetAttribute("id", CivEvt);
                        XmlElement _TagName = xmldoc.CreateElement("name");
                        _TagName.InnerText = CivEvt;
                        TagFolderCivilEv.AppendChild(_TagName);
                        TagRaiz.AppendChild(TagFolderCivilEv);
                    }
                }

                foreach (PointCivilEv pt in _map._pointsCivEvt)
                {
                    int diaSemana = (int)pt._dataEvento.DayOfWeek;
                    if (diaSemana < 5)
                        diaSemana += 7;

                    DateTime weekStart2 = pt._dataEvento.Subtract(TimeSpan.FromDays(diaSemana - 5));

                    string TagWeekId = _map.getParentFolder(pt._eventType).Replace(" ", "") + weekStart2.ToShortDateString();
                    XmlElement tagPlacemark = xmldoc.GetElementById(TagWeekId.Substring(0, 10) + pt._pointId);

                    if (_year == weekStart2.Year && tagPlacemark == null) //only consider the point if it corresponds to selected year and if point does not exist yet
                    {
                        XmlElement TagFolderCivilEv = xmldoc.GetElementById(_map.getParentFolder(pt._eventType));
                        string weekName = weekStart2.ToShortDateString() + " - " + weekStart2.AddDays(6).ToShortDateString();
                        DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();

                        XmlElement TagFolderWeek = xmldoc.GetElementById(TagWeekId);
                        if (TagFolderWeek == null)
                        {
                            TagFolderWeek = xmldoc.CreateElement("Folder");
                            TagFolderWeek.SetAttribute("id", TagWeekId);
                            TagFolderCivilEv.AppendChild(TagFolderWeek);
                            XmlElement TagName = xmldoc.CreateElement("name");
                            TagName.InnerText = weekName;
                            TagFolderWeek.AppendChild(TagName);

                            TagFolderWeek.InnerXml += _map.getStyle(pt._eventType);
                        }

                        if (pt._longitude == null && pt._latitude == null)
                            throw new Exception("Point " + pt._pointId + " contains empty Latitude or Longitude, please verify.");

                        AddPlaceMark(TagWeekId, pt._pointId, pt._description, pt._latitude, pt._longitude, "#" + pt.getStyleMap(), string.Empty);

                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void CriaMapa(Map _map, int _year)
        {
            foreach (Point pt in _map._points)
            {
                int diaSemana = (int)pt._dataEvento.DayOfWeek;
                if (diaSemana < 5)
                    diaSemana += 7;

                DateTime weekStart2 = pt._dataEvento.Subtract(TimeSpan.FromDays(diaSemana - 5));
                string FolderId = _map.getParentFolder(pt._eventType).Replace(" ", "") + weekStart2.ToShortDateString().Replace(" ", "");
                XmlElement tagPlacemark = xmldoc.GetElementById(FolderId.Substring(0, 10) + pt._pointId);

                if (_year == weekStart2.Year && tagPlacemark == null) //only consider the point if it corresponds to selected year
                {
                    try
                    {
                        string weekName = weekStart2.ToShortDateString() + " - " + weekStart2.AddDays(6).ToShortDateString();
                        DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                        string month = mfi.GetMonthName(weekStart2.Month).ToString();

                        XmlElement TagFolderWeek = xmldoc.GetElementById(weekName.Replace(" ", ""));
                        if (TagFolderWeek == null)
                        {

                            XmlElement TagFolderMonth = xmldoc.GetElementById(month);
                            if (TagFolderMonth == null)
                            {
                                TagFolderMonth = xmldoc.CreateElement("Folder");
                                TagFolderMonth.SetAttribute("id", month);
                                TagRaiz.AppendChild(TagFolderMonth);
                                XmlElement TagNameMonth = xmldoc.CreateElement("name");
                                TagNameMonth.InnerText = month;
                                TagFolderMonth.AppendChild(TagNameMonth);
                            }

                            TagFolderWeek = xmldoc.CreateElement("Folder");
                            TagFolderWeek.SetAttribute("id", weekName.Replace(" ", ""));
                            TagFolderMonth.AppendChild(TagFolderWeek);
                            XmlElement TagName = xmldoc.CreateElement("name");
                            TagName.InnerText = weekName;
                            TagFolderWeek.AppendChild(TagName);

                            foreach (Eventype crime in _map._crimeTypes)
                            {
                                XmlElement TagDocCrime = xmldoc.CreateElement("Document");
                                string cr = _map.getParentFolder(crime);
                                TagDocCrime.SetAttribute("id", cr.Replace(" ", "") + weekStart2.ToShortDateString().Replace(" ", ""));
                                XmlElement _TagName = xmldoc.CreateElement("name");
                                _TagName.InnerText = cr;
                                TagDocCrime.AppendChild(_TagName);
                                TagDocCrime.InnerXml += _map.getStyle(crime);
                                TagFolderWeek.AppendChild(TagDocCrime);
                            }
                        }

                        if (pt._longitude == null && pt._latitude == null)
                            throw new Exception("Point " + pt._pointId + " contains empty Latitude or Longitude, please verify.");

                        AddPlaceMark(FolderId, pt._pointId, pt._description, pt._latitude, pt._longitude, "#" + pt.getStyleMap(), string.Empty);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }

            }

        }

        private static void CriaMapaWeapons(Map _map, int _year)
        {
            foreach (PointWeapon pt in _map._pointWeapon)
            {
                int diaSemana = (int)pt._dataEvento.DayOfWeek;
                if (diaSemana < 5)
                    diaSemana += 7;

                DateTime weekStart2 = pt._dataEvento.Subtract(TimeSpan.FromDays(diaSemana - 5));
                string fld = _map.getParentFolder();
                string FolderId = fld.Replace(" ", "") + weekStart2.ToShortDateString().Replace(" ", "");

                XmlElement tagPlacemark = xmldoc.GetElementById(FolderId.Substring(0, 10) + pt._pointId);

                if (_year == weekStart2.Year && tagPlacemark == null) //only consider the point if it corresponds to selected year
                {
                    string weekName = weekStart2.ToShortDateString() + " - " + weekStart2.AddDays(6).ToShortDateString();
                    DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                    string month = mfi.GetMonthName(weekStart2.Month).ToString();

                    XmlElement TagFolderWeek = xmldoc.GetElementById(weekName.Replace(" ", ""));
                    if (TagFolderWeek == null)
                    {
                        XmlElement TagFolderMonth = xmldoc.GetElementById(month);
                        if (TagFolderMonth == null)
                        {
                            TagFolderMonth = xmldoc.CreateElement("Folder");
                            TagFolderMonth.SetAttribute("id", month);
                            TagRaiz.AppendChild(TagFolderMonth);
                            XmlElement TagNameMonth = xmldoc.CreateElement("name");
                            TagNameMonth.InnerText = month;
                            TagFolderMonth.AppendChild(TagNameMonth);
                        }

                        TagFolderWeek = xmldoc.CreateElement("Folder");
                        TagFolderWeek.SetAttribute("id", weekName.Replace(" ", ""));
                        TagFolderMonth.AppendChild(TagFolderWeek);
                        XmlElement TagName = xmldoc.CreateElement("name");
                        TagName.InnerText = weekName;
                        TagFolderWeek.AppendChild(TagName);
                    }


                    XmlElement TagDocWeapon = xmldoc.GetElementById(FolderId);
                    if (TagDocWeapon == null)
                    {
                        // Creates folder Seized weapon
                        TagDocWeapon = xmldoc.CreateElement("Document");
                        TagDocWeapon.SetAttribute("id", FolderId);
                        XmlElement _TagName = xmldoc.CreateElement("name");
                        _TagName.InnerText = fld;
                        TagDocWeapon.AppendChild(_TagName);
                        TagDocWeapon.InnerXml += _map.getStyle();
                        TagFolderWeek.AppendChild(TagDocWeapon);
                    }

                    if (pt._longitude == null && pt._latitude == null)
                        throw new Exception("Point " + pt._pointId + " contains empty Latitude or Longitude, please verify.");

                    AddPlaceMark(FolderId, pt._pointId, pt._description, pt._latitude, pt._longitude, "#" + pt.getStyleMap(), string.Empty);
                }

            }

        }

        private static void CriaGenerico(Map _map)
        {
            TagRaiz.InnerXml += _map.getStyle(""); //add icon information to file
            try
            {
                foreach (PointGeneric pt in _map._pointsGeneric)
                {
                    XmlElement TagFolderDirectory2 = xmldoc.GetElementById(pt._directory2 + pt._directory1);
                    if (TagFolderDirectory2 == null && (_map._Directory2 == true || _map._Directory1 == true)) //In case none of the directories was defined there is no need to go into this step
                    {
                        XmlElement TagFolderDirectory1 = xmldoc.GetElementById(pt._directory1);
                        if (TagFolderDirectory1 == null && _map._Directory1 == true)
                        {
                            TagFolderDirectory1 = xmldoc.CreateElement("Folder");
                            TagFolderDirectory1.SetAttribute("id", pt._directory1);
                            TagRaiz.AppendChild(TagFolderDirectory1);
                            XmlElement TagNameDirectory = xmldoc.CreateElement("name");
                            TagNameDirectory.InnerText = pt._directory1;
                            TagFolderDirectory1.AppendChild(TagNameDirectory);
                        }
                        else if (_map._Directory1 == false)
                        {
                            TagFolderDirectory1 = TagRaiz;
                        }

                        if (_map._Directory2 == true)
                        {
                            TagFolderDirectory2 = xmldoc.CreateElement("Folder");
                            TagFolderDirectory2.SetAttribute("id", pt._directory2 + pt._directory1);
                            TagFolderDirectory1.AppendChild(TagFolderDirectory2);
                            XmlElement TagName = xmldoc.CreateElement("name");
                            TagName.InnerText = pt._directory2;
                            TagFolderDirectory2.AppendChild(TagName);
                        }
                    }

                    if (pt._longitude == null && pt._latitude == null)
                        throw new Exception("Point " + pt._pointId + " contains empty Latitude or Longitude, please verify.");

                    AddPlaceMark(pt._directory2 + pt._directory1, pt._pointId, pt._description, pt._latitude, pt._longitude, "#" + pt.getStyleMap(), pt._picture);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void AddPlaceMark(string parentFolder, string ID, string description, string latitude, string longitude, string style, string picture)
        {
            XmlElement tagDocument = xmldoc.GetElementById(parentFolder);
            if (parentFolder == "")
                tagDocument = TagRaiz;

            XmlElement tagPlacemark = xmldoc.CreateElement("Placemark");
            if (parentFolder.Length>10)
                tagPlacemark.SetAttribute("id", parentFolder.Substring(0, 10) + ID);
            tagDocument.AppendChild(tagPlacemark);

            XmlElement tagName = xmldoc.CreateElement("name");
            tagName.InnerText = ID;
            tagPlacemark.AppendChild(tagName);

            XmlElement tagstyleUrl = xmldoc.CreateElement("styleUrl");
            tagstyleUrl.InnerText = style;
            tagPlacemark.AppendChild(tagstyleUrl);

            XmlElement tagPoint = xmldoc.CreateElement("Point");
            tagPlacemark.AppendChild(tagPoint);

            XmlElement tagCoord = xmldoc.CreateElement("coordinates");
            if(latitude.Contains("N") && longitude.Contains("W"))
                tagCoord.InnerText = longitude + "," + latitude;
            else
                tagCoord.InnerText = longitude.Replace("°", "") + "," + latitude.Replace("°", "");
            tagPoint.AppendChild(tagCoord);

            XmlElement tagDescript = xmldoc.CreateElement("description");
            tagDescript.InnerText = description;
            if(picture != string.Empty)
                tagDescript.InnerText += "<img src='file://////" + picture + "'//>";
            tagPlacemark.AppendChild(tagDescript);

            tagPlacemark.InnerXml += "<Snippet maxlines='0'></Snippet>";
        }
        #endregion

    }
}
