using CommonLib;

namespace DataAccess.Helpers
{
    internal sealed class LoggingManagement : ILoggingManagement
    {
        public string RequestId => _requestId;

        private string _requestId { get; set; }

        public LoggingManagement()
        {
            _requestId = Utils.GenGuidStringN();
        }

        public void ReCreateRequestId()
        {
            _requestId = Utils.GenGuidStringN();
        }
    }
}
