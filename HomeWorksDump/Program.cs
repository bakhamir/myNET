using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using MailKit.Net.Smtp;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit.Security;
using MimeKit;
using Renci.SshNet;
using FluentFTP;
using System.Net.Mail;
using System.Net.Mime;

namespace Exam
{
    internal class Program
    {
        static string ftpUrl = "ftp://ftp.dlptest.com";
        static string ftpUser = "dlpuser";
        static string ftpPassword = "rNrKYTX9g7z3RgJRmxWuGHbeu";

        static string sftpHost = "test.rebex.net";
        static string sftpUser = "demo";
        static string sftpPassword = "password";

        static string smtpHost = "smtp.mail.ru";
        static string smtpUser = "elmirs@mail.ru";
        static string smtpPassword = "altyn1965..";

        static string imapHost = "imap.mail.ru";
        static string imapUser = "elmirs@mail.ru";
        static string imapPassword = "altyn1965..";

        static void Main(string[] args)
        {
 
            StartTcpServer();
            StartUdpServer();
            StartHttpListener(8080, HttpMethod.Get);
            StartHttpListener(8081, HttpMethod.Post);
            FTPUploadFile("example.txt");
            SFTPDownloadFile("readme.txt");
            SendEmailWithAttachments();
            ReadEmailSubjects();
        }

        static void StartTcpServer()
        {
            Task.Run(() =>
            {
                var listener = new TcpListener(IPAddress.Any, 9000);
                listener.Start();
                while (true)
                {
                    var client = listener.AcceptTcpClient();
                    var stream = client.GetStream();
                    using (var fileStream = new FileStream("received_file.txt", FileMode.Create))
                    {
                        stream.CopyTo(fileStream);
                    }
                    using (var archive = ZipFile.Open("archive.zip", ZipArchiveMode.Create))
                    {
                        archive.CreateEntryFromFile("received_file.txt", "received_file.txt");
                    }
                    using (var archiveStream = File.OpenRead("archive.zip"))
                    {
                        archiveStream.CopyTo(stream);
                    }
                    client.Close();
                }
            });
        }

        static void StartUdpServer()
        {
            Task.Run(() =>
            {
                var udpClient = new UdpClient(9001);
                IPEndPoint remoteEP = null;
                var data = udpClient.Receive(ref remoteEP);
                File.WriteAllBytes("received_file_udp.txt", data);
                using (var archive = ZipFile.Open("archive_udp.zip", ZipArchiveMode.Create))
                {
                    archive.CreateEntryFromFile("received_file_udp.txt", "received_file_udp.txt");
                }
            });
        }

        static void StartHttpListener(int port, HttpMethod method)
        {
            Task.Run(() =>
            {
                var listener = new HttpListener();
                listener.Prefixes.Add($"http://localhost:{port}/");
                listener.Start();
                while (true)
                {
                    var context = listener.GetContext();
                    var response = context.Response;
                    int number = int.Parse(context.Request.QueryString["number"] ?? "0");
                    long factorial = Factorial(number);
                    byte[] buffer = Encoding.UTF8.GetBytes($"Factorial of {number} is {factorial}");
                    response.ContentLength64 = buffer.Length;
                    response.OutputStream.Write(buffer, 0, buffer.Length);
                    response.OutputStream.Close();
                }
            });
        }

        static long Factorial(int number)
        {
            if (number <= 1) return 1;
            return number * Factorial(number - 1);
        }

        static void FTPUploadFile(string localFilePath)
        {
            using (var ftpClient = new FtpClient(ftpUrl, new NetworkCredential(ftpUser, ftpPassword)))
            {
                ftpClient.Connect();
                ftpClient.UploadFile(localFilePath, $"/{Path.GetFileName(localFilePath)}");
            }
        }

        static void SFTPDownloadFile(string remoteFilePath)
        {
            using (var sftpClient = new SftpClient(sftpHost, sftpUser, sftpPassword))
            {
                sftpClient.Connect();
                using (var fileStream = File.OpenWrite(Path.GetFileName(remoteFilePath)))
                {
                    sftpClient.DownloadFile(remoteFilePath, fileStream);
                }
            }
        }

        static void SendEmailWithAttachments()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Exam User", smtpUser));
            message.To.Add(new MailboxAddress("Exam User", smtpUser));
            message.Subject = "Sample";

            var multipart = new Multipart("mixed");
            for (int i = 1; i <= 3; i++)
            {
                var attachment = new MimePart("application", "vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    Content = new MimeContent(File.OpenRead($"file{i}.xlsx")),
                    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                    ContentTransferEncoding = ContentEncoding.Base64,
                    FileName = $"file{i}.xlsx"
                };
                multipart.Add(attachment);
            }
            message.Body = multipart;

            using (var client = new SmtpClient())
            {
                client.Connect(smtpHost, 587, false);
                client.Authenticate(smtpUser, smtpPassword);
                client.Send(message);
                client.Disconnect(true);
            }
        }

        static void ReadEmailSubjects()
        {
            using (var client = new ImapClient())
            {
                client.Connect(imapHost, 993, true);
                client.Authenticate(imapUser, imapPassword);
                client.Inbox.Open(MailKit.FolderAccess.ReadOnly);
                var uids = client.Inbox.Search(SearchQuery.All).Take(10);
                foreach (var uid in uids)
                {
                    var message = client.Inbox.GetMessage(uid);
                    Console.WriteLine("Subject: " + message.Subject);
                }
                client.Disconnect(true);
            }
        }
    }
}
