namespace Borgniki
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.OpenDBF_button = new System.Windows.Forms.Button();
            this.SavePDF_button = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // OpenDBF_button
            // 
            this.OpenDBF_button.Location = new System.Drawing.Point(33, 12);
            this.OpenDBF_button.Name = "OpenDBF_button";
            this.OpenDBF_button.Size = new System.Drawing.Size(123, 26);
            this.OpenDBF_button.TabIndex = 0;
            this.OpenDBF_button.Text = "Открыть DBF...";
            this.OpenDBF_button.UseVisualStyleBackColor = true;
            this.OpenDBF_button.Click += new System.EventHandler(this.OpenDBF_button_Click);
            // 
            // SavePDF_button
            // 
            this.SavePDF_button.Location = new System.Drawing.Point(33, 60);
            this.SavePDF_button.Name = "SavePDF_button";
            this.SavePDF_button.Size = new System.Drawing.Size(123, 26);
            this.SavePDF_button.TabIndex = 1;
            this.SavePDF_button.Text = "Сохранить PDF...";
            this.SavePDF_button.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(186, 96);
            this.Controls.Add(this.SavePDF_button);
            this.Controls.Add(this.OpenDBF_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OpenDBF_button;
        private System.Windows.Forms.Button SavePDF_button;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

