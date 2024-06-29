using Microsoft.AspNetCore.Mvc;
using Zanzarah_fairy_book.Models;

namespace Zanzarah_fairy_book.Migrations.Controllers;
[Route("[controller]/[action]")]
public class FairyController : Controller
{
    DataBaseContext _db;

    public FairyController(DataBaseContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult GetById(int id)
    {
        var fairy = _db.Fairies
            .FirstOrDefault(x => x.Id == id);
        return Ok(fairy);
    }

    [HttpPost]
    public IActionResult AddFairy(Fairy fairy)
    {
        _db.Fairies.Add(fairy);
        _db.SaveChanges();
        return Ok();
    }

    [HttpPost]
    public IActionResult UpdateFairy(Fairy fairy)
    {
        _db.Fairies.Update(fairy);
        _db.SaveChanges();
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteFairy(int id)
    {
        var fairy = _db.Fairies.FirstOrDefault(x => x.Id == id);
        _db.Remove(fairy);
        _db.SaveChanges();
        return Ok();
    }
}