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
    [RoutePrefix("api/staff")]
    public class StaffController : BaseController
    {
        private StaffView MapToStaffView(Staff staff)
        {
            var dbRoles = ApiDbContext.Roles.ToList();
            var role = dbRoles.FirstOrDefault(e => e.RoleId == staff.RoleId);
            StaffView staffView = new StaffView()
            {
                StaffId = staff.Id,
                StaffName = staff.Name,
                PhoneNumber = staff.PhoneNumber,
                Role = role != null ? role.RoleName : "",
            };
            return staffView;
        }
        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetStaff()
        {
            var dbStaff = ApiDbContext.Staff.ToList();

            List<StaffView> staff = new List<StaffView>();
            dbStaff.ForEach((_) => { staff.Add(MapToStaffView(_)); });
            return Ok(staff);
        }

        [HttpGet]
        [Route("byId/{id}")]
        public IHttpActionResult GetStaffById(int id)
        {
            var dbStaff = ApiDbContext.Staff.ToList();
            var staff=dbStaff.FirstOrDefault(_ => _.Id == id);
            if (staff == null)
            {
                return NotFound();
            }
            var staffView = MapToStaffView(staff);
            return Ok(staffView);
        }
    }
}