namespace MediCare.Core.Entity.Base
{
    public class BaseMultiLanguageEntity : BaseEntity
    {
        public string EnName { get; set; } = string.Empty;
        public string ArName { get; set; } = string.Empty;
        public string EnDescription { get; set; } = string.Empty;
        public string ArDescription { get; set; } = string.Empty;
    }
}
