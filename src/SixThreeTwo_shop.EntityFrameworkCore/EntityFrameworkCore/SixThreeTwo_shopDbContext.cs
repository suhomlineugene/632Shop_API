using Abp.Zero.EntityFrameworkCore;
using SixThreeTwo_shop.Authorization.Roles;
using SixThreeTwo_shop.Authorization.Users;
using SixThreeTwo_shop.MultiTenancy;
using SixThreeTwo_shop.Products;
using SixThreeTwo_shop.Users;
using Microsoft.EntityFrameworkCore;
using SixThreeTwo_shop.Cars;
using SixThreeTwo_shop.Orders;
using SixThreeTwo_shop.Reviews;
using SixThreeTwo_shop.Wishlists;

namespace SixThreeTwo_shop.EntityFrameworkCore;

public class SixThreeTwo_shopDbContext(DbContextOptions<SixThreeTwo_shopDbContext> options)
  : AbpZeroDbContext<Tenant, Role, User, SixThreeTwo_shopDbContext>(options)
{
  // ── Users ──────────────────────────────────────────────────
  public DbSet<UserAddress> UserAddresses { get; set; }
  public DbSet<SavedVehicle> SavedVehicles { get; set; }

  // ── Products ───────────────────────────────────────────────
  public DbSet<Product> Products { get; set; }
  public DbSet<ProductImage> ProductImages { get; set; }
  public DbSet<MotorOil> MotorOils { get; set; }
  public DbSet<TransmissionFluid> TransmissionFluids { get; set; }
  public DbSet<Coolant> Coolants { get; set; }
  public DbSet<Additive> Additives { get; set; }
  public DbSet<OilApproval> OilApprovals { get; set; }
  public DbSet<ManufacturerApproval> ManufacturerApprovals { get; set; }
  public DbSet<MotorOilToOilApproval> MotorOilToOilApprovals { get; set; }
  public DbSet<MotorOilManufacturerApproval> MotorOilManufacturerApprovals { get; set; }
  public DbSet<TransmissionFluidManufacturerApproval> TransmissionFluidManufacturerApprovals { get; set; }
  public DbSet<VehicleSpecToOilApproval> VehicleSpecToOilApprovals { get; set; }
  public DbSet<VehicleSpecToManufacturerApproval> VehicleSpecToManufacturerApprovals { get; set; }

  // ── Orders ─────────────────────────────────────────────────
  public DbSet<Order> Orders { get; set; }
  public DbSet<OrderItem> OrderItems { get; set; }
  public DbSet<Return> Returns { get; set; }
  public DbSet<ReturnItem> ReturnItems { get; set; }
  public DbSet<Promotion> Promotions { get; set; }

  // ── Reviews ────────────────────────────────────────────────
  public DbSet<Review> Reviews { get; set; }

  // ── Wishlists ──────────────────────────────────────────────
  public DbSet<Wishlist> Wishlists { get; set; }

  // ── Cars ───────────────────────────────────────────────────
  public DbSet<CarBrand> CarBrands { get; set; }
  public DbSet<CarModel> CarModels { get; set; }
  public DbSet<VehicleVariant> VehicleVariants { get; set; }
}
