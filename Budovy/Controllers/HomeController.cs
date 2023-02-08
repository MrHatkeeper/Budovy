
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
    
    public IActionResult Index()
    {
        _op.AddBuilding("gej", "abc");
        _op.AddBuilding("haha", "def");
        List<Building> data = _op.GetAllBuildings();
        ViewData["data"] = data;   
        return View();
    }

}