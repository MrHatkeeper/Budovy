using Budovy.Controllers.Budovy.objects;

namespace Budovy.Controllers.Budovy;

public class RoomsOperations
{
    private readonly IdOperations _idOperations = new IdOperations();
    private const string TimeSchedulesPath = "bin/Debug/net7.0/database/timeSchedule.csv";
    private const string RoomsPath = "bin/Debug/net7.0/database/rooms.csv";

    public List<Room> GetAllRooms(int parentId)
    {
        List<string> listOfBuildings = File.ReadAllLines(RoomsPath).ToList();
        List<Room> output = new();
        foreach (var i in listOfBuildings)
        {
            List<string> holder = i.Split(";").ToList();
            if (parentId == int.Parse(holder[0]))
                output.Add(new Room(int.Parse(holder[0]), int.Parse(holder[1]), holder[2]));
        }

        return output;
    }

    public Room GetRoom(int id)
    {
        List<string> listOfRooms = File.ReadAllLines(RoomsPath).ToList();
        foreach (var i in listOfRooms)
        {
            List<string> holder = i.Split(";").ToList();
            if (int.Parse(holder[1]) == id)
            {
                return new Room(int.Parse(holder[0]), int.Parse(holder[1]), holder[2]);
            }
        }

        return new Room(-1, -1, "null");
    }

    public void AddRoom(string? name, int parentId)
    {
        int id = _idOperations.GetIdAndAddOneToId("r");
        List<string> file = File.ReadAllLines(RoomsPath).ToList();
        file.Add($"{parentId};{id};{name}");
        File.WriteAllLines(RoomsPath, file);
    }

    public void EditRoom(int parentId, int id, string name)
    {
        List<string> file = File.ReadAllLines(RoomsPath).ToList();
        file.RemoveAll(s => int.Parse(s.Split(";")[1]) == id);
        file.Add($"{parentId};{id};{name}");
        File.WriteAllLines(RoomsPath, file);
    }

    public void RemoveRoom(int id)
    {

        List<string> file = File.ReadAllLines(RoomsPath).ToList();
        List<string> listOfRoomIds = file.FindAll(s => int.Parse(s.Split(";")[1]) == id);
        file.RemoveAll(s => int.Parse(s.Split(";")[1]) == id);
        File.WriteAllLines(RoomsPath, file);


        file = File.ReadAllLines(TimeSchedulesPath).ToList();
        foreach (var i in listOfRoomIds) file.RemoveAll(s => int.Parse(s.Split(";")[0]) == int.Parse(i));
        File.WriteAllLines(TimeSchedulesPath, file);
    }
}