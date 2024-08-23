namespace ServerFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
        private void ReceiveFile(String FilePath, int Port)
        {
            System.Threading.Thread WorkerThread = new System.Threading.Thread(() =>
            {
                System.Net.Sockets.TcpListener TcpListener = new System.Net.Sockets.TcpListener(System.Net.IPAddress.Any, Port);
                TcpListener.Start();
                System.Net.Sockets.Socket HandlerSocket = TcpListener.AcceptSocket();
                System.Net.Sockets.NetworkStream NetworkStream = new System.Net.Sockets.NetworkStream(HandlerSocket);
                int BlockSize = 1024;
                int DataRead = 0;
                Byte[] DataByte = new Byte[BlockSize];
                lock (this)
                {
                    System.IO.Stream FileStream = System.IO.File.OpenWrite(FilePath);

                    while (true)
                    {
                        DataRead = NetworkStream.Read(DataByte, 0, BlockSize);
                        FileStream.Write(DataByte, 0, DataRead);
                        if (DataRead == 0)
                        {
                            break;
                        }
                    }
                    FileStream.Close();
                }
            });
            WorkerThread.Start();
        }
    }
}