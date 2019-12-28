using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework_main
{
    public class LogFile
    {
        public string fileName;
        public string onlyFilePath;
        public string onlyFileName = "";

        //public bool isWholeFileRead;
        public bool isFilterModeActive = false;

        public List<string> wrongRecordsList;

        public Dictionary<string, float> fileInfo;

        public bool isBackgroundWatcherON;
        //private bool isAnyFilterActive = false;

        public LogFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog() { Filter = "Текстовые файлы(*.log)|*.log" };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                onlyFilePath = openFileDialog1.FileName;
                onlyFileName = openFileDialog1.SafeFileName;
                onlyFilePath = onlyFilePath.Replace(onlyFileName, "");

            }

            fileInfo = new Dictionary<string, float>();
            long size = 0;
            if (fileName != null)
            {
                FileInfo file = new System.IO.FileInfo(fileName);
                size = file.Length;
            }
            else
                return;
            fileInfo.Add("Размер файла", (int)size);

            isBackgroundWatcherON = false;
            //fileInfo.Add("Некорректные логи", 0);
        }
        public void writeFileToConsole()
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (OneRecord.IsRecordCanBeCreated(line))
                        {
                            OneRecord record = new OneRecord(line);
                            record.WriteToConsole();
                            Console.WriteLine("");
                        }

                    }
                }
            }
            catch (FileNotFoundException ioEx)
            {
                Console.WriteLine(ioEx.Message);
            }
        }
        //public void delegate AppentTextDelegate(string text);
        //class floid
        //{
        //    public static void FlMethod(AppentTextDelegate AppentText)
        //    {
        //        /* прочий код */
        //        AppentText("{0} " + array[i, j]);
        //        /* прочий код */
        //    }
        //}
        public void writeFileToWindow(System.Windows.Forms.RichTextBox richTextBox1)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
                {
                    int lineNumbers = 0;
                    int outputLineNumbers = 0;
                    int wrongRecords = 0;
                    string line;
                    wrongRecordsList = new List<string>();
                    while ((line = sr.ReadLine()) != null)
                    {
                        lineNumbers++;
                        if (OneRecord.IsRecordCanBeCreated(line))
                        {
                            outputLineNumbers++;
                            OneRecord record = new OneRecord(line);
                            richTextBox1.Text += String.Format("[{0}]    {1}\n", lineNumbers, record.logString);
                            //richTextBox1.AppendText("aaa");
                        }
                        else
                        {
                            wrongRecords++;
                            wrongRecordsList.Add(line);
                        }

                    }
                    fileInfo["Колличество строк"] = lineNumbers;
                    fileInfo["Выведено строк"] = outputLineNumbers;
                    fileInfo["Некорректные запросы"] = wrongRecords;

                }
            }
            catch (FileNotFoundException ioEx)
            {
                Console.WriteLine(ioEx.Message);
            }
        }

        public void writeFileInfoToWindow(System.Windows.Forms.RichTextBox InfoTextBox)
        {
            InfoTextBox.Text = "";

            foreach (KeyValuePair<string, float> keyValue in fileInfo)
            {
                if (keyValue.Key == "Размер файла")
                {
                    InfoTextBox.Text += String.Format("{0} : {1} байт\n", keyValue.Key, keyValue.Value);
                    continue;
                }
                //if (!isFilterModeActive)
                //{
                //    if (keyValue.Key == "Выведено строк")
                //        continue;
                //}
                //else
                //{
                //    if (keyValue.Key == "Выведено строк")
                //    {
                //        InfoTextBox.Text += String.Format("{0} : {1}\n", keyValue.Key, keyValue.Value);
                //        continue;
                //    }
                //}
                //if (isFilterModeActive)
                //    if (keyValue.Key == "Выведено строк")

                if (keyValue.Key == "Некорректные запросы")
                {
                    if (keyValue.Value == 0)
                        InfoTextBox.Text += String.Format("{0} : {1}\n", keyValue.Key, keyValue.Value);
                    else
                    {
                        InfoTextBox.Text += String.Format("{0} : {1}\n", keyValue.Key, keyValue.Value);
                        foreach (string _record in wrongRecordsList)
                            InfoTextBox.Text += "  " + _record + "\n";
                    }
                    continue;
                }
                //Console.WriteLine("{0} : {1}", keyValue.Key, keyValue.Value);
                InfoTextBox.Text += String.Format("{0} : {1}\n", keyValue.Key, keyValue.Value);

                //MessageBox.Show(String.Format("{0} - {1}", keyValue.Key,keyValue.Value));
            }
        }

        public FilteredRecords Filter(DateTime minDate = default(DateTime), DateTime maxDate = default(DateTime), string fileName = default(string), int resultType = 0, string ip = default(string), int lastRecords = -1)
        {
            FilteredRecords filteredList = new FilteredRecords();

            bool isMinDateFilterActive = false;
            if (minDate != default(DateTime))
                isMinDateFilterActive = true;
            bool isMaxDateFilterActive = false;
            if (maxDate != default(DateTime))
                isMaxDateFilterActive = true;
            bool isNameFilterActive = false;
            if (fileName != default(string))
                isNameFilterActive = true;
            bool isResultFilterActive = false;
            if (resultType != 0)
                isResultFilterActive = true;
            bool isIpFilterActive = false;
            if (ip != default(string))
                isIpFilterActive = true;
            bool isLastRecordsFilterActive = false;
            if (lastRecords > -1)
                isLastRecordsFilterActive = true;
            //if (isMinDateFilterActive || isMaxDateFilterActive || isNameFilterActive || isResultFilterActive || isIpFilterActive || isLastRecordsFilterActive)
            //    filteredList.anyFilterActive = true;
            //if (!isMinDateFilterActive && !isMaxDateFilterActive && !isNameFilterActive && !isResultFilterActive && !isIpFilterActive && !isLastRecordsFilterActive)
            //    filteredList.anyFilterActive = true;
            //else
            //{
            filteredList = Filter(minDate, maxDate, fileName, resultType, ip, lastRecords,
             isMinDateFilterActive, isMaxDateFilterActive, isNameFilterActive, isResultFilterActive, isIpFilterActive, isLastRecordsFilterActive);
            //}

            return filteredList;
        }

        private FilteredRecords Filter(DateTime min, DateTime max, string _name, int _resultType, string _ip, int _lastRecords,
            bool isMinDateFilterActive, bool IsMaxDateFilterActive, bool isNameFilterActive, bool isResultFilterActive, bool isIpFilterActive, bool isLastRecordsFilterActive)
        {
            FilteredRecords filteredList = new FilteredRecords();
            wrongRecordsList = new List<string>();
            try
            {
                int lineNumbersInFile = 0;
                using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        ++lineNumbersInFile;
                    }
                }

                fileInfo["Колличество строк"] = lineNumbersInFile;
                if (!isLastRecordsFilterActive)
                {

                    using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
                    {
                        string line;
                        int lineNumbers = 0;
                        int wrongRecords = 0;
                        while ((line = sr.ReadLine()) != null)
                        {

                            if (OneRecord.IsRecordCanBeCreated(line))
                            {
                                OneRecord record = new OneRecord(line);
                                bool allFiltersOK = true;


                                if (isMinDateFilterActive)
                                    if (!record.isRecordMinDateValid(min))
                                        allFiltersOK = false;
                                if (IsMaxDateFilterActive)
                                    if (!record.isRecordMaxDateValid(max))
                                        allFiltersOK = false;
                                if (isNameFilterActive)
                                    if (!record.isRecordFileNameValid(_name.Trim()))
                                        allFiltersOK = false;
                                if (isResultFilterActive)
                                    if (!record.isRecordsResultTypeValid(_resultType))
                                        allFiltersOK = false;
                                if (isIpFilterActive)
                                    if (!record.isRecordIPValid(_ip.Trim()))
                                        allFiltersOK = false;


                                if (allFiltersOK)
                                {
                                    filteredList.AddRecord(record);
                                    lineNumbers++;
                                }
                            }
                            else
                            {
                                wrongRecords++;
                                wrongRecordsList.Add(line);
                            }
                        }

                        fileInfo["Выведено строк"] = lineNumbers;
                        fileInfo["Некорректные запросы"] = wrongRecords;
                    }
                }
                else
                {
                    //int lineNumbersInFile = 0;
                    //using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
                    //{
                    //    string line;
                    //    while ((line = sr.ReadLine()) != null)
                    //    {
                    //        ++lineNumbersInFile;
                    //    }
                    //}
                    if (_lastRecords > lineNumbersInFile)
                        _lastRecords = lineNumbersInFile;
                    using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
                    {
                        string line;
                        int lineNumber = 0;
                        int outputLineNumbers = 0;
                        int wrongRecords = 0;
                        while ((line = sr.ReadLine()) != null)
                        {
                            ++lineNumber;
                            if (lineNumber >= lineNumbersInFile - _lastRecords)
                            {
                                if (OneRecord.IsRecordCanBeCreated(line))
                                {
                                    OneRecord record = new OneRecord(line);
                                    bool allFiltersOK = true;

                                    if (isMinDateFilterActive)
                                        if (!record.isRecordMinDateValid(min))
                                            allFiltersOK = false;
                                    if (IsMaxDateFilterActive)
                                        if (!record.isRecordMaxDateValid(max))
                                            allFiltersOK = false;
                                    if (isNameFilterActive)
                                        if (!record.isRecordFileNameValid(_name))
                                            allFiltersOK = false;
                                    if (isResultFilterActive)
                                        if (!record.isRecordsResultTypeValid(_resultType))
                                            allFiltersOK = false;
                                    if (isIpFilterActive)
                                        if (!record.isRecordIPValid(_ip))
                                            allFiltersOK = false;


                                    if (allFiltersOK)
                                    {
                                        filteredList.AddRecord(record);
                                        outputLineNumbers++;
                                    }
                                }
                                else
                                {
                                    wrongRecords++;
                                    wrongRecordsList.Add(line);
                                }
                            }
                        }
                        fileInfo["Выведено строк"] = outputLineNumbers;
                        fileInfo["Некорректные запросы"] = wrongRecords;
                    }
                }

            }
            catch (FileNotFoundException ioEx)
            {
                Console.WriteLine(ioEx.Message);
            }
            return filteredList;

        }


        public DangerousHTTPRequests SecureFilterAndScanAllFile()
        {
            DangerousHTTPRequests dangerousRequests = new DangerousHTTPRequests();
            FilteredRecords filtered = new FilteredRecords();
            try
            {
                using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
                {
                    string line;
                    //long bytesSeek = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (OneRecord.IsRecordCanBeCreated(line))
                        {
                            OneRecord record = new OneRecord(line);



                            //filteredList.AddRecord(record);
                            if (DangerousHTTPRequests.isRecordLoginFailure(record))
                            {
                                filtered.AddRecord(record);

                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException ioEx)
            {
                Console.WriteLine(ioEx.Message);
            }

            dangerousRequests = filtered.AttackDetector();
            return dangerousRequests;
        }

        public static BackgroundWatcher MakeBackgroundWatcher(LogFile logFile, NotifyIcon notifyIcon1, MailAddress mail = null)
        {
            BackgroundWatcher bgw = new BackgroundWatcher(logFile, notifyIcon1, mail);
            return bgw;
        }
    }
}
