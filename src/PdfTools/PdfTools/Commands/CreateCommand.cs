using System;
using System.IO;
using System.Linq;
using FSharp.Markdown;
using FSharp.Markdown.Pdf;

namespace PdfTools.Commands
{
    class CreateCommand : ICommand
    {
        public bool CanExecute(string[] context)
        {
            if (context.Length != 2) return false;
            if (string.Compare(context[0], "create", StringComparison.InvariantCultureIgnoreCase) != 0)
                return false;

            return true;
        }
        public void Execute(string[] context)
        {
            if (!CanExecute(context)) throw new ArgumentException("Command cannot be executed");

            DoCreate(context.Skip(1).ToArray());
        }

        private static void DoCreate(string[] args)
        {
            //_logger.Trace("Creating pdf for a markdown file");

            var inFile = args[0];
            var outFile = args[1];

            var mdText = File.ReadAllText(inFile);
            var mdDoc = Markdown.Parse(mdText);

            MarkdownPdf.Write(mdDoc, outFile);
        }

    }
}