using AutoMapper;
using MediCare.Application.Identity.AppService;
using MediCare.Application.Identity.Localization;
using MediCare.Common.Interface;
using MediCare.Core.IRepository.IUnitOfWork;
using MediCare.IApplication.Identity.Base;
using Microsoft.Extensions.Logging;

namespace MediCare.Application.Identity.Base
{
    public class BaseAppService : IBaseAppService
    {
        protected ICurrentUserService CurrentUser;
        protected IUnitOfWork UnitOfWork { get; }
        protected ILogger Logger { get; }
        protected ILocalizationService Localization { get; set; }
        protected IMapper Mapper { get; set; }

        public BaseAppService(IMapper mapper, ILocalizationService localization, ILogger logger, IUnitOfWork unitOfWork, ICurrentUserService currentUser)
        {
            Mapper = mapper;
            Localization = localization;
            Logger = logger;
            UnitOfWork = unitOfWork;
            CurrentUser = currentUser;
        }
    }
}
