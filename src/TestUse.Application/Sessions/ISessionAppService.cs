using System.Threading.Tasks;
using Abp.Application.Services;
using TestUse.Sessions.Dto;

namespace TestUse.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
