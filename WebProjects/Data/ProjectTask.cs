using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProjects.Models.Data;

public class ProjectTask
{
    [Key]
    public int ProjectTaskId { get; set; }
    [Required]
    public string? ProjectTaskName { get; set; }
    public bool IsClosed { get; set; }
    [Required]
    public int ProjectId { get; set; }
    
    [ForeignKey("ProjectId")]
    public Project? Project { get; set; }
}