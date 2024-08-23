using System.IO.Compression;
using FluentFTP;
using Renci.SshNet;
using System.Net;



namespace Exam
{
    internal class Program
    {
        static string url = "ftp://ftp.dlptest.com";
        static string user = "dlpuser";
        static string password = "rNrKYTX9g7z3RgJRmxWuGHbeu";

        static void Main(string[] args)
        {
            //zipTxtsToFTP();
            downloadPdfTask();
        }
        public static void zipTxtsToFTP()
        {
    
            FtpClient ftp = new FtpClient();
            ftp.Host = url;
            ftp.Credentials = new System.Net.NetworkCredential(user, password);
            ftp.Connect();
            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {

                    archive.CreateEntryFromFile(@"C:\Users\БахытжановА\myNET\Exam\sample1.txt", "sample1.txt");
                    archive.CreateEntryFromFile(@"C:\Users\БахытжановА\myNET\Exam\sample2.txt", "sample2.txt");
                    archive.CreateEntryFromFile(@"C:\Users\БахытжановА\myNET\Exam\sample3.txt", "sample3.txt");
                    archive.CreateEntryFromFile(@"C:\Users\БахытжановА\myNET\Exam\sample4.txt", "sample4.txt");
                    //using (var entryStream = demoFile.Open())
                    //using (var streamWriter = new StreamWriter(entryStream))
                    //{
                    //    streamWriter.Write("Bar!");
                    //}
                }
            
                    using (var fileStream = new FileStream(@"C:\Users\БахытжановА\myNET\Exam\exam.zip", FileMode.Create))
                    {
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        memoryStream.CopyTo(fileStream);
                    }
                try
                {
                    var status = ftp.UploadFile(@"C:\Users\БахытжановА\myNET\Exam\exam.zip", $"/07/exam.zip");

                }
                catch (Exception e)
                {
                    Console.WriteLine("there is an FTP connection error");
                    Console.WriteLine(e.InnerException);
                }


            }
        }
        public static void downloadPdfTask()
        {
            //using (var client = new WebClient())
            //{
            //    client.DownloadFile("https://beeline.kz/binaries/content/assets/public_offer/public_offer_ru.pdf", "exam.pdf");
            //}
            FtpClient ftp = new FtpClient();
            ftp.Host = url;
            ftp.Credentials = new System.Net.NetworkCredential(user, password);
    
            ftp.Connect();

            try
            {
                var status = ftp.UploadFile(@"https://beeline.kz/binaries/content/assets/public_offer/public_offer_ru.pdf", $"/exam.zip");
                Console.WriteLine(status);
            }
            catch (Exception e )
            {
                Console.WriteLine(e.InnerException);
            }
            
        }
     
    }

}