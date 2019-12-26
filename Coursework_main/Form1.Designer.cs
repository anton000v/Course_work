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
            this.components = new System.ComponentModel.Container();
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
            this.ResultTypeComboBox = new System.Windows.Forms.ComboBox();
            this.resultTypeCheckbox = new System.Windows.Forms.CheckBox();
            this.IpGroupBox = new System.Windows.Forms.GroupBox();
            this.IpTextBox = new System.Windows.Forms.TextBox();
            this.ipCheckbox = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FileNameShowTextBox = new System.Windows.Forms.TextBox();
            this.ChoseFileButton = new System.Windows.Forms.Button();
            this.ChoseFileGroupbox = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.checkAllFileCheckbox = new System.Windows.Forms.CheckBox();
            this.checkLastNRecordsCheckbox = new System.Windows.Forms.CheckBox();
            this.searchAllFileOrNotGroupBox = new System.Windows.Forms.GroupBox();
            this.CheckLastRecordsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.SecurityAnalysisButton = new System.Windows.Forms.Button();
            this.AnalysisTextBox = new System.Windows.Forms.RichTextBox();
            this.HackingStatiscticsRadiobutton = new System.Windows.Forms.RadioButton();
            this.FileInfoRadioButton = new System.Windows.Forms.RadioButton();
            this.BackgroundModeActive = new System.Windows.Forms.Button();
            this.backgroundModeGroupBox = new System.Windows.Forms.GroupBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.DateGroupBox.SuspendLayout();
            this.FileNameGroupBox.SuspendLayout();
            this.typeResultGroupBox.SuspendLayout();
            this.IpGroupBox.SuspendLayout();
            this.ChoseFileGroupbox.SuspendLayout();
            this.searchAllFileOrNotGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckLastRecordsNumericUpDown)).BeginInit();
            this.backgroundModeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(81, 529);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(106, 38);
            this.SearchButton.TabIndex = 1;
            this.SearchButton.Text = "Поиск";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // MinDateTimePicker
            // 
            this.MinDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinDateTimePicker.Location = new System.Drawing.Point(27, 29);
            this.MinDateTimePicker.Name = "MinDateTimePicker";
            this.MinDateTimePicker.Size = new System.Drawing.Size(193, 20);
            this.MinDateTimePicker.TabIndex = 2;
            // 
            // maxDateTimePicker
            // 
            this.maxDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxDateTimePicker.Location = new System.Drawing.Point(27, 64);
            this.maxDateTimePicker.Name = "maxDateTimePicker";
            this.maxDateTimePicker.Size = new System.Drawing.Size(193, 20);
            this.maxDateTimePicker.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(61, 126);
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
            this.DateGroupBox.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateGroupBox.Location = new System.Drawing.Point(9, 156);
            this.DateGroupBox.Name = "DateGroupBox";
            this.DateGroupBox.Size = new System.Drawing.Size(226, 100);
            this.DateGroupBox.TabIndex = 6;
            this.DateGroupBox.TabStop = false;
            this.DateGroupBox.Text = "Дата";
            this.DateGroupBox.Enter += new System.EventHandler(this.DateGroupBox_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "С";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "По";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // DateCheckbox
            // 
            this.DateCheckbox.AutoSize = true;
            this.DateCheckbox.Location = new System.Drawing.Point(241, 243);
            this.DateCheckbox.Name = "DateCheckbox";
            this.DateCheckbox.Size = new System.Drawing.Size(15, 14);
            this.DateCheckbox.TabIndex = 6;
            this.DateCheckbox.UseVisualStyleBackColor = true;
            this.DateCheckbox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // FileNameCheckbox
            // 
            this.FileNameCheckbox.AutoSize = true;
            this.FileNameCheckbox.Location = new System.Drawing.Point(241, 311);
            this.FileNameCheckbox.Name = "FileNameCheckbox";
            this.FileNameCheckbox.Size = new System.Drawing.Size(15, 14);
            this.FileNameCheckbox.TabIndex = 7;
            this.FileNameCheckbox.UseVisualStyleBackColor = true;
            this.FileNameCheckbox.CheckedChanged += new System.EventHandler(this.FileNameCheckbox_CheckedChanged);
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.Location = new System.Drawing.Point(122, 19);
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.Size = new System.Drawing.Size(100, 21);
            this.FileNameTextBox.TabIndex = 8;
            this.FileNameTextBox.TextChanged += new System.EventHandler(this.FileNameTextBox_TextChanged);
            // 
            // FileNameGroupBox
            // 
            this.FileNameGroupBox.Controls.Add(this.FileNameTextBox);
            this.FileNameGroupBox.Enabled = false;
            this.FileNameGroupBox.Font = new System.Drawing.Font("OCR A Extended", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNameGroupBox.Location = new System.Drawing.Point(9, 273);
            this.FileNameGroupBox.Name = "FileNameGroupBox";
            this.FileNameGroupBox.Size = new System.Drawing.Size(226, 51);
            this.FileNameGroupBox.TabIndex = 9;
            this.FileNameGroupBox.TabStop = false;
            this.FileNameGroupBox.Text = "Имя файла";
            // 
            // typeResultGroupBox
            // 
            this.typeResultGroupBox.Controls.Add(this.ResultTypeComboBox);
            this.typeResultGroupBox.Enabled = false;
            this.typeResultGroupBox.Location = new System.Drawing.Point(9, 330);
            this.typeResultGroupBox.Name = "typeResultGroupBox";
            this.typeResultGroupBox.Size = new System.Drawing.Size(226, 48);
            this.typeResultGroupBox.TabIndex = 11;
            this.typeResultGroupBox.TabStop = false;
            this.typeResultGroupBox.Text = "Тип результата";
            // 
            // ResultTypeComboBox
            // 
            this.ResultTypeComboBox.FormattingEnabled = true;
            this.ResultTypeComboBox.Location = new System.Drawing.Point(122, 19);
            this.ResultTypeComboBox.Name = "ResultTypeComboBox";
            this.ResultTypeComboBox.Size = new System.Drawing.Size(100, 21);
            this.ResultTypeComboBox.TabIndex = 0;
            // 
            // resultTypeCheckbox
            // 
            this.resultTypeCheckbox.AutoSize = true;
            this.resultTypeCheckbox.Location = new System.Drawing.Point(241, 361);
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
            this.IpGroupBox.Location = new System.Drawing.Point(9, 384);
            this.IpGroupBox.Name = "IpGroupBox";
            this.IpGroupBox.Size = new System.Drawing.Size(226, 42);
            this.IpGroupBox.TabIndex = 13;
            this.IpGroupBox.TabStop = false;
            this.IpGroupBox.Text = "Исходный IP";
            this.IpGroupBox.Enter += new System.EventHandler(this.IpGroupBox_Enter);
            // 
            // IpTextBox
            // 
            this.IpTextBox.Location = new System.Drawing.Point(122, 16);
            this.IpTextBox.Name = "IpTextBox";
            this.IpTextBox.Size = new System.Drawing.Size(100, 20);
            this.IpTextBox.TabIndex = 0;
            // 
            // ipCheckbox
            // 
            this.ipCheckbox.AutoSize = true;
            this.ipCheckbox.Location = new System.Drawing.Point(241, 409);
            this.ipCheckbox.Name = "ipCheckbox";
            this.ipCheckbox.Size = new System.Drawing.Size(15, 14);
            this.ipCheckbox.TabIndex = 14;
            this.ipCheckbox.UseVisualStyleBackColor = true;
            this.ipCheckbox.CheckedChanged += new System.EventHandler(this.ipCheckbox_CheckedChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FloralWhite;
            this.richTextBox1.Font = new System.Drawing.Font("Myanmar Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(273, 29);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(589, 481);
            this.richTextBox1.TabIndex = 16;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Сейчас выбран";
            // 
            // FileNameShowTextBox
            // 
            this.FileNameShowTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNameShowTextBox.Location = new System.Drawing.Point(98, 22);
            this.FileNameShowTextBox.Name = "FileNameShowTextBox";
            this.FileNameShowTextBox.ReadOnly = true;
            this.FileNameShowTextBox.Size = new System.Drawing.Size(100, 20);
            this.FileNameShowTextBox.TabIndex = 18;
            this.FileNameShowTextBox.Text = "Не выбрано";
            // 
            // ChoseFileButton
            // 
            this.ChoseFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.ChoseFileGroupbox.BackColor = System.Drawing.Color.MintCream;
            this.ChoseFileGroupbox.Controls.Add(this.FileNameShowTextBox);
            this.ChoseFileGroupbox.Controls.Add(this.ChoseFileButton);
            this.ChoseFileGroupbox.Controls.Add(this.label4);
            this.ChoseFileGroupbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChoseFileGroupbox.Location = new System.Drawing.Point(9, 18);
            this.ChoseFileGroupbox.Name = "ChoseFileGroupbox";
            this.ChoseFileGroupbox.Size = new System.Drawing.Size(226, 105);
            this.ChoseFileGroupbox.TabIndex = 20;
            this.ChoseFileGroupbox.TabStop = false;
            this.ChoseFileGroupbox.Text = "Выберите файл";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Text = "Справки";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(160, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "строках";
            this.label5.Click += new System.EventHandler(this.label5_Click_1);
            // 
            // checkAllFileCheckbox
            // 
            this.checkAllFileCheckbox.AutoSize = true;
            this.checkAllFileCheckbox.Checked = true;
            this.checkAllFileCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAllFileCheckbox.Location = new System.Drawing.Point(0, 19);
            this.checkAllFileCheckbox.Name = "checkAllFileCheckbox";
            this.checkAllFileCheckbox.Size = new System.Drawing.Size(103, 17);
            this.checkAllFileCheckbox.TabIndex = 24;
            this.checkAllFileCheckbox.Text = "Во всем файле";
            this.checkAllFileCheckbox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.checkAllFileCheckbox.UseVisualStyleBackColor = true;
            this.checkAllFileCheckbox.CheckedChanged += new System.EventHandler(this.checkAllFileCheckbox_CheckedChanged);
            // 
            // checkLastNRecordsCheckbox
            // 
            this.checkLastNRecordsCheckbox.AutoSize = true;
            this.checkLastNRecordsCheckbox.Location = new System.Drawing.Point(0, 45);
            this.checkLastNRecordsCheckbox.Name = "checkLastNRecordsCheckbox";
            this.checkLastNRecordsCheckbox.Size = new System.Drawing.Size(92, 17);
            this.checkLastNRecordsCheckbox.TabIndex = 25;
            this.checkLastNRecordsCheckbox.Text = "В последних ";
            this.checkLastNRecordsCheckbox.UseVisualStyleBackColor = true;
            this.checkLastNRecordsCheckbox.CheckedChanged += new System.EventHandler(this.checkLastNRecordsCheckbox_CheckedChanged);
            // 
            // searchAllFileOrNotGroupBox
            // 
            this.searchAllFileOrNotGroupBox.Controls.Add(this.CheckLastRecordsNumericUpDown);
            this.searchAllFileOrNotGroupBox.Controls.Add(this.checkAllFileCheckbox);
            this.searchAllFileOrNotGroupBox.Controls.Add(this.checkLastNRecordsCheckbox);
            this.searchAllFileOrNotGroupBox.Controls.Add(this.label5);
            this.searchAllFileOrNotGroupBox.Location = new System.Drawing.Point(9, 432);
            this.searchAllFileOrNotGroupBox.Name = "searchAllFileOrNotGroupBox";
            this.searchAllFileOrNotGroupBox.Size = new System.Drawing.Size(226, 79);
            this.searchAllFileOrNotGroupBox.TabIndex = 26;
            this.searchAllFileOrNotGroupBox.TabStop = false;
            this.searchAllFileOrNotGroupBox.Text = "Производить поиск";
            // 
            // CheckLastRecordsNumericUpDown
            // 
            this.CheckLastRecordsNumericUpDown.Enabled = false;
            this.CheckLastRecordsNumericUpDown.Location = new System.Drawing.Point(98, 42);
            this.CheckLastRecordsNumericUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.CheckLastRecordsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CheckLastRecordsNumericUpDown.Name = "CheckLastRecordsNumericUpDown";
            this.CheckLastRecordsNumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.CheckLastRecordsNumericUpDown.TabIndex = 26;
            this.CheckLastRecordsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CheckLastRecordsNumericUpDown.ValueChanged += new System.EventHandler(this.CheckLastRecordsNumericUpDown_ValueChanged);
            // 
            // SecurityAnalysisButton
            // 
            this.SecurityAnalysisButton.Enabled = false;
            this.SecurityAnalysisButton.Location = new System.Drawing.Point(489, 529);
            this.SecurityAnalysisButton.Name = "SecurityAnalysisButton";
            this.SecurityAnalysisButton.Size = new System.Drawing.Size(212, 36);
            this.SecurityAnalysisButton.TabIndex = 27;
            this.SecurityAnalysisButton.Text = "Анализ на безопасность";
            this.SecurityAnalysisButton.UseVisualStyleBackColor = true;
            this.SecurityAnalysisButton.Click += new System.EventHandler(this.SecurityAnalysisButton_Click);
            // 
            // AnalysisTextBox
            // 
            this.AnalysisTextBox.BackColor = System.Drawing.Color.FloralWhite;
            this.AnalysisTextBox.Location = new System.Drawing.Point(867, 39);
            this.AnalysisTextBox.Name = "AnalysisTextBox";
            this.AnalysisTextBox.ReadOnly = true;
            this.AnalysisTextBox.Size = new System.Drawing.Size(252, 471);
            this.AnalysisTextBox.TabIndex = 28;
            this.AnalysisTextBox.Text = "";
            // 
            // HackingStatiscticsRadiobutton
            // 
            this.HackingStatiscticsRadiobutton.AutoSize = true;
            this.HackingStatiscticsRadiobutton.Enabled = false;
            this.HackingStatiscticsRadiobutton.Location = new System.Drawing.Point(1007, 18);
            this.HackingStatiscticsRadiobutton.Name = "HackingStatiscticsRadiobutton";
            this.HackingStatiscticsRadiobutton.Size = new System.Drawing.Size(124, 17);
            this.HackingStatiscticsRadiobutton.TabIndex = 30;
            this.HackingStatiscticsRadiobutton.TabStop = true;
            this.HackingStatiscticsRadiobutton.Text = "Статистика взлома";
            this.HackingStatiscticsRadiobutton.UseVisualStyleBackColor = true;
            this.HackingStatiscticsRadiobutton.CheckedChanged += new System.EventHandler(this.HackingStatiscticsRadiobutton_CheckedChanged);
            // 
            // FileInfoRadioButton
            // 
            this.FileInfoRadioButton.AutoSize = true;
            this.FileInfoRadioButton.Enabled = false;
            this.FileInfoRadioButton.Location = new System.Drawing.Point(867, 18);
            this.FileInfoRadioButton.Name = "FileInfoRadioButton";
            this.FileInfoRadioButton.Size = new System.Drawing.Size(135, 17);
            this.FileInfoRadioButton.TabIndex = 31;
            this.FileInfoRadioButton.TabStop = true;
            this.FileInfoRadioButton.Text = "Информация о файле";
            this.FileInfoRadioButton.UseVisualStyleBackColor = true;
            this.FileInfoRadioButton.CheckedChanged += new System.EventHandler(this.FileInfoRadioButton_CheckedChanged);
            // 
            // BackgroundModeActive
            // 
            this.BackgroundModeActive.Location = new System.Drawing.Point(8, 19);
            this.BackgroundModeActive.Name = "BackgroundModeActive";
            this.BackgroundModeActive.Size = new System.Drawing.Size(94, 21);
            this.BackgroundModeActive.TabIndex = 27;
            this.BackgroundModeActive.Text = "Активировать";
            this.BackgroundModeActive.UseVisualStyleBackColor = true;
            this.BackgroundModeActive.Visible = false;
            this.BackgroundModeActive.Click += new System.EventHandler(this.BackgroundModeActive_Click);
            // 
            // backgroundModeGroupBox
            // 
            this.backgroundModeGroupBox.Controls.Add(this.BackgroundModeActive);
            this.backgroundModeGroupBox.Location = new System.Drawing.Point(1007, 518);
            this.backgroundModeGroupBox.Name = "backgroundModeGroupBox";
            this.backgroundModeGroupBox.Size = new System.Drawing.Size(108, 49);
            this.backgroundModeGroupBox.TabIndex = 32;
            this.backgroundModeGroupBox.TabStop = false;
            this.backgroundModeGroupBox.Text = "Фоновый режим";
            this.backgroundModeGroupBox.Visible = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "dsfsdf";
            this.notifyIcon1.Text = "log VnAlyzer";
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1138, 603);
            this.Controls.Add(this.backgroundModeGroupBox);
            this.Controls.Add(this.FileInfoRadioButton);
            this.Controls.Add(this.HackingStatiscticsRadiobutton);
            this.Controls.Add(this.AnalysisTextBox);
            this.Controls.Add(this.SecurityAnalysisButton);
            this.Controls.Add(this.searchAllFileOrNotGroupBox);
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
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "log VnVlyzer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
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
            this.searchAllFileOrNotGroupBox.ResumeLayout(false);
            this.searchAllFileOrNotGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckLastRecordsNumericUpDown)).EndInit();
            this.backgroundModeGroupBox.ResumeLayout(false);
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
        public DangerousHTTPRequests dangerousRequests;
        public FilteredRecords filteredRecords;
        public Dictionary<int, string> httpResultTypes = OneRecord.GetHTTPResultValidTypes();
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FileNameShowTextBox;
        private System.Windows.Forms.Button ChoseFileButton;
        private System.Windows.Forms.GroupBox ChoseFileGroupbox;
        private System.Windows.Forms.ComboBox ResultTypeComboBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkAllFileCheckbox;
        private System.Windows.Forms.CheckBox checkLastNRecordsCheckbox;
        private System.Windows.Forms.GroupBox searchAllFileOrNotGroupBox;
        private System.Windows.Forms.NumericUpDown CheckLastRecordsNumericUpDown;
        private System.Windows.Forms.Button SecurityAnalysisButton;
        private System.Windows.Forms.RichTextBox AnalysisTextBox;
        private System.Windows.Forms.RadioButton HackingStatiscticsRadiobutton;
        private System.Windows.Forms.RadioButton FileInfoRadioButton;
        private System.Windows.Forms.Button BackgroundModeActive;
        private System.Windows.Forms.GroupBox backgroundModeGroupBox;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

