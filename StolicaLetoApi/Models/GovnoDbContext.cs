using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StolicaLetoApi.Models;

public partial class GovnoDbContext : DbContext
{
    public GovnoDbContext()
    {
    }

    public GovnoDbContext(DbContextOptions<GovnoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<QuestionnaireDto> QuestionnaireDtos { get; set; }

    public virtual DbSet<Smena> Smenas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=govnoDB;Username=postgres;Password=vagina21519687");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<QuestionnaireDto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Smena_pkey");

            entity.ToTable("QuestionnaireDTO");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Qimage)
                .HasColumnType("bit(1)[]")
                .HasColumnName("QImage");
            entity.Property(e => e.Qvideo)
                .HasColumnType("bit(1)[]")
                .HasColumnName("QVideo");
        });

        modelBuilder.Entity<Smena>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("number_pkey");

            entity.ToTable("Smena");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Color).HasColumnName("color");
            entity.Property(e => e.Dates).HasColumnName("dates");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsAvailable).HasColumnName("isAvailable");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
