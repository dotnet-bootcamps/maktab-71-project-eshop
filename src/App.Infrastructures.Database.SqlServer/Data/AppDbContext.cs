﻿using Microsoft.EntityFrameworkCore;
using App.Domain.Core.Product.Entities;
using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Operator.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace App.Infrastructures.Database.SqlServer.Data
{
    public partial class AppDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>,int>
    {


        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<CategorySpacification> CategorySpacifications { get; set; } = null!;
        public virtual DbSet<Collection> Collections { get; set; } = null!;
        public virtual DbSet<CollectionProduct> CollectionProducts { get; set; } = null!;
        public virtual DbSet<Color> Colors { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<FileType> FileTypes { get; set; } = null!;
        public virtual DbSet<FileTypeExtention> FileTypeExtentions { get; set; } = null!;
        public virtual DbSet<Model> Models { get; set; } = null!;
        public virtual DbSet<Operator> Operators { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductColor> ProductColors { get; set; } = null!;
        public virtual DbSet<ProductFile> ProductFiles { get; set; } = null!;
        public virtual DbSet<ProductTag> ProductTags { get; set; } = null!;
        public virtual DbSet<ProductView> ProductViews { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;
        public virtual DbSet<TagCategory> TagCategories { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=DotNetShopDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<CategorySpacification>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategorySpacifications)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategorySpacifications_Categories");

                entity.HasOne(d => d.TagCategory)
                    .WithMany(p => p.CategorySpacifications)
                    .HasForeignKey(d => d.TagCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategorySpacifications_TagCategories");
            });

            modelBuilder.Entity<Collection>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<CollectionProduct>(entity =>
            {
                entity.HasIndex(e => e.CollectionId, "IX_CollectionProducts_CollectionId");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.HasOne(d => d.Collection)
                    .WithMany(p => p.CollectionProducts)
                    .HasForeignKey(d => d.CollectionId);

                entity.HasOne(d => d.CollectionNavigation)
                    .WithMany(p => p.CollectionProducts)
                    .HasForeignKey(d => d.CollectionId);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasIndex(e => e.ProductId, "IX_Comments_ProductId");

                entity.HasIndex(e => e.StatusId, "IX_Comments_StatusId");

                entity.HasIndex(e => e.UserId, "IX_Comments_UserId");

                entity.Property(e => e.CommentText).HasMaxLength(3000);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ProductId);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.StatusId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<FileType>(entity =>
            {
                entity.ToTable("fileTypes");

                entity.HasIndex(e => e.FileTypeExtentionId, "IX_fileTypes_FileTypeExtentionId");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.HasOne(d => d.FileTypeExtention)
                    .WithMany(p => p.FileTypes)
                    .HasForeignKey(d => d.FileTypeExtentionId);
            });

            modelBuilder.Entity<FileTypeExtention>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Operator>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.BrandId, "IX_Products_BrandId");

                entity.HasIndex(e => e.CategoryId, "IX_Products_CategoryId");

                entity.HasIndex(e => e.ModelId, "IX_Products_ModelId");

                entity.HasIndex(e => e.OperatorId, "IX_Products_OperatorId");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ModelId);

                entity.HasOne(d => d.Operator)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.OperatorId);
            });

            modelBuilder.Entity<ProductColor>(entity =>
            {
                entity.HasIndex(e => e.ColorId, "IX_ProductColors_ColorId");

                entity.HasIndex(e => e.ProductId, "IX_ProductColors_ProductID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.ProductColors)
                    .HasForeignKey(d => d.ColorId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductColors)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<ProductFile>(entity =>
            {
                entity.HasIndex(e => e.FileTypeId, "IX_ProductFiles_FileTypeId");

                entity.HasIndex(e => e.ProductId, "IX_ProductFiles_ProductId");

                entity.HasOne(d => d.FileType)
                    .WithMany(p => p.ProductFiles)
                    .HasForeignKey(d => d.FileTypeId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductFiles)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<ProductTag>(entity =>
            {
                entity.HasIndex(e => e.ProductId, "IX_ProductTags_ProductId");

                entity.HasIndex(e => e.TagId, "IX_ProductTags_TagId");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Value).HasMaxLength(500);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductTags)
                    .HasForeignKey(d => d.ProductId);

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.ProductTags)
                    .HasForeignKey(d => d.TagId);
            });

            modelBuilder.Entity<ProductView>(entity =>
            {
                entity.HasIndex(e => e.ProductId, "IX_ProductViews_ProductId");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductViews)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasIndex(e => e.TagCategoryId, "IX_Tags_TagCategoryId");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.HasOne(d => d.TagCategory)
                    .WithMany(p => p.Tags)
                    .HasForeignKey(d => d.TagCategoryId);
            });

            modelBuilder.Entity<TagCategory>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
