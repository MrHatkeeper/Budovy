namespace Budovy.Controllers.Budovy.objects;

public class TimeReservations
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }

    public TimeReservations(int id, int parentId, DateTime start, DateTime end)
    {
        Id = id;
        ParentId = parentId;
        Start = start;
        End = end;
    }
}