using System.Threading.Tasks;

namespace Business.Core
{
    public interface INotifyClient
    {
        Task<bool> Send(NotifyMessage message);
    }
}
