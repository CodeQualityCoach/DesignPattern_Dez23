using PdfTools.ToRefactor;

namespace PdfTools.Strategies
{
    public class ArchivePdfStrategy : IPdfStrategy
    {
        public void Start(string[] args)
        {
            var archiver = new PdfArchiver();
            archiver.Archive(args[1]);
            archiver.SaveAs(args[2]);
        }
    }
}