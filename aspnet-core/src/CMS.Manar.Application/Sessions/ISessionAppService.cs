using System.Threading.Tasks;
using Abp.Application.Services;
using CMS.Manar.Sessions.Dto;

namespace CMS.Manar.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
