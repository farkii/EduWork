﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduWork.Common.DTO.User
{
    public record ProfileShortDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public List<UserProjectDto> Projects { get; set; }
    }
}
