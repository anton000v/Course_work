using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_main
{
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

                    AnalysisTextBox.Text += String.Format("[{0}]  {1} - {2:F}%\n", lineNumbers, keyValue.Key, keyValue.Value);
                }
            }
            else
            {
                AnalysisTextBox.Text = String.Format("Угроз не обнаружено");
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
