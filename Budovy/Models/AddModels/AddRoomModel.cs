namespace Budovy.Models.AddModels;

public class AddRoomModel
{
    public int ParentId { get; set; }
    
    public DateTime Start { get; set; }
    
    public DateTime End { get; set; }
    
    public int Id { get; set; }
    public string? Name { get; set; }
    
    public string? Desc { get; set; }
}