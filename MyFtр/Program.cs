using FluentFTP;
using Renci.SshNet;
//using System.Net.FtpClient;
namespace MyFtр
{
    internal class Program
    {
        static string url = "ftp://ftp.dlptest.com";
        static string user = "dlpuser";
        static string password = "rNrKYTX9g7z3RgJRmxWuGHbeu";

        static void Ftp_test()
        {
            FtpClient ftp = new FtpClient();
            ftp.Host = url;
            ftp.Credentials = new System.Net.NetworkCredential(user, password);
            ftp.Connect();
            int i = 0;
            while (true)
            {
                i++;
                var status = ftp.UploadFile("C:\\Users\\БахытжановА\\myNET\\MyFtр\\amirwashere.txt", $"/07/amirwashere{i}.txt");

            }


            //var downStatus = ftp.DownloadFile("C:\\Users\\БахытжановА\\myNET\\MyFtр\\Tima.txt", "/07/19/Tima.txt");
            //ftp.DeleteFile("/07/amirwashere.txt");
            var getstatus = ftp.GetListing("/07/");
            //ftp.Rename("/07/amirwashere.txt", "amireditedhere");
            //ftp.UploadDirectory("C:\\Users\\БахытжановА\\myNET\\MyFtр\\4dalulz", "/07/forlulz");
            foreach (var item in getstatus)
            {
                Console.WriteLine(item);
            }
   
            //Console.WriteLine(status);
        }
        public  static void SFTP()
        {
            string username = "demo";
            string password = "password";
            string host = "test.rebex.net";
            int port = 22;
            string LocalDestinationFilename = "amirwashere";
            using (var sftp = new SftpClient(host,port,username,password))
            {
                sftp.Connect();
                var files = sftp.ListDirectory("//");
                foreach (var item in files)
                {
                    Console.WriteLine(item.Name);
                }
        
                using (Stream fileStream = File.Create(@"C:\Users\БахытжановА\myNET\MyFtр\readme.txt"))
                {
                    sftp.DownloadFile("/readme.txt", fileStream);
                    //sftp.UploadFile(fileStream, "//");
                    sftp.Delete("/readme.txt");
                }
                //using (Stream fileStream = File.OpenRead(@"C:\Users\БахытжановА\myNET\MyFtр\readme.txt"))
                //{
                   
                //}
      
                sftp.Disconnect();
            }
        }

        static void Main(string[] args)
        {
            //Ftp_test();
            
            SFTP();
        }
    
    }
}