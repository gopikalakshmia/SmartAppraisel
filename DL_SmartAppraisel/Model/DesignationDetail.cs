using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DL_SmartAppraisel.Model
{
    [Table("DesignationDetails")]
    public class DesignationDetail
    {
        public int Id { get; set; }
        public string DesignationName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
