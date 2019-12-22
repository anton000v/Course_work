using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

            if (logFile == null)
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
                    richTextBox1.Text = "";
                    logFile.writeFileToWindow(richTextBox1);
                    return;
                }
                else
                    return;
            }
            if(allFiltersFilled)
            {
                richTextBox1.Text = "";
                logFile.Filter(minDate, maxDate, fileName, resultType,ip,lastRecords).WriteFilterRecordsToWindow(richTextBox1);
                //MessageBox.Show("AAAAAAAAAAAAAAAAA", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
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
            logFile = new LogFile();
            FileNameShowTextBox.Text = logFile.onlyFileName;
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
        }

        private void checkLastNRecordsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkLastNRecordsCheckbox.Checked)
            {
                checkAllFileCheckbox.Checked = false;
                CheckLastRecordsNumericUpDown.Enabled = true;
            }
        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void CheckLastRecordsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }
    }

}
