using System.ComponentModel.DataAnnotations;

namespace Budovy.Models.AddModels;

public class AddRoomModel
{
    public int Id { get; set; }

    [Required] public string? Name { get; set; }
    [Required] public string? Desc { get; set; }
}