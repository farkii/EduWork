using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduWork.Common.DTO
{
    public record UserProjectRole
    {
        public int Id { get; set; }
        public Project Project { get; set; }
        public string ProjectRole { get; set; }
    }
}
