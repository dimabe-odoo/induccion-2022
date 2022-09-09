using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebProjects.Models.Data;

//[Index(nameof(ProjectName), IsUnique = true)]
public class Project
{
    [Key]
    public int ProjectId { get; set; }

    [Required]
    
    public string? ProjectName { get; set; }

    public string? ProjectCover { get; set; }

    public List<ProjectTask>? ProjectTasks { get; set; }
}