﻿using System;
using System.IO;
using System.Linq;
using FSharp.Markdown;
using FSharp.Markdown.Pdf;

namespace PdfTools.Strategies
{
    class CreatePdfStrategy : IPdfStrategy
    {
        public void Start(string[] args)
        {
            DoCreate(args.Skip(1).ToArray());
        }

        private static void DoCreate(string[] args)
        {
            if (args.Length != 2)
                throw new ArgumentException("at least in and out parameter is required");

            //_logger.Trace("Creating pdf for a markdown file");

            var inFile = args[0];
            var outFile = args[1];

            var mdText = File.ReadAllText(inFile);
            var mdDoc = Markdown.Parse(mdText);

            MarkdownPdf.Write(mdDoc, outFile);
        }

    }
}