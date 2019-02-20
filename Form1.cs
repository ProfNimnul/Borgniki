using System;
using System.Windows.Forms;
using System.Collections.Generic;
using IniParser;
using IniParser.Model;

namespace Borgniki
{
    
    public partial class Form1 : Form
    {

        public static Dictionary<string, string> pathsDictionary = new Dictionary<string, string>();
        public static IniData datafromini;
        Dbf dbf;
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenDBF_button_Click(object sender, EventArgs e)
        {
            datafromini = BaseFunctions.OpenAndReadConfig(); // читаем файл config.ini


            // оба имени без квадратных скобок

            Dictionary<string, string> rd = BaseFunctions.GetSectionItemsFromConfigIni(datafromini, "replace");

            Dictionary<string, string> pd = BaseFunctions.GetSectionItemsFromConfigIni(datafromini, "paths");

            
                     
            Paths paths = new Paths();
            paths.ExtractPathsFromDict(datafromini);
        
            
            dbf = new Dbf(); // создали класс Dbf

            if (rd.Count > 0) // если удалось считать секцию [replace]
            {// тут выполняем код по замене

                
                dbf.OpenDBF();
                bool opened = dbf.ReplaceInExcel(rd);
                if (opened)

                    dbf.SaveXls();

            }                // ...
            paths.SaveNewPaths(datafromini);
            dbf.CloseExcel();
                
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //paths.SaveNewPaths(datafromini);
            dbf.CloseExcel();
        }
    }
}
