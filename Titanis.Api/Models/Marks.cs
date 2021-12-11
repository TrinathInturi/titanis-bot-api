using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Titanis.Api.Models
{
    public class Marks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecordId { get; set; }
        public string RollNumber { get; set; }
        [ForeignKey("RollNumber")] public Student Student { get; set; }
        public string ExamCode { get; set; }
        [ForeignKey("ExamCode")] public Exam Exam { get; set; }
        public string SubjectCode { get; set; }
        [ForeignKey("SubjectCode")] public Subject Subject { get; set; }
        public int MaxMarks { get; set; }
        public int ObtainedMarks { get; set; }
    }
}