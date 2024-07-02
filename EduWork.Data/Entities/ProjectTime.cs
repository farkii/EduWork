using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduWork.Data.Entities
{
    [Table("ProjectTime")]
    public class ProjectTime
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("WorkDay")]
        [Required]
        public int WorkDayId { get; set; }

        [ForeignKey("Project")]
        [Required]
        public int ProjectId { get; set; }

        [MaxLength(200)]
        public string Comment { get; set; }

        [Required]
        public int TimeSpentMinutes { get; set; }

        public virtual WorkDay WorkDay { get; set; }
        public virtual Project Project { get; set; }
    }
}
