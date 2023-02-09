namespace Budovy.Controllers.Budovy.objects;

public class Building
{
    public int Id { get; set; }
    public string? Name { get; set;}
    public string? Description { get; set; }

    public Building(int id,string? name, string? description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
}