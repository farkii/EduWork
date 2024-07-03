using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduWork.Common.DTO
{
    public record UserProjectRoleDto
    {
        public int Id { get; set; }
        public ProjectDto Project { get; set; }
        public string ProjectRole { get; set; }
    }
}
