using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoNuevo.Data;
using ProyectoNuevo.Models;

namespace ProyectoNuevo.Controllers;

public class HomeController : Controller
{
    
    private readonly MysqlDbContext context;
    public HomeController(MysqlDbContext context)
    {
        this.context = context;
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

    public IActionResult verItems(int id){
        List<Item>arrItems =context.items.ToList();
        return View(arrItems); 
        } 
       
    [HttpGet("Home/Elitem/{id}/{name}")]
    public IActionResult Elitem(int id, string name){
        return Content($"El item seleccionado es {name} con id {id}");
    }
    
    public IActionResult ItemEspecifico(int id){
        Item[]arrItems ={
            new Item{
                id = 1,
                name = "Espada",
                type = "Arma",
                STR = 10,
                AGI = 5,
                INTE = 0,
                MND = 0,
                VIT = 5
            },
            new Item{
                id = 2,
                name = "Escudo",
                type = "Armadura",
                STR = 0,
                AGI = 0,
                INTE = 0,
                MND = 0,
                VIT = 10
            },
            new Item{
                id = 3,
                name = "Pocion",
                type = "Consumible",
                STR = 0,
                AGI = 0,
                INTE = 0,
                MND = 0,
                VIT = 0
            }
        } ;
        Item? item = arrItems.FirstOrDefault(x => x.id == id);
        if(item == null){
            return Content("No se encontro el item");
        }
        return View("ItemMuestra", item);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
