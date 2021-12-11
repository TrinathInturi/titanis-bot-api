using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace Titanis.Api.Models
{
    [Table("AcademicPerformance")]
    public class AcademicPerformance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string RollNumber { get; set; }
        [ForeignKey("RollNumber")] public Student Student { get; set; }
        public int CurrentSemester { get; set; }
        public float AttendancePercentage { get; set; }
    }
}