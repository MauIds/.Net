using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    public async Task<IActionResult> verItems(int id){
        List<Item>arrItems = await context.items.ToListAsync();
        return View(arrItems); 
        } 
       
    public async Task<IActionResult> verItem(int id){
        Item? item = await context.items.FindAsync(id);
        if(item == null) return NotFound();
        return View("ItemMuestra", item);
    }
    //Crear
    [HttpGet]
    public IActionResult Crear(){
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Crear(Item item){
        if(item == null) return Error();{
        if (ModelState.IsValid){
            context.items.Add(item);
            await context.SaveChangesAsync();
            RedirectToAction("verItems");
        }
        return View(item);
    }
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
