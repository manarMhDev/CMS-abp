

using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using CMS.Manar.Dtos.Helpers;
using CMS.Manar.Dtos.Services;
using CMS.Manar.Entities.Galleries;
using CMS.Manar.Entities.Services;
using CMS.Manar.Entities.Tags;
using System.Threading.Tasks;

namespace CMS.Manar.Services.Services
{
    public class ServicesAppCrud : AsyncCrudAppService<Service, ServiceDto, int, PagedResultDto, CreateServiceDto, CreateServiceDto>, IServicesAppCrud
    {
        private readonly IRepository<Gallery> _galleryRepository;
        private readonly IRepository<ServiceTag> _serviceTagRepository;
        private readonly IRepository<Tag> _tagRepository;
        public ServicesAppCrud(IRepository<Service> ServiceRepository,
           IRepository<Gallery> galleryRepository,
              IRepository<ServiceTag> serviceTagRepository,
            IRepository<Tag> tagRepository)
            : base(ServiceRepository)
        {
            _galleryRepository = galleryRepository;
            _serviceTagRepository = serviceTagRepository;
            _tagRepository = tagRepository;
        }
        public override async Task<ServiceDto> CreateAsync(CreateServiceDto input)
        {
            var slugExist = await Repository
                    .FirstOrDefaultAsync(a => a.Slug == input.Slug);
            if (slugExist == null)
            {
                var service = ObjectMapper.Map<Service>(input);
                service.CreatorUserId = AbpSession.GetUserId();
                var objId = await Repository.InsertAndGetIdAsync(service);
                //if (input.Tags != null && input.Tags.Count != 0)
                //{
                //    foreach (var tag in input.Tags)
                //    {
                //        var t = await _tagRepository.FirstOrDefaultAsync(x => x.Slug == tag.Slug);
                //        if (t == null)
                //        {
                //            var id = await _tagRepository.InsertAndGetIdAsync(ObjectMapper.Map<Tag>(tag));
                //            var serviceTag = new ServiceTag()
                //            {
                //                ServiceId = objId,
                //                TagId = id
                //            };
                //            await _serviceTagRepository.InsertAsync(serviceTag);
                //        }
                //        else
                //        {
                //            var serviceTag = new ServiceTag()
                //            {
                //                ServiceId = objId,
                //                TagId = t.Id
                //            };
                //            await _serviceTagRepository.InsertAsync(serviceTag);
                //        }
                //    }
                //}
                return ObjectMapper.Map<ServiceDto>(service);
            }
            return null;
        }
    }
}
