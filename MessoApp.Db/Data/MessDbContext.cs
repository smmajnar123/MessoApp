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

    public virtual DbSet<AdminSubscriptionPayment> AdminSubscriptionPayments { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<MemberTransaction> MemberTransactions { get; set; }

    public virtual DbSet<Mess> Messes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admins__719FE488445AA774");

            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.AdminName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmailId)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("Male");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Subscription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("1 Month Free");
            entity.Property(e => e.SubscriptionPrice)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SubscriptionRemainingDays).HasDefaultValue(30);
            entity.Property(e => e.SubscriptionStartDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TotalActiveMemberCount).HasDefaultValue(0);
            entity.Property(e => e.TotalInActiveMemberCount).HasDefaultValue(0);
            entity.Property(e => e.TotalMemberCount).HasDefaultValue(0);
        });

        modelBuilder.Entity<AdminSubscriptionPayment>(entity =>
        {
            entity.HasKey(e => e.SubscriptionPaymentId).HasName("PK__AdminSub__8BE6C43B2B27ABC9");

            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.EndDate).HasDefaultValueSql("(dateadd(day,(30),getdate()))");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentMode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("UPI");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Paid");
            entity.Property(e => e.PlanDurationDays).HasDefaultValue(30);
            entity.Property(e => e.Remarks)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.SubscriptionPlan)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Monthly");

            entity.HasOne(d => d.Admin).WithMany(p => p.AdminSubscriptionPayments)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdminSubscriptionPayments_Admins");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK__Members__0CF04B18229BB742");

            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EmailId)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ExtraLunchDays).HasDefaultValue(0);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("Male");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.JoinedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LeaveDays).HasDefaultValue(0);
            entity.Property(e => e.MemberCategory)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Student");
            entity.Property(e => e.MemberName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MessType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Monthly");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.MonthlyPrice)
                .HasDefaultValue(0.00m)
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RemainingLunchDays).HasDefaultValue(0);
            entity.Property(e => e.TotalTiffinCount).HasDefaultValue(0);

            entity.HasOne(d => d.Mess).WithMany(p => p.Members)
                .HasForeignKey(d => d.MessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Members_Messes");
        });

        modelBuilder.Entity<MemberTransaction>(entity =>
        {
            entity.HasKey(e => e.MemberTransactionId).HasName("PK__MemberTr__5A28B3B4924D1318");

            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PaymentMode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Cash");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Paid");
            entity.Property(e => e.Remarks)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TransactionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Member).WithMany(p => p.MemberTransactions)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MemberTransactions_Members");
        });

        modelBuilder.Entity<Mess>(entity =>
        {
            entity.HasKey(e => e.MessId).HasName("PK__Messes__9CC50CDD17624153");

            entity.Property(e => e.ActiveMemberCount).HasDefaultValue(0);
            entity.Property(e => e.InActiveMemberCount).HasDefaultValue(0);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.MembersCount).HasDefaultValue(0);
            entity.Property(e => e.MessAddress)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.MessGender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("Mixed");
            entity.Property(e => e.MessName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Admin).WithMany(p => p.Messes)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Messes_Admins");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
