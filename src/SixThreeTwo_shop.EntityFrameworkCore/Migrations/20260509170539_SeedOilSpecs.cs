using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SixThreeTwo_shop.Migrations
{
    /// <inheritdoc />
   public partial class SeedOilSpecs : Migration
    {
        // =====================================================================
        // NOTE ON DESIGN
        // =====================================================================
        // All INSERT statements look up foreign-key IDs via slug/code joins so
        // the seed is fully ID-order-independent and safe to re-run on any
        // database that already has the CarBrands / CarModels / VehicleVariants
        // data from the previous migration.
        //
        // The temp table #InsertedSpecs is created and dropped inside a single
        // migrationBuilder.Sql() call, which EF sends as one SQL batch —
        // identical to running it in SSMS.  EF's own ambient transaction wraps
        // the whole migration, so no BEGIN/COMMIT is needed here.
        //
        // FuelType: 0=Petrol  1=Diesel  2=Hybrid/PHEV  3=Electric
        // ChangeInterval: km
        // OilCapacity: litres
        // =====================================================================

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ------------------------------------------------------------------
            // 1. APPROVAL STANDARDS
            // ------------------------------------------------------------------
            migrationBuilder.InsertData(
                table: "ApprovalStandards",
                columns: ["Category", "Code", "Description"],
                values: new object[,]
                {
                    // API Petrol
                    { "API", "API SJ",    "API Service SJ – petrol engines up to 2001" },
                    { "API", "API SL",    "API Service SL – petrol engines 2001–2004" },
                    { "API", "API SM",    "API Service SM – petrol engines 2004–2010" },
                    { "API", "API SN",    "API Service SN – petrol engines 2010–2020" },
                    { "API", "API SN+",   "API Service SN+ – LSPI protection, petrol 2018+" },
                    { "API", "API SP",    "API Service SP – latest petrol standard 2020+" },
                    // API Diesel
                    { "API", "API CF",    "API Service CF – diesel engines" },
                    { "API", "API CF-4",  "API Service CF-4 – diesel direct injection" },
                    { "API", "API CG-4",  "API Service CG-4 – diesel, heavy duty" },
                    { "API", "API CH-4",  "API Service CH-4 – diesel, low emission" },
                    { "API", "API CI-4",  "API Service CI-4 – diesel with EGR systems" },
                    { "API", "API CJ-4",  "API Service CJ-4 – diesel with DPF" },
                    { "API", "API CK-4",  "API Service CK-4 – latest diesel standard" },
                    // ACEA
                    { "ACEA", "ACEA A1/B1", "ACEA A1/B1 – fuel economy petrol/diesel" },
                    { "ACEA", "ACEA A3/B3", "ACEA A3/B3 – high performance petrol/diesel" },
                    { "ACEA", "ACEA A3/B4", "ACEA A3/B4 – high performance direct injection diesel" },
                    { "ACEA", "ACEA A5/B5", "ACEA A5/B5 – fuel economy, extended drain" },
                    { "ACEA", "ACEA C1",    "ACEA C1 – catalyst compatible, low SAPS" },
                    { "ACEA", "ACEA C2",    "ACEA C2 – catalyst compatible, mid SAPS, fuel economy" },
                    { "ACEA", "ACEA C3",    "ACEA C3 – catalyst compatible, mid SAPS, high performance" },
                    { "ACEA", "ACEA C4",    "ACEA C4 – catalyst compatible, low SAPS DPF" },
                    { "ACEA", "ACEA C5",    "ACEA C5 – catalyst compatible, fuel economy, low viscosity" },
                    { "ACEA", "ACEA C6",    "ACEA C6 – latest low viscosity catalyst compatible" },
                    { "ACEA", "ACEA E4",    "ACEA E4 – heavy duty diesel, extended drain" },
                    { "ACEA", "ACEA E6",    "ACEA E6 – heavy duty diesel, DPF/EGR compatible" },
                    { "ACEA", "ACEA E7",    "ACEA E7 – heavy duty diesel" },
                    { "ACEA", "ACEA E9",    "ACEA E9 – heavy duty diesel, latest" },
                });

            // ------------------------------------------------------------------
            // 2. MANUFACTURER APPROVALS
            // ------------------------------------------------------------------
            migrationBuilder.InsertData(
                table: "ManufacturerApprovals",
                columns: ["Code", "Name"],
                values: new object[,]
                {
                    // GM / Chevrolet / Buick / GMC / Pontiac / Cadillac
                    { "GM dexos1",      "GM dexos1 – petrol engines (2011+)" },
                    { "GM dexos1 Gen2", "GM dexos1 Gen2 – petrol engines (2017+)" },
                    { "GM dexos1 Gen3", "GM dexos1 Gen3 – petrol engines (2022+)" },
                    { "GM dexos2",      "GM dexos2 – diesel engines" },
                    { "GM 6094M",       "GM 6094M – older petrol specification" },
                    { "GM 4718M",       "GM 4718M – older engine oil spec" },
                    // Ford
                    { "Ford WSS-M2C913-A", "Ford WSS-M2C913-A – petrol/diesel (older)" },
                    { "Ford WSS-M2C913-B", "Ford WSS-M2C913-B – petrol/diesel" },
                    { "Ford WSS-M2C913-C", "Ford WSS-M2C913-C – petrol/diesel (current)" },
                    { "Ford WSS-M2C913-D", "Ford WSS-M2C913-D – petrol/diesel (latest)" },
                    { "Ford WSS-M2C929-A", "Ford WSS-M2C929-A – 5W-20 fuel economy" },
                    { "Ford WSS-M2C945-A", "Ford WSS-M2C945-A – 0W-20 fuel economy" },
                    { "Ford WSS-M2C947-A", "Ford WSS-M2C947-A – synthetic 5W-30" },
                    { "Ford WSS-M2C948-B", "Ford WSS-M2C948-B – EcoBoost petrol" },
                    // FCA / Stellantis
                    { "FCA MS-6395",    "FCA MS-6395 – petrol 5W-20/5W-30" },
                    { "FCA MS-10725",   "FCA MS-10725 – diesel Euro 6" },
                    { "FCA MS-12633",   "FCA MS-12633 – petrol latest" },
                    { "Mopar ATF+4",    "Mopar ATF+4 – automatic transmission fluid" },
                    // Volkswagen Group
                    { "VW 501.01",  "VW 501.01 – petrol, multigrade" },
                    { "VW 502.00",  "VW 502.00 – petrol, high performance" },
                    { "VW 503.00",  "VW 503.00 – petrol, longlife" },
                    { "VW 503.01",  "VW 503.01 – petrol, longlife high performance" },
                    { "VW 504.00",  "VW 504.00 – petrol, longlife II (2002+)" },
                    { "VW 505.00",  "VW 505.00 – diesel (non-PD)" },
                    { "VW 505.01",  "VW 505.01 – diesel PD (pumpe-düse)" },
                    { "VW 506.00",  "VW 506.00 – diesel, longlife" },
                    { "VW 506.01",  "VW 506.01 – diesel PD, longlife" },
                    { "VW 507.00",  "VW 507.00 – petrol/diesel DPF, longlife III (2004+)" },
                    { "VW 508.00",  "VW 508.00 – petrol, low viscosity (2016+)" },
                    { "VW 509.00",  "VW 509.00 – diesel, low viscosity (2016+)" },
                    // BMW
                    { "BMW LL-98",    "BMW Longlife-98 – older petrol/diesel" },
                    { "BMW LL-01",    "BMW Longlife-01 – petrol/diesel (2001+)" },
                    { "BMW LL-01 FE", "BMW Longlife-01 FE – fuel economy 0W-30" },
                    { "BMW LL-04",    "BMW Longlife-04 – petrol/diesel DPF (2004+)" },
                    { "BMW LL-12 FE", "BMW Longlife-12 FE – low viscosity fuel economy" },
                    { "BMW LL-14 FE+","BMW Longlife-14 FE+ – ultra low viscosity" },
                    { "BMW LL-17 FE+","BMW Longlife-17 FE+ – latest low viscosity" },
                    // Mercedes-Benz
                    { "MB 226.5",  "MB-Approval 226.5 – petrol/diesel (older)" },
                    { "MB 229.1",  "MB-Approval 229.1 – petrol/diesel standard" },
                    { "MB 229.3",  "MB-Approval 229.3 – petrol/diesel, extended drain" },
                    { "MB 229.5",  "MB-Approval 229.5 – high performance, extended drain" },
                    { "MB 229.31", "MB-Approval 229.31 – diesel, low SAPS" },
                    { "MB 229.51", "MB-Approval 229.51 – petrol/diesel, low SAPS" },
                    { "MB 229.52", "MB-Approval 229.52 – petrol/diesel low viscosity" },
                    { "MB 229.61", "MB-Approval 229.61 – latest low viscosity" },
                    // Toyota / Lexus
                    { "Toyota 0W-20 SN+",  "Toyota Genuine Motor Oil 0W-20 SN+" },
                    { "Toyota 5W-30",      "Toyota Genuine Motor Oil 5W-30" },
                    { "Toyota Hybrid Oil", "Toyota Hybrid Motor Oil specification" },
                    // Honda / Acura
                    { "Honda HTO-06",    "Honda Genuine Motor Oil HTO-06 (0W-20)" },
                    { "Honda 08798-9032","Honda Genuine 0W-20 hybrid spec" },
                    // Nissan / Infiniti
                    { "Nissan NS-2", "Nissan Motor Oil Standard NS-2" },
                    { "Nissan NS-3", "Nissan Motor Oil Standard NS-3 (2014+)" },
                    { "Nissan NS-4", "Nissan Motor Oil Standard NS-4 (2018+)" },
                    // Mazda
                    { "Mazda 5W-30", "Mazda Genuine Motor Oil 5W-30" },
                    { "Mazda 0W-20", "Mazda Genuine Motor Oil 0W-20 (SkyActiv)" },
                    // Subaru
                    { "Subaru 5W-30", "Subaru Genuine Motor Oil 5W-30" },
                    { "Subaru 0W-20", "Subaru Genuine Motor Oil 0W-20 (2012+)" },
                    // Hyundai / Kia / Genesis
                    { "Hyundai 0W-20", "Hyundai/Kia Genuine Motor Oil 0W-20" },
                    { "Hyundai 5W-30", "Hyundai/Kia Genuine Motor Oil 5W-30" },
                    // Mitsubishi
                    { "MMC MZCD", "Mitsubishi Motor Oil specification (diamond)" },
                    // Volvo
                    { "Volvo VCC-RBS0-2AE", "Volvo Cars Corrosion Std – 5W-30/0W-30" },
                    // Jaguar / Land Rover
                    { "JLR Land Rover STJLR.03.5004", "JLR oil spec – petrol/diesel" },
                    { "JLR STJLR.51.5122",            "JLR low viscosity spec" },
                    // Porsche
                    { "Porsche A40",   "Porsche A40 – all engines (5W-40/0W-40)" },
                    // Renault
                    { "Renault RN0700", "Renault oil spec – petrol RN0700" },
                    { "Renault RN0710", "Renault oil spec – diesel RN0710" },
                    { "Renault RN0720", "Renault oil spec – latest (2019+)" },
                    // PSA / Stellantis EU / FIAT
                    { "PSA B71 2290",    "PSA/Stellantis B71 2290 – petrol" },
                    { "PSA B71 2294",    "PSA/Stellantis B71 2294 – diesel" },
                    { "PSA B71 2312",    "PSA/Stellantis B71 2312 – e-HDi diesel" },
                    { "FIAT 9.55535-GH2", "FIAT 9.55535-GH2 – petrol/diesel" },
                    { "FIAT 9.55535-S3",  "FIAT 9.55535-S3 – diesel TJD" },
                    { "FIAT 9.55535-DSX", "FIAT 9.55535-DSX – multijet diesel" },
                    // Saab / Opel legacy GM
                    { "Saab 93 165 147", "Saab GM-approved 5W-30 spec" },
                    { "GM LL-A-025",     "Opel/Vauxhall LL-A-025 – petrol longlife" },
                    { "GM LL-B-025",     "Opel/Vauxhall LL-B-025 – diesel longlife" },
                });

            // ------------------------------------------------------------------
            // 3 + 4 + 5 + 6.  OilSpecs, OilSpecApprovals, OilSpecManufacturerApprovals
            //
            // Everything from here is raw SQL.  A single Sql() call is one batch,
            // so the temp table created at the top is visible to all statements
            // below it in the same string.
            // ------------------------------------------------------------------
            migrationBuilder.Sql("""
                -- -------------------------------------------------------
                -- Temp table: captures the auto-generated OilSpec IDs so
                -- we can link them to ApprovalStandards and ManufacturerApprovals
                -- without a second round-trip.
                -- -------------------------------------------------------
                CREATE TABLE #InsertedSpecs (
                    Id         INT            NOT NULL,
                    ModelSlug  NVARCHAR(200)  NOT NULL,
                    EngineCode NVARCHAR(100)  NULL
                );

                -- ==============================================================
                -- FORD MUSTANG
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'ford-mustang', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('289',       '10W-40', 'Conventional',   4.7,  8000,  'V8 289; use conventional or semi-synthetic 10W-40'),
                    ('289HiPo',   '10W-40', 'Conventional',   4.7,  8000,  'Hi-Performance 289; high-revving, check level frequently'),
                    ('390GT',     '10W-40', 'Conventional',   5.2,  8000,  'Big-block 390 GT; 10W-40 conventional'),
                    ('Boss302',   '10W-40', 'Semi-Synthetic', 4.7,  8000,  'Boss 302; semi-synthetic recommended'),
                    ('429CJ',     '10W-40', 'Conventional',   5.7,  8000,  'Cobra Jet 429; 10W-40 conventional'),
                    ('2.3',       '10W-30', 'Conventional',   4.2,  8000,  'Mustang II 2.3L I4'),
                    ('2.8V6',     '10W-30', 'Conventional',   4.0,  8000,  '2.8L V6 Cologne'),
                    ('5.0HO',     '5W-30',  'Conventional',   4.7,  8000,  'Fox Body 5.0 HO; 5W-30 as per Ford spec'),
                    ('2.3T',      '5W-30',  'Conventional',   4.7,  8000,  'Turbo SVO 2.3L'),
                    ('3.8V6',     '5W-30',  'Conventional',   4.7,  8000,  'SN95 3.8L V6; 5W-30 Ford spec'),
                    ('4.6GT',     '5W-30',  'Conventional',   5.7,  8000,  'SN95/S197 4.6 GT modular; 5W-30'),
                    ('4.6Cobra',  '5W-30',  'Semi-Synthetic', 5.7,  8000,  '4.6 DOHC Cobra; semi-synthetic 5W-30'),
                    ('4.0V6',     '5W-20',  'Conventional',   4.7,  8000,  'S197 4.0L V6; Ford spec 5W-20'),
                    ('5.4Shelby', '5W-50',  'Full Synthetic', 6.6,  8000,  'GT500 5.4L SC; full synthetic 5W-50'),
                    ('3.7V6',     '5W-20',  'Full Synthetic', 5.7,  8000,  'S197 3.7L V6; 5W-20 API SN'),
                    ('5.0GT',     '5W-50',  'Full Synthetic', 8.0,  8000,  'Coyote 5.0 V8; Ford WSS-M2C948-B 5W-50 or 5W-30 track'),
                    ('5.8Shelby', '5W-50',  'Full Synthetic', 6.6,  8000,  'GT500 5.8L Predator; full synthetic 5W-50'),
                    ('2.3EB',     '5W-30',  'Full Synthetic', 5.7,  10000, 'EcoBoost 2.3L; Ford WSS-M2C947-A 5W-30'),
                    ('5.2GT500',  '5W-50',  'Full Synthetic', 8.2,  8000,  'GT500 5.2L Voodoo; full synthetic 5W-50'),
                    ('5.0Dark',   '5W-50',  'Full Synthetic', 8.0,  8000,  'Dark Horse 5.0; full synthetic 5W-50')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'ford-mustang'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- FORD F-150
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'ford-f150', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('5.0V8',    '10W-30', 'Conventional',   5.7,  8000,  'F-150 pre-1997 5.0L V8'),
                    ('5.8V8',    '10W-30', 'Conventional',   5.7,  8000,  '5.8L 351W V8'),
                    ('5.0HO',    '5W-30',  'Conventional',   5.7,  8000,  '5.0 HO V8; 5W-30'),
                    ('4.2V6',    '5W-30',  'Conventional',   4.7,  8000,  '4.2L Essex V6'),
                    ('4.6V8',    '5W-20',  'Conventional',   5.7,  8000,  '4.6L Triton 2-valve; Ford WSS-M2C929-A'),
                    ('5.4V8',    '5W-20',  'Conventional',   7.0,  8000,  '5.4L Triton 3-valve; Ford WSS-M2C929-A'),
                    ('3.7V6',    '5W-20',  'Full Synthetic', 6.2,  10000, '3.7L Ti-VCT V6; 5W-20'),
                    ('3.5EB',    '5W-30',  'Full Synthetic', 6.0,  10000, '3.5L EcoBoost V6; Ford WSS-M2C948-B 5W-30'),
                    ('5.0V8',    '5W-20',  'Full Synthetic', 8.0,  10000, '5.0L Coyote Gen2 V8; 5W-20 API SP'),
                    ('2.7EB',    '5W-30',  'Full Synthetic', 5.7,  10000, '2.7L EcoBoost V6; Ford WSS-M2C948-B'),
                    ('3.5EBHV',  '5W-30',  'Full Synthetic', 6.0,  10000, '3.5L PowerBoost Hybrid; 5W-30 full synthetic'),
                    ('Lightning', NULL,    'Electric',       0.0,  0,     'F-150 Lightning BEV – no engine oil required')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'ford-f150'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- VW GOLF
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'vw-golf', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('1.1',       '15W-40', 'Conventional',   3.0,  10000, 'Golf Mk1 1.1L; 15W-40 conventional'),
                    ('1.5D',      '15W-40', 'Conventional',   3.5,  10000, 'Golf Mk1 diesel 1.5L'),
                    ('1.6GTI',    '10W-40', 'Semi-Synthetic', 3.5,  10000, 'Golf GTI Mk1 1.6; 10W-40'),
                    ('1.3',       '10W-40', 'Conventional',   3.0,  10000, 'Golf Mk2 1.3L'),
                    ('1.6D',      '15W-40', 'Conventional',   3.5,  10000, 'Golf Mk2 1.6 diesel'),
                    ('1.8GTI',    '10W-40', 'Semi-Synthetic', 3.5,  10000, 'Golf GTI Mk2 1.8; VW 501.01'),
                    ('1.8GTI16v', '10W-40', 'Semi-Synthetic', 3.5,  10000, 'Golf GTI 16v Mk2'),
                    ('1.4',       '10W-40', 'Conventional',   3.5,  15000, 'Golf Mk3 1.4L'),
                    ('1.6',       '10W-40', 'Semi-Synthetic', 4.0,  15000, 'Golf Mk3 1.6L'),
                    ('1.9TDI',    '5W-40',  'Full Synthetic', 4.5,  15000, 'Golf Mk3 1.9 TDI; VW 505.00'),
                    ('2.0GTI',    '5W-40',  'Semi-Synthetic', 4.0,  15000, 'Golf GTI Mk3 2.0; VW 502.00'),
                    ('2.8VR6',    '5W-40',  'Full Synthetic', 5.5,  15000, 'Golf VR6 Mk3; VW 502.00'),
                    ('1.8TGTi',   '5W-40',  'Full Synthetic', 4.3,  15000, 'Golf GTI Mk4 1.8T; VW 502.00'),
                    ('3.2R32',    '5W-40',  'Full Synthetic', 5.3,  15000, 'Golf R32 Mk4/Mk5; VW 502.00'),
                    ('1.4TSI',    '5W-30',  'Full Synthetic', 4.5,  30000, 'Golf Mk5/Mk6/Mk7 1.4 TSI; VW 504.00'),
                    ('2.0TFSI',   '5W-30',  'Full Synthetic', 4.5,  30000, 'Golf GTI Mk5/Mk6/Mk7/Mk8; VW 504.00'),
                    ('1.2TSI',    '5W-30',  'Full Synthetic', 3.8,  30000, 'Golf Mk6 1.2 TSI; VW 504.00'),
                    ('2.0TDI',    '5W-30',  'Full Synthetic', 4.3,  30000, 'Golf Mk6/Mk7/Mk8 2.0 TDI; VW 507.00'),
                    ('2.0TDI150', '5W-30',  'Full Synthetic', 4.3,  30000, 'Golf Mk8 2.0 TDI 150; VW 507.00/509.00'),
                    ('2.0R',      '5W-30',  'Full Synthetic', 5.7,  30000, 'Golf R Mk6/Mk7/Mk8; VW 504.00'),
                    ('1.0TSI',    '0W-20',  'Full Synthetic', 3.3,  30000, 'Golf Mk7/Mk8 1.0 TSI; VW 508.00'),
                    ('1.5TSI',    '0W-20',  'Full Synthetic', 4.6,  30000, 'Golf Mk7/Mk8 1.5 TSI evo; VW 508.00'),
                    ('GTE',       '5W-30',  'Full Synthetic', 4.5,  30000, 'Golf GTE/eHybrid PHEV; VW 504.00/508.00'),
                    ('eHybrid',   '5W-30',  'Full Synthetic', 4.5,  30000, 'Golf Mk8 eHybrid; VW 508.00')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'vw-golf'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- VW PASSAT
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'vw-passat', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('1.3',      '15W-40', 'Conventional',   3.0,  10000, 'Passat B1 1.3L'),
                    ('1.6',      '15W-40', 'Conventional',   3.5,  10000, 'Passat B1/B2 1.6L'),
                    ('1.6D',     '15W-40', 'Conventional',   3.5,  10000, 'Passat B2 diesel 1.6L'),
                    ('1.8',      '10W-40', 'Semi-Synthetic', 4.0,  15000, 'Passat B3/B4 1.8L'),
                    ('1.9TDI',   '5W-40',  'Full Synthetic', 4.5,  15000, 'Passat B3/B4/B5 TDI; VW 505.00'),
                    ('1.8T',     '5W-40',  'Full Synthetic', 4.5,  15000, 'Passat B5 1.8T; VW 502.00'),
                    ('2.8V6',    '5W-40',  'Full Synthetic', 5.5,  15000, 'Passat B5 2.8 V6; VW 502.00'),
                    ('2.0',      '5W-40',  'Semi-Synthetic', 4.5,  15000, 'Passat B5.5 2.0L'),
                    ('2.0TDI',   '5W-30',  'Full Synthetic', 4.3,  30000, 'Passat B5.5/B6/B7/B8 2.0 TDI; VW 507.00'),
                    ('1.6FSI',   '5W-30',  'Full Synthetic', 4.5,  30000, 'Passat B6 1.6 FSI; VW 503.00'),
                    ('2.0TFSI',  '5W-30',  'Full Synthetic', 4.5,  30000, 'Passat B6/B7 2.0 TFSI; VW 504.00'),
                    ('3.2V6',    '5W-30',  'Full Synthetic', 5.5,  30000, 'Passat B6 3.2 V6; VW 504.00'),
                    ('1.4TSI',   '5W-30',  'Full Synthetic', 4.6,  30000, 'Passat B7/B8 1.4 TSI; VW 504.00'),
                    ('1.8TSI',   '5W-30',  'Full Synthetic', 4.6,  30000, 'Passat B7/B8 1.8 TSI; VW 504.00'),
                    ('GTE',      '5W-30',  'Full Synthetic', 4.5,  30000, 'Passat GTE PHEV B8; VW 508.00'),
                    ('1.5TSI',   '0W-20',  'Full Synthetic', 4.6,  30000, 'Passat B8 1.5 TSI evo; VW 508.00'),
                    ('2.0TSI',   '5W-30',  'Full Synthetic', 4.9,  30000, 'Passat B8 2.0 TSI; VW 504.00')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'vw-passat'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- BMW 3 SERIES
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'bmw-3-series', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('M3E30',    '10W-60', 'Full Synthetic', 4.0,  10000, 'M3 E30 2.3L S14; 10W-60 full synthetic'),
                    ('M3E36',    '10W-60', 'Full Synthetic', 5.5,  10000, 'M3 E36 3.0L S50; 10W-60'),
                    ('M3E46',    '10W-60', 'Full Synthetic', 6.5,  10000, 'M3 E46 3.2L S54; 10W-60 BMW LL-01'),
                    ('M3E90',    '10W-60', 'Full Synthetic', 7.5,  10000, 'M3 E90 4.0L V8 S65; 10W-60'),
                    ('M3F80',    '10W-60', 'Full Synthetic', 7.5,  10000, 'M3 F80 3.0T S55; 10W-60 BMW LL-04'),
                    ('M3G80',    '10W-60', 'Full Synthetic', 7.5,  10000, 'M3 G80 S58 3.0T; 10W-60'),
                    ('1.7TDS',   '5W-40',  'Semi-Synthetic', 5.0,  15000, 'E36 1.7 diesel 318tds; BMW LL-98'),
                    ('2.0D',     '5W-30',  'Full Synthetic', 5.5,  25000, 'E46/E90/F30/G20 320d; BMW LL-04'),
                    ('1.5T',     '5W-30',  'Full Synthetic', 4.5,  25000, 'F30 316i 1.5T 3-cyl; BMW LL-01 FE'),
                    ('2.0T',     '5W-30',  'Full Synthetic', 5.0,  25000, 'E90/F30 320i; BMW LL-01'),
                    ('2.0T28',   '5W-30',  'Full Synthetic', 5.0,  25000, 'F30 328i; BMW LL-01'),
                    ('3.0T',     '5W-30',  'Full Synthetic', 6.5,  25000, 'F30 335i; BMW LL-01'),
                    ('330ePHEV', '5W-30',  'Full Synthetic', 5.0,  25000, 'F30/G20 330e PHEV; BMW LL-04'),
                    ('2.0T30',   '0W-30',  'Full Synthetic', 5.0,  25000, 'G20 330i; BMW LL-12 FE / LL-17 FE+'),
                    ('3.0M340',  '0W-30',  'Full Synthetic', 6.5,  25000, 'G20 M340i; BMW LL-14 FE+ / LL-17 FE+'),
                    ('1.8',      '5W-30',  'Full Synthetic', 4.3,  25000, 'E46 318i; BMW LL-01'),
                    ('2.0',      '5W-30',  'Full Synthetic', 5.0,  25000, 'E36/E46/E90 320i; BMW LL-01'),
                    ('2.5',      '5W-30',  'Full Synthetic', 5.5,  25000, 'E36/E46/E90 325i; BMW LL-01'),
                    ('3.0',      '5W-30',  'Full Synthetic', 5.5,  25000, 'E46/E90 330i; BMW LL-01')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'bmw-3-series'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- MERCEDES-BENZ C-CLASS
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'mb-c-class', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('1.8K',      '5W-40',  'Semi-Synthetic', 6.0,  10000, 'W202/W203 C180K Kompressor; MB 229.1'),
                    ('2.0',       '5W-40',  'Semi-Synthetic', 6.0,  10000, 'W202/W203 C200; MB 229.1'),
                    ('2.2D',      '5W-40',  'Semi-Synthetic', 6.5,  10000, 'W202 C220 diesel; MB 229.1'),
                    ('2.5D',      '5W-40',  'Semi-Synthetic', 6.5,  10000, 'W202 C250 diesel I5; MB 229.1'),
                    ('2.2CDI',    '5W-30',  'Full Synthetic', 6.5,  25000, 'W203/W204 C220 CDI; MB 229.31'),
                    ('2.0T',      '5W-30',  'Full Synthetic', 6.5,  25000, 'W204/W205 C200 Turbo; MB 229.5'),
                    ('AMG32',     '5W-40',  'Full Synthetic', 8.5,  10000, 'C32 AMG W203; MB 229.5'),
                    ('AMG63',     '5W-40',  'Full Synthetic', 8.5,  10000, 'C63 AMG W204 6.2L V8; MB 229.5'),
                    ('1.6T',      '5W-30',  'Full Synthetic', 6.0,  25000, 'W205 C180 1.6T; MB 229.5'),
                    ('2.0T300',   '5W-30',  'Full Synthetic', 6.5,  25000, 'W205/W206 C300; MB 229.5 / MB 229.61'),
                    ('2.0CDI',    '5W-30',  'Full Synthetic', 6.5,  25000, 'W205 C220d; MB 229.51'),
                    ('AMG43',     '5W-30',  'Full Synthetic', 8.5,  10000, 'C43 AMG W205/W206; MB 229.5'),
                    ('AMG63S',    '0W-40',  'Full Synthetic', 9.5,  10000, 'C63 S AMG W205 4.0 V8; MB 229.5'),
                    ('C350ePHEV', '5W-30',  'Full Synthetic', 6.5,  25000, 'C350e PHEV W205; MB 229.5'),
                    ('1.5T',      '0W-20',  'Full Synthetic', 5.5,  25000, 'W206 C180 MHEV; MB 229.61'),
                    ('2.0T200',   '0W-20',  'Full Synthetic', 6.5,  25000, 'W206 C200; MB 229.61'),
                    ('2.0D',      '5W-30',  'Full Synthetic', 6.5,  25000, 'W206 C220d; MB 229.52'),
                    ('C300ePHEV', '0W-20',  'Full Synthetic', 6.5,  25000, 'W206 C300e PHEV; MB 229.61'),
                    ('AMG63E',    '0W-40',  'Full Synthetic', 6.0,  10000, 'W206 AMG C63 PHEV 2.0T; MB 229.5')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'mb-c-class'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- AUDI A4
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'audi-a4', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('1.6',       '10W-40', 'Conventional',   3.5,  10000, 'A4 B5 1.6L; VW 501.01'),
                    ('1.8',       '5W-40',  'Semi-Synthetic', 4.5,  15000, 'A4 B5 1.8L; VW 502.00'),
                    ('1.8T',      '5W-40',  'Full Synthetic', 4.5,  15000, 'A4 B5/B6 1.8T; VW 502.00'),
                    ('2.6V6',     '5W-40',  'Full Synthetic', 5.5,  15000, 'A4 B5 2.6 V6; VW 502.00'),
                    ('1.9TDI',    '5W-40',  'Full Synthetic', 4.5,  15000, 'A4 B5/B6 1.9 TDI; VW 505.00'),
                    ('1.9TDIPD',  '5W-40',  'Full Synthetic', 4.5,  15000, 'A4 B5 1.9 TDI PD 115; VW 505.01'),
                    ('3.0V6',     '5W-40',  'Full Synthetic', 6.5,  15000, 'A4 B6 3.0 V6; VW 502.00'),
                    ('2.5TDI',    '5W-40',  'Full Synthetic', 5.7,  15000, 'A4 B6 2.5 V6 TDI; VW 505.00'),
                    ('2.0TFSI',   '5W-30',  'Full Synthetic', 4.6,  30000, 'A4 B7/B8/B9 2.0 TFSI; VW 504.00'),
                    ('3.2FSI',    '5W-30',  'Full Synthetic', 6.5,  30000, 'A4 B7 3.2 FSI; VW 504.00'),
                    ('2.0TDI',    '5W-30',  'Full Synthetic', 4.5,  30000, 'A4 B7/B8/B9 2.0 TDI; VW 507.00'),
                    ('1.8TFSI',   '5W-30',  'Full Synthetic', 4.6,  30000, 'A4 B8 1.8 TFSI; VW 504.00'),
                    ('3.0TFSI',   '5W-30',  'Full Synthetic', 7.0,  30000, 'A4 B8/B9 3.0 TFSI V6; VW 504.00'),
                    ('2.0TDI177', '5W-30',  'Full Synthetic', 4.5,  30000, 'A4 B8 2.0 TDI 177; VW 507.00'),
                    ('RS4B8',     '5W-40',  'Full Synthetic', 8.5,  10000, 'RS4 B8 4.2 V8 FSI; VW 502.00'),
                    ('1.4TFSI',   '0W-20',  'Full Synthetic', 4.6,  30000, 'A4 B9 1.4 TFSI; VW 508.00'),
                    ('2.0TFSI45', '5W-30',  'Full Synthetic', 4.9,  30000, 'A4 B9 2.0 TFSI 45; VW 504.00'),
                    ('2.0TDI40',  '5W-30',  'Full Synthetic', 4.5,  30000, 'A4 B9 2.0 TDI 40; VW 507.00'),
                    ('PHEV',      '5W-30',  'Full Synthetic', 4.6,  30000, 'A4 B9 TFSI e PHEV; VW 508.00'),
                    ('RS4B9',     '5W-40',  'Full Synthetic', 7.5,  10000, 'RS4 B9 2.9 V6 Biturbo; VW 502.00')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'audi-a4'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- TOYOTA COROLLA
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'toyota-corolla', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('1.1',   '20W-40', 'Conventional',   3.0,  5000,  'K10 1.1L; 20W-40 conventional'),
                    ('1.2',   '20W-40', 'Conventional',   3.0,  5000,  'E20/E30 1.2L; conventional'),
                    ('1.3',   '10W-30', 'Conventional',   3.5,  5000,  'E70–E170 1.3L; 10W-30'),
                    ('1.6GT', '10W-40', 'Semi-Synthetic', 3.8,  5000,  'AE86 1.6 GT 4A-GE; 10W-40'),
                    ('1.6',   '10W-30', 'Conventional',   3.8,  5000,  'E90–E170 1.6L; 10W-30'),
                    ('2.0D',  '5W-30',  'Conventional',   4.3,  5000,  'E100/E120/E140 2.0L diesel'),
                    ('1.4',   '5W-30',  'Semi-Synthetic', 3.8,  10000, 'E120/E140 1.4L; Toyota 5W-30'),
                    ('1.33',  '5W-30',  'Full Synthetic', 3.7,  10000, 'E170 1.33L 2NR-FE; Toyota 0W-20'),
                    ('1.2T',  '5W-30',  'Full Synthetic', 4.2,  10000, 'E210 1.2T 8NR-FTS; Toyota 5W-30'),
                    ('1.8H',  '0W-20',  'Full Synthetic', 4.2,  15000, 'E210 1.8 Hybrid 2ZR-FXE; Toyota Hybrid Oil 0W-20'),
                    ('2.0H',  '0W-20',  'Full Synthetic', 4.6,  15000, 'E210 2.0 Hybrid M20A-FXS; Toyota 0W-20'),
                    ('1.6T',  '5W-40',  'Full Synthetic', 5.0,  10000, 'GR Corolla 1.6T G16E-GTS; 5W-40')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'toyota-corolla'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- TOYOTA CAMRY
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'toyota-camry', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.0',   '10W-30', 'Conventional',   4.0,  8000,  'Camry V10/V20 2.0L; 10W-30'),
                    ('2.2',   '5W-30',  'Conventional',   4.3,  8000,  'Camry V30 2.2L 5S-FE; 5W-30'),
                    ('3.0V6', '5W-30',  'Conventional',   4.5,  8000,  'Camry V30 3.0 V6 1MZ-FE'),
                    ('2.4',   '5W-30',  'Semi-Synthetic', 4.3,  8000,  'Camry 2.4L 2AZ-FE; 5W-30'),
                    ('3.5V6', '5W-30',  'Full Synthetic', 6.4,  10000, 'Camry 3.5L 2GR-FE; 5W-30 API SN'),
                    ('2.4HV', '0W-20',  'Full Synthetic', 4.3,  10000, 'Camry Hybrid 2AZ-FXE; 0W-20'),
                    ('2.5',   '0W-20',  'Full Synthetic', 5.0,  10000, 'Camry 2.5L 2AR-FE; Toyota 0W-20'),
                    ('2.5HV', '0W-20',  'Full Synthetic', 4.8,  15000, 'Camry Hybrid A25A-FXS; Toyota Hybrid 0W-20')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'toyota-camry'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- HONDA CIVIC
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'honda-civic', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('1.2',       '20W-40', 'Conventional',   3.0,  5000,  'Civic 1st gen 1.2L'),
                    ('1.5CVCC',   '10W-40', 'Conventional',   3.0,  5000,  'Civic CVCC 1.5L'),
                    ('1.3',       '10W-30', 'Conventional',   3.0,  5000,  'Civic 3G/4G 1.3L'),
                    ('1.4',       '10W-30', 'Conventional',   3.0,  7500,  'Civic EG/EK/EP/FK 1.4L'),
                    ('1.6VTEC',   '10W-40', 'Semi-Synthetic', 4.0,  7500,  'Civic EF/EG/EK 1.6 VTEC B16A'),
                    ('2.0TypeR',  '10W-40', 'Full Synthetic', 5.1,  7500,  'Civic Type-R EP3/FN2/FK8/FL5 2.0 VTEC'),
                    ('1.6',       '5W-30',  'Semi-Synthetic', 3.5,  7500,  'Civic 7G/8G 1.6L'),
                    ('1.8',       '5W-20',  'Full Synthetic', 4.2,  10000, 'Civic 8G/9G/10G 1.8L R18; Honda HTO-06'),
                    ('2.2CTDi',   '5W-30',  'Full Synthetic', 4.5,  15000, 'Civic 8G 2.2 CDTi diesel N22'),
                    ('1.6iDTEC',  '5W-30',  'Full Synthetic', 3.5,  25000, 'Civic 9G 1.6 iDTEC diesel; 0W-30/5W-30'),
                    ('1.0T',      '0W-20',  'Full Synthetic', 3.2,  10000, 'Civic 10G 1.0T P10A3 VTEC Turbo; 0W-20'),
                    ('1.5T',      '0W-20',  'Full Synthetic', 4.0,  10000, 'Civic 10G/11G 1.5T L15B/B7; Honda 0W-20'),
                    ('eHV',       '0W-20',  'Full Synthetic', 3.5,  15000, 'Civic e:HEV 11G 2.0 hybrid; Honda 08798-9032')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'honda-civic'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- TESLA MODEL 3  (BEV – no engine oil)
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'tesla-model-3', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, NULL, 'Electric', 0.0, 0,
                    'BEV – no engine oil required. Check gearbox ATF per Tesla schedule.'
                FROM [CarModels] m
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id
                WHERE m.Slug = 'tesla-model-3';

                -- ==============================================================
                -- PORSCHE 911
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'porsche-911', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.0',    '20W-50', 'Conventional',   8.0,  10000, '901 2.0L air-cooled; 20W-50 monograde'),
                    ('2.2',    '20W-50', 'Conventional',   8.0,  10000, '911S 2.2L; 20W-50'),
                    ('2.4',    '20W-50', 'Conventional',   8.0,  10000, '911S 2.4L; 20W-50'),
                    ('2.7RS',  '20W-50', 'Conventional',   8.0,  10000, 'Carrera RS 2.7L; 20W-50'),
                    ('3.0SC',  '20W-50', 'Conventional',   9.0,  10000, '911 SC 3.0L; 20W-50'),
                    ('3.2',    '20W-50', 'Semi-Synthetic', 9.0,  10000, 'Carrera 3.2L; 20W-50 semi-synthetic'),
                    ('3.6',    '5W-40',  'Full Synthetic', 9.5,  15000, '964/993 3.6L; Porsche A40 5W-40'),
                    ('3.6T',   '5W-40',  'Full Synthetic', 9.5,  15000, '964/993 Turbo; Porsche A40 5W-40'),
                    ('3.4',    '5W-40',  'Full Synthetic', 9.5,  15000, '996/997 3.4L; Porsche A40 5W-40'),
                    ('3.8S',   '5W-40',  'Full Synthetic', 9.5,  15000, '997 S 3.8; Porsche A40'),
                    ('3.8T',   '5W-40',  'Full Synthetic', 9.5,  15000, '997 Turbo 3.8; Porsche A40'),
                    ('3.0T',   '0W-40',  'Full Synthetic', 8.75, 20000, '991.2/992 Carrera 3.0T; VW 502.00 0W-40'),
                    ('3.0TT',  '0W-40',  'Full Synthetic', 8.75, 20000, '991.2/992 Turbo; VW 502.00'),
                    ('3.8TT',  '0W-40',  'Full Synthetic', 9.5,  20000, '992 Turbo S 3.8; VW 502.00'),
                    ('3.6HV',  '0W-40',  'Full Synthetic', 8.75, 20000, '992.2 T-Hybrid 3.6; VW 502.00')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'porsche-911'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- VOLVO XC60
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'volvo-xc60', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.4D',    '5W-30', 'Full Synthetic', 5.5, 20000, 'XC60 Mk1 D5 2.4L I5; Volvo VCC-RBS0-2AE'),
                    ('3.0T',    '5W-30', 'Full Synthetic', 6.8, 20000, 'XC60 Mk1 T6 3.0T I6; Volvo 5W-30'),
                    ('2.0T',    '5W-30', 'Full Synthetic', 5.5, 20000, 'XC60 Mk1 T5 2.0T; 5W-30'),
                    ('2.0D',    '5W-30', 'Full Synthetic', 5.0, 20000, 'XC60 Mk1/Mk2 D4 2.0L diesel; VCC-RBS0-2AE'),
                    ('2.0TT',   '5W-30', 'Full Synthetic', 6.8, 20000, 'XC60 Mk1 T6 Drive-E 2.0T; 5W-30'),
                    ('B4D',     '0W-20', 'Full Synthetic', 5.0, 20000, 'XC60 Mk2 B4 diesel; Volvo 0W-20'),
                    ('B5D',     '0W-20', 'Full Synthetic', 5.0, 20000, 'XC60 Mk2 B5 diesel; Volvo 0W-20'),
                    ('B4P',     '0W-20', 'Full Synthetic', 5.0, 20000, 'XC60 Mk2 B4 petrol; Volvo 0W-20'),
                    ('B5P',     '0W-20', 'Full Synthetic', 5.0, 20000, 'XC60 Mk2 B5 petrol; Volvo 0W-20'),
                    ('B6P',     '0W-20', 'Full Synthetic', 5.0, 20000, 'XC60 Mk2 B6 AWD; Volvo 0W-20'),
                    ('T8PHEV',  '0W-20', 'Full Synthetic', 5.0, 20000, 'XC60 T8 PHEV; Volvo 0W-20 hybrid spec'),
                    ('Recharge','0W-20', 'Full Synthetic', 5.0, 20000, 'XC60 Recharge T8; Volvo 0W-20')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'volvo-xc60'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- HYUNDAI TUCSON
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'hyundai-tucson', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.0',     '5W-30', 'Semi-Synthetic', 4.0, 10000, 'Tucson JM 2.0L G4KA; API SL 5W-30'),
                    ('2.7V6',   '5W-30', 'Conventional',   4.2, 10000, 'Tucson JM 2.7 V6 G6BA'),
                    ('2.0CRDi', '5W-30', 'Full Synthetic', 4.5, 15000, 'Tucson JM/LM/TL/NX 2.0 CRDi; API CF 5W-30'),
                    ('1.6GDi',  '5W-30', 'Semi-Synthetic', 4.2, 10000, 'Tucson LM/TL 1.6 GDi G4FD'),
                    ('1.7CRDi', '5W-30', 'Full Synthetic', 4.3, 15000, 'Tucson LM/TL 1.7 CRDi D4FD'),
                    ('1.6TGDi', '5W-30', 'Full Synthetic', 4.2, 10000, 'Tucson TL/NX 1.6 T-GDi G4FJ; API SP'),
                    ('1.6HEV',  '0W-20', 'Full Synthetic', 4.2, 15000, 'Tucson NX HEV 1.6 hybrid; Hyundai 0W-20'),
                    ('1.6PHEV', '0W-20', 'Full Synthetic', 4.2, 15000, 'Tucson NX PHEV 1.6; Hyundai 0W-20')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'hyundai-tucson'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- KIA SPORTAGE
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'kia-sportage', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.0',     '10W-30', 'Conventional',   4.0, 8000,  'Sportage K00 2.0L; 10W-30'),
                    ('2.0D',    '5W-30',  'Conventional',   4.5, 8000,  'Sportage K00 2.0 diesel'),
                    ('2.7V6',   '5W-30',  'Conventional',   4.2, 10000, 'Sportage JE 2.7V6'),
                    ('2.0CRDi', '5W-30',  'Full Synthetic', 4.5, 15000, 'Sportage JE/SL/QL/NQ5 2.0 CRDi'),
                    ('1.6GDi',  '5W-30',  'Semi-Synthetic', 4.2, 10000, 'Sportage SL/QL 1.6 GDi G4FD'),
                    ('1.7CRDi', '5W-30',  'Full Synthetic', 4.3, 15000, 'Sportage SL 1.7 CRDi D4FD'),
                    ('1.6TGDi', '5W-30',  'Full Synthetic', 4.2, 10000, 'Sportage QL/NQ5 1.6 T-GDi G4FJ/G4FP'),
                    ('1.6CRDi', '5W-30',  'Full Synthetic', 4.5, 15000, 'Sportage QL 1.6 CRDi D4FE'),
                    ('1.6HEV',  '0W-20',  'Full Synthetic', 4.2, 15000, 'Sportage NQ5 HEV 1.6; Kia 0W-20'),
                    ('1.6PHEV', '0W-20',  'Full Synthetic', 4.2, 15000, 'Sportage NQ5 PHEV 1.6; Kia 0W-20')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'kia-sportage'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- MAZDA MX-5
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'mazda-mx5', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('1.6NA', '10W-40', 'Semi-Synthetic', 3.5, 8000,  'NA 1.6L B6; 10W-40'),
                    ('1.8NA', '10W-40', 'Semi-Synthetic', 3.8, 8000,  'NA 1.8L BP; 10W-40'),
                    ('1.6NB', '10W-40', 'Semi-Synthetic', 3.5, 8000,  'NB 1.6L B6; 10W-40'),
                    ('1.8NB', '5W-30',  'Full Synthetic', 3.8, 8000,  'NB 1.8L BP-4W VVT; 5W-30'),
                    ('2.0NC', '5W-30',  'Full Synthetic', 4.0, 10000, 'NC 2.0L LF-VE; Mazda 5W-30'),
                    ('1.5ND', '5W-30',  'Full Synthetic', 3.2, 10000, 'ND 1.5L P5-VPR SkyActiv-G; Mazda 5W-30'),
                    ('2.0ND', '5W-30',  'Full Synthetic', 4.3, 10000, 'ND 2.0L PE-VPR SkyActiv-G; Mazda 5W-30')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'mazda-mx5'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- SUBARU WRX
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'subaru-wrx', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.0T',    '5W-40', 'Full Synthetic', 3.8, 8000,  'WRX GC 2.0T EJ20T; 5W-40'),
                    ('2.0TS',   '5W-40', 'Full Synthetic', 3.8, 8000,  'STI GC/GD EJ20G/K; 5W-40'),
                    ('2.0TWrx', '5W-40', 'Full Synthetic', 4.0, 8000,  'WRX GD 2.0T EJ20K; 5W-40'),
                    ('2.5TWrx', '5W-30', 'Full Synthetic', 4.5, 8000,  'WRX GE 2.5T EJ255; Subaru 5W-30'),
                    ('2.5TS',   '5W-40', 'Full Synthetic', 4.5, 8000,  'STI GE/GV EJ257; 5W-40'),
                    ('2.0TDit', '5W-30', 'Full Synthetic', 5.1, 10000, 'WRX VA 2.0T DIT FA20DIT; 5W-30'),
                    ('2.4T',    '5W-30', 'Full Synthetic', 5.1, 10000, 'WRX VB 2.4T FA24; Subaru 5W-30'),
                    ('2.4TS',   '5W-30', 'Full Synthetic', 5.1, 8000,  'WRX STI 2.4T VB; 5W-30 full synthetic')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'subaru-wrx'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- BUICK FAMILY
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'buick-enclave', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('3.6V6', '5W-30', 'Full Synthetic', 5.7, 8000, 'Enclave 3.6L V6 LLT/LGX; GM dexos1'),
                    ('2.0T',  '5W-30', 'Full Synthetic', 5.0, 8000, 'Enclave 2.0T turbo; GM dexos1 Gen2')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'buick-enclave'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'buick-encore', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('1.4T', '5W-30', 'Full Synthetic', 4.2, 8000, 'Encore 1.4T LUV; GM dexos1'),
                    ('1.2T', '5W-30', 'Full Synthetic', 4.5, 8000, 'Encore 1.2T; GM dexos1 Gen2'),
                    ('1.3T', '5W-30', 'Full Synthetic', 5.0, 8000, 'Encore 1.3T; GM dexos1 Gen2')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'buick-encore'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'buick-encore-gx', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('1.2T', '5W-30', 'Full Synthetic', 4.5, 8000, 'Encore GX 1.2T; GM dexos1 Gen2'),
                    ('1.3T', '5W-30', 'Full Synthetic', 5.0, 8000, 'Encore GX 1.3T; GM dexos1 Gen2')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'buick-encore-gx'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'buick-envision', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.0T', '5W-30', 'Full Synthetic', 5.0, 8000, 'Envision 2.0T; GM dexos1 Gen2')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'buick-envision'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'buick-lacrosse', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('3.8V6', '5W-30',  'Conventional',   4.7, 8000, 'LaCrosse 3.8 V6 L36; GM 4718M / API SJ'),
                    ('2.4',   '5W-30',  'Full Synthetic', 5.0, 8000, 'LaCrosse 2.4L LE9; GM dexos1'),
                    ('3.6V6', '5W-30',  'Full Synthetic', 5.7, 8000, 'LaCrosse 3.6L LLT; GM dexos1'),
                    ('2.5HV', '5W-30',  'Full Synthetic', 4.5, 8000, 'LaCrosse 2.5 eAssist Hybrid; GM dexos1 Gen2')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'buick-lacrosse'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'buick-regal', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('3.8V6',  '10W-30', 'Conventional',   4.7, 8000, 'Regal 3.8L V6 L27/L36; conventional'),
                    ('2.0T',   '5W-30',  'Full Synthetic', 4.7, 8000, 'Regal 2.0T LHU; GM dexos1'),
                    ('2.0THV', '5W-30',  'Full Synthetic', 4.7, 8000, 'Regal eAssist Hybrid; GM dexos1 Gen2')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'buick-regal'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'buick-century', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('3.8V6', '10W-40', 'Conventional', 4.7, 8000, 'Century 3.8L V6; 10W-40 conventional'),
                    ('2.5',   '10W-30', 'Conventional', 4.0, 8000, 'Century 2.5L Tech IV I4; 10W-30'),
                    ('3.3V6', '10W-30', 'Conventional', 4.7, 8000, 'Century 3.3L LG7; 10W-30'),
                    ('3.1V6', '5W-30',  'Conventional', 4.5, 8000, 'Century 3.1L LG8; API SL 5W-30')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'buick-century'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- GMC FAMILY
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'gmc-sierra-1500', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('4.3V6', '5W-30',  'Conventional',   4.7,  8000,  'Sierra 4.3L V6 L35/LU3; API SJ/SL'),
                    ('4.8V8', '5W-30',  'Conventional',   5.7,  8000,  'Sierra 4.8L V8 LR4; 5W-30'),
                    ('5.3V8', '5W-30',  'Full Synthetic', 8.0,  10000, 'Sierra 5.3L V8; GM dexos1'),
                    ('6.0V8', '5W-30',  'Conventional',   6.6,  8000,  'Sierra 6.0L V8 LQ4; 5W-30'),
                    ('6.2V8', '5W-30',  'Full Synthetic', 8.0,  10000, 'Sierra 6.2L V8 L86; GM dexos1'),
                    ('2.7T',  '0W-20',  'Full Synthetic', 5.7,  10000, 'Sierra 2.7T L3B EcoTec3; GM dexos1 Gen2'),
                    ('3.0D',  '0W-20',  'Full Synthetic', 6.6,  16000, 'Sierra 3.0L Duramax diesel LM2; GM dexos2')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'gmc-sierra-1500'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'gmc-yukon', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('5.7V8', '5W-30',  'Conventional',   5.7,  8000,  'Yukon 5.7L V8 L31; API SJ'),
                    ('4.8V8', '5W-30',  'Conventional',   5.7,  8000,  'Yukon 4.8L V8; 5W-30'),
                    ('5.3V8', '5W-30',  'Full Synthetic', 8.0,  10000, 'Yukon 5.3L V8; GM dexos1'),
                    ('6.2V8', '5W-30',  'Full Synthetic', 8.0,  10000, 'Yukon 6.2L V8 L86; GM dexos1'),
                    ('3.0D',  '0W-20',  'Full Synthetic', 6.6,  16000, 'Yukon 3.0L Duramax diesel; GM dexos2')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'gmc-yukon'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'gmc-terrain', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.4',   '5W-30', 'Full Synthetic', 5.0,  8000,  'Terrain 2.4L LAF; GM dexos1'),
                    ('3.0V6', '5W-30', 'Full Synthetic', 5.7,  8000,  'Terrain 3.0L LF1; GM dexos1'),
                    ('1.5T',  '5W-30', 'Full Synthetic', 4.5,  8000,  'Terrain 1.5T LYX; GM dexos1 Gen2'),
                    ('2.0T',  '5W-30', 'Full Synthetic', 5.0,  8000,  'Terrain 2.0T LSY; GM dexos1 Gen2'),
                    ('1.6D',  '5W-30', 'Full Synthetic', 5.0,  16000, 'Terrain 1.6 diesel; GM dexos2')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'gmc-terrain'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'gmc-canyon', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.8',   '5W-30', 'Conventional',   5.0,  8000,  'Canyon 2.8L LK5 I4; API SL'),
                    ('3.5V5', '5W-30', 'Conventional',   5.7,  8000,  'Canyon 3.5L L52 I5; 5W-30'),
                    ('2.5',   '5W-30', 'Full Synthetic', 5.0,  8000,  'Canyon 2.5L LCV; GM dexos1'),
                    ('3.6V6', '5W-30', 'Full Synthetic', 5.7,  8000,  'Canyon 3.6L LGZ; GM dexos1'),
                    ('2.8D',  '5W-30', 'Full Synthetic', 6.6,  16000, 'Canyon 2.8L Duramax diesel LWN; GM dexos2'),
                    ('2.7T',  '0W-20', 'Full Synthetic', 5.7,  10000, 'Canyon 2.7T L3B Turbo; GM dexos1 Gen2')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'gmc-canyon'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- PONTIAC FAMILY
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'pontiac-firebird', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('5.7V8', '10W-40', 'Conventional', 5.7, 8000, 'Firebird 5.7L 400 V8; 10W-40'),
                    ('6.6V8', '10W-40', 'Conventional', 5.7, 8000, 'Firebird 6.6L V8; 10W-40'),
                    ('5.0V8', '10W-30', 'Conventional', 4.7, 8000, 'Firebird 5.0L HO; 10W-30'),
                    ('3.8V6', '5W-30',  'Conventional', 4.7, 8000, 'Firebird 3.8L L36; 5W-30')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'pontiac-firebird'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'pontiac-trans-am', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('6.6V8', '10W-40', 'Conventional', 5.7, 8000, 'Trans Am 6.6L SD-455; 10W-40'),
                    ('5.0V8', '10W-30', 'Conventional', 4.7, 8000, 'Trans Am 5.0L TPI; 10W-30'),
                    ('5.7V8', '5W-30',  'Conventional', 5.7, 8000, 'Trans Am 5.7L LS1; 5W-30')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'pontiac-trans-am'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'pontiac-gto', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('6.4V8', '10W-40', 'Conventional',   5.7, 8000, 'GTO 389/400 V8 1964-71; 10W-40'),
                    ('6.6V8', '10W-40', 'Conventional',   5.7, 8000, 'GTO 400 CID 1968-71; 10W-40'),
                    ('5.7V8', '5W-30',  'Full Synthetic', 5.7, 8000, 'GTO 2004-05 5.7L LS1; 5W-30'),
                    ('6.0V8', '5W-30',  'Full Synthetic', 6.6, 8000, 'GTO 2005-06 6.0L LS2; 5W-30')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'pontiac-gto'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'pontiac-grand-prix', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('6.6V8',   '10W-40', 'Conventional',   5.7, 8000, 'Grand Prix 6.6L V8; 10W-40'),
                    ('3.4V6',   '5W-30',  'Conventional',   4.7, 8000, 'Grand Prix 3.4L LA1; 5W-30'),
                    ('3.8V6',   '5W-30',  'Conventional',   4.7, 8000, 'Grand Prix 3.8L L36; API SJ'),
                    ('3.8SCV6', '5W-30',  'Conventional',   4.7, 8000, 'Grand Prix SC 3.8L L67; 5W-30'),
                    ('5.3V8',   '5W-30',  'Full Synthetic', 6.6, 8000, 'Grand Prix GXP 5.3L LS4; GM dexos1')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'pontiac-grand-prix'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- CHRYSLER / RAM
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'chrysler-300', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.7V6', '5W-30',  'Conventional',   4.7, 8000,  'Chrysler 300 2.7L V6 EER; API SM'),
                    ('3.5V6', '5W-30',  'Conventional',   5.0, 8000,  'Chrysler 300 3.5L V6 EGM'),
                    ('5.7V8', '5W-20',  'Full Synthetic', 5.7, 8000,  'Chrysler 300 5.7L HEMI; FCA MS-6395'),
                    ('6.1V8', '5W-20',  'Full Synthetic', 6.6, 8000,  'Chrysler 300 SRT8 6.1L; 5W-20'),
                    ('3.6V6', '5W-20',  'Full Synthetic', 5.7, 10000, 'Chrysler 300 3.6L Pentastar; FCA MS-6395'),
                    ('6.4V8', '5W-20',  'Full Synthetic', 7.1, 8000,  'Chrysler 300 SRT8 6.4L; 5W-20')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'chrysler-300'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'chrysler-pacifica', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('3.6V6',   '5W-20', 'Full Synthetic', 5.7, 10000, 'Pacifica 3.6L Pentastar; FCA MS-6395'),
                    ('3.6PHEV', '5W-20', 'Full Synthetic', 5.7, 10000, 'Pacifica Hybrid 3.6L; FCA MS-6395')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'chrysler-pacifica'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'chrysler-sebring', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.0',   '5W-30', 'Conventional', 4.2, 8000, 'Sebring 2.0L 420A; API SJ'),
                    ('2.5V6', '5W-30', 'Conventional', 4.7, 8000, 'Sebring 2.5L V6 6G73'),
                    ('2.4',   '5W-30', 'Conventional', 4.7, 8000, 'Sebring 2.4L EDZ; 5W-30'),
                    ('2.7V6', '5W-30', 'Conventional', 4.7, 8000, 'Sebring 2.7L EER V6; 5W-30'),
                    ('3.5V6', '5W-30', 'Conventional', 5.0, 8000, 'Sebring 3.5L V6 EGM; 5W-30')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'chrysler-sebring'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'ram-1500', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('3.6V6',    '5W-20',  'Full Synthetic', 5.7,  10000, 'Ram 1500 3.6L Pentastar; FCA MS-6395'),
                    ('5.7V8',    '5W-20',  'Full Synthetic', 6.6,  10000, 'Ram 1500 5.7L HEMI MDS; FCA MS-6395'),
                    ('3.0D',     '5W-40',  'Full Synthetic', 8.0,  16000, 'Ram 1500 3.0L EcoDiesel; FCA MS-10725'),
                    ('5.7ETORQ', '5W-20',  'Full Synthetic', 6.6,  10000, 'Ram 1500 5.7L eTorque MHEV; FCA MS-6395'),
                    ('REV',      NULL,     'Electric',       0.0,  0,     'Ram 1500 REV BEV – no engine oil required')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'ram-1500'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'ram-2500', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('5.7V8', '5W-20',  'Full Synthetic', 6.6,  10000, 'Ram 2500 5.7L HEMI; FCA MS-6395'),
                    ('6.4V8', '5W-20',  'Full Synthetic', 7.1,  10000, 'Ram 2500 6.4L HEMI; FCA MS-6395'),
                    ('6.7D',  '15W-40', 'Full Synthetic', 14.2, 24000, 'Ram 2500 6.7L Cummins I6 diesel; API CJ-4')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'ram-2500'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- SAAB FAMILY
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'saab-9-3', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.0T',   '5W-30', 'Full Synthetic', 4.0, 15000, 'Saab 9-3 YS3D/YS3F 2.0T B204/B207L; GM LL-A-025'),
                    ('2.0HOT', '5W-30', 'Full Synthetic', 4.0, 15000, 'Saab 9-3 HOT 2.0T; 5W-30'),
                    ('1.8T',   '5W-30', 'Full Synthetic', 4.0, 15000, 'Saab 9-3 YS3F 1.8T B207E; 5W-30'),
                    ('2.8TV6', '5W-30', 'Full Synthetic', 6.0, 15000, 'Saab 9-3 Aero 2.8T V6 B284; 5W-30'),
                    ('1.9TDI', '5W-30', 'Full Synthetic', 4.3, 20000, 'Saab 9-3 1.9 TDi diesel; ACEA C3')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'saab-9-3'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'saab-9-5', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.0T',   '5W-30', 'Full Synthetic', 4.0, 15000, 'Saab 9-5 YS3E 2.0T B205; GM LL-A-025'),
                    ('2.3T',   '5W-30', 'Full Synthetic', 4.5, 15000, 'Saab 9-5 2.3T B235E/R; 5W-30'),
                    ('3.0V6T', '5W-30', 'Full Synthetic', 6.0, 15000, 'Saab 9-5 3.0T V6 B308E; 5W-30'),
                    ('2.8TV6', '5W-30', 'Full Synthetic', 6.0, 15000, 'Saab 9-5 Aero 2.8T V6; GM LL-A-025'),
                    ('1.9TDI', '5W-30', 'Full Synthetic', 4.3, 20000, 'Saab 9-5 1.9 TDi; ACEA C3')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'saab-9-5'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'saab-900', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.0',   '10W-40', 'Conventional',   4.0, 10000, 'Saab 900 classic 2.0L B200; 10W-40'),
                    ('2.0T',  '10W-40', 'Semi-Synthetic', 4.0, 10000, 'Saab 900 2.0T B202; 10W-40'),
                    ('2.3',   '5W-30',  'Semi-Synthetic', 4.0, 10000, 'Saab 900 NG 2.3L B234; 5W-30'),
                    ('2.5V6', '5W-30',  'Semi-Synthetic', 5.5, 10000, 'Saab 900 2.5 V6 B258; 5W-30')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'saab-900'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- JAGUAR FAMILY
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'jaguar-xf', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.7D',    '5W-30', 'Full Synthetic', 7.0, 20000, 'XF 2.7D V6 TDV6; STJLR.03.5004'),
                    ('3.0D',    '5W-30', 'Full Synthetic', 8.5, 20000, 'XF 3.0D V6 TDV6; STJLR.03.5004'),
                    ('3.0V6',   '5W-30', 'Full Synthetic', 6.0, 20000, 'XF 3.0 V6 SC; STJLR.03.5004'),
                    ('5.0V8',   '5W-30', 'Full Synthetic', 8.5, 20000, 'XF 5.0 V8 AJ133; STJLR.03.5004'),
                    ('5.0SCV8', '5W-30', 'Full Synthetic', 8.5, 10000, 'XF-R 5.0 SC V8; STJLR.03.5004'),
                    ('2.0D',    '0W-30', 'Full Synthetic', 5.5, 25000, 'XF Mk2 2.0D Ingenium; STJLR.51.5122'),
                    ('2.0T',    '0W-30', 'Full Synthetic', 5.0, 25000, 'XF Mk2 2.0T Ingenium petrol; STJLR.51.5122'),
                    ('3.0SC',   '5W-30', 'Full Synthetic', 6.0, 20000, 'XF Mk2 3.0 SC V6; STJLR.03.5004')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'jaguar-xf'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'jaguar-f-pace', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.0D',  '0W-30', 'Full Synthetic', 5.5, 25000, 'F-Pace 2.0D Ingenium; STJLR.51.5122'),
                    ('3.0D',  '5W-30', 'Full Synthetic', 8.5, 20000, 'F-Pace 3.0D V6; STJLR.03.5004'),
                    ('2.0T',  '0W-30', 'Full Synthetic', 5.0, 25000, 'F-Pace 2.0T Ingenium; STJLR.51.5122'),
                    ('3.0SC', '5W-30', 'Full Synthetic', 6.0, 20000, 'F-Pace 3.0 SC V6; STJLR.03.5004'),
                    ('3.0T',  '0W-20', 'Full Synthetic', 7.0, 25000, 'F-Pace P400 MHEV I6; STJLR.51.5122'),
                    ('PHEV',  '0W-20', 'Full Synthetic', 5.0, 25000, 'F-Pace P400e PHEV; STJLR.51.5122')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'jaguar-f-pace'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'jaguar-f-type', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('3.0V6',  '5W-30', 'Full Synthetic', 6.0, 20000, 'F-Type 3.0 V6 SC; STJLR.03.5004'),
                    ('3.0SV6', '5W-30', 'Full Synthetic', 6.0, 20000, 'F-Type S 3.0 V6 SC; STJLR.03.5004'),
                    ('5.0V8R', '5W-30', 'Full Synthetic', 8.5, 10000, 'F-Type R 5.0 V8 SC; STJLR.03.5004'),
                    ('2.0T',   '0W-30', 'Full Synthetic', 5.0, 25000, 'F-Type P300 2.0T Ingenium; STJLR.51.5122'),
                    ('5.0V8',  '5W-30', 'Full Synthetic', 8.5, 20000, 'F-Type P450 5.0 V8; STJLR.03.5004')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'jaguar-f-type'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'jaguar-i-pace', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, NULL, 'Electric', 0.0, 0, 'I-Pace BEV – no engine oil required'
                FROM [CarModels] m
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id
                WHERE m.Slug = 'jaguar-i-pace';

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'jaguar-xj', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('4.2',     '20W-50', 'Conventional',   7.5, 8000,  'XJ Series I-III 4.2L XK6; 20W-50'),
                    ('3.6',     '10W-40', 'Semi-Synthetic', 7.0, 10000, 'XJ XJ40 3.6L I6; 10W-40'),
                    ('3.2',     '10W-40', 'Semi-Synthetic', 7.0, 10000, 'XJ X300 3.2L AJ16; 10W-40'),
                    ('4.0SC',   '10W-40', 'Semi-Synthetic', 8.0, 10000, 'XJ X300 4.0 SC; 10W-40'),
                    ('3.5V8',   '5W-30',  'Full Synthetic', 7.5, 15000, 'XJ X350 3.5L AJ-V8; 5W-30'),
                    ('4.2V8',   '5W-30',  'Full Synthetic', 7.5, 15000, 'XJ X350 4.2L AJ-V8; STJLR.03.5004'),
                    ('3.0D',    '5W-30',  'Full Synthetic', 8.5, 20000, 'XJ X351 3.0D V6 TDV6; STJLR.03.5004'),
                    ('3.0SC',   '5W-30',  'Full Synthetic', 6.0, 20000, 'XJ X351 3.0 SC V6; STJLR.03.5004'),
                    ('5.0V8',   '5W-30',  'Full Synthetic', 8.5, 20000, 'XJ X351 5.0 V8; STJLR.03.5004'),
                    ('5.0SCV8', '5W-30',  'Full Synthetic', 8.5, 10000, 'XJR X351 5.0 SC V8; STJLR.03.5004')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'jaguar-xj'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- MINI FAMILY
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'mini-hatch', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('1.6',    '5W-30', 'Full Synthetic', 4.2, 25000, 'Mini R50/R56 1.6L W10/N16; BMW LL-01'),
                    ('1.6SC',  '5W-30', 'Full Synthetic', 4.5, 25000, 'Mini Cooper S R53 1.6 SC; BMW LL-01'),
                    ('1.6T',   '5W-30', 'Full Synthetic', 4.5, 25000, 'Mini Cooper S R56 1.6T N14; BMW LL-01'),
                    ('1.6JCW', '5W-30', 'Full Synthetic', 4.5, 25000, 'Mini JCW R56 N14; BMW LL-04'),
                    ('1.6D',   '5W-30', 'Full Synthetic', 4.5, 25000, 'Mini Cooper D R56 1.6D N47; BMW LL-04'),
                    ('1.2T',   '5W-30', 'Full Synthetic', 4.2, 25000, 'Mini Cooper F56 1.2T B38; BMW LL-01 FE'),
                    ('2.0T',   '5W-30', 'Full Synthetic', 4.5, 25000, 'Mini Cooper S F56 2.0T B48; BMW LL-01 FE'),
                    ('2.0JCW', '5W-30', 'Full Synthetic', 4.5, 25000, 'Mini JCW F56 2.0T B48; BMW LL-04'),
                    ('1.5D',   '5W-30', 'Full Synthetic', 4.2, 25000, 'Mini Cooper D F56 1.5D B37; BMW LL-04'),
                    ('1.5T',   '0W-30', 'Full Synthetic', 4.2, 30000, 'Mini Cooper F56 refresh 1.5T; BMW LL-17 FE+'),
                    ('EV',     NULL,    'Electric',       0.0, 0,     'Mini Cooper SE F56/J01 BEV – no engine oil')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'mini-hatch'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'mini-countryman', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('1.6',   '5W-30', 'Full Synthetic', 4.2, 25000, 'Countryman R60 1.6L N16; BMW LL-01'),
                    ('1.6T',  '5W-30', 'Full Synthetic', 4.5, 25000, 'Countryman Cooper S R60 1.6T; BMW LL-01'),
                    ('2.0D',  '5W-30', 'Full Synthetic', 4.5, 25000, 'Countryman R60/F60 2.0D N47/B47; BMW LL-04'),
                    ('1.5T',  '5W-30', 'Full Synthetic', 4.2, 25000, 'Countryman F60 1.5T B38; BMW LL-01 FE'),
                    ('2.0T',  '5W-30', 'Full Synthetic', 4.5, 25000, 'Countryman S F60/U25 2.0T B48; BMW LL-01 FE'),
                    ('PHEV',  '5W-30', 'Full Synthetic', 4.2, 25000, 'Countryman SE PHEV F60; BMW LL-04'),
                    ('EV',    NULL,    'Electric',       0.0, 0,     'Countryman SE All4 U25 BEV – no engine oil')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'mini-countryman'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- SEAT FAMILY
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'seat-leon', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('1.4',     '10W-40', 'Conventional',   3.5, 10000, 'Leon Mk1 1.4L; VW 501.01'),
                    ('1.8T',    '5W-40',  'Full Synthetic', 4.5, 15000, 'Leon Mk1 1.8T 20v; VW 502.00'),
                    ('1.9TDI',  '5W-40',  'Full Synthetic', 4.5, 15000, 'Leon Mk1 1.9 TDI PD; VW 505.01'),
                    ('1.4TSI',  '5W-30',  'Full Synthetic', 4.5, 30000, 'Leon Mk2/Mk3 1.4 TSI; VW 504.00'),
                    ('2.0TFSI', '5W-30',  'Full Synthetic', 4.5, 30000, 'Leon Cupra Mk2/Mk3/Mk4; VW 504.00'),
                    ('2.0TDI',  '5W-30',  'Full Synthetic', 4.3, 30000, 'Leon Mk2/Mk3/Mk4 2.0 TDI; VW 507.00'),
                    ('1.0TSI',  '0W-20',  'Full Synthetic', 3.3, 30000, 'Leon Mk3/Mk4 1.0 TSI; VW 508.00'),
                    ('1.5TSI',  '0W-20',  'Full Synthetic', 4.6, 30000, 'Leon Mk4 1.5 TSI evo; VW 508.00'),
                    ('2.0TSI',  '5W-30',  'Full Synthetic', 4.5, 30000, 'Leon Cupra R Mk4; VW 504.00'),
                    ('eHybrid', '5W-30',  'Full Synthetic', 4.5, 30000, 'Leon Mk4 eHybrid PHEV; VW 508.00')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'seat-leon'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'seat-ibiza', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('1.2',    '10W-40', 'Conventional',   3.0, 10000, 'Ibiza Mk1 1.2L; VW 501.01'),
                    ('1.4',    '10W-40', 'Conventional',   3.5, 10000, 'Ibiza Mk2/Mk3 1.4L; VW 501.01'),
                    ('1.8T',   '5W-40',  'Full Synthetic', 4.5, 15000, 'Ibiza GTi Mk2 1.8T; VW 502.00'),
                    ('1.9TDI', '5W-40',  'Full Synthetic', 4.5, 15000, 'Ibiza Mk3 1.9 TDI PD; VW 505.01'),
                    ('1.2TSI', '5W-30',  'Full Synthetic', 3.8, 30000, 'Ibiza Mk4 1.2 TSI; VW 504.00'),
                    ('1.4TSI', '5W-30',  'Full Synthetic', 4.5, 30000, 'Ibiza Mk4 1.4 TSI; VW 504.00'),
                    ('1.6TDI', '5W-30',  'Full Synthetic', 3.8, 30000, 'Ibiza Mk4 1.6 TDI; VW 507.00'),
                    ('1.0TSI', '0W-20',  'Full Synthetic', 3.3, 30000, 'Ibiza Mk5 1.0 TSI; VW 508.00'),
                    ('1.5TSI', '0W-20',  'Full Synthetic', 4.5, 30000, 'Ibiza Mk5 1.5 TSI; VW 508.00'),
                    ('1.0TDI', '5W-30',  'Full Synthetic', 3.3, 30000, 'Ibiza Mk5 1.0 TDI; VW 509.00')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'seat-ibiza'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'seat-ateca', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('1.0TSI', '0W-20', 'Full Synthetic', 3.3, 30000, 'Ateca 1.0 TSI; VW 508.00'),
                    ('1.5TSI', '0W-20', 'Full Synthetic', 4.6, 30000, 'Ateca 1.5 TSI evo; VW 508.00'),
                    ('2.0TSI', '5W-30', 'Full Synthetic', 4.5, 30000, 'Ateca Cupra 2.0 TSI; VW 504.00'),
                    ('2.0TDI', '5W-30', 'Full Synthetic', 4.3, 30000, 'Ateca 2.0 TDI; VW 507.00')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'seat-ateca'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- MITSUBISHI FAMILY
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'mitsubishi-outlander', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.0',      '5W-30', 'Conventional',   4.0, 8000,  'Outlander Mk1 2.0L 4G63; API SL'),
                    ('2.4',      '5W-30', 'Conventional',   4.3, 8000,  'Outlander Mk1 2.4L 4G69; 5W-30'),
                    ('2.4PHEV',  '0W-30', 'Full Synthetic', 4.2, 15000, 'Outlander PHEV 2.4 4N14; 0W-30'),
                    ('2.2D',     '5W-30', 'Full Synthetic', 5.5, 15000, 'Outlander Mk3 2.2D 4N14; ACEA C3'),
                    ('2.5',      '5W-30', 'Full Synthetic', 4.5, 10000, 'Outlander Mk4 2.5L 4B12; API SP')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'mitsubishi-outlander'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'mitsubishi-lancer', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('1.4',   '10W-30', 'Conventional',   3.5, 8000, 'Lancer A70 1.4L; 10W-30'),
                    ('1.5',   '5W-30',  'Conventional',   3.8, 8000, 'Lancer C70/CS/CY 1.5L; 5W-30'),
                    ('2.0',   '5W-30',  'Semi-Synthetic', 4.0, 8000, 'Lancer CY 2.0L 4B11; 5W-30'),
                    ('2.0T',  '5W-40',  'Full Synthetic', 4.2, 8000, 'Lancer Evo VI-X 2.0T 4G63/4B11; 5W-40')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'mitsubishi-lancer'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'mitsubishi-eclipse-cross', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('1.5T',    '5W-30', 'Full Synthetic', 3.8, 10000, 'Eclipse Cross 1.5T 4B40; API SP'),
                    ('2.2D',    '5W-30', 'Full Synthetic', 5.5, 15000, 'Eclipse Cross 2.2D 4N14; ACEA C3'),
                    ('2.4PHEV', '0W-30', 'Full Synthetic', 4.2, 15000, 'Eclipse Cross PHEV 2.4; 0W-30')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'mitsubishi-eclipse-cross'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- LEXUS FAMILY
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'lexus-is', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.0',   '5W-30', 'Conventional',   5.5, 8000,  'IS200 1G-FE I6; Toyota 5W-30'),
                    ('3.0',   '5W-30', 'Conventional',   6.0, 8000,  'IS300 2JZ-GE I6; Toyota 5W-30'),
                    ('2.5V6', '5W-30', 'Full Synthetic', 5.5, 10000, 'IS250 4GR-FSE V6; API SN'),
                    ('3.5V6', '5W-30', 'Full Synthetic', 6.4, 10000, 'IS350 2GR-FSE V6; API SN'),
                    ('2.0T',  '5W-30', 'Full Synthetic', 5.4, 10000, 'IS200t/IS300 8AR-FTS Turbo; Toyota 5W-30'),
                    ('3.5F',  '0W-20', 'Full Synthetic', 6.4, 10000, 'IS-F/IS500 V8/V6; Toyota 0W-20')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'lexus-is'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'lexus-rx', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('3.0V6',    '5W-30', 'Conventional',   5.5, 8000,  'RX300 1MZ-FE; Toyota 5W-30'),
                    ('3.3V6',    '5W-30', 'Full Synthetic', 5.5, 8000,  'RX330/350 3MZ-FE; API SN'),
                    ('3.3HV',    '5W-30', 'Full Synthetic', 5.0, 8000,  'RX400h 3MZ-FXE Hybrid; Toyota Hybrid'),
                    ('3.5V6',    '0W-20', 'Full Synthetic', 6.4, 10000, 'RX350 2GR-FE/FKS; Toyota 0W-20'),
                    ('3.5HV',    '0W-20', 'Full Synthetic', 6.4, 10000, 'RX450h 2GR-FXS; Toyota Hybrid 0W-20'),
                    ('3.5PHEV',  '0W-20', 'Full Synthetic', 6.4, 10000, 'RX450hL PHEV; Toyota Hybrid 0W-20'),
                    ('2.5HV',    '0W-16', 'Full Synthetic', 4.8, 15000, 'RX350h A25A-FXS; Toyota 0W-16'),
                    ('2.4T',     '0W-20', 'Full Synthetic', 5.7, 10000, 'RX350 T24A-FTS; Toyota 0W-20'),
                    ('2.5PHEV',  '0W-16', 'Full Synthetic', 4.8, 15000, 'RX450h+ A25A-FXS PHEV; Toyota 0W-16')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'lexus-rx'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'lexus-nx', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.0T',    '5W-30', 'Full Synthetic', 4.8, 10000, 'NX200t 8AR-FTS; Toyota 5W-30'),
                    ('2.5HV',   '0W-20', 'Full Synthetic', 4.8, 15000, 'NX300h/NX350h A25A-FXS; Toyota Hybrid 0W-20'),
                    ('2.4T',    '0W-20', 'Full Synthetic', 5.5, 10000, 'NX350 T24A-FTS; Toyota 0W-20'),
                    ('2.5PHEV', '0W-16', 'Full Synthetic', 4.8, 15000, 'NX450h+ PHEV; Toyota 0W-16')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'lexus-nx'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'lexus-es', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.5V6', '5W-30', 'Conventional',   4.3, 8000,  'ES250 V6 2VZ-FE; 5W-30'),
                    ('3.0V6', '5W-30', 'Conventional',   5.0, 8000,  'ES300/ES330 1MZ-FE; 5W-30'),
                    ('3.5V6', '5W-30', 'Full Synthetic', 6.4, 10000, 'ES350 2GR-FE/FKS; API SN'),
                    ('2.5HV', '0W-20', 'Full Synthetic', 4.8, 15000, 'ES300h 2AR-FXE / A25A-FXS; Toyota Hybrid')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'lexus-es'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- INFINITI FAMILY
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'infiniti-q50', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('3.7V6',  '5W-30', 'Full Synthetic', 5.1, 10000, 'Q50 3.7L VQ37VHR; Nissan NS-2'),
                    ('2.0T',   '5W-30', 'Full Synthetic', 5.1, 10000, 'Q50 2.0T M274; Nissan NS-3'),
                    ('3.5HV',  '5W-30', 'Full Synthetic', 5.1, 10000, 'Q50 Hybrid 3.5L VQ35HR; Nissan NS-3'),
                    ('3.0TT',  '5W-30', 'Full Synthetic', 5.7, 10000, 'Q50 Red Sport 3.0TT VR30DDTT; Nissan NS-4')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'infiniti-q50'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'infiniti-qx60', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('3.5V6', '5W-30', 'Full Synthetic', 5.1, 10000, 'QX60 3.5L VQ35DE; Nissan NS-3'),
                    ('2.5HV', '5W-30', 'Full Synthetic', 5.1, 10000, 'QX60 Hybrid 2.5L QR25DER; Nissan NS-3')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'infiniti-qx60'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'infiniti-qx80', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('5.6V8', '5W-30', 'Full Synthetic', 6.6, 10000, 'QX80 5.6L VK56VD; Nissan NS-3'),
                    ('3.5TT', '5W-30', 'Full Synthetic', 5.7, 10000, 'QX80 3.5TT VR38DETT; Nissan NS-4')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'infiniti-qx80'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- ACURA FAMILY
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'acura-tlx', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.4',   '0W-20', 'Full Synthetic', 4.4, 10000, 'TLX 2.4L K24W7; Honda HTO-06 0W-20'),
                    ('3.5V6', '5W-20', 'Full Synthetic', 4.5, 10000, 'TLX 3.5L J35Y5; Honda 5W-20'),
                    ('2.0T',  '0W-20', 'Full Synthetic', 4.3, 10000, 'TLX 2.0T K20C4; Honda 0W-20'),
                    ('3.0TT', '0W-20', 'Full Synthetic', 5.5, 10000, 'TLX Type S 3.0T J30CA; Honda 0W-20')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'acura-tlx'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'acura-mdx', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('3.5V6', '5W-20', 'Full Synthetic', 4.5, 10000, 'MDX 3.5L J35; Honda HTO-06'),
                    ('3.7V6', '5W-20', 'Full Synthetic', 4.5, 10000, 'MDX 3.7L J37A1; Honda 5W-20'),
                    ('3.0HV', '0W-20', 'Full Synthetic', 4.5, 10000, 'MDX Sport Hybrid 3.0L J30A5; Honda 0W-20'),
                    ('3.0TS', '0W-20', 'Full Synthetic', 5.5, 10000, 'MDX Type S 3.0T J30CA; Honda 0W-20')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'acura-mdx'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'acura-rdx', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.3T',     '5W-30', 'Full Synthetic', 4.2, 8000,  'RDX 2.3T K23A1; API SM'),
                    ('3.5V6',    '5W-20', 'Full Synthetic', 4.5, 10000, 'RDX 3.5L J35Y5; Honda 5W-20'),
                    ('2.0T',     '0W-20', 'Full Synthetic', 4.3, 10000, 'RDX 2.0T K20CA; Honda 0W-20'),
                    ('2.0TPHEV', '0W-20', 'Full Synthetic', 4.3, 10000, 'RDX PHEV 2.0T; Honda 0W-20')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'acura-rdx'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- SUZUKI FAMILY
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'suzuki-swift', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('1.0',   '10W-30', 'Conventional',   3.0, 7500,  'Swift 1.0L F10A/G10A; 10W-30'),
                    ('1.3',   '10W-30', 'Conventional',   3.5, 7500,  'Swift 1.3L G13B; 10W-30'),
                    ('1.2',   '5W-30',  'Semi-Synthetic', 3.8, 10000, 'Swift Z/AZ 1.2L K12C; API SL'),
                    ('1.4T',  '5W-30',  'Full Synthetic', 4.2, 10000, 'Swift Sport 1.4T K14B; 5W-30'),
                    ('1.3D',  '5W-30',  'Full Synthetic', 3.8, 15000, 'Swift 1.3D DDiS; 5W-30'),
                    ('1.0T',  '5W-30',  'Full Synthetic', 3.8, 10000, 'Swift AZ 1.0T K10C Boosterjet; 5W-30'),
                    ('1.2HV', '5W-30',  'Full Synthetic', 3.5, 15000, 'Swift AZ 1.2 Dualjet MHEV K12D; 5W-30')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'suzuki-swift'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'suzuki-vitara', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('1.6',    '10W-40', 'Conventional',   4.0, 8000,  'Vitara G16A; 10W-40'),
                    ('2.0V6',  '10W-40', 'Conventional',   4.5, 8000,  'Vitara 2.0V6 J20A; 10W-40'),
                    ('1.0T',   '5W-30',  'Full Synthetic', 3.8, 10000, 'Vitara LY 1.0T K10C Boosterjet; 5W-30'),
                    ('1.4T',   '5W-30',  'Full Synthetic', 4.5, 10000, 'Vitara LY 1.4T K14C; 5W-30'),
                    ('1.6D',   '5W-30',  'Full Synthetic', 4.5, 15000, 'Vitara LY 1.6D D16AA; ACEA C2'),
                    ('1.4THV', '5W-30',  'Full Synthetic', 4.5, 15000, 'Vitara 1.4T MHEV K14D; 5W-30')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'suzuki-vitara'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'suzuki-jimny', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('0.8', '10W-30', 'Conventional',   3.0, 7500,  'Jimny LJ/SJ 0.8L F8A; 10W-30'),
                    ('1.3', '5W-30',  'Semi-Synthetic', 4.0, 8000,  'Jimny JB43 1.3L M13A; API SL'),
                    ('1.5', '5W-30',  'Full Synthetic', 4.0, 10000, 'Jimny JB74 1.5L K15B; API SP')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'suzuki-jimny'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- ISUZU FAMILY
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'isuzu-trooper', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.3',   '10W-30', 'Conventional', 4.5, 8000, 'Trooper 2.3L 4ZD1; 10W-30'),
                    ('3.2V6', '10W-30', 'Conventional', 5.0, 8000, 'Trooper 3.2L 6VD1; API SJ 10W-30'),
                    ('3.5V6', '5W-30',  'Conventional', 5.0, 8000, 'Trooper 3.5L 6VE1; API SJ 5W-30'),
                    ('3.0D',  '5W-40',  'Conventional', 7.0, 8000, 'Trooper 3.0D 4JX1 diesel; 5W-40')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'isuzu-trooper'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'isuzu-rodeo', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.6',   '10W-30', 'Conventional', 4.5, 8000, 'Rodeo 2.6L 4ZE1; 10W-30'),
                    ('3.1V6', '10W-30', 'Conventional', 4.5, 8000, 'Rodeo 3.1L V6; 10W-30'),
                    ('2.2',   '5W-30',  'Conventional', 4.2, 8000, 'Rodeo 2.2L X22SE; API SJ'),
                    ('3.2V6', '5W-30',  'Conventional', 5.0, 8000, 'Rodeo 3.2L 6VD1; 5W-30')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'isuzu-rodeo'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                -- ==============================================================
                -- GENESIS FAMILY
                -- ==============================================================
                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'genesis-g80', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.0T',   '5W-30', 'Full Synthetic', 4.8, 10000, 'G80 2.0T G4KH; Hyundai 5W-30'),
                    ('3.3TT',  '5W-30', 'Full Synthetic', 5.3, 10000, 'G80 3.3TT G6DP; Hyundai 5W-30'),
                    ('5.0V8',  '5W-30', 'Full Synthetic', 6.0, 10000, 'G80 5.0L V8 G8DA; 5W-30'),
                    ('2.5T',   '5W-30', 'Full Synthetic', 5.0, 10000, 'G80 2.5T G4KM; Hyundai 5W-30'),
                    ('3.5TT',  '5W-30', 'Full Synthetic', 5.3, 10000, 'G80 3.5TT G6DO; Hyundai 5W-30'),
                    ('EV',     NULL,    'Electric',       0.0, 0,     'Genesis Electrified G80 BEV – no engine oil')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'genesis-g80'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'genesis-g70', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.0T',  '5W-30', 'Full Synthetic', 4.8, 10000, 'G70 2.0T G4KH; Hyundai 5W-30'),
                    ('3.3TT', '5W-30', 'Full Synthetic', 5.3, 10000, 'G70 3.3TT G6DP; Hyundai 5W-30')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'genesis-g70'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'genesis-g90', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('3.3TT',   '5W-30', 'Full Synthetic', 5.3, 10000, 'G90 3.3TT G6DP; Hyundai 5W-30'),
                    ('5.0V8',   '5W-30', 'Full Synthetic', 6.0, 10000, 'G90 5.0 V8 G8DA; 5W-30'),
                    ('3.5TT',   '5W-30', 'Full Synthetic', 5.3, 10000, 'G90 3.5TT G6DO; Hyundai 5W-30'),
                    ('3.5TTHV', '5W-30', 'Full Synthetic', 5.3, 10000, 'G90 3.5TT E-SC MHEV; Hyundai 5W-30')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'genesis-g90'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'genesis-gv70', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.5T',  '5W-30', 'Full Synthetic', 5.0, 10000, 'GV70 2.5T G4KM; Hyundai 5W-30'),
                    ('3.5TT', '5W-30', 'Full Synthetic', 5.3, 10000, 'GV70 3.5TT G6DO; Hyundai 5W-30'),
                    ('EV',    NULL,    'Electric',       0.0, 0,     'GV70 Electrified BEV – no engine oil')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'genesis-gv70'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'genesis-gv80', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, o.ViscosityGrade, o.OilType, o.OilCapacity, o.ChangeInterval, o.Notes
                FROM (VALUES
                    ('2.5T',  '5W-30', 'Full Synthetic', 5.0, 10000, 'GV80 2.5T G4KM; Hyundai 5W-30'),
                    ('3.5TT', '5W-30', 'Full Synthetic', 5.3, 10000, 'GV80 3.5TT G6DO; Hyundai 5W-30'),
                    ('3.0D',  '5W-30', 'Full Synthetic', 6.5, 15000, 'GV80 3.0D R3.0 diesel; Hyundai 5W-30')
                ) AS o(EngineCode, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                INNER JOIN [CarModels]      m  ON m.Slug = 'genesis-gv80'
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id AND vv.EngineCode = o.EngineCode;

                INSERT INTO [OilSpecs] (VehicleVariantId, ViscosityGrade, OilType, OilCapacity, ChangeInterval, Notes)
                OUTPUT INSERTED.Id, 'genesis-gv60', INSERTED.VehicleVariantId
                    INTO #InsertedSpecs (Id, ModelSlug, EngineCode)
                SELECT vv.Id, NULL, 'Electric', 0.0, 0, 'GV60 BEV – no engine oil required'
                FROM [CarModels] m
                INNER JOIN [VehicleVariants] vv ON vv.ModelId = m.Id
                WHERE m.Slug = 'genesis-gv60';

                -- ==============================================================
                -- SECTION 5: OilSpecApprovals
                -- Links each OilSpec to applicable ACEA / API standards.
                -- ==============================================================

                -- GM / FCA / Ford petrol → API SP
                INSERT INTO [OilSpecApprovals] (OilSpecId, StandardId)
                SELECT s.Id, st.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ApprovalStandards] st ON st.Code = 'API SP'
                WHERE s.ModelSlug IN (
                    'gmc-sierra-1500','gmc-yukon','gmc-terrain','gmc-canyon',
                    'buick-enclave','buick-encore','buick-encore-gx','buick-envision',
                    'buick-lacrosse','buick-regal','buick-century',
                    'pontiac-firebird','pontiac-trans-am','pontiac-gto','pontiac-grand-prix',
                    'chrysler-300','chrysler-pacifica','chrysler-sebring','ram-1500','ram-2500',
                    'ford-mustang','ford-f150'
                ) AND os.FuelType = 0;

                -- GM diesel → API CK-4
                INSERT INTO [OilSpecApprovals] (OilSpecId, StandardId)
                SELECT s.Id, st.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ApprovalStandards] st ON st.Code = 'API CK-4'
                WHERE s.ModelSlug IN ('gmc-sierra-1500','gmc-yukon','gmc-terrain','gmc-canyon','ram-2500')
                  AND os.FuelType = 1;

                -- Ram 2500 Cummins diesel → API CJ-4 (older standard explicitly)
                INSERT INTO [OilSpecApprovals] (OilSpecId, StandardId)
                SELECT s.Id, st.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ApprovalStandards] st ON st.Code = 'API CJ-4'
                WHERE s.ModelSlug = 'ram-2500' AND os.FuelType = 1;

                -- VW Group petrol → ACEA A3/B4
                INSERT INTO [OilSpecApprovals] (OilSpecId, StandardId)
                SELECT s.Id, st.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ApprovalStandards] st ON st.Code = 'ACEA A3/B4'
                WHERE s.ModelSlug IN ('vw-golf','vw-passat','audi-a4','seat-leon','seat-ibiza','seat-ateca')
                  AND os.FuelType = 0;

                -- VW Group diesel → ACEA C3
                INSERT INTO [OilSpecApprovals] (OilSpecId, StandardId)
                SELECT s.Id, st.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ApprovalStandards] st ON st.Code = 'ACEA C3'
                WHERE s.ModelSlug IN ('vw-golf','vw-passat','audi-a4','seat-leon','seat-ibiza','seat-ateca')
                  AND os.FuelType = 1;

                -- BMW / MINI → ACEA C3
                INSERT INTO [OilSpecApprovals] (OilSpecId, StandardId)
                SELECT s.Id, st.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ApprovalStandards] st ON st.Code = 'ACEA C3'
                WHERE s.ModelSlug IN ('bmw-3-series','mini-hatch','mini-countryman')
                  AND os.FuelType IN (0, 1) AND os.OilType = 'Full Synthetic';

                -- Mercedes → ACEA C3 / C5
                INSERT INTO [OilSpecApprovals] (OilSpecId, StandardId)
                SELECT s.Id, st.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ApprovalStandards] st ON st.Code IN ('ACEA C3','ACEA C5')
                WHERE s.ModelSlug = 'mb-c-class' AND os.FuelType IN (0,1);

                -- Porsche → ACEA A3/B4
                INSERT INTO [OilSpecApprovals] (OilSpecId, StandardId)
                SELECT s.Id, st.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ApprovalStandards] st ON st.Code = 'ACEA A3/B4'
                WHERE s.ModelSlug = 'porsche-911' AND os.FuelType = 0;

                -- Toyota / Lexus / Honda / Acura → API SP
                INSERT INTO [OilSpecApprovals] (OilSpecId, StandardId)
                SELECT s.Id, st.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ApprovalStandards] st ON st.Code = 'API SP'
                WHERE s.ModelSlug IN (
                    'toyota-corolla','toyota-camry',
                    'lexus-is','lexus-rx','lexus-nx','lexus-es',
                    'honda-civic','acura-tlx','acura-mdx','acura-rdx'
                ) AND os.FuelType IN (0,2);

                -- Honda diesel → ACEA C3
                INSERT INTO [OilSpecApprovals] (OilSpecId, StandardId)
                SELECT s.Id, st.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ApprovalStandards] st ON st.Code = 'ACEA C3'
                WHERE s.ModelSlug = 'honda-civic' AND os.FuelType = 1;

                -- Volvo → ACEA C3 / C6
                INSERT INTO [OilSpecApprovals] (OilSpecId, StandardId)
                SELECT s.Id, st.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ApprovalStandards] st ON st.Code IN ('ACEA C3','ACEA C6')
                WHERE s.ModelSlug = 'volvo-xc60' AND os.FuelType IN (0,1);

                -- Jaguar / Land Rover → ACEA C3
                INSERT INTO [OilSpecApprovals] (OilSpecId, StandardId)
                SELECT s.Id, st.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ApprovalStandards] st ON st.Code IN ('ACEA C3','ACEA C5')
                WHERE s.ModelSlug IN ('jaguar-xf','jaguar-f-pace','jaguar-f-type','jaguar-xj')
                  AND os.FuelType IN (0,1);

                -- Hyundai / Kia / Genesis petrol → API SP
                INSERT INTO [OilSpecApprovals] (OilSpecId, StandardId)
                SELECT s.Id, st.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ApprovalStandards] st ON st.Code = 'API SP'
                WHERE s.ModelSlug IN (
                    'hyundai-tucson','kia-sportage',
                    'genesis-g80','genesis-g70','genesis-g90','genesis-gv70','genesis-gv80'
                ) AND os.FuelType IN (0,2);

                -- Hyundai / Kia / Genesis diesel → API CJ-4 + ACEA C3
                INSERT INTO [OilSpecApprovals] (OilSpecId, StandardId)
                SELECT s.Id, st.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ApprovalStandards] st ON st.Code IN ('API CJ-4','ACEA C3')
                WHERE s.ModelSlug IN ('hyundai-tucson','kia-sportage','genesis-gv80')
                  AND os.FuelType = 1;

                -- Mazda / Subaru → API SP
                INSERT INTO [OilSpecApprovals] (OilSpecId, StandardId)
                SELECT s.Id, st.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ApprovalStandards] st ON st.Code = 'API SP'
                WHERE s.ModelSlug IN ('mazda-mx5','subaru-wrx') AND os.FuelType = 0;

                -- Saab → ACEA A3/B3 petrol
                INSERT INTO [OilSpecApprovals] (OilSpecId, StandardId)
                SELECT s.Id, st.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ApprovalStandards] st ON st.Code = 'ACEA A3/B3'
                WHERE s.ModelSlug IN ('saab-900','saab-9-3','saab-9-5') AND os.FuelType = 0;

                -- Saab diesel → ACEA C3
                INSERT INTO [OilSpecApprovals] (OilSpecId, StandardId)
                SELECT s.Id, st.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ApprovalStandards] st ON st.Code = 'ACEA C3'
                WHERE s.ModelSlug IN ('saab-9-3','saab-9-5') AND os.FuelType = 1;

                -- Mitsubishi → API SP
                INSERT INTO [OilSpecApprovals] (OilSpecId, StandardId)
                SELECT s.Id, st.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ApprovalStandards] st ON st.Code = 'API SP'
                WHERE s.ModelSlug IN ('mitsubishi-outlander','mitsubishi-lancer','mitsubishi-eclipse-cross')
                  AND os.FuelType IN (0,2);

                -- Suzuki → API SP
                INSERT INTO [OilSpecApprovals] (OilSpecId, StandardId)
                SELECT s.Id, st.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ApprovalStandards] st ON st.Code = 'API SP'
                WHERE s.ModelSlug IN ('suzuki-swift','suzuki-vitara','suzuki-jimny')
                  AND os.FuelType = 0;

                -- Isuzu → API SL / API CF-4
                INSERT INTO [OilSpecApprovals] (OilSpecId, StandardId)
                SELECT s.Id, st.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ApprovalStandards] st ON st.Code IN ('API SL','API CF-4')
                WHERE s.ModelSlug IN ('isuzu-trooper','isuzu-rodeo') AND os.FuelType IN (0,1);

                -- Infiniti → API SP
                INSERT INTO [OilSpecApprovals] (OilSpecId, StandardId)
                SELECT s.Id, st.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ApprovalStandards] st ON st.Code = 'API SP'
                WHERE s.ModelSlug IN ('infiniti-q50','infiniti-qx60','infiniti-qx80')
                  AND os.FuelType IN (0,2);

                -- Ford ACEA A5/B5 (fuel economy)
                INSERT INTO [OilSpecApprovals] (OilSpecId, StandardId)
                SELECT s.Id, st.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ApprovalStandards] st ON st.Code = 'ACEA A5/B5'
                WHERE s.ModelSlug IN ('ford-mustang','ford-f150')
                  AND os.OilType = 'Full Synthetic' AND os.FuelType = 0;

                -- ==============================================================
                -- SECTION 6: OilSpecManufacturerApprovals
                -- ==============================================================

                -- GM dexos1 Gen2 – modern GM petrol
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'GM dexos1 Gen2'
                WHERE s.ModelSlug IN (
                    'gmc-sierra-1500','gmc-yukon','gmc-terrain','gmc-canyon',
                    'buick-enclave','buick-encore','buick-encore-gx','buick-envision',
                    'buick-lacrosse','buick-regal'
                ) AND os.FuelType = 0 AND os.OilType = 'Full Synthetic';

                -- GM dexos2 – Duramax diesel
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'GM dexos2'
                WHERE s.ModelSlug IN ('gmc-sierra-1500','gmc-yukon','gmc-terrain','gmc-canyon')
                  AND os.FuelType = 1;

                -- GM 6094M – legacy Pontiac / Buick
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'GM 6094M'
                WHERE s.ModelSlug IN (
                    'pontiac-firebird','pontiac-trans-am','pontiac-gto','pontiac-grand-prix',
                    'buick-century','buick-regal'
                ) AND os.OilType IN ('Conventional','Semi-Synthetic');

                -- Ford WSS-M2C948-B – EcoBoost full synthetic
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'Ford WSS-M2C948-B'
                WHERE s.ModelSlug IN ('ford-mustang','ford-f150')
                  AND os.OilType = 'Full Synthetic' AND os.FuelType = 0;

                -- Ford WSS-M2C913-D – conventional / semi-synthetic
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'Ford WSS-M2C913-D'
                WHERE s.ModelSlug IN ('ford-mustang','ford-f150')
                  AND os.OilType IN ('Conventional','Semi-Synthetic') AND os.FuelType = 0;

                -- VW 504.00 – petrol longlife II
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'VW 504.00'
                WHERE s.ModelSlug IN ('vw-golf','vw-passat','audi-a4','seat-leon','seat-ibiza','seat-ateca')
                  AND os.FuelType = 0 AND os.ViscosityGrade = '5W-30';

                -- VW 507.00 – diesel DPF
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'VW 507.00'
                WHERE s.ModelSlug IN ('vw-golf','vw-passat','audi-a4','seat-leon','seat-ibiza','seat-ateca')
                  AND os.FuelType = 1 AND os.OilType = 'Full Synthetic';

                -- VW 508.00 – low viscosity 0W-xx
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'VW 508.00'
                WHERE s.ModelSlug IN ('vw-golf','vw-passat','audi-a4','seat-leon','seat-ibiza','seat-ateca')
                  AND os.ViscosityGrade LIKE '0W%';

                -- VW 502.00 – high performance petrol (5W-40)
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'VW 502.00'
                WHERE s.ModelSlug IN ('vw-golf','vw-passat','audi-a4','seat-leon','seat-ibiza','porsche-911')
                  AND os.FuelType = 0 AND os.ViscosityGrade IN ('5W-40','0W-40');

                -- VW 505.01 – PD diesel 5W-40
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'VW 505.01'
                WHERE s.ModelSlug IN ('vw-golf','audi-a4','seat-ibiza','seat-leon')
                  AND os.FuelType = 1 AND os.ViscosityGrade = '5W-40';

                -- BMW LL-01
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'BMW LL-01'
                WHERE s.ModelSlug IN ('bmw-3-series','mini-hatch','mini-countryman')
                  AND os.FuelType = 0 AND os.ViscosityGrade = '5W-30';

                -- BMW LL-04 – diesel / DPF
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'BMW LL-04'
                WHERE s.ModelSlug IN ('bmw-3-series','mini-hatch','mini-countryman')
                  AND os.FuelType = 1;

                -- BMW LL-17 FE+ – 0W-30
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'BMW LL-17 FE+'
                WHERE s.ModelSlug IN ('bmw-3-series','mini-hatch','mini-countryman')
                  AND os.ViscosityGrade = '0W-30';

                -- MB 229.5
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'MB 229.5'
                WHERE s.ModelSlug = 'mb-c-class'
                  AND os.FuelType = 0 AND os.ViscosityGrade = '5W-30';

                -- MB 229.51 – diesel
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'MB 229.51'
                WHERE s.ModelSlug = 'mb-c-class' AND os.FuelType = 1;

                -- MB 229.61 – 0W-20 low viscosity
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'MB 229.61'
                WHERE s.ModelSlug = 'mb-c-class' AND os.ViscosityGrade = '0W-20';

                -- Toyota Hybrid Oil
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'Toyota Hybrid Oil'
                WHERE s.ModelSlug IN ('toyota-corolla','toyota-camry','lexus-rx','lexus-nx','lexus-es')
                  AND os.FuelType = 2;

                -- Toyota 0W-20 SN+
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'Toyota 0W-20 SN+'
                WHERE s.ModelSlug IN ('toyota-corolla','toyota-camry','lexus-rx','lexus-nx','lexus-es','lexus-is')
                  AND os.ViscosityGrade = '0W-20';

                -- Porsche A40
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'Porsche A40'
                WHERE s.ModelSlug = 'porsche-911' AND os.FuelType = 0;

                -- Volvo VCC-RBS0-2AE
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'Volvo VCC-RBS0-2AE'
                WHERE s.ModelSlug = 'volvo-xc60';

                -- JLR STJLR.03.5004 – 5W-30 older Jaguar
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'JLR Land Rover STJLR.03.5004'
                WHERE s.ModelSlug IN ('jaguar-xf','jaguar-f-pace','jaguar-f-type','jaguar-xj')
                  AND os.ViscosityGrade = '5W-30';

                -- JLR STJLR.51.5122 – 0W-xx Ingenium
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'JLR STJLR.51.5122'
                WHERE s.ModelSlug IN ('jaguar-xf','jaguar-f-pace','jaguar-f-type')
                  AND os.ViscosityGrade IN ('0W-30','0W-20');

                -- Honda HTO-06
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'Honda HTO-06'
                WHERE s.ModelSlug IN ('honda-civic','acura-tlx','acura-mdx','acura-rdx')
                  AND os.ViscosityGrade IN ('5W-20','0W-20');

                -- Honda 08798-9032 hybrid spec
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'Honda 08798-9032'
                WHERE s.ModelSlug = 'honda-civic' AND os.FuelType = 2;

                -- Nissan NS-3
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'Nissan NS-3'
                WHERE s.ModelSlug IN ('infiniti-q50','infiniti-qx60','infiniti-qx80');

                -- Nissan NS-4 – VR30DDTT only
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'Nissan NS-4'
                WHERE s.ModelSlug IN ('infiniti-q50','infiniti-qx80')
                  AND os.Notes LIKE '%VR30%';

                -- Hyundai 0W-20
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'Hyundai 0W-20'
                WHERE s.ModelSlug IN (
                    'hyundai-tucson','kia-sportage',
                    'genesis-g80','genesis-g70','genesis-g90','genesis-gv70','genesis-gv80'
                ) AND os.ViscosityGrade = '0W-20';

                -- Hyundai 5W-30
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'Hyundai 5W-30'
                WHERE s.ModelSlug IN (
                    'hyundai-tucson','kia-sportage',
                    'genesis-g80','genesis-g70','genesis-g90','genesis-gv70','genesis-gv80'
                ) AND os.ViscosityGrade = '5W-30';

                -- Mazda 5W-30
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'Mazda 5W-30'
                WHERE s.ModelSlug = 'mazda-mx5';

                -- Subaru 5W-30
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'Subaru 5W-30'
                WHERE s.ModelSlug = 'subaru-wrx' AND os.ViscosityGrade = '5W-30';

                -- GM LL-A-025 – Saab petrol
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'GM LL-A-025'
                WHERE s.ModelSlug IN ('saab-9-3','saab-9-5','saab-900') AND os.FuelType = 0;

                -- FCA MS-6395 – Chrysler / Ram petrol
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'FCA MS-6395'
                WHERE s.ModelSlug IN ('chrysler-300','chrysler-pacifica','chrysler-sebring','ram-1500','ram-2500')
                  AND os.FuelType = 0;

                -- FCA MS-10725 – Ram EcoDiesel
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'FCA MS-10725'
                WHERE s.ModelSlug = 'ram-1500' AND os.FuelType = 1;

                -- MMC MZCD – Mitsubishi
                INSERT INTO [OilSpecManufacturerApprovals] (OilSpecId, ManufacturerSpecId)
                SELECT s.Id, ma.Id
                FROM #InsertedSpecs s
                INNER JOIN [OilSpecs] os ON os.Id = s.Id
                INNER JOIN [ManufacturerApprovals] ma ON ma.Code = 'MMC MZCD'
                WHERE s.ModelSlug IN ('mitsubishi-outlander','mitsubishi-lancer','mitsubishi-eclipse-cross');

                -- ==============================================================
                -- CLEANUP
                -- ==============================================================
                DROP TABLE #InsertedSpecs;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove approval links first (FK dependency on OilSpecs)
            migrationBuilder.Sql("""
                DELETE oma
                FROM [OilSpecManufacturerApprovals] oma
                INNER JOIN [OilSpecs] os ON os.Id = oma.OilSpecId
                INNER JOIN [VehicleVariants] vv ON vv.Id = os.VehicleVariantId
                INNER JOIN [CarModels] m ON m.Id = vv.ModelId
                INNER JOIN [CarBrands] b ON b.Id = m.BrandId
                WHERE b.Slug IN (
                    'chevrolet','ford','dodge','cadillac','buick','gmc','pontiac',
                    'oldsmobile','plymouth','lincoln','mercury','chrysler','jeep',
                    'ram','tesla','volkswagen','bmw','mercedes-benz','audi','opel',
                    'renault','peugeot','citroen','fiat','alfa-romeo','volvo','saab',
                    'seat','skoda','porsche','land-rover','jaguar','mini','lancia',
                    'rover','toyota','honda','nissan','mazda','subaru','mitsubishi',
                    'lexus','infiniti','acura','suzuki','isuzu','hyundai','kia','genesis'
                );

                DELETE osa
                FROM [OilSpecApprovals] osa
                INNER JOIN [OilSpecs] os ON os.Id = osa.OilSpecId
                INNER JOIN [VehicleVariants] vv ON vv.Id = os.VehicleVariantId
                INNER JOIN [CarModels] m ON m.Id = vv.ModelId
                INNER JOIN [CarBrands] b ON b.Id = m.BrandId
                WHERE b.Slug IN (
                    'chevrolet','ford','dodge','cadillac','buick','gmc','pontiac',
                    'oldsmobile','plymouth','lincoln','mercury','chrysler','jeep',
                    'ram','tesla','volkswagen','bmw','mercedes-benz','audi','opel',
                    'renault','peugeot','citroen','fiat','alfa-romeo','volvo','saab',
                    'seat','skoda','porsche','land-rover','jaguar','mini','lancia',
                    'rover','toyota','honda','nissan','mazda','subaru','mitsubishi',
                    'lexus','infiniti','acura','suzuki','isuzu','hyundai','kia','genesis'
                );

                DELETE os
                FROM [OilSpecs] os
                INNER JOIN [VehicleVariants] vv ON vv.Id = os.VehicleVariantId
                INNER JOIN [CarModels] m ON m.Id = vv.ModelId
                INNER JOIN [CarBrands] b ON b.Id = m.BrandId
                WHERE b.Slug IN (
                    'chevrolet','ford','dodge','cadillac','buick','gmc','pontiac',
                    'oldsmobile','plymouth','lincoln','mercury','chrysler','jeep',
                    'ram','tesla','volkswagen','bmw','mercedes-benz','audi','opel',
                    'renault','peugeot','citroen','fiat','alfa-romeo','volvo','saab',
                    'seat','skoda','porsche','land-rover','jaguar','mini','lancia',
                    'rover','toyota','honda','nissan','mazda','subaru','mitsubishi',
                    'lexus','infiniti','acura','suzuki','isuzu','hyundai','kia','genesis'
                );
                """);

            migrationBuilder.DeleteData(table: "ManufacturerApprovals", keyColumn: "Code", keyValues: new object[]
            {
                "GM dexos1", "GM dexos1 Gen2", "GM dexos1 Gen3", "GM dexos2", "GM 6094M", "GM 4718M",
                "Ford WSS-M2C913-A", "Ford WSS-M2C913-B", "Ford WSS-M2C913-C", "Ford WSS-M2C913-D",
                "Ford WSS-M2C929-A", "Ford WSS-M2C945-A", "Ford WSS-M2C947-A", "Ford WSS-M2C948-B",
                "FCA MS-6395", "FCA MS-10725", "FCA MS-12633", "Mopar ATF+4",
                "VW 501.01", "VW 502.00", "VW 503.00", "VW 503.01", "VW 504.00", "VW 505.00",
                "VW 505.01", "VW 506.00", "VW 506.01", "VW 507.00", "VW 508.00", "VW 509.00",
                "BMW LL-98", "BMW LL-01", "BMW LL-01 FE", "BMW LL-04", "BMW LL-12 FE", "BMW LL-14 FE+", "BMW LL-17 FE+",
                "MB 226.5", "MB 229.1", "MB 229.3", "MB 229.5", "MB 229.31", "MB 229.51", "MB 229.52", "MB 229.61",
                "Toyota 0W-20 SN+", "Toyota 5W-30", "Toyota Hybrid Oil",
                "Honda HTO-06", "Honda 08798-9032",
                "Nissan NS-2", "Nissan NS-3", "Nissan NS-4",
                "Mazda 5W-30", "Mazda 0W-20",
                "Subaru 5W-30", "Subaru 0W-20",
                "Hyundai 0W-20", "Hyundai 5W-30",
                "MMC MZCD",
                "Volvo VCC-RBS0-2AE",
                "JLR Land Rover STJLR.03.5004", "JLR STJLR.51.5122",
                "Porsche A40",
                "Renault RN0700", "Renault RN0710", "Renault RN0720",
                "PSA B71 2290", "PSA B71 2294", "PSA B71 2312",
                "FIAT 9.55535-GH2", "FIAT 9.55535-S3", "FIAT 9.55535-DSX",
                "Saab 93 165 147", "GM LL-A-025", "GM LL-B-025",
            });

            migrationBuilder.DeleteData(table: "ApprovalStandards", keyColumn: "Code", keyValues: new object[]
            {
                "API SJ", "API SL", "API SM", "API SN", "API SN+", "API SP",
                "API CF", "API CF-4", "API CG-4", "API CH-4", "API CI-4", "API CJ-4", "API CK-4",
                "ACEA A1/B1", "ACEA A3/B3", "ACEA A3/B4", "ACEA A5/B5",
                "ACEA C1", "ACEA C2", "ACEA C3", "ACEA C4", "ACEA C5", "ACEA C6",
                "ACEA E4", "ACEA E6", "ACEA E7", "ACEA E9",
            });
        }
    }
}
