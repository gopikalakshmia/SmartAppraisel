using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DL_SmartAppraisel.Model
{
    [Table("UserDetails")]
    public class UserDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Unicode(false)]
        [StringLength(50)]
        public string UserId { get; set; }
        [Required]
        [Unicode(false)]
        [StringLength(50)]
        [MaxLength(50),MinLength(8)]
        public string Password { get; set; }
        [Required]
        public int DesgnId { get; set; }
        [Required]
        public int RoleId { get; set; }

        [Required]
        [Unicode(false)]
        [StringLength(50)]
        [MaxLength(50), MinLength(8)]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime? LastPasswordDate { get; set; }
    }
}