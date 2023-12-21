using System;

namespace Pdf.Contract
{
    public interface IConsole
    {
        void WriteLine(string message);
        string ReadLine();
    }

    public class ConsoleAdapter : IConsole
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}