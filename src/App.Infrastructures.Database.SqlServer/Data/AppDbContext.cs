global using System;
global using System.Collections.Generic;
global using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using App.Infrastructures.Database.SqlServer.Entities;

namespace App.Infrastructures.Database.SqlServer.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        //public AppDbContext(DbContextOptions<AppDbContext> options)
        //    : base(options)
        //{
        //}

        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Collection> Collections { get; set; } = null!;
        public virtual DbSet<CollectionProduct> CollectionProducts { get; set; } = null!;
        public virtual DbSet<App.Infrastructures.Database.SqlServer.Entities.Color> Colors { get; set; } = null!;
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
                optionsBuilder.UseSqlServer("Data Source=.\\sql2019; Initial Catalog=DotNetShopDb; Integrated Security=TRUE");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>(entity =>
            {
                entity
                .HasOne(x => x.ParentCagetory)
                .WithMany(x => x.ChildCategories)
                .HasForeignKey(x => x.ParentCagetoryId);
            });

            modelBuilder.Entity<CollectionProduct>(entity =>
            {
                entity.HasIndex(e => e.CollectionId, "IX_CollectionProducts_CollectionId");

                entity.HasOne(d => d.Collection)
                    .WithMany(p => p.CollectionProducts)
                    .HasForeignKey(d => d.CollectionId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CollectionProducts)
                    .HasForeignKey(d => d.CollectionId);
            });


            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasIndex(e => e.ProductId, "IX_Comments_ProductId");

                entity.HasIndex(e => e.StatusId, "IX_Comments_StatusId");

                entity.HasIndex(e => e.UserId, "IX_Comments_UserId");


                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ProductId);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.StatusId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId);
                entity.HasOne(x => x.ParentComment)
                    .WithMany(x => x.ChildComments)
                    .HasForeignKey(x => x.ParentCommentId);
            });


            modelBuilder.Entity<FileTypeExtention>(entity =>
            {
                entity.HasOne(x => x.FileType)
                    .WithMany(x => x.FileTypeExtentions)
                    .HasForeignKey(x => x.FileTypeId);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasOne(x => x.ParentModel)
                    .WithMany(x => x.ChildModels)
                    .HasForeignKey(x => x.ParentModelId);
            });


            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.BrandId, "IX_Products_BrandId");

                entity.HasIndex(e => e.CategoryId, "IX_Products_CategoryId");

                entity.HasIndex(e => e.ModelId, "IX_Products_ModelId");

                entity.HasIndex(e => e.OperatorId, "IX_Products_OperatorId");

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


                entity.HasOne(d => d.Color)
                    .WithMany(p => p.ProductColors)
                    .HasForeignKey(d => d.ColorId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductColors)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<ProductFile>(entity =>
            {
                entity.HasIndex(e => e.FileTypeExtentionId, "IX_ProductFiles_FileTypeId");

                entity.HasIndex(e => e.ProductId, "IX_ProductFiles_ProductId");

                entity.HasOne(d => d.FileTypeExtention)
                    .WithMany(p => p.ProductFiles)
                    .HasForeignKey(d => d.FileTypeExtentionId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductFiles)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<ProductTag>(entity =>
            {
                entity.HasIndex(e => e.ProductId, "IX_ProductTags_ProductId");

                entity.HasIndex(e => e.TagId, "IX_ProductTags_TagId");

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

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductViews)
                    .HasForeignKey(d => d.ProductId);
            });


            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasIndex(e => e.TagCategoryId, "IX_Tags_TagCategoryId");

                entity.HasOne(d => d.TagCategory)
                    .WithMany(p => p.Tags)
                    .HasForeignKey(d => d.TagCategoryId);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
