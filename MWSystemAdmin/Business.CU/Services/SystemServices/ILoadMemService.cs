using System.Threading.Tasks;

namespace Business.Core.Services.SystemServices
{
    public interface ILoadMemService
    {
        Task LoadAll(bool isInit);
    }
}
