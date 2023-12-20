using System.Collections.Generic;
using PdfTools.Strategies;

namespace PdfTools.Factory
{
    internal interface IStrategyFactory
    {
        IStrategy GetStrategy(string action);
        IEnumerable<IStrategy> GetAllStrategies();
        bool HasStrategyFor(string action);
    }
}