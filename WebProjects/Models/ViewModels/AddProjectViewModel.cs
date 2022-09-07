using System.ComponentModel.DataAnnotations;

namespace WebProjects.Models.Models.ViewModels;

public class AddProjectViewModel
{
    [Required]
    [Display(Name = "Nombre Proyecto")]
    [MinLength(3)]
    public string? ProjectName { get; set; }

    [Required]
    [Display(Name = "Archivo")]
    public IFormFile? ProjectFile { get; set; }
}