using MediCare.Application.BackEnd.Localization;
using MediCare.Common.Interface;
using MediCare.Core.IRepository.IUnitOfWork;
using MediCare.IApplication.BackEnd.Base;
using Microsoft.Extensions.Logging;

namespace MediCare.Application.BackEnd.Base
{
    public class BaseAppService : IBaseAppService
    {
        protected readonly ICurrentUserService CurrentUser;
        protected IUnitOfWork UnitOfWork { get; }
        protected ILogger Logger { get; }
        protected ILocalizationService Localization { get; set; }

        public BaseAppService(
            ILocalizationService localization,
            ILogger logger,
            IUnitOfWork unitOfWork,
            ICurrentUserService currentUser)
        {
            Localization = localization;
            Logger = logger;
            UnitOfWork = unitOfWork;
            CurrentUser = currentUser;
        }

    }
}
