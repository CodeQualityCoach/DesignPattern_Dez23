namespace PdfTools.Strategies
{
    public class ArchiveStrategy:IStrategy
    {
        public void Start(string[] args)
        {
            var archiver = new PdfArchiver();
            archiver.Archive(args[1]);
            archiver.SaveAs(args[2]);
        }
    }
}