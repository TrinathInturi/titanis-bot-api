using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Titanis.Api.ViewModels
{
    public class StaffView
    {
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
    }
}