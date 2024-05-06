using System.ComponentModel.DataAnnotations;

namespace ProjectManagerApi.Models.Domain
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required, StringLength(100)]
        public string FirstName { get; set; }
        [Required, StringLength(100)]
        public string LastName { get; set; }
        public string Password { get; set; }
        [StringLength(100)]
#nullable enable
        public string? TeamName { get; set; }

        public List<ProjectAssignment>? ProjectAssignments { get; set; }
#nullable restore
    }
}
