using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendFileToServer();
        }

        async Task SendFileToServer()
        {
            await Task.Run(() =>
            {
                var filePath = "path_to_file"; // Укажите путь к файлу
                byte[] fileBytes = File.ReadAllBytes(filePath);
                var ip = Dns.GetHostEntry(tbHost.Text);
                var ad = ip.AddressList[0];
                var ep = new IPEndPoint(ad, int.Parse(tbPort.Text));
                Socket sender = new Socket(ad.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                sender.Connect(ep);

                // Отправка длины файла
                byte[] fileLengthBytes = BitConverter.GetBytes(fileBytes.Length);
                sender.Send(fileLengthBytes);

                // Отправка файла
                sender.Send(fileBytes);

                // Прием архивированного файла
                byte[] buffer = new byte[1024];
                int bytesRead = sender.Receive(buffer);
                using (var fs = new FileStream("received_file.zip", FileMode.Create))
                {
                    fs.Write(buffer, 0, bytesRead);
                }

                listBox1.Items.Add("Файл получен и сохранен как received_file.zip");

                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            });
        }
<<<<<<< HEAD

        async Task SendToServer2()
        {
            await Task.Run(() =>
            {
                TcpClient client = null;
                try
                {
                    string message = tbHost.Text;
                    client = new TcpClient("127.0.0.1", int.Parse(tbPort.Text) + 1);
                    NetworkStream stream = client.GetStream();

                    // отправляем сообщение
                    StreamWriter writer = new StreamWriter(stream);
                    writer.WriteLine(message);
                    writer.Flush();
                    
                    // BinaryReader reader = new BinaryReader(new BufferedStream(stream));
                    StreamReader reader = new StreamReader(stream);
                    message = reader.ReadLine();
                    listBox1.Items.Add("Получен ответ: " + message);

                    reader.Close();
                    writer.Close();
                    stream.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (client != null)
                        client.Close();
                }

            });

        }


        private void button2_Click(object sender, EventArgs e)
        {
            SendToServer2();
        }
=======
>>>>>>> c26e7e8 (fix)
    }
}
