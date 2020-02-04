using System;
using System.Collections.Generic;
using System.Linq;
using timesheet.data;
using timesheet.model;

namespace timesheet.business
{
    public class TimesheetService
    {
        public TimesheetDb db { get; }
        public TimesheetService(TimesheetDb dbContext)
        {
            this.db = dbContext;
        }

        /// <summary>
        /// Getting timesheet details 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public IQueryable<TimesheetData> GetTimesheetDetails(DateTime startDate,DateTime endDate,int employeeId)
        {
            return this.db.TimesheetData
                .Where(x => (x.WorkingDay >= startDate && x.WorkingDay <= endDate) && x.EmployeeId == employeeId);
        }

        /// <summary>
        /// InsertUpdate
        /// </summary>
        /// <param name="timesheetData"></param>
        public void InsertUpdate(TimesheetData timesheetData)
        {
           TimesheetData existingObj= this.db.TimesheetData
                .Where(x => x.WorkingDay == timesheetData.WorkingDay && x.EmployeeId == timesheetData.EmployeeId && x.TaskId==timesheetData.TaskId).SingleOrDefault();

            using (var context = db)
            {
                if (existingObj != null)
                {
                    existingObj.NoofHrs = timesheetData.NoofHrs;
                    context.TimesheetData.Update(existingObj);
                    context.SaveChanges();
                }
                else
                {
                    context.TimesheetData.Add(timesheetData);
                    context.SaveChanges();
                }
            }
        }
    }
}
