using Budovy.Controllers.Budovy;
using Budovy.Controllers.Budovy.objects;
using Budovy.Models.AddModels;
using Microsoft.AspNetCore.Mvc;

namespace Budovy.Controllers;

public class DetailController : Controller
{
    private BuildingsOperations _op = new();
    
    public IActionResult RemoveBuilding(int id)
    {
        Console.Out.WriteLine("gigagej");
        _op.RemoveBuilding(id);
        return View("/");
    }
    
    // GET
    public IActionResult Bd(int id)
    {
        Building buildingData = _op.GetBuilding(id);
        ViewData["buildingId"] = id;
        ViewData["buildingName"] = buildingData.Name;
        ViewData["buildingDesc"] = buildingData.Description;
        
        return View();
    }
}