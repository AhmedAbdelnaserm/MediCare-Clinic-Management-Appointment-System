using AutoMapper;
using MediCare.Application.Identity.Dto.Authentication;
using MediCare.Core.Entity.Entity;

namespace MediCare.Application.Identity.Mapping
{
    public class ApplicationUserMapping : Profile
    {
        public ApplicationUserMapping()
        {
            CreateMap<RegisterDto, ApplicationUser>();
            CreateMap<ApplicationUser, AuthModel>();
        }
    }
}
