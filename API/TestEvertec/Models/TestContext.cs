using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestEvertec.Models;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCustomer> TblCustomers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCustomer>(entity =>
        {
            entity.HasKey(e => e.IdCustomer).HasName("PK__tblCusto__D0587686041D9BDE");

            entity.ToTable("tblCustomers");

            entity.Property(e => e.IdCustomer).HasColumnName("idCustomer");
            entity.Property(e => e.Birthdate).HasColumnType("datetime");
            entity.Property(e => e.LastName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
