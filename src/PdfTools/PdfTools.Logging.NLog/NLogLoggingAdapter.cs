using NLog;
using Pdf.Contract;

namespace PdfTools.Logging.NLog
{
    public class NLogLoggingAdapter : IPdfToolLogger
    {
        private readonly ILogger _logger;

        public NLogLoggingAdapter(ILogger logger)
        {
            _logger = logger;
        }

        public void Log(string message)
        {
            // Übersetzung von Log (PdfTools) nach Info (NLog)
            _logger.Info(message);
        }
    }
}