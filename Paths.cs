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

 
        private string GetRootFolderOfCurrentDisk() // возвращает корневую папку текущего диска
        {
            return Path.GetPathRoot(Directory.GetCurrentDirectory());
        }


        private void SaveNewPaths(string item, string path)
        // dbf="D:\\" - item = path
        {
            // сохраняет пути в файл config.ini (перезаписывает каждый раз)
        }


        public void ExtractPathsFromDict(IniData id)
        {
            Form1.pathsDictionary.Clear()              ;
            Form1.pathsDictionary.Add("pdf", "");
            Form1.pathsDictionary.Add("dbf", "");



            string rootfolder = GetRootFolderOfCurrentDisk();
            bool containPaths = id.Sections.ContainsSection("paths");                                                  
            if  (containPaths) // такой секции нет


            {
                SectionData section = id.Sections.GetSectionData("paths");
                if (section.Keys["dbf"] == "")
                    Form1.pathsDictionary["dbf"] = rootfolder;

                if (section.Keys["pdf"] == "")
                    Form1.pathsDictionary["pdf"] = rootfolder;

            }
            else

            {
                Form1.pathsDictionary["dbf"] =rootfolder;
                Form1.pathsDictionary["pdf"] =rootfolder;
                //.....
            }
            // содержит, проверяем каждый пункт в отдельности
            


        }

    }



}
