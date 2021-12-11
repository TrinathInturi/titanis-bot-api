using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Titanis.Api.Models
{
    [Table("Course")]
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int StreamId { get; set; }
        [ForeignKey("StreamId")] public Stream Stream { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")] public Department Department { get; set; }
    }
}