using Microsoft.AspNetCore.Mvc;
using Zanzarah_fairy_book.Models;

namespace Zanzarah_fairy_book.Migrations.Controllers;
[Route("[controller]/[action]")]
public class FairyController : Controller
{
    public DataBaseContext db;
    
    [HttpGet]
    public IActionResult GetById(int id)
    {
        var fairy = db.Fairies
            .FirstOrDefault(x => x.Id == id);
        return Ok();
    }

    [HttpPost]
    public IActionResult AddFairy(Fairy fairy)
    {
        db.Fairies.Add(fairy);
        db.SaveChanges();
        return Ok();
    }

    [HttpPost]
    public IActionResult UpdateFairy(Fairy fairy)
    {
        db.Fairies.Update(fairy);
        db.SaveChanges();
        return Ok();
    }

    [HttpPost]
    public IActionResult DeleteFairy(int id)
    {
        var fairy = db.Fairies.FirstOrDefault(x => x.Id == id);
        db.Remove(fairy);
        db.SaveChanges();
        return Ok();
    }
}