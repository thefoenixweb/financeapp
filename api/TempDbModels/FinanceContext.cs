using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace api.TempDbModels;

public partial class FinanceContext : DbContext
{
    public FinanceContext()
    {
    }

    public FinanceContext(DbContextOptions<FinanceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<BalanceSheetStatement> BalanceSheetStatements { get; set; }

    public virtual DbSet<CashFlowStatement> CashFlowStatements { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<CompanyProfile> CompanyProfiles { get; set; }

    public virtual DbSet<IncomeStatement> IncomeStatements { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Finance;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });

            entity.HasMany(d => d.Stocks).WithMany(p => p.AppUsers)
                .UsingEntity<Dictionary<string, object>>(
                    "Portfolio",
                    r => r.HasOne<Stock>().WithMany().HasForeignKey("StockId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("AppUserId"),
                    j =>
                    {
                        j.HasKey("AppUserId", "StockId");
                        j.ToTable("Portfolios");
                        j.HasIndex(new[] { "StockId" }, "IX_Portfolios_StockId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<BalanceSheetStatement>(entity =>
        {
            entity.HasIndex(e => e.StockId, "IX_BalanceSheetStatements_StockId");

            entity.Property(e => e.CalendarYear).HasColumnName("calendarYear");

            entity.HasOne(d => d.Stock).WithMany(p => p.BalanceSheetStatements).HasForeignKey(d => d.StockId);
        });

        modelBuilder.Entity<CashFlowStatement>(entity =>
        {
            entity.HasIndex(e => e.StockId, "IX_CashFlowStatements_StockId");

            entity.Property(e => e.CalendarYear).HasColumnName("calendarYear");

            entity.HasOne(d => d.Stock).WithMany(p => p.CashFlowStatements).HasForeignKey(d => d.StockId);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasIndex(e => e.AppUserId, "IX_Comments_AppUserId");

            entity.HasIndex(e => e.StockId, "IX_Comments_StockId");

            entity.Property(e => e.AppUserId).HasDefaultValue("");

            entity.HasOne(d => d.AppUser).WithMany(p => p.Comments).HasForeignKey(d => d.AppUserId);

            entity.HasOne(d => d.Stock).WithMany(p => p.Comments).HasForeignKey(d => d.StockId);
        });

        modelBuilder.Entity<CompanyProfile>(entity =>
        {
            entity.HasIndex(e => e.StockId, "IX_CompanyProfiles_StockId")
                .IsUnique()
                .HasFilter("([StockId] IS NOT NULL)");

            entity.HasOne(d => d.Stock).WithOne(p => p.CompanyProfile).HasForeignKey<CompanyProfile>(d => d.StockId);
        });

        modelBuilder.Entity<IncomeStatement>(entity =>
        {
            entity.HasIndex(e => e.StockId, "IX_IncomeStatements_StockId");

            entity.Property(e => e.CalendarYear).HasColumnName("calendarYear");

            entity.HasOne(d => d.Stock).WithMany(p => p.IncomeStatements).HasForeignKey(d => d.StockId);
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.Property(e => e.LastDiv).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Purchase).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
