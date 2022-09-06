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
        for (int i = 1; i <= 20; i++)
        {
            _projects.Add(new Project
            {
                ProjectId = i,
                ProjectName = $"Proyecto número {i}"
            });
        }
    }

    public List<Project> GetAll()
    {
        return _projects;
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
        throw new NotImplementedException();
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