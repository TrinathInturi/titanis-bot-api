using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Titanis.Api.Models;

namespace Titanis.Api.Context
{
    public class TitanisDbContext
    {
        public class ApiDbContext : DbContext
        {
            public ApiDbContext() : base("TitanisDb")
            {
            }

            public DbSet<Student> Student { get; set; }
            public DbSet<AcademicPerformance> AcademicPerformance { get; set; }
            public DbSet<Subject> Subjects { get; set; }
            public DbSet<Semester> Semesters { get; set; }
            public DbSet<Exam> Exams { get; set; }
            public DbSet<Marks> Marks { get; set; }
            public DbSet<Course> Courses { get; set; }
            public DbSet<Stream> Streams { get; set; }
            public DbSet<Department> Departments { get; set; }
            public DbSet<Role> Roles { get; set; }
            public DbSet<Staff> Staff { get; set; }
        }
    }
}