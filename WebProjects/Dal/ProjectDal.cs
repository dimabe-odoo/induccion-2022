using Microsoft.EntityFrameworkCore;
using WebProjects.Models.Data;

namespace WebProjects.Models.Dal;


public interface IProjectDal
{
    public Task<List<Project>> GetAll();
    public Task<Project> GetById(int id);
    public Task Save(Project project);
    public Task Update(int id, Project project);
    public Task<bool> Delete(int id);

    public Task<int> CountTasks(int projectId);
}

public class ProjectDal : IProjectDal
{
    private readonly ApplicationDbContext _db;
    public ProjectDal(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task<List<Project>> GetAll()
    {
        return await _db.Projects.OrderByDescending(x => x.ProjectId).ToListAsync();
    }

    public async Task<Project> GetById(int id)
    {
        Project? result = await _db.Projects.FirstOrDefaultAsync(x => x.ProjectId == id);
        if (result == null)
            throw new Exception("No se ha encontrado el proyecto");

        return result;
    }

    public async Task Save(Project project)
    {
       _db.Projects.Add(project);
       await _db.SaveChangesAsync();
    }

    public async Task Update(int id, Project project)
    {
        var projectToUpdate = await GetById(id);

        projectToUpdate.ProjectName = project.ProjectName;
        if (!string.IsNullOrEmpty(project.ProjectCover))
        {
            projectToUpdate.ProjectCover = project.ProjectCover;
        }
        _db.Entry(projectToUpdate).State = EntityState.Modified;

        await _db.SaveChangesAsync();
    }

    public async Task<bool> Delete(int id)
    {
        var projectToDelete = await GetById(id);
        _db.Projects.Remove(projectToDelete);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<int> CountTasks(int projectId)
    {
        return await _db.ProjectTasks.CountAsync(x => x.ProjectId == projectId);
    }
} 