using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_main
{
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
        public void deleteFirstRecord()
        {
            this.FilteredRecordsList.RemoveAt(0);
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

        public void WriteFilterRecordsToWindow(System.Windows.Forms.DataGridView dgv)
        {
            dgv.Rows.Clear();
            if (FilteredRecordsList.Any())
            {
                int lineNumbers = 0;
                foreach (OneRecord _record in FilteredRecordsList)
                {
                    //richTextBox1.Text += _record.logString + '\n';
                    lineNumbers++;
                    //richTextBox1.Text += String.Format("[{0}]    {1}\n", lineNumbers, _record.logString);

                    var index = dgv.Rows.Add();
                    //dgv.Rows[index].Cells["NumberOfLine"].Value = index+1;
                    dgv.Rows[index].Cells["IP"].Value = _record.ip;
                    dgv.Rows[index].Cells["DateTime"].Value = _record.date;
                    dgv.Rows[index].Cells["Request"].Value = _record.request;
                    dgv.Rows[index].Cells["AnswerNumber"].Value = _record.response;
                    dgv.Rows[index].Cells["BytesSent"].Value = _record.bytesSent;
                    //_record.WriteToConsole();
                    //Console.WriteLine("");
                }
                //fileInfo["Число строк"] = lineNumbers;
            }
            //else
            //{

            //    //richTextBox1.Text = "Filtered list is empty";
            //}

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
                    if (probabilityOfDangerous > 100)
                        probabilityOfDangerous = 100;
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
}
