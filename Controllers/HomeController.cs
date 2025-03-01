using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoNuevo.Models;

namespace ProyectoNuevo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult ItemMuestra()
    {
        Item item = new Item{
            id = 1,
            name = "Espada",
            type = "Arma",
            STR = 10,
            AGI = 5,
            INTE = 0,
            MND = 0,
            VIT = 5
        };
        return View(item);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
