using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.IO;

namespace KMLGenerator
{
    public static class CompactFile
    {
        public static void Compress(string DirectName, string destFile)
        {
            if (File.Exists(destFile))
                File.Delete(destFile);

            ZipFile.CreateFromDirectory(DirectName, destFile);
        }

        public static void CleanDirectory(string DirectName)
        {
            try { 
            string[] files = Directory.GetFiles(DirectName);
            foreach (string fl in files)
            {
                File.Delete(fl);
            }
            string[] directories = Directory.GetDirectories(DirectName);
            foreach (string dr in directories)
            {
                string[] infiles = Directory.GetFiles(dr);
                foreach (string ifl in infiles)
                {
                    File.Delete(ifl);
                }
                Directory.Delete(dr);
            }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Uncompress(string srcFile, string DirectName)
        {
            ZipFile.ExtractToDirectory(srcFile, DirectName);
        }
    }
}
