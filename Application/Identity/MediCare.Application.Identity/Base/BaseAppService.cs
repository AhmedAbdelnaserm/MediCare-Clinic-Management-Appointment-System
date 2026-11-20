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
        public BaseAppService(ILocalizationService localization, ILogger logger, IUnitOfWork unitOfWork, ICurrentUserService currentUser)
        {
            Localization = localization;
            Logger = logger;
            UnitOfWork = unitOfWork;
            CurrentUser = currentUser;
        }
    }
}
