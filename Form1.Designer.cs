﻿namespace Borgniki
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Info = new System.Windows.Forms.Label();
            this.protocolTexBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OpenDBF_button
            // 
            this.OpenDBF_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenDBF_button.Location = new System.Drawing.Point(12, 184);
            this.OpenDBF_button.Name = "OpenDBF_button";
            this.OpenDBF_button.Size = new System.Drawing.Size(318, 41);
            this.OpenDBF_button.TabIndex = 0;
            this.OpenDBF_button.Text = "Открыть и обработать DBF...";
            this.OpenDBF_button.UseVisualStyleBackColor = true;
            this.OpenDBF_button.Click += new System.EventHandler(this.OpenDBF_button_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Info
            // 
            this.Info.AutoSize = true;
            this.Info.Location = new System.Drawing.Point(21, 90);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(0, 13);
            this.Info.TabIndex = 1;
            // 
            // protocolTexBox
            // 
            this.protocolTexBox.Location = new System.Drawing.Point(12, 12);
            this.protocolTexBox.Multiline = true;
            this.protocolTexBox.Name = "protocolTexBox";
            this.protocolTexBox.Size = new System.Drawing.Size(318, 156);
            this.protocolTexBox.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 241);
            this.Controls.Add(this.protocolTexBox);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.OpenDBF_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenDBF_button;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label Info;
        public System.Windows.Forms.TextBox protocolTexBox;
    }
}

