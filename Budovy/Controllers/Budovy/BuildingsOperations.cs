using Budovy.Controllers.Budovy.objects;

namespace Budovy.Controllers.Budovy;

public class BuildingsOperations
{
    private const string BuildingsPath = "bin/Debug/net7.0/database/budovy.csv";
    private const string RoomsPath = "bin/Debug/net7.0/database/rooms.csv";
    private const string TimeSchedulesPath = "bin/Debug/net7.0/database/timeSchedule.csv";
    private const string IdCounter = "bin/Debug/net7.0/database/idCounter";

    private int GetIdAndAddOneToId(string typeOfId)
    {
        int output = new int();
        var file = File.ReadAllLines(IdCounter).ToList();
        switch (typeOfId)
        {
            case "b":
                output = int.Parse(file[0]) + 1;
                file[0] = output.ToString();
                break;
            case "r":
                output = int.Parse(file[1]) + 1;
                file[0] = output.ToString();
                break;
            case "t":
                output = int.Parse(file[2]) + 1;
                file[0] = output.ToString();
                break;
        }

        File.WriteAllLines(IdCounter, file);

        return output;
    }

    public List<Building> GetAllBuildings()
    {
        List<string> listOfBuildings = File.ReadAllLines(BuildingsPath).ToList();
        List<Building> output = new();
        foreach (var i in listOfBuildings)
        {
            List<string> holder = i.Split(";").ToList();
            output.Add(new Building(int.Parse(holder[0]), holder[1], holder[2]));
        }

        return output;
    }

    public Building GetBuilding(int id)
    {
        List<string> listOfBuildings = File.ReadAllLines(BuildingsPath).ToList();
        foreach (var i in listOfBuildings)
        {
            List<string> holder = i.Split(";").ToList();
            if (int.Parse(holder[0]) == id)
            {
                return new Building(int.Parse(holder[0]), holder[1], holder[2]);
            }
        }

        return new Building(-1, "null", "null");
    }

    public void AddBuilding(string? name, string? desc)
    {
        int id = GetIdAndAddOneToId("b");
        List<string> file = File.ReadAllLines(BuildingsPath).ToList();
        file.Add($"{id};{name};{desc}");
        File.WriteAllLines(BuildingsPath, file);
    }

    public void EditBuilding(int id, string name, string desc)
    {
        List<string> file = File.ReadAllLines(RoomsPath).ToList();
        file.RemoveAll(s => int.Parse(s.Split(";")[0]) == id);
        file.Add($"{id};{name};{desc}");
        File.WriteAllLines(BuildingsPath, file);
    }

    public void RemoveBuilding(int id)
    {
        List<string> file = File.ReadAllLines(RoomsPath).ToList();
        List<string> listOfRoomIds = file.FindAll(s => int.Parse(s.Split(";")[0]) == id);
        file.RemoveAll(s => int.Parse(s.Split(";")[0]) == id);
        File.WriteAllLines(RoomsPath,file);


        file = File.ReadAllLines(TimeSchedulesPath).ToList();
        foreach (var i in listOfRoomIds) file.RemoveAll(s => int.Parse(s.Split(";")[0]) == int.Parse(i));
        File.WriteAllLines(TimeSchedulesPath,file);

        file = File.ReadAllLines(BuildingsPath).ToList();
        file.RemoveAll(s => int.Parse(s.Split(";")[0]) == id);
        File.WriteAllLines(BuildingsPath, file);
    }
}