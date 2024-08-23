
using HtmlAgilityPack;
using System.Net;

namespace myHttpClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
             findCurrency();
        }   

        static async Task<string> firstMethod()
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.GetStringAsync("https://www.google.com/");
                return result;
            }
        }  

        static async Task secondMethod()
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.GetAsync("https://www.google.com/");

                using (StreamReader sr = new StreamReader(await result.Content.ReadAsStreamAsync()))
                {
                    string res = sr.ReadToEnd();
                    Console.WriteLine(res);
                }

             

            }
        }
        static async Task<string>  getMoneyMethod()
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.GetStringAsync("https://www.nationalbank.kz/ru/exchangerates/ezhednevnye-oficialnye-rynochnye-kursy-valyut");
                return result;
            }
        }
        static async Task findDate()
        {
            var url = "https://www.nationalbank.kz/ru/exchangerates/ezhednevnye-oficialnye-rynochnye-kursy-valyut";
            var web = new HtmlWeb();
            var doc = web.Load(url);

            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//h3[@class='title-section']"))
            {
                string[] res = link.InnerText.Split(':');
                Console.WriteLine(res[1]);
            }
            //var parentNode = doc.DocumentNode.SelectSingleNode("//div[@id='parent']");
        }
        static async Task findCurrency()
        {
            var url = "https://www.nationalbank.kz/ru/exchangerates/ezhednevnye-oficialnye-rynochnye-kursy-valyut";
            var web = new HtmlWeb();
            var doc = web.Load(url);

            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//div[@class='table-responsive mb-4']"))
            {
                string[] res = link.InnerText.Split("1 ");
                string[] vals = { "USD", "RUB", "GBP", "EUR" };
                using (StreamWriter outputFile = new StreamWriter(Path.Combine("WriteLines.txt")))
                {
                    foreach (string line in res)
                    {
                        for (int i = 0; i < vals.Length; i++)
                        {
                            if (line.Contains(vals[i]))
                            {
                                outputFile.WriteLine(line);
                            }
                        }
                        
                    }
                        
                }
            }
            //var parentNode = doc.DocumentNode.SelectSingleNode("//div[@id='parent']");
        }
        static void methodDownload()
        {
            using (var client = new WebClient())
            {
                var result = client.DownloadData("https://2ch.hk/b/src/307286908/17207678900210.mp4");
                File.WriteAllBytes("C:\\temp\\cat.mp4", result);
            }
        }
    }
}