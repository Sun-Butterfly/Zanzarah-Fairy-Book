using Zanzarah_fairy_book.Models;

namespace Zanzarah_fairy_book.Services;

public class FairyService
{
    DataBaseContext _db;

    public FairyService(DataBaseContext db)
    {
        _db = db;
    }

    public Fairy? GetById(int id)
    {
        var fairy = _db.Fairies
            .FirstOrDefault(x => x.Id == id);

        return fairy;
    }

    public Fairy? GetByName(string name)
    {
        var fairy = _db.Fairies
            .FirstOrDefault(x => x.Name == name);

        return fairy;
    }

    public void Add(Fairy fairy)
    {
        _db.Fairies.Add(fairy);
        _db.SaveChanges();
    }

    public void Update(Fairy fairy)
    {
        _db.Fairies.Update(fairy);
        _db.SaveChanges();
    }

    public void UpdateEvolve(int fairyFromId, int fairyToId)
    {
        _db.EvolveForms.Add(new EvolveForm()
        {
            FromId = fairyFromId,
            ToId = fairyToId
        });
        _db.SaveChanges();
    }

    public void Delete(int id)
    {
        var fairy = _db.Fairies.FirstOrDefault(x => x.Id == id);
        _db.Remove(fairy);
        _db.SaveChanges();
    }

    public bool ExistsById(int id)
    {
        var fairy = _db.Fairies
            .FirstOrDefault(x => x.Id == id);
        if (fairy == null)
        {
            return false;
        }

        return true;
    }

    public bool ExistsByName(string name)
    {
        var fairy = _db.Fairies
            .FirstOrDefault(x => x.Name == name);
        if (fairy == null)
        {
            return false;
        }

        return true;
    }

    public bool CanEvolve(Fairy fairy)
    {
        if (fairy.EvolveKind == EvolveKind.None)
        {
            return false;
        }

        return true;
    }
    public bool CanEvolveByLevel(Fairy fairy)
    {
        if (CanEvolve(fairy) && fairy.EvolveKind == EvolveKind.EvolveFromItem)
        {
            return false;
        }

        return true;
    }

    public bool CanEvolveByItem(Fairy fairy)
    {
        if (CanEvolve(fairy) && fairy.EvolveKind == EvolveKind.EvolveFromLevel)
        {
            return false;
        }

        return true;
    }


    public bool IsCorrectEvolve_ByLevel_Element(Fairy fairy1, Fairy fairy2)
    {
        if (fairy1.Element != fairy2.Element)
        {
            return false;
        }
        return true;
    }
    // public bool IsCorrectEvolve_ByItem_Element(Fairy fairy1, Fairy fairy2)
    // {
    //     if (fairy1.Element != fairy2.Element)
    //     {
    //         return false;
    //     }
    //     return true;
    // } //TODO:
}