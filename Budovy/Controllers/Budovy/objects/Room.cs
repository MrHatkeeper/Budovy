namespace Budovy.Controllers.Budovy.objects;

public class Room
{
    public int ParentId { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }

    public Room(int parentId, int id, string name)
    {
        Id = id;
        Name = name;
        ParentId = parentId;
    }
    
}