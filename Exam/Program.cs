using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Sockets;
using FluentFTP;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit;
using MailKit.Security;
using MimeKit;
using HtmlAgilityPack;
using Renci.SshNet;
using System.Net.Mail;

namespace Exam
{
    public static class ExamTasks
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
        static string downloadFolder = @"C:\Users\БахытжановА\myNET\Exam";

        public static void PerformAllTasks()
        {
            SendFilesViaTcp();
            ZipTxtsToFTP();
            DownloadPdfTask();
            SendEmailWithAttachment();
            MoveEmailToFolder();
            ParseSiteForPhones();
            DownloadAndExtractZip();
            GetOldestEmails();
        }

        public static void SendFilesViaTcp()
        {
            string[] files = { "sample1.txt", "sample2.txt", "sample3.txt", "sample4.txt" };
            string server = "127.0.0.1"; 
            int port = 8080; 

            foreach (var file in files)
            {
                byte[] fileData = File.ReadAllBytes(Path.Combine(downloadFolder, file));

                using (TcpClient client = new TcpClient(server, port))
                using (NetworkStream stream = client.GetStream())
                {
                    stream.Write(fileData, 0, fileData.Length);
                }
            }
        }

        public static void ZipTxtsToFTP()
        {
            FtpClient ftp = new FtpClient();
            ftp.Host = ftpUrl;
            ftp.Credentials = new NetworkCredential(ftpUser, ftpPassword);
            ftp.Connect();

            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    string[] files = { "sample1.txt", "sample2.txt", "sample3.txt", "sample4.txt" };

                    foreach (var file in files)
                    {
                        archive.CreateEntryFromFile(Path.Combine(downloadFolder, file), file);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(downloadFolder, "exam.zip"), FileMode.Create))
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    memoryStream.CopyTo(fileStream);
                }

                try
                {
                    ftp.UploadFile(Path.Combine(downloadFolder, "exam.zip"), "/07/exam.zip");
                }
                catch (Exception e)
                {
                    Console.WriteLine("there is an FTP connection error");
                    Console.WriteLine(e.InnerException);
                }
            }
        }

        public static void DownloadPdfTask()
        {
            string pdfUrl = "https://beeline.kz/binaries/content/assets/public_offer/public_offer_ru.pdf";
            string localFilePath = Path.Combine(downloadFolder, "exam.pdf");

            using (var client = new WebClient())
            {
                client.DownloadFile(pdfUrl, localFilePath);
            }

            using (var ftpStream = new WebClient().OpenRead(pdfUrl))
            using (var memoryStream = new MemoryStream())
            {
                ftpStream.CopyTo(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);

                FtpClient ftp = new FtpClient();
                ftp.Host = ftpUrl;
                ftp.Credentials = new NetworkCredential(ftpUser, ftpPassword);
                ftp.Connect();
                ftp.Upload(memoryStream, "/exam.pdf");
            }

            // Отправка файла на SFTP
            using (var ftpStream = new WebClient().OpenRead(pdfUrl))
            using (var memoryStream = new MemoryStream())
            {
                ftpStream.CopyTo(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);

                using (var sftp = new SftpClient(sftpHost, sftpUser, sftpPassword))
                {
                    sftp.Connect();
                    sftp.UploadFile(memoryStream, "/exam.pdf");
                    sftp.Disconnect();
                }
            }
        }

        public static void SendEmailWithAttachment()
        {
            var smtpClient = new SmtpClient(smtpHost)
            {
                Port = 587,
                Credentials = new NetworkCredential(smtpUser, smtpPassword),
                EnableSsl = true,
            };

            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("Sender", smtpUser));
            mailMessage.To.Add(new MailboxAddress("Receiver", smtpUser));
            mailMessage.Subject = "sample";

            var bodyBuilder = new BodyBuilder { TextBody = "sample" };
            bodyBuilder.Attachments.Add(Path.Combine(downloadFolder, "exam.zip"));
            mailMessage.Body = bodyBuilder.ToMessageBody();

            smtpClient.Send(mailMessage);
        }

        public static void MoveEmailToFolder()
        {
            using (var client = new ImapClient())
            {
                client.Connect(imapHost, 993, SecureSocketOptions.SslOnConnect);
                client.Authenticate(smtpUser, smtpPassword);

                client.Inbox.Open(FolderAccess.ReadWrite);
                var query = SearchQuery.SubjectContains("sample");
                var uids = client.Inbox.Search(query);

                foreach (var uid in uids)
                {
                    var message = client.Inbox.GetMessage(uid);
                    client.Inbox.SetFlags(uid, MessageFlags.Seen, true);
                    client.MoveTo(uid, client.GetFolder("DestinationFolder"));
                }

                client.Disconnect(true);
            }
        }

        public static void ParseSiteForPhones()
        {
            var web = new HtmlWeb();
            var doc = web.Load("https://beeline.kz/ru");

            var phones = doc.DocumentNode.SelectNodes("//footer//text()[contains(.,'116') or contains(.,'3131') or contains(.,'+7 (727) 3500 500')]");
            foreach (var phone in phones)
            {
                Console.WriteLine(phone.InnerText);
            }
        }

        public static void DownloadAndExtractZip()
        {
            string url = "https://github.com/mbaibatyr/SEP_221_NET/archive/refs/heads/master.zip";
            string zipPath = Path.Combine(downloadFolder, "master.zip");
            string extractPath = Path.Combine(downloadFolder, "extracted");

            using (var client = new WebClient())
            {
                client.DownloadFile(url, zipPath);
            }

            ZipFile.ExtractToDirectory(zipPath, extractPath);

            var gitIgnoreContent = File.ReadAllText(Path.Combine(extractPath, "SEP_221_NET-master", ".gitignore"));
            Console.WriteLine(gitIgnoreContent);

            File.Delete(zipPath);
            Directory.Delete(extractPath, true);
        }

        public static void GetOldestEmails()
        {
            using (var client = new ImapClient())
            {
                client.Connect(imapHost, 993, SecureSocketOptions.SslOnConnect);
                client.Authenticate(smtpUser, smtpPassword);

                client.Inbox.Open(FolderAccess.ReadOnly);

                var uids = client.Inbox.Search(SearchQuery.All);
                foreach (var uid in uids.Take(100))
                {
                    var message = client.Inbox.GetMessage(uid);
                    Console.WriteLine(message.Subject);
                }

                client.Disconnect(true);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start...");
            ExamTasks.PerformAllTasks();
            Console.WriteLine("end");
        }
    }
}
