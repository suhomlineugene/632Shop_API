using Abp.Application.Services;
using SixThreeTwo_shop.Authorization.Accounts.Dto;
using System.Threading.Tasks;

namespace SixThreeTwo_shop.Authorization.Accounts;

public interface IAccountAppService : IApplicationService
{
    Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

    Task<RegisterOutput> Register(RegisterInput input);
}
