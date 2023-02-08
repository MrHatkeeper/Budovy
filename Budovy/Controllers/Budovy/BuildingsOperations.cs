using Budovy.Controllers.Budovy.objects;

namespace Budovy.Controllers.Budovy;

public class BuildingsOperations
{
    private int _idCount = 0;
    private List<Building> _buildings = new();

    public List<Building> GetAllBuildings()
    {
        return _buildings;
    }

    public void AddBuilding(string? name, string? desc)
    {
        _buildings.Add(new Building(_idCount, name, desc,null));
    }
}