using System;

namespace Pdf.Contract
{
    public class NativeConsoleLogger : IPdfToolLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}