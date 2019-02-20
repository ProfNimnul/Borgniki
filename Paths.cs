using System;
using System.Collections.Generic;
using IniParser;
using System.Text;
using IniParser.Model;
using System.IO;

namespace Borgniki
{
    class Paths
    {

 
        


        public  void SaveNewPaths(IniData id)
        
        {
            id["paths"]["dbf"] = Form1.pathsDictionary["dbf"];
            id["paths"]["pdf"] = Form1.pathsDictionary["pdf"];
            BaseFunctions.parser.WriteFile(BaseFunctions.pathToConfigIni, id, Encoding.GetEncoding("Windows-1251"));

        }


        public void ExtractPathsFromDict(IniData id)
        {
            Form1.pathsDictionary.Clear()              ;
            
           // Form1.pathsDictionary.Add("dbf", ""];



            string rootfolder = BaseFunctions.GetRootFolderOfCurrentDisk();
            bool containPaths = id.Sections.ContainsSection("paths");
            SectionData section = id.Sections.GetSectionData("paths");

            try
            {
                string sss = section.Keys["dbf"];
                Form1.pathsDictionary.Add("dbf", String.IsNullOrEmpty(sss.Trim())  ? rootfolder : sss );
            }
            catch (System.NullReferenceException)
            {
              //  Form1.pathsDictionary["dbf"] = rootfolder;
              Form1.pathsDictionary.Add("dbf", rootfolder);
            }


            try
            {
                string sss = section.Keys["pdf"];
                Form1.pathsDictionary.Add("pdf", String.IsNullOrEmpty(sss.Trim()) ? rootfolder : sss);

            }
            catch (System.NullReferenceException)
            {
               // Form1.pathsDictionary["pdf"] = rootfolder;
               Form1.pathsDictionary.Add("pdf", rootfolder);
            }
        



        }

    }



}
