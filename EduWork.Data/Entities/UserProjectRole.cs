using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduWork.Data.Entities
{
    [Table("UserProjectRole")]
    public class UserProjectRole
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }

        [ForeignKey("Project")]
        [Required]
        public int ProjectId { get; set; }

        [ForeignKey("ProjectRole")]
        [Required]
        public int ProjectRoleId { get; set; }

        public virtual User User { get; set; }
        public virtual Project Project { get; set; }
        public virtual ProjectRole ProjectRole { get; set; }
    }
}
