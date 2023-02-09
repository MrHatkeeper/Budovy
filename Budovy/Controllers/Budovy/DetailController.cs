using Microsoft.AspNetCore.Mvc;

namespace Budovy.Controllers.Budovy;

public class DetailController : Controller
{
    // GET
    public IActionResult Bd()
    {
        return View();
    }
}