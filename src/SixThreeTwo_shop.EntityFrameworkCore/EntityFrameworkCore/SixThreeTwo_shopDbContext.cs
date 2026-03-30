using Abp.Zero.EntityFrameworkCore;
using SixThreeTwo_shop.Authorization.Roles;
using SixThreeTwo_shop.Authorization.Users;
using SixThreeTwo_shop.MultiTenancy;
using SixThreeTwo_shop.Products;
using SixThreeTwo_shop.Users;
using Microsoft.EntityFrameworkCore;
using SixThreeTwo_shop.Orders;
using SixThreeTwo_shop.Reviews;
using SixThreeTwo_shop.Wishlists;

namespace SixThreeTwo_shop.EntityFrameworkCore;

public class SixThreeTwo_shopDbContext(DbContextOptions<SixThreeTwo_shopDbContext> options)
  : AbpZeroDbContext<Tenant, Role, User, SixThreeTwo_shopDbContext>(options)
{
  public DbSet<UserAddress> UserAddresses { get; set; }

  public DbSet<SavedVehicle> SavedVehicles { get; set; }

  public DbSet<Product> Products { get; set; }

  public DbSet<ProductCategory> ProductCategories { get; set; }

  public DbSet<ProductImage> ProductImages { get; set; }

  public DbSet<ProductToCategory> ProductToCategories { get; set; }

  public DbSet<VehicleCompability> VehicleCompabilities { get; set; }

  public DbSet<ReturnItem> ReturnItems { get; set; }

  public DbSet<OrderItem> OrderItems { get; set; }

  public DbSet<Order> Orders { get; set; }

  public DbSet<Return> Returns { get; set; }

  public DbSet<Promotion> Promotions { get; set; }

  public DbSet<Review> Reviews { get; set; }

  public DbSet<Wishlist> Wishlists { get; set; }
}
