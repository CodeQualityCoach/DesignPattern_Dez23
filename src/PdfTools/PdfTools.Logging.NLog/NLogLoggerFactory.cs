using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using Pdf.Contract;

namespace PdfTools.Logging.NLog
{
    public class NLogLoggerFactory : IPdfToolLoggerFactory
    {
        private readonly Logger _logger;

        public NLogLoggerFactory()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public IPdfToolLogger Create()
        {
            return new NLogLoggingAdapter(_logger);
        }
    }
}
