using AutoMapper;
using Microsoft.Extensions.Logging;
using MediCare.Application.Identity.Localization;
using MediCare.Core.IRepository.IUnitOfWork;
using MediCare.IApplication.Identity.Base;

namespace MediCare.Application.Identity.Base
{
    public class BaseAppService : IBaseAppService
    {
        protected IUnitOfWork UnitOfWork { get; }
        protected ILogger Logger { get; }
        protected ILocalizationService Localization { get; set; }
        protected IMapper Mapper { get; set; }

        public BaseAppService(IMapper mapper, ILocalizationService localization, ILogger logger, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            Localization = localization;
            Logger = logger;
            UnitOfWork = unitOfWork;
        }

        //public int CurrentUserId
        //{
        //    get { return TokenInfo.GetTokenInformation().UserId; }
        //}
    }
}
