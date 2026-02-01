using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DL_SmartAppraisel.Model
{
    [Table("AssessmentResponses")]
    public class AssessmentResponse
    {
        [Key]
        public int ResponseID { get; set; }

        [Required]
        public int AssessmentID { get; set; }
        

        [Required]
        public string Question { get; set; }

        [Required]
        [StringLength(50)]
        public string Answer1 { get; set; }   // A, B, C, D

        [Required]
        [StringLength(50)]
        public string Answer2 { get; set; } 
        [Required]
        [StringLength(50)]
        public string Answer3 { get; set; } 
        [Required]
        [StringLength(50)]
        public string Answer4 { get; set; } 
        [Required]
        public int CompetencyIDForQ1 { get; set; }
        [Required]
        public int CompetencyIDForQ2 { get; set; }
        [Required]
        public int CompetencyIDForQ3 { get; set; }
        [Required]
        public int CompetencyIDForQ4 { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        


    }
}
