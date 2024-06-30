using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduWork.Data.Entities
{
    [Table("Project")]
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public DateOnly StartDate { get; set; }

        [Required]
        public DateOnly EndDate { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public bool isFinished  { get; set; }

        [Required]
        public bool isPrivate { get; set; }

        [Required]
        public bool isEducation { get; set; }

        [Required]
        public bool isPayable { get; set; }

        [Required]
        public string DevopsProjectId { get; set; }

        public virtual List<UserProjectRole> UserProjectRoles { get; set; }
        public virtual List<ProjectTime> ProjectTimes { get; set; }

    }
}
