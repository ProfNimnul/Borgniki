using System;
using System.Windows.Forms;
using System.Collections.Generic;
namespace Borgniki
{
    public partial class Form1 : Form
    {

        public static Dictionary<string, string> pathsDictionary = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenDBF_button_Click(object sender, EventArgs e)
        {
            var datafromini = BaseFunctions.OpenAndReadConfig(); // читаем файл config.ini


            // оба имени без квадратных скобок

            Dictionary<string, string> rd = BaseFunctions.GetSectionItemsFromDataIni(datafromini, "replace");

            Dictionary<string, string> pd = BaseFunctions.GetSectionItemsFromDataIni(datafromini, "paths");

            
                     
            Paths paths = new Paths();
            paths.ExtractPathsFromDict(datafromini);

            

            if (rd.Count > 0) // если удалось считать секцию [replace]
            {// тут выполняем код по замене

                Dbf dbf = new Dbf(); // создали класс Dbf

            }                // ...


                
            
        }
    }
}
