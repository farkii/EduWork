﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduWork.Common.DTO
{
    public record ProfileDetailsDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<UserProjectDto> Projects { get; set; }
        public AnnualLeaveDto AnnualLeave { get; set; }
        public List<AnnualLeaveRecordDto> AnnualLeaveRecords { get; set; }
        public List<SickLeaveRecordDto> SickLeaveRecords { get; set; }
    }
}