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
    public IActionResult UpdateEvolveForm(
        int evolveFromFormId,
        EvolveKind evolveKind,
        int evolveLevel,
        List<EvolveItem> evolveItem,
        int evolveToFormId
    )
    {
        if (evolveKind == EvolveKind.None)
        {
            return BadRequest("Фея не может эволюционировать!");
        }

        var fairyFrom = _service.GetById(evolveFromFormId);
        var fairyTo = _service.GetById(evolveToFormId);
        if (evolveKind == EvolveKind.EvolveFromLevel &&
            !_service.IsCorrectEvolve_ByLevel_Element(fairyFrom, fairyTo))
        {
            return BadRequest("Фея не может эволюционировать в другую стихию");
        }

        if (evolveKind == EvolveKind.EvolveFromItem
            && evolveItem.Contains(EvolveItem.EvolutionaryMagicOfNature)
            && fairyTo.Element != Element.Nature
           )
        {
            return BadRequest("Фея может эволюционировать только в фею природы");
        }

        if (evolveKind == EvolveKind.EvolveFromItem
            && evolveItem.Contains(EvolveItem.EvolutionaryMagicOfAir)
            && fairyTo.Element != Element.Air
           )
        {
            return BadRequest("Фея может эволюционировать только в фею воздуха");
        }

        if (evolveKind == EvolveKind.EvolveFromItem
            && evolveItem.Contains(EvolveItem.EvolutionaryMagicOfFire)
            && fairyTo.Element != Element.Fire
           )
        {
            return BadRequest("Фея может эволюционировать только в фею огня");
        }

        if (evolveKind == EvolveKind.EvolveFromItem
            && evolveItem.Contains(EvolveItem.ToolsOfTheDwarves)
            && fairyTo.Element != Element.Metal
           )
        {
            return BadRequest("Фея может эволюционировать только в фею металла");
        }

        _service.UpdateEvolve(evolveFromFormId, evolveKind, evolveLevel, evolveItem, evolveToFormId);
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