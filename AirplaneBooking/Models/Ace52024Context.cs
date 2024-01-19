using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AirplaneBooking.Models;

public partial class Ace52024Context : DbContext
{
    public Ace52024Context()
    {
    }

    public Ace52024Context(DbContextOptions<Ace52024Context> options)
        : base(options)
    {
    }
    public virtual DbSet<PriyankaBooking> PriyankaBookings { get; set; }

    public virtual DbSet<PriyankaCustomer> PriyankaCustomers { get; set; }

    public virtual DbSet<PriyankaFlight> PriyankaFlights { get; set; }

    public virtual DbSet<UserTable> UserTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DEVSQL.Corp.local;Database=ACE 5- 2024;Trusted_Connection=True;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PriyankaBooking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Priyanka__73951AED913196B0");

            entity.Property(e => e.BookingId).ValueGeneratedNever();
            entity.Property(e => e.BookingDate).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.PriyankaBookings)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__PriyankaB__Custo__46486B8E");

            entity.HasOne(d => d.Flight).WithMany(p => p.PriyankaBookings)
                .HasForeignKey(d => d.FlightId)
                .HasConstraintName("FK__PriyankaB__Fligh__45544755");
        });

        modelBuilder.Entity<PriyankaCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Priyanka__A4AE64D8F3098995");

            entity.ToTable("PriyankaCustomer");

            entity.Property(e => e.CustomerId).ValueGeneratedNever();
            entity.Property(e => e.CustomerName).HasMaxLength(255);
            entity.Property(e => e.Location).HasMaxLength(255);
        });

        modelBuilder.Entity<PriyankaFlight>(entity =>
        {
            entity.HasKey(e => e.FlightId).HasName("PK__Priyanka__8A9E14EED0F934C1");

            entity.Property(e => e.FlightId).ValueGeneratedNever();
            entity.Property(e => e.Destination)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FlightName).HasMaxLength(255);
            entity.Property(e => e.Source).HasMaxLength(255);
        });

        modelBuilder.Entity<UserTable>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__UserTabl__A9D10535637D568A");

            entity.ToTable("UserTable");

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
