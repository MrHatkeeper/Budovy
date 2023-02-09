using Budovy.Controllers.Budovy;
using Budovy.Controllers.Budovy.objects;
using Budovy.Models.AddModels;
using Microsoft.AspNetCore.Mvc;

namespace Budovy.Controllers;

public class HomeController : Controller
{
    private BuildingsOperations _op = new();


    [HttpPost]
    public IActionResult Index(AddBuildingModel model)
    {
        _op.AddBuilding(model.Name, model.Desc);
        return View();
    }

    public IActionResult RemoveBuilding(int id)
    {
        Console.Out.WriteLine("gigagej");
        _op.RemoveBuilding(id);
        return View("/");
    }
    
    //"../Detail/Bd", model
    public IActionResult Index()
    {
        ViewData["data"] = new List<Building>();
        List<Building> data = _op.GetAllBuildings();
        if (data.Count != 0)
        {
            ViewData["data"] = data;
        }

        return View();
    }
}