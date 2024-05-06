using System.ComponentModel.DataAnnotations;

namespace ProjectManagerApi.Models.Domain
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [Required, StringLength(200)]
        public string ProjectName { get; set; }
        [Required, StringLength(600)]
#nullable enable
        public string? ProjectDescription { get; set; } = string.Empty;
        public List<ProjectAssignment> ProjectAssignments { get; set; }
#nullable restore
    }
}
