using System;

namespace PdfTools.Commands
{
    public class AddCodeCommand : ICommand
    {
        public bool CanExecute(string[] context)
        {
            if (context.Length < 3) return false;
            if (string.Compare(context[0], "addcode", StringComparison.InvariantCultureIgnoreCase) != 0)
                return false;

            return true;
        }

        public void Execute(string[] context)
        {
            if (!CanExecute(context)) throw new ArgumentException("Command cannot be executed");

            var enhancer = new PdfCodeEnhancer(context[1]);

            enhancer.AddTextAsCode(context[2]);

            if (context.Length == 4)
                enhancer.SaveAs(context[3]);
            else
                enhancer.SaveAs(context[1]);
        }
    }
}