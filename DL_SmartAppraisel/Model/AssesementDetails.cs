using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DL_SmartAppraisel.Model
{
    [Table("AssessmentDetails")]
    public class AssessmentDetail
    {
        [Key]
        public int AssessmentID { get; set; }

        [Required]
        [StringLength(200)]
        public string AssessmentName { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Assessment Date")]
           [Required]
        public DateTime AssmtDate { get; set; }

        [StringLength(500)]
           [Required]
        public string Description { get; set; }

   [Required]
        public bool IsActive { get; set; }
          public bool IsReviewed { get; set; } 
           public string? Comment { get; set; } 
    }
}
