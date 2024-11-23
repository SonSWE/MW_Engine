namespace DataAccess.Helpers
{
    public interface ILoggingManagement
    {
        string RequestId { get; }
        void ReCreateRequestId();
    }
}
