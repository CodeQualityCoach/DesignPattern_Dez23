using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfTools.Commands
{
    internal class SimpleCompositeCommand : ICommand
    {
        private readonly List<ICommand> _commands;

        public SimpleCompositeCommand()
        {
            _commands = new List<ICommand>() { new AddCodeCommand(), new ArchiveCommand(), new CombineCommand(), new CreateCommand(), new DownloadCommand() };

        }
        public bool CanExecute(string[] context)
        {
            return _commands.Any(x => x.CanExecute(context));
        }

        public void Execute(string[] context)
        {
            _commands
                .Where(x => x.CanExecute(context)) // filter for executable commands
                .ToList() // make a list because of for each
                .ForEach(x => x.Execute(context)); // and now we can execute the filtered commands
        }
    }
}
