using Microsoft.EntityFrameworkCore;
using Zanzarah_fairy_book.Models;

namespace Zanzarah_fairy_book;

public class DataBaseContext : DbContext
{
    public DbSet<Fairy> Fairies { get; set; } = null!;
    public DbSet<EvolveForm> EvolveForms { get; set; } = null!;

    public DataBaseContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .SetBasePath(Directory.GetCurrentDirectory())
            .Build();
        optionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<EvolveForm>()
            .HasOne(x => x.From)
            .WithMany(x => x.EvolveToForms)
            .HasForeignKey(x => x.FromId);

        modelBuilder
            .Entity<EvolveForm>()
            .HasOne(x => x.To)
            .WithMany(x => x.EvolveFromForms)
            .HasForeignKey(x => x.ToId);
        
        //перевод листа енумов в массив строк
        modelBuilder
            .Entity<EvolveForm>()
            .Property(e => e.EvolveItem)
            .HasConversion(
                v => string.Join(",", v.Select(e => e.ToString("G"))),
                v => v.Split(new[] { ',' })
                    .Select(Enum.Parse<EvolveItem>)
                    .ToList()
            );
        
        
        
        modelBuilder.Entity<EvolveForm>()
            .HasKey(x => new { x.FromId, x.ToId });
    }
}