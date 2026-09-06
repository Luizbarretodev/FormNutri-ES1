using FormNutri_ES1.Entities;
using Microsoft.EntityFrameworkCore;

namespace FormNutri_ES1.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<RegistroAvaliacao> RegistroAvaliacoes => Set<RegistroAvaliacao>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RegistroAvaliacao>(builder =>
        {
            builder.OwnsOne(r => r.Respondente);
            builder.OwnsOne(r => r.RespostaEbia);

            builder.OwnsOne(r => r.MarcadorConsumo, marcador =>
            {
                marcador.Property(m => m.RefeicoesRealizadas)
                    .HasConversion(
                        lista => string.Join(',', lista),
                        texto => texto.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                    );
            });

            builder.HasOne<Usuario>()
                .WithMany()
                .HasForeignKey(r => r.AplicadorId);
        });

        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.Email)
            .IsUnique();
    }
}