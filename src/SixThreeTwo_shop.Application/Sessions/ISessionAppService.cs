using Abp.Application.Services;
using SixThreeTwo_shop.Sessions.Dto;
using System.Threading.Tasks;

namespace SixThreeTwo_shop.Sessions;

public interface ISessionAppService : IApplicationService
{
    Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
}
