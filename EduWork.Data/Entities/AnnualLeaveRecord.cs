using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduWork.Data.Entities
{
    [Table("AnnualLeaveRecord")]
    public class AnnualLeaveRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateOnly StartDate { get; set; }

        [Required]
        public DateOnly EndDate { get; set; }

        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }

        [MaxLength(200)]
        public string Comment { get; set; }

        public virtual User User { get; set; }
    }
}
