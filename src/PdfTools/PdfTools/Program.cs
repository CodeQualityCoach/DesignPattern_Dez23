using System;
using System.Linq;
using Pdf.Contract;
using PdfTools.Factory;

namespace PdfTools
{
    public class Program
    {
        private static readonly IPdfToolLoggerFactory Factory = new NoLoggingPdfToolLoggerFactory();


        public static void Main(string[] args)
        {

            var logger = Factory.Create();
            IConsole console = new ConsoleAdapter();

#if DEBUG
            // just a hack in case you hit play in VS
            if (args == null || args.Length == 0)
            {
                logger.Log(string.Join(", ", args ?? new string[] { }));
                var arg = console.ReadLine() ?? "help";
                args = arg.Split(',').Select(x => x.Trim()).ToArray();
            }
#endif

            foreach (var arg in args)
            {
                console.WriteLine(arg);
            }

            if (args.Length == 0)
                throw new ArgumentException("at least an action is required");

            var action = args[0];

            var factory = new PdfStrategyFactory();
            var op = factory.GetStrategy(action);
            op.Start(args);

#if DEBUG
            Console.ReadKey();
#endif
        }
    }
}
