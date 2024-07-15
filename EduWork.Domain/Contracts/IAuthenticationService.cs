using EduWork.Common.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduWork.Domain.Contracts
{
    public interface IAuthenticationService
    {
        public Task<LoggedInUserDto> UserAuthenticationAsync(string email, string name, string objectId);
    }
}
