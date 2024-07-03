using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduWork.Common.DTO
{
    public record ProjectDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Description { get; set; }
        public bool isFinished  { get; set; }
        public bool isPrivate { get; set; }
        public bool isEducation { get; set; }
        public bool isPayable { get; set; }
        public string DevopsProjectId { get; set; }

    }
}
