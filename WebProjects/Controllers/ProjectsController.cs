using Microsoft.AspNetCore.Mvc;
using WebProjects.Models.Dal;

namespace WebProjects.Controllers;

public class ProjectsController : Controller
{
    private readonly IProjectDal _db;

    public ProjectsController()
    {
        _db = new ProjectDal();
    }

    public IActionResult Index()
    {
        return View(_db.GetAll());
    }
}