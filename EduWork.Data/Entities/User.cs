using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduWork.Data.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Username { get; set; }

        [MaxLength(20)]
        [Required]
        public string Email { get; set; }

        [ForeignKey("AppRole")]
        [Required]
        public int AppRoleId { get; set; }

        [MaxLength(200)]
        [Required]
        public string EntraObjectId { get; set; }

        public AppRole AppRole { get; set; }

        public virtual List<AnnualLeave> AnnualLeave { get; set; }
        public virtual List<WorkDay> WorkDays { get; set; }
        public virtual List<UserProjectRole> UserProjectRoles { get; set; }
        public virtual List<SickLeaveRecord> SickLeaveRecords { get; set; }
        public virtual List<AnnualLeaveRecord> AnnualLeaveRecords { get; set; }
    }
}
