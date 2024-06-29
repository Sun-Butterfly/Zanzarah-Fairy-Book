namespace Zanzarah_fairy_book.Models;

public class Fairy
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public Element Element { get; set; }
    public int HitPoints { get; set; }
    public int Dexterity { get; set; }
    public int JumpAbility { get; set; }
    public int Special { get; set; }
    public EvolveKind EvolveKind { get; set; }
    public int EvolveLevel { get; set; }
    public EvolveItem EvolveItem { get; set; }
    
    public int? EvolveFormId { get; set; }
    

}