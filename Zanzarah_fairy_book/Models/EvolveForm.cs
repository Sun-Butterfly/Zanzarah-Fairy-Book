namespace Zanzarah_fairy_book.Models;

public class EvolveForm
{
    public int FromId { get; set; }

    public Fairy From { get; set; }

    public int ToId { get; set; }

    public Fairy To { get; set; }
}