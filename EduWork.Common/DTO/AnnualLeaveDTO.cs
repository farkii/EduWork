using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduWork.Common.DTO
{
    public record AnnualLeaveDTO
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int TotalLeaveDays { get; set; }
        public int LeaveDaysLeft { get; set; } 

    }
}
