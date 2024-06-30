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
    public IActionResult UpdateEvolveForm(int evolveFromFormId, int evolveToFormId)
    {
        var fairyFrom = _service.GetById(evolveFromFormId);
        var fairyTo = _service.GetById(evolveToFormId);
        if (!_service.CanEvolve(fairyFrom))
        {
            return BadRequest("Фея не может эволюционировать!");
        }
        if (_service.CanEvolveByLevel(fairyFrom) && !_service.IsCorrectEvolve_ByLevel_Element(fairyFrom, fairyTo))
        {
            return BadRequest("Фея не может эволюционировать в другую стихию");
        }
        _service.UpdateEvolve(evolveFromFormId,evolveToFormId);
        return Ok();
    }

    [HttpPost]
    public IActionResult UpdateFairy(Fairy fairy)
    {
        _service.Update(fairy);
        return Ok();
    }

    
    [HttpDelete]
    public IActionResult DeleteFairy(int id)
    {
        _service.Delete(id);
        return Ok();
    }
}