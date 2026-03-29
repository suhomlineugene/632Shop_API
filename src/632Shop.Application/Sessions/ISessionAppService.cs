using Abp.Application.Services;
using 632Shop.Sessions.Dto;
using System.Threading.Tasks;

namespace 632Shop.Sessions;

public interface ISessionAppService : IApplicationService
{
    Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
}
