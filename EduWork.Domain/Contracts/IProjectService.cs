using EduWork.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduWork.Domain.Contracts
{
    public interface IProjectService
    {
        public Task<List<ProjectShortDto>> GetAllProjectsShortAsync();
    }
}
