using MediCare.Core.Entity.Base;

namespace MediCare.Core.Entity.Entity
{
    public class UploadedAttachment : BaseEntity
    {
        public int UploadedAttachmentId { get; set; }

        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; } = null!;

        public string FileName { get; set; } = string.Empty;

        public string FilePath { get; set; } = string.Empty;

        public string ContentType { get; set; } = string.Empty; //PDF OR JPEG ...

        public long FileSize { get; set; }

        public int AttachmentTypeId { get; set; }  
    }
}
