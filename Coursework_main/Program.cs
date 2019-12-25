﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;
namespace Coursework_main
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class LogFile
    {
        public string fileName;
        public string onlyFilePath;
        public string onlyFileName = "";

        //public bool isWholeFileRead;
        public bool isFilterModeActive = false;

        public List<string> wrongRecordsList;

        public Dictionary<string,float> fileInfo;
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
            FileInfo file = new System.IO.FileInfo(fileName);
            long size = file.Length;
            fileInfo.Add("Размер файла", (int)size);
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

        public void LogWatcherON()
        {
            RunWatcher();

        }
        private void RunWatcher()
        {
            FileSystemWatcher watcher = new FileSystemWatcher { Path = onlyFilePath, Filter = onlyFileName };
            watcher.Changed += WatcherChanged;
            watcher.EnableRaisingEvents = true;
        }

        private void WatcherChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Type of changes: {0};  Changed: {1}", e.ChangeType, e.Name);
        }
    }
    public class OneRecord
    {
        public string logString;
        public string ip;
        public DateTime date;
        public string request;
        public string request_file_name;
        public int response;
        public int bytesSent;

        //public Dictionary<int, string> HTTPResultTypes
        //{
        //    get
        //    {
        //        return httpResultTypes;
        //    }
        //}
        public static Dictionary<int, string> GetHTTPResultValidTypes()
        {
            Dictionary<int, string> httpResultTypes = new Dictionary<int, string>
            {
                [100] = "Continue",
                [101] = "Switching Protocol",
                [102] = "Processing",
                [103] = "Early Hints",
                [200] = "OK",
                [201] = "Created",
                [202] = "Accepted",
                [203] = "Non-Authoritative Information",
                [204] = "No Content",
                [205] = "Reset Content",
                [206] = "Partial Content",
                [300] = "Multiple Choice",
                [301] = "Moved Permanently",
                [302] = "Found",
                [303] = "See Other",
                [304] = "Not Modified",
                [305] = "Use Proxy",
                [306] = "Switch Proxy",
                [307] = "Temporary Redirect",
                [308] = "Permanent Redirect",
                [400] = "Bad Request",
                [401] = "Unauthorized",
                [402] = "Payment Required",
                [403] = "Forbidden",
                [404] = "Not Found",
                [405] = "Method Not Allowed",
                [406] = "Not Acceptable",
                [407] = "Proxy Authentication Required",
                [408] = "Request Timeout",
                [409] = "Conflict",
                [410] = "Gone",
                [411] = "Length Required",
                [412] = "Precondition Failed",
                [413] = "Request Entity Too Large",
                [414] = "Request-URI Too Long",
                [415] = "Unsupported Media Type",
                [416] = "Requested Range Not Satisfiable",
                [417] = "Expectation Failed",
                [500] = "Internal Server Error",
                [501] = "Not Implemented",
                [502] = "Bad Gateway",
                [503] = "Service Unavailable",
                [504] = "Gateway Timeout",
                [505] = "HTTP Version Not Supported",

            };
            return httpResultTypes;
        }
        private string logEntryPattern = "^([\\d.]+) (\\S+) (\\S+) \\[([\\w:/]+\\s[+\\-]\\d{4})\\] \"(.+?)\" (\\d{3}) (\\d+)";

        public OneRecord(string _logString)
        {

            Match theMatch = Regex.Match(_logString, logEntryPattern);

            if (theMatch.Success)
            {
                logString = _logString;
                ip = theMatch.Groups[1].Value;
                date = ConvertDateToDateFormat(theMatch.Groups[4].Value);
                request = theMatch.Groups[5].Value;

                request_file_name = Path.GetFileName(request.Split()[1]);
                response = Int32.Parse(theMatch.Groups[6].Value);
                bytesSent = Int32.Parse(theMatch.Groups[7].Value);
            }
        }
        public static bool IsRecordCanBeCreated(string _logString)
        {
            string logEntryPattern = "^([\\d.]+) (\\S+) (\\S+) \\[([\\w:/]+\\s[+\\-]\\d{4})\\] \"(.+?)\" (\\d{3}) (\\d+)";
            Dictionary<int, string> HTTPResultTypes = OneRecord.GetHTTPResultValidTypes();
            Match theMatch = Regex.Match(_logString, logEntryPattern);

            if (theMatch.Success && HTTPResultTypes.ContainsKey(Int32.Parse(theMatch.Groups[6].Value)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DateTime ConvertDateToDateFormat(string _string)
        {
            _string = String.Concat(_string.Substring(0, _string.IndexOf(':')), ' ', _string.Substring(_string.IndexOf(':') + 1));
            DateTime date = DateTime.Parse(_string);
            return date;
        }
        public void WriteToConsole()
        {
            Console.WriteLine("Исходная строка: {0}", logString);
            Console.WriteLine("IP Address: {0}", ip);
            Console.WriteLine("Date time: {0}", date);
            Console.WriteLine("Request: {0}", request);
            Console.WriteLine("Request file name: {0}", request_file_name);
            Console.WriteLine("Response: {0}", response);
            Console.WriteLine("Bytes Sent: {0}", bytesSent);
        }
        //public void WriteToWindow()
        //{
        //    dataGridView1.Rows.Add(myDataCol);
        //    Console.WriteLine("Исходная строка: {0}", logString);
        //    Console.WriteLine("IP Address: {0}", ip);
        //    Console.WriteLine("Date time: {0}", date);
        //    Console.WriteLine("Request: {0}", request);
        //    Console.WriteLine("Request file name: {0}", request_file_name);
        //    Console.WriteLine("Response: {0}", response);
        //    Console.WriteLine("Bytes Sent: {0}", bytesSent);
        //}
        public bool isRecordMinDateValid(DateTime min)
        {
            if (date.CompareTo(min) > 0)
                return true;
            else
                return false;
        }
        public bool isRecordMaxDateValid(DateTime max)
        {
            if (date.CompareTo(max) < 0)
                return true;
            else
                return false;
        }
        public bool isRecordFileNameValid(string _name)
        {
            if (request_file_name == _name)
                return true;
            else
                return false;
        }
        public bool isRecordsResultTypeValid(int _type)
        {
            if (response == _type)
                return true;
            else
                return false;
        }
        public bool isRecordIPValid(string _ip)
        {
            if (ip == _ip)
                return true;
            else
                return false;
        }
    }
    public class FilteredRecords
    {
        private bool anyfilteractive = false;
        //public Dictionary<string, int> fileInfo;
        public bool anyFilterActive
        {
            get { return anyFilterActive; }
            set { anyfilteractive = anyFilterActive; }
        }
        public List<OneRecord> FilteredRecordsList;
        //private List<OneRecord> DangerousHttpRequests;
        public FilteredRecords()
        {
            FilteredRecordsList = new List<OneRecord>();
            //fileInfo = new Dictionary<string, int>();
            //DangerousHttpRequests = new List<OneRecord>();
        }
        public void AddRecord(OneRecord _record)
        {
            this.FilteredRecordsList.Add(_record);
        }
        //public void WriteFilteredRecordsToConsole()
        //{
        //    if (FilteredRecordsList.Any())
        //    {
        //        foreach (OneRecord _record in FilteredRecordsList)
        //        {
        //            _record.WriteToConsole();
        //            Console.WriteLine("");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Filtered list is empty");
        //    }
        //}

        public void WriteFilterRecordsToWindow(System.Windows.Forms.RichTextBox richTextBox1)
        {
            if (FilteredRecordsList.Any())
            {
                int lineNumbers = 0;
                foreach (OneRecord _record in FilteredRecordsList)
                {
                    //richTextBox1.Text += _record.logString + '\n';
                    lineNumbers++;
                    richTextBox1.Text += String.Format("[{0}]    {1}\n", lineNumbers, _record.logString);
                    //_record.WriteToConsole();
                    //Console.WriteLine("");
                }
                //fileInfo["Число строк"] = lineNumbers;
            }
            else
            {
               
                richTextBox1.Text = "Filtered list is empty";
            }
           
            //fileInfo["Некорректные логи"] = wrongRecords;
        }
        public DangerousHTTPRequests AttackDetector()
        {
            DangerousHTTPRequests dangerousRequests = new DangerousHTTPRequests();
            //if (anyFilterActive)
            //{
            int index = 0;
            foreach (OneRecord _record in FilteredRecordsList)
            {
                if (DangerousHTTPRequests.isRecordLoginFailure(_record))
                {

                    string ip = _record.ip;
                    string requestFilename = _record.request_file_name;
                    DateTime time = _record.date;
                    int numberOfRequests = 1;

                    //if (dangerousRequests.DangerousIp.ContainsKey(ip))
                    //    break;

                    for (int i = index + 1; i < FilteredRecordsList.Count; i++)
                    {
                        //Console.WriteLine("{0}", FilteredRecordsList[i].date - time);
                        if ((FilteredRecordsList[i].date - time).TotalMinutes >= 1)
                            break;
                        if (ip != FilteredRecordsList[i].ip)
                            continue;
                        if (requestFilename != FilteredRecordsList[i].request_file_name)
                            continue;
                        //Console.WriteLine("{0}", FilteredRecordsList[i].date);
                        numberOfRequests++;
                    }
                    float probabilityOfDangerous = (float)100 * numberOfRequests / 15; // 15 ---> 100%
                    if (DangerousHTTPRequests.isRecordDangerous(numberOfRequests, probabilityOfDangerous))
                    {
                        if (dangerousRequests.DangerousIp.ContainsKey(ip))
                        {
                            if (dangerousRequests.DangerousIp[ip] < probabilityOfDangerous)
                            {
                                dangerousRequests.DangerousIp[ip] = probabilityOfDangerous;
                                //Console.WriteLine("blya");
                            }
                            //else
                            //    break;
                        }
                        else
                            dangerousRequests.AddIp(ip, probabilityOfDangerous);
                    }
                    //Console.WriteLine("aaaaaaaaaaaaaaa {0}", dangerousRequests.DangerousIp[ip]);
                    //Console.WriteLine(string.Format("колво - {0}; Number 2 : {1:0.00##}", numberOfRequests,probabilityOfDangerous));

                }
                index++;
            }
            //}
            //else
            //{

            //}

            return dangerousRequests;
        }

    }
    public class DangerousHTTPRequests
    {
        //private List<OneRecord> DangerousRequestsList;
        private Dictionary<string, float> dangerousip;
        //private Dictionary<string, Dictionary<DateTime,float>> dangerousrequest;
        public Dictionary<string, float> DangerousIp
        {
            get { return dangerousip; }
        }
        //public Dictionary<string, Dictionary<DateTime, float>> dangerousRequest
        //{
        //    get { return dangerousrequest; }
        //}
        public DangerousHTTPRequests()
        {
            //DangerousRequestsList = new List<OneRecord>();
            dangerousip = new Dictionary<string, float>();
        }

        //public void AddRecordToList(OneRecord _record)
        //{
        //    DangerousRequestsList.Add(_record);        
        //}
        public void AddIp(string ip, float probabilityOfDangerous)
        {
            dangerousip[ip] = probabilityOfDangerous;
        }
        //public void AddDangerousRequest(string ip,DateTime time ,float probabilityOfDangerous)
        //{
        //    dangerousrequest[ip].Add(time,probabilityOfDangerous);
        //}
        //public bool alreadyHaveThisTime(string ip,DateTime date)
        //{
        //    foreach (KeyValuePair<string, Dictionary<DateTime, float>> keyValue in dangerousrequest)
        //    {
        //        //Console.WriteLine("ip {0}", keyValue.Key);
        //        if(keyValue.Key == ip)
        //            if (keyValue.Value.ContainsKey(date))

        //                    return true;
        //    }
        //    return false;
        //}
        //public void writeDangerousRequestsToConsole()
        //{
        //    if (DangerousIp.Any())
        //    {
        //        foreach (KeyValuePair<string, Dictionary<DateTime,float>> keyValue in dangerousrequest)
        //        {
        //            Console.WriteLine("ip {0}", keyValue.Key);
        //            foreach (KeyValuePair<DateTime, float> keyValue2 in keyValue.Value)
        //            {
        //                Console.WriteLine("{0} - {1:F}", keyValue2.Key, keyValue2.Value);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("There are no dangerous requests");
        //    }
        //}
        public void writeDangerousRequestsToConsole()
        {
            if (DangerousIp.Any())
            {
                foreach (KeyValuePair<string, float> keyValue in DangerousIp)
                {
                    Console.WriteLine("{0} - {1:F}", keyValue.Key, keyValue.Value);
                }
            }
            else
            {
                Console.WriteLine("There are no dangerous requests");
            }
        }

        public void writeDangerousRequestsToWindow(System.Windows.Forms.RichTextBox AnalysisTextBox)
        {
            //if (FilteredRecordsList.Any())
            //{
            //    int lineNumbers = 0;
            //    foreach (OneRecord _record in FilteredRecordsList)
            //    {
            //        //richTextBox1.Text += _record.logString + '\n';
            //        lineNumbers++;
            //        richTextBox1.Text += String.Format("[{0}]    {1}\n", lineNumbers, _record.logString);
            //        //_record.WriteToConsole();
            //        //Console.WriteLine("");
            //    }
            //}
            //else
            //{

            //    richTextBox1.Text = "Filtered list is empty";
            //}

            if (DangerousIp.Any())
            {
                int lineNumbers = 0;
                AnalysisTextBox.Text = "[Номер]  [ip] - [Вероятность попытки взлома]\n\n";
                foreach (KeyValuePair<string, float> keyValue in DangerousIp)
                {
                    lineNumbers++;
                    //Console.WriteLine("{0} - {1:F}", keyValue.Key, keyValue.Value);
                    
                    AnalysisTextBox.Text += String.Format("[{0}]  {1} - {2:F}%", lineNumbers,keyValue.Key, keyValue.Value);
                }
            }
            else
            {
                AnalysisTextBox.Text = String.Format("There are no dangerous requests");
            }

        }

        public static bool isRecordLoginFailure(OneRecord _record)
        {
            if (_record.request_file_name == "login.php")
            {
                if (_record.response != 200)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool isRecordDangerous(int numberOfRequests, float probabilityOfDangerous)
        {
            //float probabilityOfDangerous = (float)100 * numberOfRequests / 15; // 15 ---> 100%
            //                                                                   //Console.WriteLine(string.Format("колво - {0}; Number 2 : {1:0.00##}", numberOfRequests,probabilityOfDangerous));
            if (probabilityOfDangerous > 30)
            {
                //dangerousRequests.AddIp(ip, probabilityOfDangerous);
                return true;
            }
            return false;
        }

    }
}