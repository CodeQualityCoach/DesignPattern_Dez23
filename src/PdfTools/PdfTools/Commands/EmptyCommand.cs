namespace PdfTools.Commands
{
    class EmptyCommand : ICommand
    {
        public bool CanExecute(string[] context)
        {
            return false;
        }

        public void Execute(string[] context)
        {
            // nix
        }
    }
}