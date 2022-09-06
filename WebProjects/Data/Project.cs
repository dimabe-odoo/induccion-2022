namespace WebProjects.Models.Data;

public class Project
{
    public int ProjectId { get; set; }

    public string? ProjectName { get; set; }

    public string? ProjectCover { get; set; }

    public List<ProjectTask>? ProjectTasks { get; set; }
}