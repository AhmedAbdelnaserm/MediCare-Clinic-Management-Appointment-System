using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediCare.Core.Entity.Entity
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        [ForeignKey("Specialization")]
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

        public ApprovalStatus ApprovalStatus { get; set; }
    }

    public enum ApprovalStatus
    {
        Pending,
        Approved,
        Rejected
    }
}