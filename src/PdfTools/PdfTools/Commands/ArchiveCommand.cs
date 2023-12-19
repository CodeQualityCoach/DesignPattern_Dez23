using System;

namespace PdfTools.Commands
{
    /// <summary>
    /// Download & Save PDF
    /// </summary>
    public class ArchiveCommand:ICommand
    {
        public bool CanExecute(string[] context)
        {
            if (context.Length < 3) return false;
            if (string.Compare(context[0], "archive", StringComparison.InvariantCultureIgnoreCase) != 0)
                return false;

            return true;
        }
        public void Execute(string[] context)
        {
            if (!CanExecute(context)) throw new ArgumentException("Command cannot be executed");

            var archiver = new PdfArchiver();
            archiver.Archive(context[1]);
            archiver.SaveAs(context[2]);
        }
    }
}