namespace WebProjects.Models.Data;

public class ProjectTask
{
    public int ProjectTaskId { get; set; }
    public string ProjectTaskName { get; set; }
    public bool IsClosed { get; set; }

    public int ProjectId { get; set; }

    public Project Project { get; set; }
}