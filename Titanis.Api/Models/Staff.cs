using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Titanis.Api.Models
{
    [Table("Staff")]
    public class Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")] public Department Department { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")] public Role Role { get; set; }
    }
}