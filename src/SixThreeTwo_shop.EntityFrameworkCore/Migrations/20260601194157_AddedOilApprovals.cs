using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SixThreeTwo_shop.Migrations
{
    /// <inheritdoc />
    public partial class AddedOilApprovals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
migrationBuilder.Sql(@"
SET IDENTITY_INSERT [OilApprovals] ON;
INSERT INTO [OilApprovals] ([Id], [Name], [Description], [StandardType])
VALUES
    -- API Standards (StandardType = 0)
    (1,  'API SN Plus', 'Designed to protect turbocharged gasoline engines from Low Speed Pre-Ignition (LSPI)', 0),
    (2,  'API SN',      'Full ILSAC GF-5 performance, improved high-temperature deposit protection for pistons', 0),
    (3,  'API SM',      'Improved oxidation resistance, deposit protection, wear protection and low-temperature performance', 0),
    (4,  'API SL',      'Used in gasoline-powered passenger cars, SUVs, light-duty trucks and vans', 0),
    (5,  'API SJ',      'For gasoline-powered automotive engines built before 2001', 0),
    (6,  'API CK-4',    'Diesel engine oil for 2017 and newer heavy-duty engines; improved shear stability and oxidation resistance', 0),
    (7,  'API CJ-4',    'Diesel oil designed for engines meeting 2007 emission standards with DPF', 0),
    (8,  'API CI-4',    'Designed for high-speed four-stroke diesel engines; compatible with EGR systems', 0),
    (9,  'API CH-4',    'Specifically compounded for high-speed, four-stroke diesel engines; meets 1998 exhaust standards', 0),
    (10, 'API FA-4',    'Specifically for diesel engines using XW-16 viscosity grades to improve fuel economy', 0),

    -- ACEA Standards (StandardType = 1)
    (11, 'ACEA A1/B1',  'Fuel-economy oil for gasoline and light-duty diesel engines with low high-temperature high-shear viscosity', 1),
    (12, 'ACEA A3/B3',  'High-performance and/or extended-drain gasoline and light-duty diesel engines', 1),
    (13, 'ACEA A3/B4',  'High-performance gasoline and direct injection diesel engines', 1),
    (14, 'ACEA A5/B5',  'Fuel-economy oil for gasoline and light-duty diesel with mid-SAPS formulation', 1),
    (15, 'ACEA C1',     'Low-SAPS oil compatible with DPF and TWC; lowest sulfated ash, phosphorus and sulfur', 1),
    (16, 'ACEA C2',     'Mid-SAPS fuel-economy oil compatible with DPF and TWC for gasoline and diesel engines', 1),
    (17, 'ACEA C3',     'Mid-SAPS high-performance oil compatible with DPF and TWC', 1),
    (18, 'ACEA C4',     'Low-SAPS oil compatible with DPF and TWC; lower sulfated ash than C3', 1),
    (19, 'ACEA C5',     'Mid-SAPS fuel-economy oil with very low HTHS viscosity for modern emission systems', 1),
    (20, 'ACEA E4',     'Highly stable, keep-clean heavy-duty diesel oil for EGR engines without DPF', 1),
    (21, 'ACEA E6',     'Highly stable heavy-duty diesel oil for EGR engines with DPF using low-sulfur fuel', 1),
    (22, 'ACEA E7',     'Stable heavy-duty diesel oil for EGR engines; may be used with or without DPF', 1),
    (23, 'ACEA E9',     'Low-SAPS heavy-duty diesel oil compatible with SCR, DPF and EGR systems', 1),

    -- ILSAC Standards (StandardType = 2)
    (24, 'ILSAC GF-6A', 'Latest standard for fuel economy; backward compatible with GF-5 and earlier; protects against LSPI and timing chain wear', 2),
    (25, 'ILSAC GF-6B', 'New category for SAE 0W-16 viscosity grade for improved fuel economy in modern engines', 2),
    (26, 'ILSAC GF-5',  'Improved high-temperature deposit protection, better fuel economy, emission system compatibility', 2),
    (27, 'ILSAC GF-4',  'Improved oxidation stability, deposit control and fuel economy for gasoline engines', 2),
    (28, 'ILSAC GF-3',  'Improved resistance to oxidation and wear, better fuel economy retention over oil drain interval', 2),
    (29, 'ILSAC GF-2',  'For gasoline-powered vehicles with fuel economy requirements; suitable for engines before 2000', 2),
    (30, 'ILSAC GF-1',  'First ILSAC standard; baseline fuel economy and emissions compatibility for gasoline engines', 2);
SET IDENTITY_INSERT [OilApprovals] OFF;
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.Sql("DELETE FROM [OilApprovals] WHERE [Id] BETWEEN 1 AND 30;");
        }
    }
}
