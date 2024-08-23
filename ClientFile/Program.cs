namespace ClientFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
        private void SendFile(String FileName, String IPAddress, int Port)
        {
            System.Net.Sockets.TcpClient TcpClient = new System.Net.Sockets.TcpClient(IPAddress, Port);
            System.Net.Sockets.NetworkStream NetworkStream = TcpClient.GetStream();
            System.IO.Stream FileStream = System.IO.File.OpenRead(FileName);
            byte[] FileBuffer = new byte[FileStream.Length];

            FileStream.Read(FileBuffer, 0, (int)FileStream.Length);
            NetworkStream.Write(FileBuffer, 0, FileBuffer.GetLength(0));
            NetworkStream.Close();
        }
    }
}