using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduWork.Data.Entities
{
    [Table("NonWorkingDay")]
    public class NonWorkingDay
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateOnly NonWorkingDate { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
