using System.Net;
using System.Text;

namespace myHttp
{
    internal class Program
    {
        static Thread threadListener;
        static void Main(string[] args)
        {
            threadListener = new Thread(new ParameterizedThreadStart(Start2));
            threadListener.Start("http://localhost:12345/");

        }

        public static void Start(object prefix)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(prefix.ToString());
            listener.Start();
            while (true)
            {

                Console.WriteLine("Прослушка работает..");
                HttpListenerContext context = listener.GetContext();

                HttpListenerRequest request = context.Request;
                if (request.RawUrl == "/favicon.ico")
                    continue;
                var qry = request.RawUrl.Split('/');
                string Segment = null;


                int a  = Int32.Parse(qry[1]);
                int b = Int32.Parse(qry[2]);
                int c = Int32.Parse(qry[3]);

                int[] vars = { a, b, c };

                foreach (var item in vars)
                {
                    Console.WriteLine("Получено.." + item);

                }
                HttpListenerResponse response = context.Response;
                string responseString = "<HTML><BODY> ";

                double discriminant = Math.Sqrt(Math.Pow(b, 2) - 4 * a * c);
                if (discriminant < 0)
                    responseString = "<HTML><BODY> no answer </BODY></HTML>";

                double[] answers = { ((b * -1) - discriminant) / 2 * a, ((b * -1) + discriminant) / 2 * a };

                foreach (var item in answers)
                {
                    responseString += "<UL>";
                    responseString += $"<LI>{item}</LI>";
                    responseString += "</UL></BODY></HTML>";

                }
          


                byte[] buffer = Encoding.UTF8.GetBytes(responseString);

                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);

                output.Close();
            }

            
            //listener.Stop();
        }
        public static void Start2(object prefix)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(prefix.ToString());
            listener.Start();
            while (true)
            {
                Console.WriteLine("Прослушка работает..");
                HttpListenerContext context = listener.GetContext();

                HttpListenerRequest request = context.Request;
                string text;string[] vals; string[] temp;

                using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
                {
                    text = reader.ReadToEnd();
                }
                temp = text.Split('&');
                foreach (var item in temp)
                {
                    vals = item.Split("=");
                }


                HttpListenerResponse response = context.Response;
                string responseString = "<HTML><BODY> HELLO " + text + " </BODY></HTML>";
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);

                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);

                output.Close();
            }
            //listener.Stop();
        }
    }
}