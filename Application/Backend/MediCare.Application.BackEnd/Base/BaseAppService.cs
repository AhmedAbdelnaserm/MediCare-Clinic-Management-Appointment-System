using AutoMapper;
using MediCare.Application.BackEnd.Localization;
using MediCare.Core.IRepository.IUnitOfWork;
using MediCare.IApplication.BackEnd.Base;
using Microsoft.Extensions.Logging;

namespace MediCare.Application.BackEnd.Base
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

    }
}
