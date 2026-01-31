using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DL_SmartAppraisel.Model
{
    [Table("CompetencyDetails")]
    public class CompetencyDetail
    {
        [Key]
        public int CompID { get; set; }

        [Required]
        [StringLength(100)]
        public string CompName { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
