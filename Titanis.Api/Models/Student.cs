using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace Titanis.Api.Models
{
    [Table("Student")]
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key]
        [Required]
        public string RollNumber { get; set; }
        [Required]
        public string StudentName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        public int? CourseId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public int? ParentPhoneNumber { get; set; }
        public string? GuardianName { get; set; }
        public int? GuardianPhoneNumber { get; set; }
        public int? AdmissionYear { get; set; }
        public int? GraduationYear { get; set; }
        [Required]
        public string Batch { get; set; }
    }
}