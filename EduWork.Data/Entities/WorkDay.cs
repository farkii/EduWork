using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduWork.Data.Entities
{
    [Table("WorkDay")]
    public class WorkDay
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        [Required]
        public int UserId{ get; set; }

        [Required]
        public DateOnly WorkDate { get; set; }

        public virtual User User { get; set; }

        public virtual List<WorkDayTime> WorkDayTimes { get; set; }

        public virtual List<ProjectTime> ProjectTimes { get; set; }
    }
}
