using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Titanis.Api.Models;
using Titanis.Api.ViewModels;

namespace Titanis.Api.Controllers
{
    [RoutePrefix("api/courses")]
    public class CourseController : BaseController
    {
        private readonly List<Stream> _dbStreams;
        private readonly List<Department> _dbDepartments;
        private readonly List<Course> _dbCourses;

        CourseController()
        {
            _dbStreams = ApiDbContext.Streams.ToList();
            _dbDepartments = ApiDbContext.Departments.ToList();
            _dbCourses = ApiDbContext.Courses.ToList();
        }

        private CourseView ToCourseView(Course course)
        {
            var streamName = _dbStreams.FirstOrDefault(_ => _.StreamId == course.StreamId);
            var department = _dbDepartments.FirstOrDefault(_ => _.DepartmentId == course.DepartmentId);
            if (streamName != null || department != null)
            {
                return new CourseView()
                {
                    CourseId = course.Id,
                    StreamName = streamName?.StreamName,
                    DepartmentName = department?.DepartmentName,
                };
            }

            return null;
        }

        [Route("all")]
        public IHttpActionResult GetAll()
        {
            List<CourseView> courses = new List<CourseView>();
            _dbCourses.ForEach((_) =>
            {
                var courseView = ToCourseView(_);
                if (courseView != null)
                {
                    courses.Add(courseView);
                }
            });
            return Ok(courses);
        }

        [Route("byId/{id}")]
        public IHttpActionResult GetCourseById(int id)
        {
            var course = _dbCourses.FirstOrDefault(_ => _.Id == id);
            var courseView = ToCourseView(course);
            if (courseView == null)
            {
                return NotFound();
            }

            return Ok(courseView);
        }
    }
}