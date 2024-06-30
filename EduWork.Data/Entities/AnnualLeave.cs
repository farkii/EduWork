using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduWork.Data.Entities
{
    [Table("AnnualLeave")]
    public class AnnualLeave
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int TotalLeaveDays { get; set; }
        
        [Required]
        public int LeaveDaysLeft { get; set; } 

        public User User { get; set; }

    }
}
