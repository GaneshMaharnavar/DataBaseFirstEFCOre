using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataBaseFirstEFCOre.Models;

public partial class Dotnet8Context : DbContext
{
    public Dotnet8Context()
    {
    }

    public Dotnet8Context(DbContextOptions<Dotnet8Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Emp> Emps { get; set; }

    public virtual DbSet<Student8> Student8s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Emp>(entity =>
        {
            entity.HasKey(e => e.Empid).HasName("PK__Emp__AF2EBFA1F80907AD");

            entity.ToTable("Emp");

            entity.Property(e => e.Empid).ValueGeneratedNever();
            entity.Property(e => e.Documents)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("documents");
            entity.Property(e => e.Ename)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Qualification)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student8>(entity =>
        {
            entity.HasKey(e => e.SId).HasName("PK__Student8__A3DCCCA5B22D718F");

            entity.ToTable("Student8");

            entity.Property(e => e.SId)
                .ValueGeneratedNever()
                .HasColumnName("S_id");
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Sname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
