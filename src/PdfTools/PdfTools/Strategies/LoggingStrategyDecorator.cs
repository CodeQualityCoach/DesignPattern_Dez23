using System;

namespace PdfTools.Strategies
{
    class LoggingStrategyDecorator : IStrategy
    {
        private readonly IStrategy _strategy;

        public LoggingStrategyDecorator(IStrategy strategy)
        {
            _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
        }
        public void Start(string[] args)
        {
            Console.WriteLine(args);
            _strategy.Start(args);
        }
    }
}