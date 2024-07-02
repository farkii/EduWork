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
        public Task<List<UserProfile>> GetAllUserProfilesAsync();
        public Task<UserProfile> GetUserProfileAsync(int userId);
        public Task<List<UserProject>> GetAllUserProjectsAsync(int userId);
        public Task<List<AnnualLeaveDTO>> GetUserAnnualLeaveAsync(int userId);
        public Task<List<AnnualLeaveRecordDTO>> GetUserAnnualLeaveRecordsAsync(int userId);
        public Task<List<SickLeaveRecordDTO>> GetUserSickLeaveRecordsAsync(int userId);
    }
}
