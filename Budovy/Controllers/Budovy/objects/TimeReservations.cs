namespace Budovy.Controllers.Budovy.objects;

public class TimeReservations
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public string Name { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }

    public TimeReservations(int parentId, int id, DateTime start, DateTime end, string name)
    {
        Id = id;
        ParentId = parentId;
        Start = start;
        End = end;
        Name = name;
    }
}