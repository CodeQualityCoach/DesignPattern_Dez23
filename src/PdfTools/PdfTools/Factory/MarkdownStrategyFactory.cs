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
        private readonly Dictionary<string, IMarkdownStrategy> _strategies;

        public MarkdownStrategyFactory()
        {
            _strategies = new Dictionary<string, IMarkdownStrategy>()
            {
                {"convert", new ConvertMarkdownStrategy()}
            };
        }
        public IStrategy GetStrategy(string action)
        {
            if (_strategies.TryGetValue(action, out var strategy))
                return strategy;

            return new EmptyPdfStrategy();
        }

        public IEnumerable<IStrategy> GetAllStrategies()
        {
            return Enumerable.Empty<IPdfStrategy>();
        }

        public bool HasStrategyFor(string action)
        {
            return false;
        }

        public void Remove(IStrategy strategy)
        {
            IMarkdownStrategy strategyClone = (IMarkdownStrategy)strategy;
        }
    }
}
