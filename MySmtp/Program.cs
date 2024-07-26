using System.Net.Mail;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;

namespace MySmtp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }


        public class MailSend
        {
            //https://help.mail.ru/mail/mailer/popsmtp/
            public static void Send()
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.IsBodyHtml = true;
                    mail.From = new MailAddress("murat_b@mail.ru");
                    mail.To.Add("dinash6145@mail.ru");
                    mail.CC.Add("ment_0000@mail.ru");
                    //mail.Bcc.Add("murat_b@mail.ru");
                    mail.Subject = "Excel";
                    mail.Body = "<h1>Excel во вложении</h1>";
                    Attachment attachment = new Attachment(@"C:\Users\байбатыровм\Desktop\123.xlsx");

                    mail.Attachments.Add(attachment);
                    using (System.Net.Mail.SmtpClient server = new System.Net.Mail.SmtpClient("smtp.mail.ru", 587))
                    {
                        server.UseDefaultCredentials = false;
                        server.Credentials = new System.Net.NetworkCredential("murat_b@mail.ru", "");
                        server.EnableSsl = true;
                        server.DeliveryMethod = SmtpDeliveryMethod.Network;
                        server.Send(mail);
                        server.Dispose();
                        Console.WriteLine("Send");
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }

            public static void Send2(byte[] rep, string name)
            {
                try
                {
                    LinkedResource res = new LinkedResource("12222.png");
                    res.ContentId = Guid.NewGuid().ToString();
                    string TextBody = String.Format(@"
                <html><body>
	            <font face='Calibri'>Добрый день, " +
                            "<br><br>Отчет <b>" + name + "</b> прикреплен! " +
                            "<br><br><b>	С уважением и любовью, <br> </b> </font>			<p><img src='cid:{0}' alt='photo robot'/></p>	</body></html>",
                        res.ContentId);
                    String htmlBody = TextBody;
                    System.Net.Mime.ContentType mimeType = new System.Net.Mime.ContentType("text/html");
                    AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, mimeType);
                    alternateView.LinkedResources.Add(res);
                    MailMessage mail = new MailMessage();
                    mail.IsBodyHtml = true;
                    mail.AlternateViews.Add(alternateView);
                    mail.From = new MailAddress("", "");
                    if (!string.IsNullOrEmpty("emailsTo"
                        ))
                    {
                        var emailsTo = "emailsTo".Split(';');
                        foreach (string item in emailsTo)
                        {
                            mail.To.Add(item);
                        }
                    }
                    //if (!string.IsNullOrEmpty(config["emailsCopy"]))
                    {
                        var emailsCopy = "".Split(';');
                        foreach (string item in emailsCopy)
                        {
                            mail.Bcc.Add(item);
                        }
                    }
                    mail.Subject = "Отчет: " + name;
                    MemoryStream ms = new MemoryStream(rep);
                    mail.Attachments.Add(new Attachment(ms, name));
                    using (SmtpClient server = new SmtpClient("smtpIp", 25))
                    {
                        server.Timeout = 10000000;
                        server.Send(mail);
                        server.Dispose();
                        ms.Close();
                    }
                }
                catch (Exception err)
                {
                    //logger.Error(err.Message);
                    //return "error: " + err.Message;
                }
            }
        }
        public class MailKit
        {
            public static void Start()
            {
                using (var client = new ImapClient())
                {

                    client.Connect("imap.mail.ru", 993, true);
                    client.Authenticate("murat_b@mail.ru", "");
                    client.Inbox.Open(FolderAccess.ReadWrite);
                    var ns = client.GetFolder("INBOX");
                    //IMailFolder inbox = client.GetFolder("Test");
                    //inbox.Open(FolderAccess.ReadWrite);
                    var uids = ns.Search(SearchQuery.All);
                    foreach (var uid in uids)
                    {
                        var message = ns.GetMessage(uid);

                        Console.WriteLine(message.Subject);
                    }




                }
            }
        }
    }


}