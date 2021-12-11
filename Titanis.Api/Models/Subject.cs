using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Titanis.Api.Models
{
    [Table("Subject")]
    public class Subject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        [Required] public string SubjectName { get; set; }
        [Key] [Required] public string SubjectCode { get; set; }
        public int SemesterCode { get; set; }
        [ForeignKey("SemesterCode")] public Semester Semester { get; set; }
    }
}