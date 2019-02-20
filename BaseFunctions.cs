using IniParser;
using System.Text;
using IniParser.Model;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Borgniki
{
     class BaseFunctions
    {
        public static FileIniDataParser parser = new FileIniDataParser();

        public static string pathToConfigIni;

        private Form1 form=new Form1();


        public BaseFunctions(Form1 form)
        {
            this.form = form;
        }

        public static string GetRootFolderOfCurrentDisk() // возвращает корневую папку текущего диска
        {
            return Path.GetPathRoot(Directory.GetCurrentDirectory());
        }

        public static IniData OpenAndReadConfig()
        {
            string appfolder = Directory.GetCurrentDirectory()+@"\\";
            pathToConfigIni = appfolder + "config.ini";
            IniData data = new IniData();
           
            data.Configuration.CaseInsensitive = true;
        
            
            
            if (File.Exists(pathToConfigIni)) { 
                 data = parser.ReadFile(pathToConfigIni,Encoding.GetEncoding("Windows-1251"));

               
                }
            return data;
        

        }

        public static Dictionary<string, string> GetSectionItemsFromConfigIni(IniData data, string sect)
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

        public void Protocol( string msg)
        {


            form.protocolTexBox.Text += msg;


        }
    

       

    }





}
