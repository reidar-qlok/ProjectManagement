using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagerApi.Models.Domain
{
    public class ProjectAssignment
    {
        [Key]
        public int ProjectAssignmentId { get; set; }
        [Required]
        public int FkEmployeeId { get; set; }
        [ForeignKey("FkEmployeeId")]
        public virtual Employee Employee { get; set; }

        [Required]
        public int FkProjectId { get; set; }
        [ForeignKey("FkProjectId")]
        public virtual Project Project { get; set; }

#nullable enable
        public DateTime? Date { get; set; }


        public decimal? HoursWorked { get; set; }

        [StringLength(500)]
        public string? WorkDescription { get; set; }
#nullable restore
    }
}
