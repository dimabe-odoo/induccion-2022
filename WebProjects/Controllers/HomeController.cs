using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebProjects.Models;
using WebProjects.Models.Dal;

namespace WebProjects.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IProjectDal _db;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _db = new ProjectDal();
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}