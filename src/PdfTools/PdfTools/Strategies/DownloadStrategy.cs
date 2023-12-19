using System.IO;
using System.Net.Http;

namespace PdfTools.Strategies
{
    public class DownloadStrategy : IStrategy
    {
        public void Start(string[] args)
        {
            var client = new HttpClient();
            var response = client.GetAsync(args[1]).Result;
            var pdf = response.Content.ReadAsByteArrayAsync().Result;

            File.WriteAllBytes(args[2], pdf);
        }
    }
}