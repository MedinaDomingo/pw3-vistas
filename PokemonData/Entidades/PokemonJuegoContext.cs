using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PokemonData.Entidades;

public partial class PokemonJuegoContext : DbContext
{
    public PokemonJuegoContext()
    {
    }

    public PokemonJuegoContext(DbContextOptions<PokemonJuegoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ataque> Ataques { get; set; }

    public virtual DbSet<Pokemon> Pokemons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS01;Database=Pokemon-Juego;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ataque>(entity =>
        {
            entity.ToTable("Ataque");

            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsFixedLength();

            entity.HasOne(d => d.IdPokemonNavigation).WithMany(p => p.Ataques)
                .HasForeignKey(d => d.IdPokemon)
                .HasConstraintName("FK_Ataque_Pokemon");
        });

        modelBuilder.Entity<Pokemon>(entity =>
        {
            entity.ToTable("Pokemon");

            entity.Property(e => e.Imagen).HasColumnType("ntext");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Vida).HasDefaultValueSql("((100))");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
