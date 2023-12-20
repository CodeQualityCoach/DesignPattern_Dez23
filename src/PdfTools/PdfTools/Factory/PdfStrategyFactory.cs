using System.Collections.Generic;
using PdfTools.Strategies;

namespace PdfTools.Factory
{
    class PdfStrategyFactory : IStrategyFactory
    {
        private readonly Dictionary<string, IStrategy> _strategies;

        public PdfStrategyFactory()
        {
            _strategies = new Dictionary<string, IStrategy>()
            {
                { "create", new CreateStrategy() },
                { "addcode", new AddCodeStrategy() },
                { "download", new DownloadStrategy() },
                { "archive", new ArchiveStrategy() },
                { "combine", new CombineStrategy() },
            };
        }

        public IStrategy GetStrategy(string action)
        {
            if (_strategies.ContainsKey(action))
                return _strategies[action];

            return new EmptyStrategy();
        }

        public IEnumerable<IStrategy> GetAllStrategies()
        {
            return _strategies.Values;
        }

        public bool HasStrategyFor(string action)
        {
            return _strategies.ContainsKey(action);
        }
    }
}