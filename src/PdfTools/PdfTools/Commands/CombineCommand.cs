using System;
using System.IO;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PdfTools.Commands
{
    public class CombineCommand : ICommand
    {
        public bool CanExecute(string[] context)
        {
            if (context.Length < 3) return false;
            if (string.Compare(context[0], "combine", StringComparison.InvariantCultureIgnoreCase) != 0)
                return false;

            return true;
        }

        public void Execute(string[] context)
        {
            if (!CanExecute(context)) throw new ArgumentException("Command cannot be executed");

            CombineMultiplePDF(context.Skip(2).ToArray(), context[1]);
        }

        private static void CombineMultiplePDF(string[] fileNames, string outFile)
        {
            //_logger.Trace($"Combile multiple pdf files {string.Join(",", fileNames)} into {outFile}");

            // step 1: creation of a document-object
            Document document = new Document();
            //create newFileStream object which will be disposed at the end
            using (FileStream newFileStream = new FileStream(outFile, FileMode.Create))
            {
                // step 2: we create a writer that listens to the document
                PdfCopy writer = new PdfCopy(document, newFileStream);

                // step 3: we open the document
                document.Open();

                foreach (string fileName in fileNames)
                {
                    // we create a reader for a certain document
                    PdfReader reader = new PdfReader(fileName);
                    reader.ConsolidateNamedDestinations();

                    // step 4: we add content
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        PdfImportedPage page = writer.GetImportedPage(reader, i);
                        writer.AddPage(page);
                    }

                    //PRAcroForm form = reader.AcroForm;
                    //if (form != null)
                    //{
                    //    writer.AddDocument(reader);
                    //}

                    reader.Close();
                }

                // step 5: we close the document and writer
                writer.Close();
                document.Close();
            }//disposes the newFileStream object
        }

    }
}