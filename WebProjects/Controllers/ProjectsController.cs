using Microsoft.AspNetCore.Mvc;
using WebProjects.Models.Dal;
using WebProjects.Models.Data;
using WebProjects.Models.Helpers;
using WebProjects.Models.Models.ViewModels;

namespace WebProjects.Controllers;

public class ProjectsController : Controller
{
    private readonly IProjectDal _db;
    private readonly IWebHostEnvironment _hostingEnvironment;

    public ProjectsController(IWebHostEnvironment environment, IProjectDal db)
    {
        _hostingEnvironment = environment;
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        List<IndexProjectViewModel> vm = new List<IndexProjectViewModel>();
        foreach (var item in await _db.GetAll())
        {
            vm.Add(new IndexProjectViewModel
            {
                ProjectId = item.ProjectId,
                ProjectName = item.ProjectName,
                ProjectTaskCount = await _db.CountTasks(item.ProjectId)
            });
        }
        return View(vm);
    }

    public ViewResult Show()
    {
        return View("_ModalAddProject");
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
            
            var project = new Project
            {
                ProjectName = model.ProjectName,
                ProjectCover = filePath,
            };
        
            await _db.Save(project);
        }

        SetMessage("Se ha registrado el nuevo proyecto");
        
        return RedirectToAction("Index");
    }

    public void SetMessage(string message, bool isError = false)
    {
        var messageType = isError ? "Error": "Message";
        
        TempData[messageType] = message;
    }
}