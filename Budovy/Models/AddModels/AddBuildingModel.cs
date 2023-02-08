using System.ComponentModel.DataAnnotations;

namespace Budovy.Models.AddModels;

public class AddBuildingModel
{

    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Desc { get; set; }
}