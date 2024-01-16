using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace bank.Models;

public partial class Ace52024Context : DbContext
{
    public Ace52024Context()
    {
    }

    public Ace52024Context(DbContextOptions<Ace52024Context> options)
        : base(options)
    {
    }

    public virtual DbSet<PriyankaSbaccount> PriyankaSbaccounts { get; set; }

    public virtual DbSet<PriyankaSbtransaction> PriyankaSbtransactions { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DEVSQL.Corp.local;Database=ACE 5- 2024;Trusted_Connection=True;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
 

        modelBuilder.Entity<PriyankaSbaccount>(entity =>
        {
            entity.HasKey(e => e.AccountNumber).HasName("PK__Priyanka__BE2ACD6E0DCCC692");

            entity.ToTable("PriyankaSBAccount");

            entity.Property(e => e.AccountNumber).ValueGeneratedNever();
            entity.Property(e => e.CurrentBalance).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PriyankaSbtransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Priyanka__55433A6B0231BAB5");

            entity.ToTable("PriyankaSBTransaction");

            entity.Property(e => e.TransactionId).ValueGeneratedNever();
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.AccountNumberNavigation).WithMany(p => p.PriyankaSbtransactions)
                .HasForeignKey(d => d.AccountNumber)
                .HasConstraintName("FK__PriyankaS__Accou__70A8B9AE");
        });

  
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
