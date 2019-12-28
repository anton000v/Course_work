using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework_main
{
    public class BackgroundWatcher
    {
        //List<OneRecord> recordsList;
        public delegate void BacggroundWatcherAddDangerousIp();
        public event BacggroundWatcherAddDangerousIp addDangerousIp;              // 1.Определение события
        private FilteredRecords filteredRecords;

        private NotifyIcon notifyIcon1;

        private LogFile logfile;

        private MailAddress mailAddress;

        public DangerousHTTPRequests dangerousRequests;


        //private newRecords = 0;

        //public bool isHackDetacted;

        //private System.Windows.Forms.RichTextBox AnalysisTextBox;

        private FileSystemWatcher watcher;
        //private int DangerousIpSize;
        public bool isAnyDangerousIpDetected;
        //private int lineNumbers;
        //private bool isLastRecordValid = false;
        //public BackgroundWatcher()
        //{
        //    //recordsList = new List<OneRecord>();
        //    filteredRecords = new FilteredRecords();
        //}
        public BackgroundWatcher(LogFile lf, NotifyIcon notifyIcon, MailAddress mail = null)
        {
            //recordsList = new List<OneRecord>();
            filteredRecords = new FilteredRecords();
            logfile = lf;
            notifyIcon1 = notifyIcon;
            //AnalysisTextBox = atextbox;
            isAnyDangerousIpDetected = false;
            //lineNumbers = 0;
            //DangerousIpSize = 0;
            dangerousRequests = new DangerousHTTPRequests();
            mailAddress = mail;
        }

        public void LogWatcherON()
        {
            RunWatcher();

        }
        public void LogWatcherOFF()
        {
            StopWatcher();
        }
        private void StopWatcher()
        {
            watcher.Dispose();
        }
        private void RunWatcher()
        {

            watcher = new FileSystemWatcher { Path = logfile.onlyFilePath, Filter = logfile.onlyFileName };
            fillFilteredRecords();
            watcher.Changed += new FileSystemEventHandler(WatcherChanged);
            watcher.EnableRaisingEvents = true;
            //try
            //{

            //    using (FileStream fs = File.OpenRead(logfile.fileName))
            //    {
            //        watcher.Changed += new FileSystemEventHandler(WatcherChanged);
            //        watcher.EnableRaisingEvents = true;
            //    }
            //}

            //catch (Exception ex)
            //{
            //    //if (ex.HResult == -2147024894)
            //}

        }

        private void WatcherChanged(object sender, FileSystemEventArgs e)
        {
            //Console.WriteLine("Type of changes: {0};  Changed: {1}", e.ChangeType, e.Name);
            //MessageBox.Show(String.Format("Type of changes: {0};  Changed: {1}", e.ChangeType, e.Name));
            //isHackDetacted = false; 

            DangerousHTTPRequests dr = new DangerousHTTPRequests();
            int DangerousIpSize = dangerousRequests.DangerousIp.Count();
            //if (dangerousRequests.DangerousIp.Any())
            //{
            //    DangerousIpSize = dangerousRequests.DangerousIp.Count();
            //}
            //string s = ReadLastLine(logfile.fileName);
            //MessageBox.Show(String.Format("Добавлено: {0}", s));
            if (isLastRecordAdded())
            {
                //MessageBox.Show(String.Format("Добавлено: {0} --- {1}", filteredRecords.FilteredRecordsList.Last().logString,filteredRecords.FilteredRecordsList.First().logString));
                dr = filteredRecords.AttackDetector();

                if (dr.DangerousIp.Any())
                {

                    foreach (KeyValuePair<string, float> keyValue in dr.DangerousIp)
                    {
                        bool isHackerDetected = false;
                        if (keyValue.Value == 100)
                        {
                            if (mailAddress != null)
                            {
                                SendEmail(keyValue.Key);
                                BackgroundWatcher.makeNotify(notifyIcon1, String.Format("ip: {0} взламывает ваш ресурс прямо сейчас! Мы отправили уведомление на вашу почту!", keyValue.Key));
                            }
                            else
                                BackgroundWatcher.makeNotify(notifyIcon1, String.Format("ip: {0} взламывает ваш ресурс прямо сейчас!", keyValue.Key));
                            isHackerDetected = true;

                        }
                        if (!dangerousRequests.DangerousIp.ContainsKey(keyValue.Key))
                        {
                            if (!isHackerDetected)
                                BackgroundWatcher.makeNotify(notifyIcon1, "Попытка возможного взлома обнаружена");
                            dangerousRequests.DangerousIp[keyValue.Key] = keyValue.Value;
                            addDangerousIp?.Invoke();   // 2.Вызов события 
                            //writeToAnalisisTextBox();
                        }
                        else
                        {
                            float value = 0;
                            dangerousRequests.DangerousIp.TryGetValue(keyValue.Key, out value);
                            if (keyValue.Value > value)
                            {
                                if (!isHackerDetected)
                                    BackgroundWatcher.makeNotify(notifyIcon1, "Попытка возможного взлома обнаружена с большей вероятностью");
                                dangerousRequests.DangerousIp[keyValue.Key] = keyValue.Value;
                                addDangerousIp?.Invoke();   // 2.Вызов события 
                            }

                        }


                    }

                }

                //if (dangerousRequests.DangerousIp.Count() > DangerousIpSize)
                //{

                //    BackgroundWatcher.makeNotify(notifyIcon1, "Попытка возможного взлома обнаружена");
                //    //DangerousIpSize = dangerousRequests.DangerousIp.Count();
                //    //DangerousIpSize = dangerousRequests.DangerousIp.Count();
                //    //if (!isAnyDangerousIpDetected)
                //    //{

                //    //    isAnyDangerousIpDetected = true;
                //    //}

                //    //isHackDetacted = true;

                //    //foreach(KeyValuePair<string,float> keyValue in dangerousRequests.DangerousIp)
                //    //    WriteDangerousRequest_InBackgroundMode_ToWindow(keyValue);
                //    //dangerousRequests.DangerousIp.Clear();

                //    }
                //}

                //foreach (KeyValuePair<string, float> keyValue in dangerousRequests.DangerousIp)
                //{
                //    //if (isDangerousIPFound(keyValue))
                //    //{

                //    //}
                //}
            }

        }

        public void WriteDangerousRequest_InBackgroundMode_ToWindow(RichTextBox AnalysisTextBox)
        {
            int lineNumbers = 0;
            AnalysisTextBox.Invoke(new Action(() => {
                AnalysisTextBox.Text = "[Номер]  [ip] - [Вероятность попытки взлома]\n\n";
            }));
            foreach (KeyValuePair<string, float> keyValue in dangerousRequests.DangerousIp)
            {
                lineNumbers++;
                AnalysisTextBox.Invoke(new Action(() => {
                    AnalysisTextBox.Text = String.Format(AnalysisTextBox.Text += String.Format("[{0}]  {1} - {2:F}%\n", lineNumbers, keyValue.Key, keyValue.Value));
                }));
            }

        }

        private void fillFilteredRecords(int n = 20)
        {
            filteredRecords = logfile.Filter(lastRecords: n);
        }
        private bool isLastRecordAdded()
        {
            string record = BackgroundWatcher.ReadLastLine(logfile.fileName);
            if (record != "" && record != filteredRecords.FilteredRecordsList.Last().logString)
            {
                if (OneRecord.IsRecordCanBeCreated(record))
                {
                    OneRecord _record = new OneRecord(record);
                    filteredRecords.deleteFirstRecord();
                    filteredRecords.AddRecord(_record);
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }

        }
        static string ReadLastLine(string path)
        {
            //using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None))
            //{
            //    byte b;
            //    fs.Position = fs.Length;
            //    while (fs.Position > 0)
            //    {
            //        fs.Position--;
            //        b = (byte)fs.ReadByte();
            //        if (b == '\n')
            //        {
            //            break;
            //        }
            //        fs.Position--;
            //    }
            //    byte[] bytes = new byte[fs.Length - fs.Position];
            //    fs.Read(bytes, 0, bytes.Length);
            //    fs.Flush();
            //    //fs.BaseStream.Flush();
            //    return System.Text.Encoding.UTF8.GetString(bytes);
            //}

            if (BackgroundWatcher.IsFileClosed(path, true))
            {
                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    byte b;
                    fs.Position = fs.Length;
                    while (fs.Position > 0)
                    {
                        fs.Position--;
                        b = (byte)fs.ReadByte();
                        if (b == '\n')
                        {
                            break;
                        }
                        fs.Position--;
                    }
                    byte[] bytes = new byte[fs.Length - fs.Position];
                    fs.Read(bytes, 0, bytes.Length);
                    //fs.Flush();
                    //fs.BaseStream.Flush();
                    fs.Close();
                    return System.Text.Encoding.UTF8.GetString(bytes);
                }
            }
            return "";
            //fs.Close();

        }

        //private bool isDangerousIPFound(KeyValuePair<string,float> keyValue)
        //{
        //    if (keyValue.Value > 40)
        //    {
        //        //notifyIcon1.BalloonTipText = "log VnVlyzer переведен в фоновый режим";
        //        //notifyIcon1.ShowBalloonTip(1000);
        //        return true;
        //    }
        //    return false;
        //}
        public static bool IsFileClosed(string filepath, bool wait)
        {
            bool fileClosed = false;
            int retries = 20;
            const int delay = 500; // Max time spent here = retries*delay milliseconds

            if (!File.Exists(filepath))
                return false;

            do
            {
                try
                {
                    // Attempts to open then close the file in RW mode, denying other users to place any locks.
                    FileStream fs = File.Open(filepath, FileMode.Open, FileAccess.Read, FileShare.None);
                    fs.Close();
                    fileClosed = true; // success
                }
                catch (IOException) { }

                if (!wait) break;

                retries--;

                if (!fileClosed)
                    Thread.Sleep(delay);
            }
            while (!fileClosed && retries > 0);

            return fileClosed;
        }

        public static void makeNotify(NotifyIcon notifyIcon1, string text, int time = 1000)
        {
            notifyIcon1.BalloonTipText = text;
            notifyIcon1.ShowBalloonTip(time);
        }

        public void SendEmail(string ip)
        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("logvnvlyzer@gmail.com", "log VnVlyzer");
            // кому отправляем
            MailAddress to = mailAddress;
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = "На вашем ресурсе обнаружен вредитель!";
            // текст письма
            m.Body = String.Format("<h2>Мы поймали на вашем ресурсе розбийныка!<br>Его ip - <p style=\"color:red\">{0}</p>", ip);
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 25);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("logvnvlyzer@gmail.com", "a_qwerty");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }

    }
}
