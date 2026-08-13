# AGENTS.md

## Architecture Overview
This is an **ASP.NET Boilerplate (ABP) 10.2.0** multi-tenant application (.NET 9) — the API backend for an Angular SPA client (referenced in `docker/ng/` but not in this repo). Layers depend on each other via ABP module classes (`[Name]Module.cs`), each calling `DependsOn(typeof(OtherModule))`:

```
Core (domain entities, auth, consts)
  ← Application (app services, AutoMapper profiles) — depends on Core
  ← EntityFrameworkCore (DbContext, Migrations, seeders) — depends on Core
  ← Web.Core (controllers, JWT/auth config) — depends on Application + EF
  ← Web.Host (Startup, Program.cs, appsettings) — depends on Web.Core
Shared (DTOs/interfaces referenced from multiple layers, e.g. Products/Brands/Cars DTOs)
Migrator (standalone console app for DB migration/seeding) — depends on EF only
```
Module files live at the project root (e.g. `src/SixThreeTwo_shop.Core/SixThreeTwo_shopCoreModule.cs`). When adding a new layer dependency (e.g. a new NuGet package usage), register it in `Initialize()`/`PreInitialize()` of the relevant module, not just the `.csproj`.

## Feature Folder Convention
Each business feature (e.g. `Products`, `Brands`, `Cars`) gets a folder mirrored across layers:
- `SixThreeTwo_shop.Core/<Feature>/` — entities (POCOs extending `Entity`/`FullAuditedEntity`)
- `SixThreeTwo_shop.Shared/<Feature>/Dto/` — DTOs and app-service interfaces (`I<Feature>AppService`)
- `SixThreeTwo_shop.Application/<Feature>/<Feature>AppService.cs` — implementation
- `SixThreeTwo_shop.Application/Mapping/<Feature>MapProfile.cs` — AutoMapper `Profile`

App services use **primary constructors** injecting `IRepository<T>` per entity and inherit `SixThreeTwo_shopAppServiceBase`:
```csharp
public class ProductsAppService(
  IRepository<Product> productRepository,
  IRepository<MotorOil> motorOilRepository,
  IS3Uploader s3Uploader,
  IConfiguration configuration)
  : SixThreeTwo_shopAppServiceBase, IProductsAppService
{
  public async Task<List<ProductDto>> GetAllProducts()
  {
    var products = await (await productRepository.GetAllAsync())
      .Include(p => p.MotorOil)
      .ToListAsync();
    return ObjectMapper.Map<List<ProductDto>>(products);
  }
}
```
Use `ObjectMapper.Map<T>()` (AutoMapper via ABP), not manual DTO construction. AutoMapper profiles use `CreateMap<Entity, Dto>().ForMember(...)` to flatten related entities and `Ignore()` audit fields on the reverse `Dto -> Entity` map.

## Authorization Pattern
Permissions are defined as `const string` in `src/SixThreeTwo_shop.Core/Authorization/PermissionNames.cs` using the naming pattern `Pages_<Feature> = "Pages.<Feature>"` (e.g. `Pages_Products`, `Pages_OilSpecs`). They're registered in `SixThreeTwo_shopAuthorizationProvider.SetPermissions()` via `context.CreatePermission(PermissionNames.Pages_X, L("X"))`. When adding a new feature, add both the const and the registration — a missing registration means `[AbpAuthorize(PermissionNames.Pages_X)]` will silently deny everyone.

## Multi-Tenancy
`Tenant` (Core/MultiTenancy) extends `AbpTenant<User>`. Data isolation is automatic via ABP's `IMustHaveTenant`/EF query filters — don't manually filter by `TenantId` in app services. Tests skip multi-tenant-specific tests unless `SixThreeTwo_shopConsts.MultiTenancyEnabled` — use `[MultiTenantFact]` (from `test/SixThreeTwo_shop.Tests/MultiTenantFactAttribute.cs`) instead of `[Fact]` for tenant-dependent tests.

## Database & Migrations
- EF Core with **Pomelo MySQL** provider (also references SqlServer package but MySQL is the active connection string in `appsettings.json`).
- Migrations live in `src/SixThreeTwo_shop.EntityFrameworkCore/Migrations/`, named `YYYYMMDDHHMMSS_DescriptiveName.cs`. Generate with EF CLI from the `SixThreeTwo_shop.EntityFrameworkCore` project (needs `-s` pointing at `SixThreeTwo_shop.Web.Host` or `SixThreeTwo_shop.Migrator` for design-time context).
- **`SixThreeTwo_shop.Migrator`** is a separate console app (`Program.cs`) that runs host + all tenant migrations via `MultiTenantMigrateExecuter` (dedupes tenants sharing a connection string). Run it instead of `dotnet ef database update` when multiple tenants exist. Supports a `-q` quiet flag.
- Seed data logic lives in the EF module (`SixThreeTwo_shopEntityFrameworkModule`) and is toggled off for the Migrator/tests via `SkipDbSeed`.

## Build & Docker Workflows
- `build/build-with-ng.ps1` / `.sh`: builds two Docker images — `abp/host` (from `src/SixThreeTwo_shop.Web.Host/Dockerfile`, built from repo root) and `abp/ng` (from a sibling `angular/` directory — the Angular client is a separate repo checked out alongside this one).
- `docker/ng/docker-compose.yml`: runs `abp_host` (port 44311→80) and `abp_ng` (port 4200→80) together. Key env vars for the host container: `ConnectionStrings__Default`, `App__ServerRootAddress`, `App__ClientRootAddress`, `App__CorsOrigins`, `ASPNETCORE_ENVIRONMENT=Staging`. Use `docker/ng/up.ps1` / `down.ps1` to start/stop.
- CORS origin for local dev is hardcoded to `http://localhost:4200` in `appsettings.json` (`App:CorsOrigins`) and `Startup.cs`.

## Startup Pipeline (Web.Host)
`Startup.cs` → `services.AddAbpWithoutCreatingServiceProvider<SixThreeTwo_shopWebHostModule>()` then `app.UseAbp()` → `UseCors()` → routing → JWT auth → SignalR hub at `/signalr` → Swagger at `/swagger`. JWT settings (`SecurityKey`/`Issuer`/`Audience`) come from `appsettings.json`, configured in `SixThreeTwo_shopWebCoreModule`.

## Testing
- `test/SixThreeTwo_shop.Tests/SixThreeTwo_shopTestBase.cs` inherits `AbpIntegratedTestBase<SixThreeTwo_shopTestModule>`; uses **EF Core in-memory** provider (`SkipDbContextRegistration=true` in the test module registers it manually).
- Constructor seeds host + tenant/role/user data via `InitialHostDbBuilder`/`TenantRoleAndUserBuilder`.
- Use `UsingDbContext<T>(...)` helper to run assertions/setup against the in-memory context with correct tenant scoping (`UsingTenantId()`).
- External deps like email sending are mocked with **NSubstitute** in `SixThreeTwo_shopTestModule`.

## Key External Integrations
- **AWS S3** (`AWSSDK.S3`) via `IS3Uploader` — used for product image uploads (see `Aws.S3` config section in `appsettings.json`).
- **CsvHelper** / **ExcelDataReader** — used in `ProductsAppService` for bulk product import (`ProductImport.ChunkSize` config controls batch size).
- **log4net** (`Abp.Castle.Log4Net`) for logging, configured via `log4net.config` / `log4net.Production.config`.

