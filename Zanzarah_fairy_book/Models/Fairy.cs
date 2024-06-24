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
    public bool CanEvolve { get; set; }
    public int EvolveLevel { get; set; }
    
    public int? EvolveFormId { get; set; }
    public Fairy? EvolveForm { get; set; }

}