using System.Linq;
using timesheet.data;
using timesheet.model;

namespace timesheet.business
{
    public class TaskService
    {
        public TimesheetDb db { get; }
        public TaskService(TimesheetDb dbContext)
        {
            this.db = dbContext;
        }

        public IQueryable<Tasks> GetTasks()
        {
            return this.db.Tasks;
        }
    }
}
