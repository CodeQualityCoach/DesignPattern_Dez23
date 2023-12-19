using System;
using System.IO;
using System.Net.Http;

namespace PdfTools.Commands
{
    public class DownloadCommand : ICommand
    {
        public bool CanExecute(string[] context)
        {
            if (context.Length != 3) return false;
            if (string.Compare(context[0], "download", StringComparison.InvariantCultureIgnoreCase) != 0)
                return false;

            return true;
        }
        public void Execute(string[] context)
        {
            if (!CanExecute(context)) throw new ArgumentException("Command cannot be executed");

            var client = new HttpClient();
            var response = client.GetAsync(context[1]).Result;
            var pdf = response.Content.ReadAsByteArrayAsync().Result;

            File.WriteAllBytes(context[2], pdf);
        }
    }
}