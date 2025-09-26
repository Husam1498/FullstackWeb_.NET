using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
namespace DataAccess.Concrete
{
    public class MsSqlContext:DbContext
    {

        public DbSet<Kullanicilar> Kullanicilar { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Colors> Colors { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Sizes> Sizes { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductColor> ProductColor { get; set; }
        public DbSet<ProductSize> ProductSize { get; set; }
       




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-S32BE3K;Database=DenemeWebNet; Trusted_Connection=True; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kullanicilar>()
                .HasKey(u => u.K_id);

            modelBuilder.Entity<Product>()
                 .Property(p => p.Price)
                 .HasColumnType("decimal(18,2)"); // Fiyat için hassasiyet ve ölçek tanımlandı

            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            modelBuilder.Entity<ProductCategory>()
                .HasOne(e => e.Product)  // ProductCategory, bir Product'a ait.
                .WithMany(p => p.ProductCategories)// Bir Product, birçok ProductCategory'ye sahip olabilir.
                .HasForeignKey(e => e.ProductId); // İlişki, ProductCategory tablosundaki ProductId ile bağlanır
           
            modelBuilder.Entity<ProductCategory>()
                .HasOne(e => e.Category) 
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(e => e.CategoryId); // İlişki, ProductCategory tablosundaki CategoryId ile bağlanır

            modelBuilder.Entity<ProductSize>()
                .HasKey(ps => new { ps.ProductId, ps.SizeId });

            modelBuilder.Entity<ProductSize>()
                .HasOne(ps => ps.Product)
                .WithMany(p => p.ProductSizes)
                .HasForeignKey(ps => ps.ProductId);

            modelBuilder.Entity<ProductSize>()
                .HasOne(ps => ps.Size)
                .WithMany(s => s.ProductSizes)
                .HasForeignKey(ps => ps.SizeId);

            modelBuilder.Entity<ProductColor>()
                 .HasKey(pc => new { pc.ProductId, pc.ColorId });

            modelBuilder.Entity<ProductColor>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductColors)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductColor>()
                .HasOne(pc => pc.Color)
                .WithMany(c => c.ProductColors)
                .HasForeignKey(pc => pc.ColorId);
            modelBuilder.Entity<Photo>()
                .Property(p => p.PhotoId)
                .ValueGeneratedOnAdd();


            modelBuilder.Entity<ProductCategory>().ToTable("ProductCategory");
            modelBuilder.Entity<ProductColor>().ToTable("ProductColor");
            modelBuilder.Entity<ProductSize>().ToTable("ProductSize");
            modelBuilder.Entity<Photo>().ToTable("Photo");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Colors>().ToTable("Colors");
            modelBuilder.Entity<Sizes>().ToTable("Sizes");


        }
    }
}
