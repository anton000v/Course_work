using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Coursework_main
{
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
}
