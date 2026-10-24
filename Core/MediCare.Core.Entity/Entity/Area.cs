using MediCare.Core.Entity.Base;

namespace MediCare.Core.Entity.Entity
{
    public class Area : BaseMultiLanguageEntity
    {
        public int AreaId { get; set; }
        public int CityId { get; set; }
    }
}
