using EduWork.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduWork.Domain.Contracts
{
    public interface IUserProfileService
    {
        public Task<List<ProfileShortDto>> GetAllUserProfilesAsync();
        public Task<ProfileDetailsDto> GetUserProfileAsync(int userId);
        public Task<List<UserProjectDto>> GetAllUserProjectsAsync(int userId);
        public Task<List<AnnualLeaveDto>> GetUserAnnualLeaveAsync(int userId);
        public Task<List<AnnualLeaveRecordDto>> GetUserAnnualLeaveRecordsAsync(int userId);
        public Task<List<SickLeaveRecordDto>> GetUserSickLeaveRecordsAsync(int userId);
    }
}
