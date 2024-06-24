using Microsoft.EntityFrameworkCore;
using Zanzarah_fairy_book.Models;

namespace Zanzarah_fairy_book;

public class DataBaseContext : DbContext
{
    public DbSet<Fairy> Fairies { get; set; } = null!;
    
    public DataBaseContext()
    {}
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .SetBasePath(Directory.GetCurrentDirectory())
            .Build();
        optionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnection"));
    }
}