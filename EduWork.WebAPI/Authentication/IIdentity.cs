﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduWork.WebAPI.Authentication
{
    public interface IIdentity
    {
        string? DisplayName { get; }
        string? Email { get; }
        Guid? ObjectId { get; }
    }
}
