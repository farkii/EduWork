using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduWork.Common.DTO
{
    public record ProjectTime
    {
        public int Id { get; set; }
        public int WorkDayId { get; set; }
        public int ProjectId { get; set; }
        public string Comment { get; set; }
        public int TimeSpentMinutes { get; set; }
    }
}
