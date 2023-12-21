using System;
using System.Collections.Generic;
using PdfTools.Strategies;

namespace PdfTools.Factory
{
    class PdfStrategyFactory : IStrategyFactory
    {
        private readonly Dictionary<string, IPdfStrategy> _strategies;

        public PdfStrategyFactory()
        {
            _strategies = new Dictionary<string, IPdfStrategy>()
            {
                { "create", new CreatePdfStrategy() },
                { "addcode", new AddCodePdfStrategy() },
                { "download", new DownloadPdfStrategy() },
                { "archive", new ArchivePdfStrategy() },
                { "combine", new CombinePdfStrategy() },
            };
        }

        public IStrategy GetStrategy(string action)
        {
            if (_strategies.ContainsKey(action))
                return _strategies[action];

            return new EmptyPdfStrategy();
        }

        public IEnumerable<IStrategy> GetAllStrategies()
        {
            return _strategies.Values;
        }

        public bool HasStrategyFor(string action)
        {
            return _strategies.ContainsKey(action);
        }

        public void Remove(IStrategy strategy)
        {
            // Hier kann es Probleme geben, wenn die Strategie nicht von dieser Abstract Factory erzeugt wurde
            var strategyClone = (IPdfStrategy)strategy;
        }
    }
}