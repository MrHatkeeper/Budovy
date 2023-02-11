using Budovy.Controllers.Budovy;
using Budovy.Controllers.Budovy.objects;
using Budovy.Models.AddModels;
using Microsoft.AspNetCore.Mvc;

namespace Budovy.Controllers;

public class HomeController : Controller
{
    private RoomsOperations _ro = new();
    private BuildingsOperations _op = new();


    [HttpPost]
    public IActionResult AddBuilding(AddBuildingModel model)
    {
        _op.AddBuilding(model.Name, model.Desc);
        return View("Index");
    }



    public IActionResult Index()
    {
        List<Building> data = _op.GetAllBuildings();
        ViewData["data"] = new List<Building>();
        if (data.Count != 0)
        {
            ViewData["data"] = data;
        }

        return View();
    }
    
    public IActionResult Bd(int id)
    {
        Building buildingData = _op.GetBuilding(id);
        ViewData["buildingId"] = id;
        ViewData["buildingName"] = buildingData.Name;
        ViewData["buildingDesc"] = buildingData.Description;

        List<Room> roomsList = _ro.GetAllRooms(id);
        ViewData["roomList"] = roomsList;

        return View("../Detail/Bd");
    }
}