using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using timesheet.business;
using timesheet.model;

namespace timesheet.api.controllers
{
    [Route("api/v1/timesheetdata")]
    [ApiController]
    public class TimesheetDataController : ControllerBase
    {
        private readonly TimesheetService timesheetService;
        public TimesheetDataController(TimesheetService timesheetService)
        {
            this.timesheetService = timesheetService;
        }

        [HttpPost("getall")]
        public IActionResult GetAll([FromForm] string startDate, [FromForm] string endDate, [FromForm] string employeeId)
        {
            var items = this.timesheetService.GetTimesheetDetails(Convert.ToDateTime(startDate), Convert.ToDateTime(endDate), Convert.ToInt32(employeeId));
            return new ObjectResult(items);
        }

        [HttpPost("insertUpdate")]
        public void InsertUpdate(TimesheetData timesheetData)
        {
            this.timesheetService.InsertUpdate(timesheetData);
        }
    }
}