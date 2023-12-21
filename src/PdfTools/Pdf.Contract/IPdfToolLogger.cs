using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pdf.Contract
{
    public interface IPdfToolLogger 
    {
        void Log(string message);
    }

    public interface IPdfToolLoggerFactory
    {
        IPdfToolLogger Create();
    }

    public class NoLoggingPdfToolLoggerFactory : IPdfToolLoggerFactory
    {
        public IPdfToolLogger Create()
        {
            return new EmptyPdfToolLogger();
        }
    }
}
