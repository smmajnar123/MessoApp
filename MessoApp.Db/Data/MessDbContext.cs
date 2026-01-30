using System;
using System.Collections.Generic;
using MessoApp.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace MessoApp.Db.Data;

public partial class MessDbContext : DbContext
{
    public MessDbContext()
    {
    }

    public MessDbContext(DbContextOptions<MessDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AdminSubscriptionDetail> AdminSubscriptionDetails { get; set; }

    public virtual DbSet<MemberMessDetail> MemberMessDetails { get; set; }

    public virtual DbSet<MemberProfile> MemberProfiles { get; set; }

    public virtual DbSet<MemberTransaction> MemberTransactions { get; set; }

    public virtual DbSet<Mess> Messes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=GJSHD-0520\\SQLEXPRESS;Initial Catalog=TestMessDb;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.AdminName).HasMaxLength(200);
            entity.Property(e => e.EmailId).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.MobileNumber).HasMaxLength(50);
        });

        modelBuilder.Entity<AdminSubscriptionDetail>(entity =>
        {
            entity.HasKey(e => e.SubscriptionPaymentId);

            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.EndDate).HasDefaultValueSql("(CONVERT([date],dateadd(day,(30),getdate())))");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentMode)
                .HasMaxLength(20)
                .HasDefaultValue("UPI");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(20)
                .HasDefaultValue("Paid");
            entity.Property(e => e.PlanDurationDays).HasDefaultValue(30);
            entity.Property(e => e.Remarks).HasMaxLength(200);
            entity.Property(e => e.StartDate).HasDefaultValueSql("(CONVERT([date],getdate()))");
            entity.Property(e => e.SubscriptionPlan)
                .HasMaxLength(50)
                .HasDefaultValue("Monthly");

            entity.HasOne(d => d.Admin).WithMany(p => p.AdminSubscriptionDetails)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdminSubscriptionDetails_Admins");
        });

        modelBuilder.Entity<MemberMessDetail>(entity =>
        {
            entity.Property(e => e.MemberCategory).HasMaxLength(50);
            entity.Property(e => e.MessType).HasMaxLength(50);
            entity.Property(e => e.MonthlyPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Mess).WithMany(p => p.MemberMessDetails)
                .HasForeignKey(d => d.MessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberMessDetails_Messes");

            entity.HasOne(d => d.Profile).WithMany(p => p.MemberMessDetails)
                .HasForeignKey(d => d.ProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberMessDetails_MemberProfiles");
        });

        modelBuilder.Entity<MemberProfile>(entity =>
        {
            entity.HasKey(e => e.ProfileId);

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.EmailId).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.MemberName).HasMaxLength(200);
            entity.Property(e => e.MobileNumber).HasMaxLength(50);

            entity.HasOne(d => d.Admin).WithMany(p => p.MemberProfiles)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberProfiles_Admins");
        });

        modelBuilder.Entity<MemberTransaction>(entity =>
        {
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentMode).HasMaxLength(50);
            entity.Property(e => e.PaymentStatus).HasMaxLength(50);
            entity.Property(e => e.RemainingAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.TotalPaidAmount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TransactionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.MemberMessDetail).WithMany(p => p.MemberTransactions)
                .HasForeignKey(d => d.MemberMessDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberTransactions_MemberMessDetails");

            entity.HasOne(d => d.Mess).WithMany(p => p.MemberTransactions)
                .HasForeignKey(d => d.MessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberTransactions_Messes");
        });

        modelBuilder.Entity<Mess>(entity =>
        {
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.MessAddress).HasMaxLength(200);
            entity.Property(e => e.MessEmail).HasMaxLength(100);
            entity.Property(e => e.MessMobile).HasMaxLength(50);
            entity.Property(e => e.MessName).HasMaxLength(100);

            entity.HasOne(d => d.Admin).WithMany(p => p.Messes)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Messes_Admins");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
