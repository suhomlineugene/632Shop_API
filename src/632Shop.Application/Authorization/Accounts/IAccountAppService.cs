using Abp.Application.Services;
using 632Shop.Authorization.Accounts.Dto;
using System.Threading.Tasks;

namespace 632Shop.Authorization.Accounts;

public interface IAccountAppService : IApplicationService
{
    Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

    Task<RegisterOutput> Register(RegisterInput input);
}
