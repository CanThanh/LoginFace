using AE.Net.Mail;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using xNet;

namespace XMDT
{
    internal class Mail
    {
        public void Verify(string email, string pass, string ipmap, int port)
        {
            string url = null;
            using (ImapClient ic = new ImapClient())
            {
                ic.Connect(ipmap, port, true, false);
                ic.Login(email, pass);
                ic.SelectMailbox("INBOX");
                int mailcount;
                for (mailcount = ic.GetMessageCount(); mailcount < 2; mailcount = ic.GetMessageCount())
                {
                    Mail.Delay(5);
                    ic.SelectMailbox("INBOX");
                }
                MailMessage[] mm = ic.GetMessages(mailcount - 1, mailcount - 1, false, false);
                MailMessage[] array = mm;
                for (int j = 0; j < array.Length; j++)
                {
                    MailMessage i = array[j];
                    {
                        string sbody = i.Body;
                        url = Regex.Match(i.Body, "abcd").Groups[1].Value;
                        bool flag2 = string.IsNullOrEmpty(url);
                        if (flag2)
                        {
                            url = Regex.Match(i.Body, "(http.*)").Groups[1].Value.Trim();
                            url = url.Substring(0, url.IndexOf('"'));
                        }
                        break;
                    }
                }
                ic.Dispose();
            }
            HttpRequest rq = new HttpRequest();
            rq.Cookies = new CookieDictionary(false);
            rq.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.92 Safari/537.36";
            bool Load = false;
            while (!Load)
            {
                try
                {
                    rq.Get(url, null);
                    Load = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public string GetCode(string email, string pass, string ipmap, int port, string strRegex)
        {
            string result = null;
            string url = null;
            using (ImapClient ic = new ImapClient())
            {
                ic.Connect(ipmap, port, true, false);
                ic.Login(email, pass);
                ic.SelectMailbox("INBOX");
                int mailcount;
                for (mailcount = ic.GetMessageCount(); mailcount < 2; mailcount = ic.GetMessageCount())
                {
                    Mail.Delay(5);
                    ic.SelectMailbox("INBOX");
                }
                MailMessage[] mm = ic.GetMessages(mailcount - 50, mailcount -1, false, false);
                //MailMessage[] mm = ic.GetMessages(0, 20, false, false);
                MailMessage[] array = mm;
                for (int j = 0; j < array.Length; j++)
                {
                    MailMessage i = array[j];
                    {
                        if (i.Subject.ToLower().Contains("facebook") && i.From.Address.ToLower().Contains("security"))
                        {
                            string sbody = i.Body;
                            result = Regex.Match(i.Body, strRegex).Value;
                            if(result.Length  >= 6)
                            {
                                return result;
                            }
                        }
                    }
                }
                ic.Dispose();
            }
            return result;
        }

        private static void Delay(int time)
        {
            for (int i = 0; i < time; i++)
            {
                Thread.Sleep(time);
            }
        }
    }
}
