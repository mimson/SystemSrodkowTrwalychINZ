using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SrodkiTrwale.Api.Models
{
    public partial class SystemSrodkowTrwalychContext : DbContext
    {
        public SystemSrodkowTrwalychContext()
        {
        }

        public SystemSrodkowTrwalychContext(DbContextOptions<SystemSrodkowTrwalychContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Amortization> Amortizations { get; set; }
        public virtual DbSet<AmortizationRow> AmortizationRows { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<FixedAsset> FixedAssets { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }
        public virtual DbSet<Raport> Raports { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=SystemSrodkowTrwalych;Trusted_Connection=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Amortization>(entity =>
            {
                entity.ToTable("Amortization");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.FixedAssetsId).HasColumnName("FixedAssetsID");

                entity.Property(e => e.ModificationDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<AmortizationRow>(entity =>
            {
                entity.ToTable("AmortizationRow");

                entity.HasIndex(e => e.AmortizationId, "IX_AmortizationId");

                entity.HasIndex(e => e.FixedAssetId, "IX_FixedAssetId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.Amortization)
                    .WithMany(p => p.AmortizationRows)
                    .HasForeignKey(d => d.AmortizationId)
                    .HasConstraintName("FK_dbo.AmortizationRow_dbo.Amortization_AmortizationId");

                entity.HasOne(d => d.FixedAsset)
                    .WithMany(p => p.AmortizationRows)
                    .HasForeignKey(d => d.FixedAssetId)
                    .HasConstraintName("FK_dbo.AmortizationRow_dbo.FixedAssets_FixedAssetId");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<FixedAsset>(entity =>
            {
                entity.HasIndex(e => e.AmortizationId, "IX_Amortization_ID");

                entity.HasIndex(e => e.CategoriesId, "IX_CategoriesID");

                entity.HasIndex(e => e.UserId, "IX_UserID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AmortizationId).HasColumnName("Amortization_ID");

                entity.Property(e => e.CategoriesId).HasColumnName("CategoriesID");

                entity.Property(e => e.DateOfCollections).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Amortization)
                    .WithMany(p => p.FixedAssets)
                    .HasForeignKey(d => d.AmortizationId)
                    .HasConstraintName("FK_dbo.FixedAssets_dbo.Amortization_Amortization_ID");

                entity.HasOne(d => d.Categories)
                    .WithMany(p => p.FixedAssets)
                    .HasForeignKey(d => d.CategoriesId)
                    .HasConstraintName("FK_dbo.FixedAssets_dbo.Categories_CategoriesID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FixedAssets)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.FixedAssets_dbo.Users_UserID");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Raport>(entity =>
            {
                entity.HasIndex(e => e.FixedAssetsId, "IX_FixedAssets_ID");

                entity.HasIndex(e => e.UsersId, "IX_Users_ID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreactionDate).HasColumnType("datetime");

                entity.Property(e => e.FixedAssetsId).HasColumnName("FixedAssets_ID");

                entity.Property(e => e.UsersId).HasColumnName("Users_ID");

                entity.HasOne(d => d.FixedAssets)
                    .WithMany(p => p.Raports)
                    .HasForeignKey(d => d.FixedAssetsId)
                    .HasConstraintName("FK_dbo.Raports_dbo.FixedAssets_FixedAssets_ID");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Raports)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("FK_dbo.Raports_dbo.Users_Users_ID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserRolesId, "IX_UserRolesID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UserRolesId).HasColumnName("UserRolesID");

                entity.HasOne(d => d.UserRoles)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRolesId)
                    .HasConstraintName("FK_dbo.Users_dbo.UserRoles_UserRolesID");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
