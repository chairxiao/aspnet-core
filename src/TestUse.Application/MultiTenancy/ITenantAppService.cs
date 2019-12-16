using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TestUse.MultiTenancy.Dto;

namespace TestUse.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

