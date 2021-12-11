using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Titanis.Api.Models
{
    [Table("Semester")]
    public class Semester
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string SemesterName { get; set; }
        [Key]
        [Required]
        public int SemesterCode { get; set; }
    }
}