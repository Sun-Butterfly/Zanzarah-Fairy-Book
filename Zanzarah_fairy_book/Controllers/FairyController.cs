using Microsoft.AspNetCore.Mvc;
using Zanzarah_fairy_book.Models;
using Zanzarah_fairy_book.Services;

namespace Zanzarah_fairy_book.Migrations.Controllers;

[Route("[controller]/[action]")]
public class FairyController : Controller
{
    private readonly FairyService _service;

    public FairyController(FairyService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetById(int id)
    {
        if (_service.ExistsById(id) == false)
        {
            return BadRequest("Данной феи не существует");
        }

        var fairy = _service.GetById(id);
        return Ok(fairy);
    }
    
    [HttpGet]
    public IActionResult GetByName(string name)
    {
        if (_service.ExistsByName(name) == false)
        {
            return BadRequest("Данной феи не существует");
        }

        var fairy = _service.GetByName(name);
        return Ok(fairy);
    }

    [HttpPost]
    public IActionResult AddFairy(Fairy fairy)
    {
        if (_service.ExistsById(fairy.Id) || _service.ExistsByName(fairy.Name))
        {
            return BadRequest("Данная фея уже существует");
        }
        _service.Add(fairy);
        return Ok();
    }

    [HttpPost]
    public IActionResult UpdateEvolveForm(Fairy fairy, EvolveForm evolveForm)
    {
        if (!_service.CanEvolveByLevel(fairy) || !_service.CanEvolveByItem(fairy))
        {
            return BadRequest("Фея не может эволюционировать!");
        }
        //TODO:
        // if (_service.CanEvolveByLevel(fairy) && !_service.IsCorrectEvolve_ByLevel_Element(fairy, evolveForm))
        // {
        //     return BadRequest("Фея не может эволюционировать в другую стихию");
        // }
        _service.UpdateEvolve(fairy,evolveForm);
        return Ok();
    }

    [HttpPost]
    public IActionResult UpdateFairy(Fairy fairy)
    {
        _service.Update(fairy);
        return Ok();
    }

    //TODO:
    // [HttpDelete]
    // public IActionResult DeleteFairy(int id)
    // {
    //     var fairy = _db.Fairies.FirstOrDefault(x => x.Id == id);
    //     _db.Remove(fairy);
    //     _db.SaveChanges();
    //     return Ok();
    // }
}