using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduWork.Data.Entities
{
    [Table("WorkDayTime")]
    public class WorkDayTime
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("WorkDay")]
        [Required]
        public int WorkDayId { get; set; }

        [Required]
        public DateOnly StartTime { get; set; }

        [Required]
        public DateOnly EndTime { get; set; }

        public WorkDay WorkDay { get; set; }
    }
}
