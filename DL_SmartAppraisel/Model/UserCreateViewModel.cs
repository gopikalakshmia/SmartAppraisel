using DL_SmartAppraisel.Model; // SelectListItem
using System.ComponentModel.DataAnnotations;

namespace SmartAppraisel.ViewModels
{
    public class UserCreateViewModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "User Name")]
        public string UserId { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Designation")]
        public int DesgnId { get; set; }

        [Required]
        [Display(Name = "Project")]
        public int RoleId { get; set; }

        public List<RoleDetail> Roles { get; set; }
        public List<DesignationDetail> Designations { get; set; }
    }
}
