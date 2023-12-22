using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using iTextSharp.text.pdf;
using PdfTools.Facade;
using QRCoder;
using Image = iTextSharp.text.Image;

namespace PdfTools.ToRefactor
{
    public class PdfArchiver
    {
        private readonly string _tempFile;
        private readonly HttpClientFacade _httpClient;
        private readonly ICodeGenerator _codeGenerator;

        public PdfArchiver(ICodeGenerator generator = null)
        {
            _tempFile = Path.GetTempFileName();
            _httpClient = new HttpClientFacade();
            _codeGenerator = generator ?? new QrCodeGenerator();
        }

        public void Archive(string url)
        {
            var tmpTempFile = Path.GetTempFileName();
            var pdf = _httpClient.DownloadFile(url);
            File.WriteAllBytes(tmpTempFile, pdf);

            using (Stream inputPdfStream = new FileStream(tmpTempFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (Stream inputImageStream = new MemoryStream())
            using (Stream outputPdfStream = new FileStream(_tempFile, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var code = _codeGenerator.CreateInitCode(url);
                code.Save(inputImageStream, ImageFormat.Jpeg);
                inputImageStream.Position = 0;

                var reader = new PdfReader(inputPdfStream);
                var stamper = new PdfStamper(reader, outputPdfStream);
                var pdfContentByte = stamper.GetOverContent(1);

                var image = Image.GetInstance(inputImageStream);
                image.SetAbsolutePosition(5, 5);
                pdfContentByte.AddImage(image);
                stamper.Close();
            }
        }

        public void SaveAs(string destFile)
        {
            File.Copy(_tempFile, destFile, true);
        }
    }

    public class QrCodeGenerator : ICodeGenerator
    {
        public Bitmap CreateInitCode(string text)
        {
            var qrCodeGenerator = new QRCodeGenerator();
            var qrCodeData = qrCodeGenerator.CreateQrCode(new PayloadGenerator.Url(text), QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);

            return qrCode.GetGraphic(2);
        }
    }

    public interface ICodeGenerator
    {
        Bitmap CreateInitCode(string text);
    }
}