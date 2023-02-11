using System.Net;
using Budovy.Controllers.Budovy.objects;

namespace Budovy.Controllers.Budovy;

public class TimeScheduleOperations
{
    private readonly IdOperations _idOperations = new ();
    private const string TimeSchedulesPath = "bin/Debug/net7.0/database/timeSchedule.csv";

    public List<TimeReservations> GetAllTimeReservations(int parentId)
    {
        List<string> listOfBuildings = File.ReadAllLines(TimeSchedulesPath).ToList();
        List<TimeReservations> output = new();
        foreach (var i in listOfBuildings)
        {
            List<string> holder = i.Split(";").ToList();
            if (parentId == int.Parse(holder[0]))
                output.Add(new TimeReservations(int.Parse(holder[0]), int.Parse(holder[1]), DateTime.Parse(holder[2]),
                    DateTime.Parse(holder[3]), holder[4]));
        }

        return output;
    }

    public void AddTimeReservation(int parentId, DateTime start, DateTime end, string name)
    {
        List<string> file = File.ReadAllLines(TimeSchedulesPath).ToList();
        file.Add($"{parentId};{_idOperations.GetIdAndAddOneToId("t")};{start};{end};{name}");
        File.WriteAllLines(TimeSchedulesPath, file);
    }

    public void RemoveReservation(int id)
    {
        List<string> file = File.ReadAllLines(TimeSchedulesPath).ToList();
        file.RemoveAll(s => int.Parse(s.Split(";")[1]) == id);
        File.WriteAllLines(TimeSchedulesPath, file);
    }
}