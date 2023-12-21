using System.IO;
using System.Net.Http;
using PdfTools.Facade;

namespace PdfTools.Strategies
{
    public class DownloadPdfStrategy : IPdfStrategy
    {
        private readonly HttpClientFacade _httpClient;

        public DownloadPdfStrategy()
        {
            _httpClient = new HttpClientFacade();
        }
        public void Start(string[] args)
        {
            var pdf = _httpClient.DownloadFile(args[1]);

            File.WriteAllBytes(args[2], pdf);
        }
    }
}