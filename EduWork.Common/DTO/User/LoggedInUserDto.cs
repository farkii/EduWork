using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduWork.Common.DTO.User
{
    public record LoggedInUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string EntraObjectId { get; set; }

        public string AppRole { get; set; }
    }
}
