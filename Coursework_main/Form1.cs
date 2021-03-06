﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework_main
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //BackgroundWatcher.SendEmailAsync();

            //logFile = new LogFile();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DateGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (DateCheckbox.Checked)
                DateGroupBox.Enabled = true;
            else
                DateGroupBox.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         foreach(KeyValuePair<int,string> keyValue in httpResultTypes)
            {
                ResultTypeComboBox.Items.Add(String.Format("{0} - ({1})",keyValue.Key,keyValue.Value));
            }

        }

        private void FileNameCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (FileNameCheckbox.Checked)
                FileNameGroupBox.Enabled = true;
            else
                FileNameGroupBox.Enabled = false;
        }

        private void resultTypeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (resultTypeCheckbox.Checked)
                typeResultGroupBox.Enabled = true;
            else
                typeResultGroupBox.Enabled = false;
        }

        private void IpGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void ipCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (ipCheckbox.Checked)
                IpGroupBox.Enabled = true;
            else
                IpGroupBox.Enabled = false;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            bool allFiltersFilled = true;
            bool AreAnyFilters = false;

            DateTime minDate = default(DateTime);
            DateTime maxDate = default(DateTime);
            int resultType = default(int);
            string fileName = default(string);
            string ip = default(string);

            int lastRecords = -1;

            if (logFile == null || logFile.fileName == null)
            {
                MessageBox.Show("Пожалуйста, выберите файл.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(checkLastNRecordsCheckbox.Checked)
            {
                AreAnyFilters = true;
                lastRecords = (int)CheckLastRecordsNumericUpDown.Value;
                //if (lastRecords != 1)
                    lastRecords--;
            }
            if (DateCheckbox.Checked)
            {
                AreAnyFilters = true;
                minDate = MinDateTimePicker.Value;
                maxDate = maxDateTimePicker.Value;
            }
            if (resultTypeCheckbox.Checked)
            {
                AreAnyFilters = true;
               
                if (ResultTypeComboBox.Text == "")
                    allFiltersFilled = false;
                else
                    resultType = Int32.Parse(ResultTypeComboBox.Text.Split()[0]);
            }
            if (FileNameCheckbox.Checked)
            {
                AreAnyFilters = true;
              
                if (FileNameTextBox.Text == "")
                    allFiltersFilled = false;
                else
                    fileName = FileNameTextBox.Text;
            }
            if(ipCheckbox.Checked)
            {
                AreAnyFilters = true;
               
                if (IpTextBox.Text == "")
                    allFiltersFilled = false;
                else
                    ip = IpTextBox.Text;
            }
            if(!allFiltersFilled)
            {
                MessageBox.Show("Пожалуйста, заполните все выбранные фильтры, или деактивируйте их", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (!AreAnyFilters && allFiltersFilled)
            {
                DialogResult ReadAllFileDialogResult = MessageBox.Show("Вы не выбрали ни один из фильтров. Файл может быть очень большим.\nВы уверены, что хотите прочитать его весь?", "Вы уверены?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ReadAllFileDialogResult == DialogResult.Yes)
                {
                    //richTextBox1.Text = "";
                    //logFile.isWholeFileRead = true;
                    logFile.writeFileToWindow(RequestsOutputDataGrid);

                    logFile.isFilterModeActive = false;

                    FileInfoRadioButton.Enabled = true;
                    AnalysisTextBox.Enabled = true;

                    if (FileInfoRadioButton.Checked == true)
                    {
                        FileInfoRadioButton.Checked = false;
                        FileInfoRadioButton.Checked = true;
                    }
                    else
                        FileInfoRadioButton.Checked = true;
                    HackingStatiscticsRadiobutton.Enabled = false;
                    SecurityAnalysisButton.Enabled = true;
                    //HackingStatiscticsRadiobutton.Enabled = false;
                    //logFile.writeFileInfoToWindow(AnalysisTextBox,false);
                    return;
                }
                else
                    return;
            }
            if(allFiltersFilled)
            {
                //richTextBox1.Text = "";
                filteredRecords = logFile.Filter(minDate, maxDate, fileName, resultType, ip, lastRecords);
                filteredRecords.WriteFilterRecordsToWindow(RequestsOutputDataGrid);

                logFile.isFilterModeActive = true;

                FileInfoRadioButton.Enabled = true;
                AnalysisTextBox.Enabled = true;
                //FileInfoRadioButton.Checked = true;

               

                if (FileInfoRadioButton.Checked == true)
                {
                    FileInfoRadioButton.Checked = false;
                    FileInfoRadioButton.Checked = true;
                }
                else
                    FileInfoRadioButton.Checked = true;
                HackingStatiscticsRadiobutton.Enabled = false;
                SecurityAnalysisButton.Enabled = true;
                //logFile.writeFileInfoToWindow(AnalysisTextBox,true);
                //MessageBox.Show("AAAAAAAAAAAAAAAAA", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //MessageBox.Show(String.Format("{0}", logFile.isFilterModeActive));


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //richTextBox1.sh
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ChoseFileButton_Click(object sender, EventArgs e)
        {
            //Refresh();
            if (notifyIcon1.Visible == false)
            {
                logFile = new LogFile();
                FileNameShowTextBox.Text = logFile.onlyFileName;
                if (logFile.fileName != null)
                {
                    backgroundModeGroupBox.Visible = true;
                    BackgroundModeActive.Visible = true;
                    DateCheckbox.Enabled = true;
                    ipCheckbox.Enabled = true;
                    resultTypeCheckbox.Enabled = true;
                    FileNameCheckbox.Enabled = true;
                }
            }
            else
               MessageBox.Show("Сначала деактивируйте фоновый режим", "Ошибочка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FileNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkAllFileCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAllFileCheckbox.Checked)
            {
                checkLastNRecordsCheckbox.Checked = false;
                CheckLastRecordsNumericUpDown.Enabled = false;
            }
            else
            {
                if(!checkLastNRecordsCheckbox.Checked)
                {
                    checkLastNRecordsCheckbox.Checked = true;
                }
            }
        }

        private void checkLastNRecordsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkLastNRecordsCheckbox.Checked)
            {
                checkAllFileCheckbox.Checked = false;
                CheckLastRecordsNumericUpDown.Enabled = true;
            }
            else
            {
                if (!checkAllFileCheckbox.Checked)
                {
                    checkAllFileCheckbox.Checked = true;
                }
            }
        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void CheckLastRecordsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void SecurityAnalysisButton_Click(object sender, EventArgs e)
        {
            
            if (!logFile.isFilterModeActive)
            {
                DialogResult ReadAllFileDialogResult = MessageBox.Show("Вы действительно хотите сканировать весь файл? (Не рекомендуется)", "Вы уверены?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ReadAllFileDialogResult == DialogResult.Yes)
                {
                    dangerousRequests = logFile.SecureFilterAndScanAllFile();
                    HackingStatiscticsRadiobutton.Enabled = true;
                    HackingStatiscticsRadiobutton.Checked = true;
                    return;
                }
            }
            else
            {
                dangerousRequests =  filteredRecords.AttackDetector();
                HackingStatiscticsRadiobutton.Enabled = true;
                HackingStatiscticsRadiobutton.Checked = true;
                return;
            }
            

        }

        private void FileInfoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (FileInfoRadioButton.Checked)
            {
                //AnalysisTextBox.Text = "";
                logFile.writeFileInfoToWindow(AnalysisTextBox);
            }
            else
            {
                AnalysisTextBox.Text = "";
                //HackingStatiscticsRadiobutton.Checked = false;
            }
        }

        private void HackingStatiscticsRadiobutton_CheckedChanged(object sender, EventArgs e)
        {
            if (HackingStatiscticsRadiobutton.Checked)
            {
                //AnalysisTextBox.Text = "";
                if(!logFile.isBackgroundWatcherON)
                    dangerousRequests.writeDangerousRequestsToWindow(AnalysisTextBox);
            }
            else
            {
                AnalysisTextBox.Text = "";
                //FileInfoRadioButton.Checked = false;
            }
        }


        private void DisplayDangerousRequests()
        {
            //DangerousHTTPRequests dangerousHTTPRequests = backgroundWatcher.dangerousRequests;
            //dangerousHTTPRequests.writeDangerousRequestsToWindow(AnalysisTextBox);

            backgroundWatcher.WriteDangerousRequest_InBackgroundMode_ToWindow(AnalysisTextBox);
        }

        private void BackgroundModeActive_Click(object sender, EventArgs e)
        {
            if (BackgroundModeActive.Text == "Активировать")
            {

                    DialogResult logWatcherOnDialogResult = MessageBox.Show(String.Format("Вы действительно хотите активировать фоновый режим, анализирующий файл \"{0}\"?", logFile.onlyFileName), "Вы уверены?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (logWatcherOnDialogResult == DialogResult.Yes)
                    {

                        MailAddress Email = Form2.getEmail();

                        backgroundWatcher = LogFile.MakeBackgroundWatcher(logFile, notifyIcon1, Email);
                        backgroundWatcher.LogWatcherON();
                        backgroundWatcher.addDangerousIp += DisplayDangerousRequests;
                        logFile.isBackgroundWatcherON = true;

                        BackgroundModeActive.Text = "Деактивировать";

                        SearchButton.Enabled = false;
                        searchAllFileOrNotGroupBox.Enabled = false;
                        DateCheckbox.Enabled = false;
                        FileNameCheckbox.Enabled = false;
                        resultTypeCheckbox.Enabled = false;
                        ipCheckbox.Enabled = false;
                        ChoseFileGroupbox.Enabled = false;

                        FileInfoRadioButton.Checked = false;
                        FileInfoRadioButton.Enabled = false;

                        AnalysisTextBox.Enabled = true;
                        AnalysisTextBox.Text = "";
                        SecurityAnalysisButton.Enabled = false;

                        HackingStatiscticsRadiobutton.Enabled = true;
                        HackingStatiscticsRadiobutton.Checked = true;
                        AnalysisTextBox.Text = "Фоновый режим активирован. Чтобы выйти - нажмите \"Деактивировать\"\n";
                        AnalysisTextBox.Text += "Угроз не обнаружено, но мы продолжаем работать в этом направлении.";
                        this.WindowState = FormWindowState.Minimized;

                        //WindowState = FormWindowState.Minimized;
                        notifyIcon1.Icon = SystemIcons.Application;
                        notifyIcon1.Visible = true;
                        BackgroundWatcher.makeNotify(notifyIcon1, "log VnVlyzer переведен в фоновый режим");
                        //Form1_Deactivate(sender, e);
                    }
                
                else
                    return;
            }
            else
            {
                DialogResult logWatcherOnDialogResult = MessageBox.Show(String.Format("Вы действительно хотите деактивировать фоновый режим, анализирующий файл \"{0}\"?", logFile.onlyFileName), "Вы уверены?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (logWatcherOnDialogResult == DialogResult.Yes)
                {
                    backgroundWatcher.LogWatcherOFF();
                    BackgroundModeActive.Text = "Активировать";
                    logFile.isBackgroundWatcherON = false;
                    SearchButton.Enabled = true;
                    searchAllFileOrNotGroupBox.Enabled = true;
                    DateCheckbox.Enabled = true;
                    FileNameCheckbox.Enabled = true;
                    resultTypeCheckbox.Enabled = true;
                    ipCheckbox.Enabled = true;
                    ChoseFileGroupbox.Enabled = true;
                    HackingStatiscticsRadiobutton.Enabled = false;
                    HackingStatiscticsRadiobutton.Checked = false;

                    //richTextBox1.Text = "";
                    AnalysisTextBox.Text = "";
                    
                    BackgroundWatcher.makeNotify(notifyIcon1, "log VnVlyzer переведен в обычный режим");
                    notifyIcon1.Visible = false;

                }
                else
                    return;
            }
        }

        //private void Form1_SizeChanged(object sender, EventArgs e)
        //{
        //    if (this.WindowState == FormWindowState.Minimized)
        //    {
        //        this.ShowInTaskbar = false;
        //        notifyIcon1.Visible = true;
        //    }
        //}

        //private void notifyIcon1_DoubleClick(object sender, MouseEventArgs e)
        //{
        //    //if (this.WindowState == FormWindowState.Minimized)
        //    //{
        //    //    this.WindowState = FormWindowState.Normal;
        //    //    this.ShowInTaskbar = true;
        //    //    notifyIcon1.Visible = false;
        //    //}
        //    //else
        //    //{
        //        this.WindowState = FormWindowState.Normal;
        //        this.ShowInTaskbar = true;
        //        notifyIcon1.Visible = false;
        //    //}
        //}
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (notifyIcon1.Visible) 
            {
                this.Hide();
                e.Cancel = true;
                notifyIcon1.BalloonTipText = "Не забудьте про фоновый режим";
                notifyIcon1.ShowBalloonTip(1000);
            }
            else
            {
                e.Cancel = false;
            }

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Normal;

            //if (this.Visible == Hide)
            //{
                this.Show();

                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;

                SecurityAnalysisButton.Enabled = true;

                //if (backgroundWatcher.dangerousRequests.DangerousIp.Count()>0)
                //{

                //    //backgroundWatcher.WriteDangerousRequest_InBackgroundMode_ToWindow(AnalysisTextBox);
                //}

            //notifyIcon1.Visible = ;

        }

        private void RequestsOutputDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void справкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Выберите файл и выставьте необходимые фильтры и нажмите на Поиск. Дальше Вы можете анализировать данные на попытки взлома и ввести приложение в фоновый режим. Программа разработана в рамках курсового проекта студента групы КИУКИ-17-3 Антонова Данила.", "Справки", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            //notifyIcon1.Visible = false;
            backgroundWatcher.LogWatcherOFF();
            Close();
        }

        private void справкиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Log watcher выполняется в фоновом режиме. Вы можете закрыть приложение нажав на кнопку выхода", "Справки", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //public void writeToAnalisisTextBox()
        //{
        //    //this.WindowState = FormWindowState.Normal;

        //    //if (this.Visible == Hide)
        //    //{
        //    if (notifyIcon1.Visible)
        //    {

        //        //AnalysisTextBox.Enabled = true;
        //        //AnalysisTextBox.Text = "[Номер]  [ip] - [Вероятность попытки взлома]\n\n";
        //        DangerousHTTPRequests dangerousHTTPRequests = backgroundWatcher.dangerousRequests;
        //        dangerousHTTPRequests.writeDangerousRequestsToWindow(AnalysisTextBox);
        //        //backgroundWatcher.WriteDangerousRequest_InBackgroundMode_ToWindow(AnalysisTextBox);

        //    }
        //    //notifyIcon1.Visible = ;

        //}
    }
    //public static class Prompt
    //{
    //    public static string ShowDialog(string caption)
    //    {
    //        Form prompt = new Form();
    //        prompt.Width = 400;
    //        prompt.Height = 300;
    //        prompt.Text = caption;
    //        Label textLabel = new Label() { Left = 50, Top = 20, Text = "Введите ваш email аддрес, чтобы всегда узнавать об угрозах.\"n\"Или оставьте его пустым"};
    //        TextBox inputBox = new TextBox() { Left = 50, Top = 50, Width = 200 };
    //        Button confirmation = new Button() { Text = "Ok", Left = 150, Width = 100, Top = 70 };
    //        confirmation.Click += (sender, e) => { prompt.Close(); };
    //        prompt.Controls.Add(confirmation);
    //        prompt.Controls.Add(textLabel);
    //        prompt.Controls.Add(inputBox);
    //        prompt.ShowDialog();
    //        return inputBox.Text;
    //    }
    //}
}
