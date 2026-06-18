using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Data.Models;

namespace StoreManagementSystem.Data;

public class AppDbContext : DbContext
{
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<SaleOrder> SaleOrders => Set<SaleOrder>();
    public DbSet<SaleItem> SaleItems => Set<SaleItem>();
    public DbSet<StockIn> StockIns => Set<StockIn>();
    public DbSet<StockOut> StockOuts => Set<StockOut>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>(e =>
        {
            e.HasIndex(p => p.Barcode).IsUnique().HasFilter("[Barcode] IS NOT NULL");
            e.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<SaleOrder>(e =>
        {
            e.HasIndex(o => o.OrderNo).IsUnique();
            e.HasOne(o => o.Customer)
                .WithMany(c => c.SaleOrders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<SaleItem>(e =>
        {
            e.HasOne(si => si.SaleOrder)
                .WithMany(o => o.SaleItems)
                .HasForeignKey(si => si.SaleOrderId)
                .OnDelete(DeleteBehavior.Cascade);
            e.HasOne(si => si.Product)
                .WithMany(p => p.SaleItems)
                .HasForeignKey(si => si.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<StockIn>(e =>
        {
            e.HasOne(si => si.Product)
                .WithMany(p => p.StockIns)
                .HasForeignKey(si => si.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<StockOut>(e =>
        {
            e.HasOne(s => s.Product)
                .WithMany(p => p.StockOuts)
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Seed data
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "饮料", Description = "各类饮品" },
            new Category { Id = 2, Name = "零食", Description = "休闲食品" },
            new Category { Id = 3, Name = "日用品", Description = "日常用品" },
            new Category { Id = 4, Name = "其他", Description = "其他商品" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "农夫山泉矿泉水", Barcode = "6901010101001", CostPrice = 1.2m, SalePrice = 2.0m, StockQuantity = 100, LowStockThreshold = 20, CategoryId = 1 },
            new Product { Id = 2, Name = "可口可乐330ml", Barcode = "6901010101002", CostPrice = 2.0m, SalePrice = 3.0m, StockQuantity = 80, LowStockThreshold = 20, CategoryId = 1 },
            new Product { Id = 3, Name = "乐事薯片原味", Barcode = "6901010101003", CostPrice = 4.5m, SalePrice = 7.0m, StockQuantity = 50, LowStockThreshold = 10, CategoryId = 2 },
            new Product { Id = 4, Name = "奥利奥饼干", Barcode = "6901010101004", CostPrice = 6.0m, SalePrice = 9.0m, StockQuantity = 40, LowStockThreshold = 10, CategoryId = 2 },
            new Product { Id = 5, Name = "维达抽纸(3包装)", Barcode = "6901010101005", CostPrice = 8.0m, SalePrice = 12.0m, StockQuantity = 30, LowStockThreshold = 5, CategoryId = 3 }
        );
    }
}
