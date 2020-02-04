using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace timesheet.model
{
    /// <summary>
    /// Timesheet data
    /// </summary>
    public class TimesheetData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        public int TaskId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public DateTime WorkingDay { get; set; }
        [Required]
        public int NoofHrs { get; set; }
    }
}
