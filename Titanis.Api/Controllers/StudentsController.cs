using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Titanis.Api.Context;
using Titanis.Api.Models;

namespace Titanis.Api.Controllers
{
    [RoutePrefix("api/students")]
    public class StudentsController : BaseController
    {
        
        [HttpGet]
        [Route("all")]
        public IHttpActionResult Get()
        {
            return Ok(ApiDbContext.Student.ToList());
        }

        [HttpGet]
        [Route("byId/{rollNumber}")]
        public IHttpActionResult Get(string rollNumber)
        {
            rollNumber = rollNumber.ToUpper();
            try
            {
                return Ok(ApiDbContext.Student.First(e => e.RollNumber == rollNumber));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult Post([FromBody] Student student)
        {
            try
            {
                student.RollNumber = student.RollNumber.ToLower();
                ApiDbContext.Student.Add(student);
                ApiDbContext.SaveChanges();
                return Ok("New Student Added");
            }
            catch (Exception e)
            {
                return BadRequest("Please check your input data");
            }
        }

        [HttpPut]
        [Route("update/{rollNumber}")]
        public IHttpActionResult Put(string rollNumber, [FromBody] Student student)
        {
            try
            {
                Student currentStudent;
                if ((currentStudent = ApiDbContext.Student.First(e => e.RollNumber == rollNumber)) != null)
                {
                    currentStudent.AdmissionYear = student.AdmissionYear;
                    currentStudent.Batch = student.Batch;
                    currentStudent.Course = student.Course;
                    currentStudent.DOB = student.DOB;
                    currentStudent.StudentName = student.StudentName;
                    currentStudent.Email = student.Email;
                    currentStudent.FatherName = student.FatherName;
                    currentStudent.FirstName = student.FatherName;
                    currentStudent.LastName = student.LastName;
                    currentStudent.GraduationYear = student.GraduationYear;
                    ApiDbContext.SaveChanges();
                }
                else
                {
                    return NotFound();
                }

                return Ok($"{student.StudentName} details Updated");
            }
            catch (Exception)
            {
                return BadRequest("Please enter valid input data");
            }
        }

        [HttpDelete]
        [Route("delete/{rollNumber}")]
        public IHttpActionResult Delete(string rollNumber)
        {
            try
            {
                var student = ApiDbContext.Student.First(e => e.RollNumber == rollNumber);
                ApiDbContext.Student.Remove(student);
                ApiDbContext.SaveChanges();
                return Ok($"{student.StudentName} deleted!");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
