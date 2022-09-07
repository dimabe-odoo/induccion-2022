using Microsoft.AspNetCore.Mvc;
using WebProjects.Models.Dal;
using WebProjects.Models.Data;
using WebProjects.Models.Helpers;
using WebProjects.Models.Models.ViewModels;

namespace WebProjects.Controllers;

public class ProjectsController : Controller
{
    private readonly IProjectDal _db;
    private IWebHostEnvironment _hostingEnvironment;

    public ProjectsController(IWebHostEnvironment environment)
    {
        _hostingEnvironment = environment;
        _db = new ProjectDal();
    }

    public IActionResult Index()
    {
        return View(_db.GetAll());
    }

    public async Task<IActionResult> Save(AddProjectViewModel model)
    {
        if (!ModelState.IsValid)
        {
            SetMessage("Existen errores de validación", true);
            return RedirectToAction("Index");
        }

        
        var folderPath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

        if (model?.ProjectFile != null)
        {
            var filePath = await ImageUpload.UploadImage(folderPath, model?.ProjectFile);

            int projectId = _db.GetAll().MaxBy(x => x.ProjectId)!.ProjectId + 1;
            var project = new Project
            {
                ProjectName = model.ProjectName,
                ProjectCover = filePath,
                ProjectId = projectId
            };
        
            _db.Save(project);
        }

        SetMessage("Se ha registrado el nuevo proyecto");
        
        return RedirectToAction("Index");
    }

    public void SetMessage(string message, bool isError = false)
    {
        var messageType = "";
        if (isError == true)
        {
            messageType = "Error";
        }
        else
        {
            messageType = "Message";
        }

        TempData[messageType] = message;
    }
}