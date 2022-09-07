using WebProjects.Models.Data;

namespace WebProjects.Models.Dal;


public interface IProjectDal
{
    public List<Project> GetAll();
    public Project GetById(int id);
    public void Save(Project project);
    public void Update(int id, Project project);
    public bool Delete(int id);
}

public class ProjectDal : IProjectDal
{
    private List<Project> _projects;

    public ProjectDal()
    {
        _projects = new List<Project>();
        Random random = new Random();
        for (int i = 1; i <= 20; i++)
        {
            var project = new Project
            {
                ProjectId = i,
                ProjectName = $"Proyecto número {i}",
                ProjectTasks = new List<ProjectTask>()
            };
            for (int j = 1; j < random.Next(2, 7); j++)
            {
                project.ProjectTasks.Add(new ProjectTask
                {
                    ProjectId = j,
                    IsClosed = random.Next(2) == 1,
                    ProjectTaskName = $"Tarea {j}",
                    ProjectTaskId = int.Parse(i.ToString() + j.ToString())
                });
            }
            _projects.Add(project);
        }
    }

    public List<Project> GetAll()
    {
        return _projects.OrderByDescending(x => x.ProjectId).ToList();
    }

    public Project GetById(int id)
    {
        Project? result = _projects.FirstOrDefault(x => x.ProjectId == id);
        if (result == null)
            throw new Exception("No se ha encontrado el proyecto");

        return result;
    }

    public void Save(Project project)
    {
       _projects.Add(project);
    }

    public void Update(int id, Project project)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }
} 