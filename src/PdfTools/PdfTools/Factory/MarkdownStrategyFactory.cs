using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute.Exceptions;
using PdfTools.Strategies;

namespace PdfTools.Factory
{
    class MarkdownStrategyFactory : IStrategyFactory
    {
        public IStrategy GetStrategy(string action)
        {
            return new EmptyStrategy();
        }

        public IEnumerable<IStrategy> GetAllStrategies()
        {
            return Enumerable.Empty<IStrategy>();
        }

        public bool HasStrategyFor(string action)
        {
            return false;
        }
    }
}
