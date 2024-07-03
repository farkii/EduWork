using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduWork.Common.DTO
{
    public record WorkDayDto
    {
        public int Id { get; set; }
        public int UserId{ get; set; }
        public DateOnly WorkDate { get; set; }
    }
}
