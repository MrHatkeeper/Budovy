using Budovy.Controllers.Budovy;
using Budovy.Controllers.Budovy.objects;
using Budovy.Models.AddModels;
using Microsoft.AspNetCore.Mvc;

namespace Budovy.Controllers;

public class DetailController : Controller
{
    private RoomsOperations _ro = new();
    private readonly BuildingsOperations _op = new();
    private TimeScheduleOperations _to = new ();
    

    [HttpPost]
    public IActionResult EditBuilding(AddRoomModel model)
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
    
    [HttpPost]
    public IActionResult AddRoom(AddRoomModel model)
    {
        _ro.AddRoom(model.Name, model.ParentId);
        return View("Bd");
    }
    
    public IActionResult RoomDetail(int id)
    {
        Room room = _ro.GetRoom(id);
        
        ViewData["roomName"] = room.Name;
        ViewData["roomId"] = room.Id;
        ViewData["roomParentId"] = room.ParentId;

        List<TimeReservations> timeSchedules = _to.GetAllTimeReservations(room.Id);
        ViewData["timeList"] = timeSchedules;


        return View();
    }

    public IActionResult AddReservation(AddRoomModel model)
    {
        _to.AddTimeReservation(model.ParentId, model.Start, model.End, model.Name!);
        return View("RoomDetail");
    }

    public IActionResult RemoveReservation(AddRoomModel model)
    {
        _to.RemoveReservation(model.Id);
        return View("RoomDetail");
    }

    public IActionResult EditRoom(AddRoomModel model)
    {
        _ro.EditRoom(model.ParentId, model.Id, model.Name!);
        return View("Bd");
    }

    public IActionResult RemoveRoom(AddRoomModel model)
    {
        _ro.RemoveRoom(model.Id);

        return View("Bd");
    }


}

