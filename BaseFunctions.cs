using IniParser;
using System.Text;
using IniParser.Model;
using System.Collections.Generic;
using System.IO;

namespace Borgniki
{
    class BaseFunctions
    {
     //   public static Dictionary<string, string> dictionary;
        

        public static IniData OpenAndReadConfig()
        {
            string appfolder = Directory.GetCurrentDirectory()+@"\\";
          //  string appfolder = Path.GetPathRoot(Directory.GetCurrentDirectory());
            var parser = new FileIniDataParser();
            
            string config = appfolder + "config.ini";
            IniData data = new IniData();
           
            data.Configuration.CaseInsensitive = true;
        
            
            
            if (File.Exists(config)) { 
                 data = parser.ReadFile(config,Encoding.GetEncoding("Windows-1251"));

               
                }
            return data;
        

        }

        public static Dictionary<string, string> GetSectionItemsFromDataIni(IniData data, string sect)
        {// возвращает словарь данных, заполненный парами из секции sect
            SectionData section = data.Sections.GetSectionData(sect);
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Clear();
          if (section!=null) // секция найдена
            foreach (KeyData key in section.Keys)
            {
                dictionary.Add(key.KeyName, key.Value);
            }

            return dictionary;
        }


    

       

    }





}
