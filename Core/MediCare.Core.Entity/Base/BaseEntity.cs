using MediCare.Common.Enum;
using System.ComponentModel.DataAnnotations;

namespace MediCare.Core.Entity.Base
{
    public class BaseEntity
    {
        internal BaseEntity()
        {
            DeleteStatusId = (int)DeleteStatusEnum.NotDeleted;
        }
        [Required]
        public int DeleteStatusId { get; set; }
        [Required]
        public DateTime CreationTime { get; set; }
        public DateTime LastModificationTime { get; set; }

        // IdentityUser default ID is string.
        public string? CreatorUserId { get; set; }
        public string? LastModifierUserId { get; set; }
    }
}
