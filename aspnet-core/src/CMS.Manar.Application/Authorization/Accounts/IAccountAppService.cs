using System.Threading.Tasks;
using Abp.Application.Services;
using CMS.Manar.Authorization.Accounts.Dto;

namespace CMS.Manar.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
