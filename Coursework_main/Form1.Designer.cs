using System.Collections.Generic;

namespace Coursework_main
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
            this.SearchButton = new System.Windows.Forms.Button();
            this.MinDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.maxDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.DateGroupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DateCheckbox = new System.Windows.Forms.CheckBox();
            this.FileNameCheckbox = new System.Windows.Forms.CheckBox();
            this.FileNameTextBox = new System.Windows.Forms.TextBox();
            this.FileNameGroupBox = new System.Windows.Forms.GroupBox();
            this.typeResultGroupBox = new System.Windows.Forms.GroupBox();
            this.resultTypeCheckbox = new System.Windows.Forms.CheckBox();
            this.IpGroupBox = new System.Windows.Forms.GroupBox();
            this.IpTextBox = new System.Windows.Forms.TextBox();
            this.ipCheckbox = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FileNameShowTextBox = new System.Windows.Forms.TextBox();
            this.ChoseFileButton = new System.Windows.Forms.Button();
            this.ChoseFileGroupbox = new System.Windows.Forms.GroupBox();
            this.ResultTypeComboBox = new System.Windows.Forms.ComboBox();
            this.DateGroupBox.SuspendLayout();
            this.FileNameGroupBox.SuspendLayout();
            this.typeResultGroupBox.SuspendLayout();
            this.IpGroupBox.SuspendLayout();
            this.ChoseFileGroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(92, 449);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(107, 38);
            this.SearchButton.TabIndex = 1;
            this.SearchButton.Text = "Поиск";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // MinDateTimePicker
            // 
            this.MinDateTimePicker.Location = new System.Drawing.Point(27, 28);
            this.MinDateTimePicker.Name = "MinDateTimePicker";
            this.MinDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.MinDateTimePicker.TabIndex = 2;
            // 
            // maxDateTimePicker
            // 
            this.maxDateTimePicker.Location = new System.Drawing.Point(27, 64);
            this.maxDateTimePicker.Name = "maxDateTimePicker";
            this.maxDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.maxDateTimePicker.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(72, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Фильтры";
            // 
            // DateGroupBox
            // 
            this.DateGroupBox.Controls.Add(this.label3);
            this.DateGroupBox.Controls.Add(this.label2);
            this.DateGroupBox.Controls.Add(this.MinDateTimePicker);
            this.DateGroupBox.Controls.Add(this.maxDateTimePicker);
            this.DateGroupBox.Enabled = false;
            this.DateGroupBox.Location = new System.Drawing.Point(19, 151);
            this.DateGroupBox.Name = "DateGroupBox";
            this.DateGroupBox.Size = new System.Drawing.Size(227, 100);
            this.DateGroupBox.TabIndex = 6;
            this.DateGroupBox.TabStop = false;
            this.DateGroupBox.Text = "Дата";
            this.DateGroupBox.Enter += new System.EventHandler(this.DateGroupBox_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "С";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "По";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // DateCheckbox
            // 
            this.DateCheckbox.AutoSize = true;
            this.DateCheckbox.Location = new System.Drawing.Point(252, 237);
            this.DateCheckbox.Name = "DateCheckbox";
            this.DateCheckbox.Size = new System.Drawing.Size(15, 14);
            this.DateCheckbox.TabIndex = 6;
            this.DateCheckbox.UseVisualStyleBackColor = true;
            this.DateCheckbox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // FileNameCheckbox
            // 
            this.FileNameCheckbox.AutoSize = true;
            this.FileNameCheckbox.Location = new System.Drawing.Point(252, 304);
            this.FileNameCheckbox.Name = "FileNameCheckbox";
            this.FileNameCheckbox.Size = new System.Drawing.Size(15, 14);
            this.FileNameCheckbox.TabIndex = 7;
            this.FileNameCheckbox.UseVisualStyleBackColor = true;
            this.FileNameCheckbox.CheckedChanged += new System.EventHandler(this.FileNameCheckbox_CheckedChanged);
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.Location = new System.Drawing.Point(121, 19);
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.FileNameTextBox.TabIndex = 8;
            this.FileNameTextBox.TextChanged += new System.EventHandler(this.FileNameTextBox_TextChanged);
            // 
            // FileNameGroupBox
            // 
            this.FileNameGroupBox.Controls.Add(this.FileNameTextBox);
            this.FileNameGroupBox.Enabled = false;
            this.FileNameGroupBox.Location = new System.Drawing.Point(19, 267);
            this.FileNameGroupBox.Name = "FileNameGroupBox";
            this.FileNameGroupBox.Size = new System.Drawing.Size(227, 51);
            this.FileNameGroupBox.TabIndex = 9;
            this.FileNameGroupBox.TabStop = false;
            this.FileNameGroupBox.Text = "Имя файла";
            // 
            // typeResultGroupBox
            // 
            this.typeResultGroupBox.Controls.Add(this.ResultTypeComboBox);
            this.typeResultGroupBox.Enabled = false;
            this.typeResultGroupBox.Location = new System.Drawing.Point(19, 324);
            this.typeResultGroupBox.Name = "typeResultGroupBox";
            this.typeResultGroupBox.Size = new System.Drawing.Size(227, 48);
            this.typeResultGroupBox.TabIndex = 11;
            this.typeResultGroupBox.TabStop = false;
            this.typeResultGroupBox.Text = "Тип результата";
            // 
            // resultTypeCheckbox
            // 
            this.resultTypeCheckbox.AutoSize = true;
            this.resultTypeCheckbox.Location = new System.Drawing.Point(252, 355);
            this.resultTypeCheckbox.Name = "resultTypeCheckbox";
            this.resultTypeCheckbox.Size = new System.Drawing.Size(15, 14);
            this.resultTypeCheckbox.TabIndex = 12;
            this.resultTypeCheckbox.UseVisualStyleBackColor = true;
            this.resultTypeCheckbox.CheckedChanged += new System.EventHandler(this.resultTypeCheckbox_CheckedChanged);
            // 
            // IpGroupBox
            // 
            this.IpGroupBox.Controls.Add(this.IpTextBox);
            this.IpGroupBox.Enabled = false;
            this.IpGroupBox.Location = new System.Drawing.Point(19, 378);
            this.IpGroupBox.Name = "IpGroupBox";
            this.IpGroupBox.Size = new System.Drawing.Size(227, 42);
            this.IpGroupBox.TabIndex = 13;
            this.IpGroupBox.TabStop = false;
            this.IpGroupBox.Text = "Исходный IP";
            this.IpGroupBox.Enter += new System.EventHandler(this.IpGroupBox_Enter);
            // 
            // IpTextBox
            // 
            this.IpTextBox.Location = new System.Drawing.Point(121, 16);
            this.IpTextBox.Name = "IpTextBox";
            this.IpTextBox.Size = new System.Drawing.Size(100, 20);
            this.IpTextBox.TabIndex = 0;
            // 
            // ipCheckbox
            // 
            this.ipCheckbox.AutoSize = true;
            this.ipCheckbox.Location = new System.Drawing.Point(252, 403);
            this.ipCheckbox.Name = "ipCheckbox";
            this.ipCheckbox.Size = new System.Drawing.Size(15, 14);
            this.ipCheckbox.TabIndex = 14;
            this.ipCheckbox.UseVisualStyleBackColor = true;
            this.ipCheckbox.CheckedChanged += new System.EventHandler(this.ipCheckbox_CheckedChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Myanmar Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(283, 9);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(847, 551);
            this.richTextBox1.TabIndex = 16;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Сейчас выбран";
            // 
            // FileNameShowTextBox
            // 
            this.FileNameShowTextBox.Location = new System.Drawing.Point(98, 22);
            this.FileNameShowTextBox.Name = "FileNameShowTextBox";
            this.FileNameShowTextBox.ReadOnly = true;
            this.FileNameShowTextBox.Size = new System.Drawing.Size(100, 20);
            this.FileNameShowTextBox.TabIndex = 18;
            this.FileNameShowTextBox.Text = "Не выбрано";
            // 
            // ChoseFileButton
            // 
            this.ChoseFileButton.Location = new System.Drawing.Point(34, 48);
            this.ChoseFileButton.Name = "ChoseFileButton";
            this.ChoseFileButton.Size = new System.Drawing.Size(134, 39);
            this.ChoseFileButton.TabIndex = 19;
            this.ChoseFileButton.Text = "Выбрать файл";
            this.ChoseFileButton.UseVisualStyleBackColor = true;
            this.ChoseFileButton.Click += new System.EventHandler(this.ChoseFileButton_Click);
            // 
            // ChoseFileGroupbox
            // 
            this.ChoseFileGroupbox.Controls.Add(this.FileNameShowTextBox);
            this.ChoseFileGroupbox.Controls.Add(this.ChoseFileButton);
            this.ChoseFileGroupbox.Controls.Add(this.label4);
            this.ChoseFileGroupbox.Location = new System.Drawing.Point(19, 12);
            this.ChoseFileGroupbox.Name = "ChoseFileGroupbox";
            this.ChoseFileGroupbox.Size = new System.Drawing.Size(227, 105);
            this.ChoseFileGroupbox.TabIndex = 20;
            this.ChoseFileGroupbox.TabStop = false;
            this.ChoseFileGroupbox.Text = "Выберите файл";
            // 
            // ResultTypeComboBox
            // 
            this.ResultTypeComboBox.FormattingEnabled = true;
            this.ResultTypeComboBox.Location = new System.Drawing.Point(121, 19);
            this.ResultTypeComboBox.Name = "ResultTypeComboBox";
            this.ResultTypeComboBox.Size = new System.Drawing.Size(100, 21);
            this.ResultTypeComboBox.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 572);
            this.Controls.Add(this.ChoseFileGroupbox);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.ipCheckbox);
            this.Controls.Add(this.IpGroupBox);
            this.Controls.Add(this.resultTypeCheckbox);
            this.Controls.Add(this.typeResultGroupBox);
            this.Controls.Add(this.FileNameGroupBox);
            this.Controls.Add(this.FileNameCheckbox);
            this.Controls.Add(this.DateCheckbox);
            this.Controls.Add(this.DateGroupBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SearchButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DateGroupBox.ResumeLayout(false);
            this.DateGroupBox.PerformLayout();
            this.FileNameGroupBox.ResumeLayout(false);
            this.FileNameGroupBox.PerformLayout();
            this.typeResultGroupBox.ResumeLayout(false);
            this.IpGroupBox.ResumeLayout(false);
            this.IpGroupBox.PerformLayout();
            this.ChoseFileGroupbox.ResumeLayout(false);
            this.ChoseFileGroupbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.DateTimePicker MinDateTimePicker;
        private System.Windows.Forms.DateTimePicker maxDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox DateGroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox DateCheckbox;
        private System.Windows.Forms.CheckBox FileNameCheckbox;
        private System.Windows.Forms.TextBox FileNameTextBox;
        private System.Windows.Forms.GroupBox FileNameGroupBox;
        private System.Windows.Forms.GroupBox typeResultGroupBox;
        private System.Windows.Forms.CheckBox resultTypeCheckbox;
        private System.Windows.Forms.GroupBox IpGroupBox;
        private System.Windows.Forms.CheckBox ipCheckbox;
        private System.Windows.Forms.TextBox IpTextBox;
        public LogFile logFile;
        public Dictionary<int, string> httpResultTypes = OneRecord.GetHTTPResultValidTypes();
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FileNameShowTextBox;
        private System.Windows.Forms.Button ChoseFileButton;
        private System.Windows.Forms.GroupBox ChoseFileGroupbox;
        private System.Windows.Forms.ComboBox ResultTypeComboBox;
    }
}

