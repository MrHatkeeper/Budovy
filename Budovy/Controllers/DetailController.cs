using Budovy.Controllers.Budovy;
using Budovy.Controllers.Budovy.objects;
using Budovy.Models.AddModels;
using Microsoft.AspNetCore.Mvc;

namespace Budovy.Controllers;

public class DetailController : Controller
{
    private RoomsOperations _ro = new();
    private readonly BuildingsOperations _op = new();

    [HttpPost]
    public IActionResult AddRoom(AddRoomModel model)
    {
        _ro.AddRoom(model.Name, model.ParentId);
        return View("Bd");
    }

    [HttpPost]
    public IActionResult EditPost(AddRoomModel model)
    {
        _op.EditBuilding(model.ParentId, model.Name!, model.Desc!);
        
        return View("Bd");
    }
    
    [HttpPost]
    public IActionResult RemoveBuilding(AddRoomModel model)
    {
        _op.RemoveBuilding(model.ParentId);
        return View("../Home/Index");
    }

    // GET
    public IActionResult Bd(int id)
    {
        Building buildingData = _op.GetBuilding(id);
        ViewData["buildingName"] = buildingData.Name;
        ViewData["buildingDesc"] = buildingData.Description;

        List<Room> roomsList = _ro.GetAllRooms();
        ViewData["roomList"] = roomsList;

        return View("Bd");
    }

    public IActionResult RoomDetail(int id)
    {
        Room room = _ro.GetRoom(id);
        ViewData["roomName"] = room.Name;
        ViewData["roomId"] = room.Id;
        
        
        return View();
    }

    public IActionResult EditRoom(AddRoomModel model)
    {
        _ro.EditRoom(model.ParentId, model.Name!);
        return View("RoomDetail");
    }
}

