using System.Threading.Tasks;
using Abp.Application.Services;
using TestUse.Authorization.Accounts.Dto;

namespace TestUse.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
