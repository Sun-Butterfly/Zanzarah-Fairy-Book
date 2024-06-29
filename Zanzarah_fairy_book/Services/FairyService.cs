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
    public void UpdateEvolve(Fairy fairy, EvolveForm evolveForm)
    {
        _db.Fairies.Update(fairy);
        _db.EvolveForms?.Update(evolveForm);
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

    public bool CanEvolveByLevel(Fairy fairy)
    {
        if (fairy.EvolveKind == EvolveKind.None || fairy.EvolveKind == EvolveKind.EvolveFromItem)
        {
            return false;
        }
        return true;
    }
    
    public bool CanEvolveByItem(Fairy fairy)
    {
        if (fairy.EvolveKind == EvolveKind.None || fairy.EvolveKind == EvolveKind.EvolveFromLevel)
        {
            return false;
        }
        return true;
    }

    
    public bool IsCorrectEvolve_ByLevel_Element(Fairy fairy)
    {
        // if (fairy.Element != evolveForm.Element)
        // {
        //     return false;
        // }
        // TODO: 
        return true;
    }
    
}