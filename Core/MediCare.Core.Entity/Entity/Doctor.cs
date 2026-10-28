using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MediCare.Common.Enum;
namespace MediCare.Core.Entity.Entity
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int SpecializationId { get; set; }
        public virtual Specialization Specialization { get; set; }
        [Required]
        [MaxLength(200)]
        public string Education { get; set; } = string.Empty;
        public int GraduationYear { get; set; }
        public DateTime DateOfBirth { get; set; }
        [MaxLength(500)]
        public string? ProfileImageUrl { get; set; }
        [Range(0, 5)]
        public decimal Rating { get; set; } = 0;
        public int TotalReviews { get; set; } = 0;
        public decimal ConsultationFee { get; set; }

        public int ConsultationDurationMinutes { get; set; }

        public ApprovalStatusEnum ApprovalStatus { get; set; }
    }


}