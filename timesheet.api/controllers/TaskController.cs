using System;
using Microsoft.AspNetCore.Mvc;
using timesheet.business;

namespace timesheet.api.controllers
{
    [Route("api/v1/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService taskService;
        public TaskController(TaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll(DateTime startDate , DateTime endDate)
        {
            var items = this.taskService.GetTasks();
            return new ObjectResult(items);
        }
    }
}