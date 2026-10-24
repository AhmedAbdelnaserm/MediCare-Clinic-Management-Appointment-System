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
        public int CreatorUserId { get; set; }
        public int LastModifierUserId { get; set; }
    }
}
