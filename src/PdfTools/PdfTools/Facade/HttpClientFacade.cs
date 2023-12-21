using System.Net.Http;
using Pdf.Contract;

namespace PdfTools.Facade
{
    public class HttpClientFacade : IHttpClient
    {
        private readonly HttpClient _client;

        public HttpClientFacade()
        {
            _client = new HttpClient();
        }

        public byte[] DownloadFile(string url)
        {
            var response = _client.GetAsync(url).Result;
            var pdf = response.Content.ReadAsByteArrayAsync().Result;
            return pdf;
        }
    }
}