using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduWork.Common.DTO
{
    public record NonWorkingDayDto
    {
        public int Id { get; set; }
        public DateOnly NonWorkingDate { get; set; }
        public string Description { get; set; }
    }
}
