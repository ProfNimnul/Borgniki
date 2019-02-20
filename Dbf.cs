using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Borgniki
{
    class Dbf
    {

        public Excel.Workbook xlWbk;
        public Excel.Application xlApp;
        public Excel.Worksheet xlWsht;



        public bool OpenDBF()
        {

            //var fileContent = string.Empty;
            string path = string.Empty;

            bool result = false;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {


                string initialDirectory = Form1.pathsDictionary["dbf"];

                openFileDialog.InitialDirectory = Directory.Exists(initialDirectory)
                    ? initialDirectory
                    : BaseFunctions.GetRootFolderOfCurrentDisk();


                {
                    openFileDialog.Filter = "Файлы Dbf (*.Dbf)|*.Dbf";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;
                }


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    //workForm.CreatePdfButton.Enabled = true;
                    //Get the path of specified file
                    string dbffname = openFileDialog.FileName;
                    initialDirectory = Path.GetDirectoryName(dbffname);


                    xlApp = new Excel.Application();

                    if (xlApp == null)
                    {
                        MessageBox.Show("Отсутствует или неверно установлен Microsoft Excel!",
                            "Хьюстон, у нас проблема!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    // все нормально, начинаем работать с dbf
                    else
                    {

                        Form1.pathsDictionary["dbf"] = initialDirectory;
                        xlWbk = xlApp.Workbooks.Open(dbffname); // открыли файл с базой
                        xlWsht = (Excel.Worksheet) xlWbk.Worksheets[1];
                        xlApp.DisplayAlerts = false;
                        result = true; // возвращаем true только в том случае, если удалось нормально открыть файл Dbf

                    }
                }
            }

            return result;
        }




        public bool ReplaceInExcel(Dictionary<string, string> templateDictionary)
        {
            bool result = true;
            xlApp.Visible = false;

            try
            {
                xlWsht.Activate(); // кидает эксепшен
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.ToString());
                result = false;
            }

            try
            {
                CreateHeader(); // вставляем заголовок

                var range = (Excel.Range) xlWsht.Columns["A:C"];


                foreach (var pair in templateDictionary)
                {

                    range.Replace(pair.Key, pair.Value, 2, 2, false, true);

                }
                //xlApp.Visible = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.ToString());
                result = false;
                

            }

            return result;

        }



        public void SaveXls()
        {
            string currentDate = DateTime.Now.ToString("MM-yyyy");
            string foldername = String.Empty;


            string initialDirectory = Form1.pathsDictionary["pdf"];


            initialDirectory = Directory.Exists(initialDirectory)
                ? initialDirectory
                : BaseFunctions.GetRootFolderOfCurrentDisk();





            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowNewFolderButton = true;


            folder.SelectedPath = initialDirectory;



            if (folder.ShowDialog() == DialogResult.OK)
            {
                foldername = folder.SelectedPath;
            }

            if (!String.IsNullOrEmpty(foldername))
            {
                Form1.pathsDictionary["pdf"] = foldername;

                foldername = foldername + String.Format("Боржники станом на {0}", currentDate) + ".pdf";
                xlWbk.ExportAsFixedFormat(0, foldername, 0, 0);

                 // сохраняем новый путь
                // сохранение в INI-при выходе из программы


            }



            CloseExcel();

        }

        public void CloseExcel()
        {
            try
            {
                {
                    xlWbk.Saved = true;
                    xlWbk.Close();
                }
                
            }
        
            catch (Exception e)
            {

            }
            finally
            { 
            
            xlApp.Quit();
            }



        }



        private void CreateHeader()
        {
            string[] monts = new[]
            {
                "січня", "лютого", "березня", "квітня", "травня", "червня", "липня", "серпня",
                "вересня", "жовтня", "листопада", "грудня"
            };


            int monthnumber = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            string monthname = monts[monthnumber-1];

            // cюда потом вставить чтение хедера из файла warning.dat
            // или использовать работу с ini





            string warning =
                "Усім боржникам потрібно терминово погасити існуючу заборгованість для подальшого відповідного надання послуг з утримання будинків та прибудинкових територій!";
            // Єто перенести
            string city = "м. Чорноморськ";
            string info =String.Format("Перелік боржників за послуги з утримання будинків та прибудинкових теріторій станом на 01 {0} {1} року.", monthname, year);
             


            // for(byte i=1; i<=5; i++) // добавляем пустые строки сверху
            /* на будущее-хранить все строки заголовка в файле, загружать в  массив или в список */
            xlWsht.Range["2:10"].Insert(Excel.XlInsertShiftDirection.xlShiftDown); // добавляем строку
            xlWsht.Range["A1:F6"].ClearContents();



            xlWsht.Range["A1:F1"].Merge();
            xlWsht.Range["A1"].HorizontalAlignment = -4108; //xlCenter
            xlWsht.Range["A1"].VerticalAlignment = -4160; //xlTop

            xlWsht.Range["A1"].Value = city;
            xlWsht.Range["A1"].Font.Bold = -1;

            xlWsht.Range["A2:F2"].Merge();
            xlWsht.Range["A2"].Value = "КП \"МУЖКГ\"";
            xlWsht.Range["A2"].Font.Bold = -1;
            xlWsht.Range["A2"].HorizontalAlignment = -4108; //xlCenter
            xlWsht.Range["A2"].VerticalAlignment = -4160; //xlTop

            xlWsht.Range["A3:F4"].Merge();

            xlWsht.Range["A3"].HorizontalAlignment = -4108; // xlCenter
            xlWsht.Range["A3"].VerticalAlignment = -4160; // xlTop
            xlWsht.Range["A3"].ShrinkToFit = 0;
            xlWsht.Range["A3"].WrapText = -1;
            xlWsht.Range["A3"].Font.Bold = -1;
            xlWsht.Range["A3"].Value = info;

            xlWsht.Range["A6:F8"].Merge();
            xlWsht.Range["A6"].HorizontalAlignment = -4108; //xlCenter
            xlWsht.Range["A6"].VerticalAlignment = -4160; //xlTop
            xlWsht.Range["A6"].WrapText = -1;
            xlWsht.Range["A6"].Orientation = 0;
            xlWsht.Range["A6"].AddIndent = 0;
            xlWsht.Range["A6"].IndentLevel = 0;
            xlWsht.Range["A6"].ShrinkToFit = -1;
            xlWsht.Range["A6"].ReadingOrder = -5002; //xlContext
            xlWsht.Range["A6"].MergeCells = -1;
            xlWsht.Range["A6"].Font.Size = 16;
            xlWsht.Range["A6"].Font.Bold = -1;
            xlWsht.Range["A6"].Font.Color = -16776961;
            xlWsht.Range["A6"].RowHeight = 58.5;


            xlWsht.Range["A6"].Value = warning;

            xlWsht.Range["A10"].Font.Bold = -1;
            xlWsht.Range["B10"].Font.Bold = -1;
            xlWsht.Range["C10"].Font.Bold = -1;

            xlWsht.Range["A10"].Value = "Вул., буд.";
            xlWsht.Range["B10"].Value = "кв.";
            xlWsht.Range["C10"].HorizontalAlignment = -4152; // xlRight
            xlWsht.Range["C10"].Value = "Борг, грн.,коп.";
            xlWsht.Range["C10"].ShrinkToFit = -1;
            xlWsht.Range["C10"].ReadingOrder = -5002; //xlContext

        }
    }
}
