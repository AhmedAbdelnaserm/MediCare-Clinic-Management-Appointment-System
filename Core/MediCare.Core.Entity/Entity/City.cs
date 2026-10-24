using MediCare.Core.Entity.Base;

namespace MediCare.Core.Entity.Entity
{
    public class City : BaseMultiLanguageEntity
    {
        public int CityId { get; set; }
        public ICollection<Area> Areas { get; set; }
    }
}
