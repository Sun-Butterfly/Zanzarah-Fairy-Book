namespace Zanzarah_fairy_book.Models;

public class EvolveForm
{
    public int FromId { get; set; }

    public Fairy From { get; set; }

    public EvolveKind EvolveKind { get; set; }
    public int EvolveLevel { get; set; }
    public List<EvolveItem>? EvolveItem { get; set; } = new();
    public int ToId { get; set; }

    public Fairy To { get; set; }
}