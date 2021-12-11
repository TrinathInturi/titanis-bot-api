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
    [RoutePrefix("api/performance")]
    public class AcademicPerformanceController : BaseController
    {
        [HttpGet]
        [Route("all")]
        public IHttpActionResult Get()
        {
            return Ok(ApiDbContext.AcademicPerformance.ToList());
        }

        [HttpGet]
        [Route("byId/{rollNumber}")]
        public IHttpActionResult Get(string rollNumber)
        {
            try
            {
                return Ok(ApiDbContext.AcademicPerformance.First(e => e.RollNumber == rollNumber));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult Post([FromBody] AcademicPerformance performance)
        {
            ApiDbContext.AcademicPerformance.Add(performance);
            ApiDbContext.SaveChanges();
            return Ok("Academic Performance of Student Added");
        }

        [HttpPut]
        [Route("update/{rollNumber}")]
        public IHttpActionResult Put(string rollNumber, [FromBody] AcademicPerformance performance)
        {
            try
            {
                AcademicPerformance currentPerformance;
                if ((currentPerformance = ApiDbContext.AcademicPerformance.First(e => e.RollNumber == rollNumber)) !=
                    null)
                {
                    currentPerformance.RollNumber = performance.RollNumber;
                    currentPerformance.AttendancePercentage = performance.AttendancePercentage;
                    currentPerformance.CurrentSemester = performance.CurrentSemester;
                    ApiDbContext.SaveChanges();
                }
                else
                {
                    return NotFound();
                }

                return Ok($"{currentPerformance.RollNumber} details Updated");
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        [Route("delete/rollNumber")]
        public IHttpActionResult Delete(string rollNumber)
        {
            try
            {
                var currentAcademicPerformance =
                    ApiDbContext.AcademicPerformance.First(e => e.RollNumber == rollNumber);
                ApiDbContext.AcademicPerformance.Remove(currentAcademicPerformance);
                ApiDbContext.SaveChanges();
                return Ok($"{currentAcademicPerformance.RollNumber} deleted!");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}