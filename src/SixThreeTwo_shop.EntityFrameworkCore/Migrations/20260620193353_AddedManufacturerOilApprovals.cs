using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SixThreeTwo_shop.Migrations
{
    /// <inheritdoc />
    public partial class AddedManufacturerOilApprovals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
 migrationBuilder.Sql(@"
SET IDENTITY_INSERT [ManufacturerApprovals] ON;
INSERT INTO [ManufacturerApprovals] ([Id], [Name], [Description], [ManufacturerName])
VALUES
    (1, 'dexos1 Gen2', 'GM standard for gasoline engines; replaces dexos1 with improved oxidation and volatility control', 'Chevrolet'),
    (2, 'dexos1 Gen2', 'GM standard for gasoline engines; replaces dexos1 with improved oxidation and volatility control', 'Cadillac'),
    (3, 'dexos1 Gen2', 'GM standard for gasoline engines; replaces dexos1 with improved oxidation and volatility control', 'Buick'),
    (4, 'dexos1 Gen2', 'GM standard for gasoline engines; replaces dexos1 with improved oxidation and volatility control', 'GMC'),
    (5, 'dexos1 Gen2', 'GM standard for gasoline engines; replaces dexos1 with improved oxidation and volatility control', 'Pontiac'),
    (6, 'dexos1 Gen2', 'GM standard for gasoline engines; replaces dexos1 with improved oxidation and volatility control', 'Oldsmobile'),
    (7, 'dexos2', 'GM standard for diesel and some gasoline engines, primarily for European-market GM vehicles', 'Cadillac'),
    (8, 'dexos2', 'GM standard for diesel and some gasoline engines, primarily for European-market GM vehicles', 'Buick'),
    (9, 'dexos2', 'GM standard for diesel and some gasoline engines, primarily for European-market GM vehicles', 'Opel'),
    (10, 'dexosD', 'GM standard for light-duty diesel engines', 'Chevrolet'),
    (11, 'dexosD', 'GM standard for light-duty diesel engines', 'GMC'),
    (12, 'dexosD', 'GM standard for light-duty diesel engines', 'Cadillac'),
    (13, 'WSS-M2C913-D', 'Ford specification for 5W-20/5W-30 oils in gasoline engines, superseded by newer specs', 'Ford'),
    (14, 'WSS-M2C913-D', 'Ford specification for 5W-20/5W-30 oils in gasoline engines, superseded by newer specs', 'Lincoln'),
    (15, 'WSS-M2C913-D', 'Ford specification for 5W-20/5W-30 oils in gasoline engines, superseded by newer specs', 'Mercury'),
    (16, 'WSS-M2C913-C', 'Ford specification for gasoline engines requiring 5W-20 oils with improved fuel economy', 'Ford'),
    (17, 'WSS-M2C913-C', 'Ford specification for gasoline engines requiring 5W-20 oils with improved fuel economy', 'Lincoln'),
    (18, 'WSS-M2C913-C', 'Ford specification for gasoline engines requiring 5W-20 oils with improved fuel economy', 'Mercury'),
    (19, 'WSS-M2C947-A', 'Ford specification for modern gasoline turbocharged direct injection (EcoBoost) engines', 'Ford'),
    (20, 'WSS-M2C947-A', 'Ford specification for modern gasoline turbocharged direct injection (EcoBoost) engines', 'Lincoln'),
    (21, 'WSS-M2C171-F1', 'Ford specification for 0W-20 fuel-economy oils in modern gasoline engines', 'Ford'),
    (22, 'WSS-M2C171-F1', 'Ford specification for 0W-20 fuel-economy oils in modern gasoline engines', 'Lincoln'),
    (23, 'WSS-M2C205-A1', 'Ford specification for Power Stroke diesel engines', 'Ford'),
    (24, 'MS-6395', 'Chrysler/Stellantis material standard for gasoline engine oils', 'Dodge'),
    (25, 'MS-6395', 'Chrysler/Stellantis material standard for gasoline engine oils', 'Chrysler'),
    (26, 'MS-6395', 'Chrysler/Stellantis material standard for gasoline engine oils', 'Jeep'),
    (27, 'MS-6395', 'Chrysler/Stellantis material standard for gasoline engine oils', 'Ram'),
    (28, 'MS-10725', 'Chrysler/Stellantis specification for 0W-20 fuel economy engine oils', 'Dodge'),
    (29, 'MS-10725', 'Chrysler/Stellantis specification for 0W-20 fuel economy engine oils', 'Chrysler'),
    (30, 'MS-10725', 'Chrysler/Stellantis specification for 0W-20 fuel economy engine oils', 'Jeep'),
    (31, 'MS-10725', 'Chrysler/Stellantis specification for 0W-20 fuel economy engine oils', 'Ram'),
    (32, 'MS-11106', 'Chrysler/Stellantis specification for diesel engine oils used in Ram trucks', 'Ram'),
    (33, 'MS-11106', 'Chrysler/Stellantis specification for diesel engine oils used in Ram trucks', 'Jeep'),
    (34, 'Tesla Approved EV Coolant/Lubricant Spec', 'Tesla-specific lubricant requirements for reduction gear and drive unit fluids (not engine oil, EVs use specialized gear oil)', 'Tesla'),
    (35, 'VW 502.00', 'Volkswagen Group standard for gasoline engines with extended service intervals', 'Volkswagen'),
    (36, 'VW 502.00', 'Volkswagen Group standard for gasoline engines with extended service intervals', 'Audi'),
    (37, 'VW 502.00', 'Volkswagen Group standard for gasoline engines with extended service intervals', 'SEAT'),
    (38, 'VW 502.00', 'Volkswagen Group standard for gasoline engines with extended service intervals', 'Škoda'),
    (39, 'VW 504.00', 'Volkswagen Group standard for gasoline engines with long-life service; low-SAPS, compatible with emission systems', 'Volkswagen'),
    (40, 'VW 504.00', 'Volkswagen Group standard for gasoline engines with long-life service; low-SAPS, compatible with emission systems', 'Audi'),
    (41, 'VW 504.00', 'Volkswagen Group standard for gasoline engines with long-life service; low-SAPS, compatible with emission systems', 'SEAT'),
    (42, 'VW 504.00', 'Volkswagen Group standard for gasoline engines with long-life service; low-SAPS, compatible with emission systems', 'Škoda'),
    (43, 'VW 504.00', 'Volkswagen Group standard for gasoline engines with long-life service; low-SAPS, compatible with emission systems', 'Porsche'),
    (44, 'VW 505.00', 'Volkswagen Group standard for diesel engines without DPF', 'Volkswagen'),
    (45, 'VW 505.00', 'Volkswagen Group standard for diesel engines without DPF', 'Audi'),
    (46, 'VW 505.00', 'Volkswagen Group standard for diesel engines without DPF', 'SEAT'),
    (47, 'VW 505.00', 'Volkswagen Group standard for diesel engines without DPF', 'Škoda'),
    (48, 'VW 507.00', 'Volkswagen Group standard for diesel engines with DPF; low-SAPS long-life oil', 'Volkswagen'),
    (49, 'VW 507.00', 'Volkswagen Group standard for diesel engines with DPF; low-SAPS long-life oil', 'Audi'),
    (50, 'VW 507.00', 'Volkswagen Group standard for diesel engines with DPF; low-SAPS long-life oil', 'SEAT'),
    (51, 'VW 507.00', 'Volkswagen Group standard for diesel engines with DPF; low-SAPS long-life oil', 'Škoda'),
    (52, 'VW 507.00', 'Volkswagen Group standard for diesel engines with DPF; low-SAPS long-life oil', 'Porsche'),
    (53, 'Porsche A40', 'Porsche specification for high-performance sports car engines requiring high HTHS viscosity', 'Porsche'),
    (54, 'Porsche C30', 'Porsche specification for low-SAPS oils compatible with particulate filters', 'Porsche'),
    (55, 'BMW Longlife-01', 'BMW specification for gasoline and some diesel engines with extended service intervals', 'BMW'),
    (56, 'BMW Longlife-01', 'BMW specification for gasoline and some diesel engines with extended service intervals', 'Mini'),
    (57, 'BMW Longlife-04', 'BMW specification for low-SAPS oils compatible with diesel particulate filters', 'BMW'),
    (58, 'BMW Longlife-04', 'BMW specification for low-SAPS oils compatible with diesel particulate filters', 'Mini'),
    (59, 'BMW Longlife-12 FE', 'BMW specification for fuel-economy low-viscosity oils in modern gasoline/diesel engines', 'BMW'),
    (60, 'BMW Longlife-12 FE', 'BMW specification for fuel-economy low-viscosity oils in modern gasoline/diesel engines', 'Mini'),
    (61, 'MB 229.5', 'Mercedes-Benz specification for gasoline and diesel engines with extended service life', 'Mercedes-Benz'),
    (62, 'MB 229.51', 'Mercedes-Benz low-SAPS specification compatible with diesel particulate filters', 'Mercedes-Benz'),
    (63, 'MB 229.52', 'Mercedes-Benz specification for low-ash oils with extended drain intervals for modern Euro 6 engines', 'Mercedes-Benz'),
    (64, 'MB 229.71', 'Mercedes-Benz specification for fuel-efficient low-viscosity oils in latest-generation engines', 'Mercedes-Benz'),
    (65, 'GM-LL-A-025', 'General Motors Europe (Opel) specification for gasoline engines', 'Opel'),
    (66, 'GM-LL-B-025', 'General Motors Europe (Opel) specification for diesel engines', 'Opel'),
    (67, 'Renault RN0700', 'Renault specification for gasoline engine oils', 'Renault'),
    (68, 'Renault RN0710', 'Renault specification for diesel engine oils with extended drain capability', 'Renault'),
    (69, 'Renault RN17', 'Renault specification for low-SAPS oils compatible with DPF/SCR systems', 'Renault'),
    (70, 'PSA B71 2290', 'PSA (Peugeot/Citroën) specification for low-SAPS diesel engine oils', 'Peugeot'),
    (71, 'PSA B71 2290', 'PSA (Peugeot/Citroën) specification for low-SAPS diesel engine oils', 'Citroën'),
    (72, 'PSA B71 2312', 'PSA (Peugeot/Citroën) specification for gasoline engines with extended service intervals', 'Peugeot'),
    (73, 'PSA B71 2312', 'PSA (Peugeot/Citroën) specification for gasoline engines with extended service intervals', 'Citroën'),
    (74, 'PSA B71 2296', 'PSA (Peugeot/Citroën) specification for low-viscosity fuel-economy oils', 'Peugeot'),
    (75, 'PSA B71 2296', 'PSA (Peugeot/Citroën) specification for low-viscosity fuel-economy oils', 'Citroën'),
    (76, 'Fiat 9.55535-S1', 'Fiat specification for high-performance gasoline and diesel engines', 'Fiat'),
    (77, 'Fiat 9.55535-S1', 'Fiat specification for high-performance gasoline and diesel engines', 'Alfa Romeo'),
    (78, 'Fiat 9.55535-S1', 'Fiat specification for high-performance gasoline and diesel engines', 'Lancia'),
    (79, 'Fiat 9.55535-G1', 'Fiat specification for gasoline engine oils with standard service intervals', 'Fiat'),
    (80, 'Fiat 9.55535-G1', 'Fiat specification for gasoline engine oils with standard service intervals', 'Alfa Romeo'),
    (81, 'Fiat 9.55535-G1', 'Fiat specification for gasoline engine oils with standard service intervals', 'Lancia'),
    (82, 'Fiat 9.55535-N2', 'Fiat specification for low-SAPS oils compatible with diesel particulate filters', 'Fiat'),
    (83, 'Fiat 9.55535-N2', 'Fiat specification for low-SAPS oils compatible with diesel particulate filters', 'Alfa Romeo'),
    (84, 'Fiat 9.55535-N2', 'Fiat specification for low-SAPS oils compatible with diesel particulate filters', 'Lancia'),
    (85, 'Volvo VCC 95200377', 'Volvo specification for low-SAPS engine oils with extended drain intervals', 'Volvo'),
    (86, 'Volvo VCC RBS0-2AE', 'Volvo specification for fuel-economy oils in modern gasoline/diesel engines', 'Volvo'),
    (87, 'GM-LL-A-025 (Saab)', 'General Motors specification adopted by Saab for gasoline engines', 'Saab'),
    (88, 'JLR STJLR.03.5005', 'Jaguar Land Rover specification for low-SAPS engine oils', 'Land Rover'),
    (89, 'JLR STJLR.03.5005', 'Jaguar Land Rover specification for low-SAPS engine oils', 'Jaguar'),
    (90, 'JLR STJLR.51.5122', 'Jaguar Land Rover specification for fuel-economy low-viscosity oils', 'Land Rover'),
    (91, 'JLR STJLR.51.5122', 'Jaguar Land Rover specification for fuel-economy low-viscosity oils', 'Jaguar'),
    (92, 'Rover OEM Spec', 'Historic Rover Group factory-recommended engine oil specification', 'Rover'),
    (93, 'Toyota Genuine Motor Oil Spec', 'Toyota factory specification for gasoline engines, generally aligned with ILSAC GF standards', 'Toyota'),
    (94, 'Toyota Genuine Motor Oil Spec', 'Toyota factory specification for gasoline engines, generally aligned with ILSAC GF standards', 'Lexus'),
    (95, 'Toyota Low SAPS Diesel Spec', 'Toyota specification for low-ash diesel engine oils compatible with DPF systems', 'Toyota'),
    (96, 'Toyota Low SAPS Diesel Spec', 'Toyota specification for low-ash diesel engine oils compatible with DPF systems', 'Lexus'),
    (97, 'Honda Genuine Motor Oil Spec', 'Honda factory specification, typically requiring ILSAC GF-6 oils', 'Honda'),
    (98, 'Honda Genuine Motor Oil Spec', 'Honda factory specification, typically requiring ILSAC GF-6 oils', 'Acura'),
    (99, 'Nissan Genuine Oil Spec', 'Nissan factory specification, generally aligned with ILSAC GF and API SN/SP standards', 'Nissan'),
    (100, 'Nissan Genuine Oil Spec', 'Nissan factory specification, generally aligned with ILSAC GF and API SN/SP standards', 'Infiniti'),
    (101, 'Mazda Genuine Oil Spec', 'Mazda factory specification for SKYACTIV gasoline and diesel engines, aligned with ILSAC GF standards', 'Mazda'),
    (102, 'Subaru Genuine Oil Spec', 'Subaru factory specification for flat (boxer) engines, typically requiring ILSAC GF-6 oils', 'Subaru'),
    (103, 'Mitsubishi Genuine Oil Spec', 'Mitsubishi factory specification generally aligned with API SN/SP and ILSAC GF standards', 'Mitsubishi'),
    (104, 'Suzuki Genuine Oil Spec', 'Suzuki factory specification generally aligned with API SN/SP and ILSAC GF standards', 'Suzuki'),
    (105, 'Isuzu Diesel Spec', 'Isuzu factory specification for diesel engines, generally aligned with API CJ-4/CK-4', 'Isuzu'),
    (106, 'Hyundai/Kia Genuine Oil Spec', 'Hyundai-Kia factory specification, generally aligned with ILSAC GF-6 and API SN Plus/SP', 'Hyundai'),
    (107, 'Hyundai/Kia Genuine Oil Spec', 'Hyundai-Kia factory specification, generally aligned with ILSAC GF-6 and API SN Plus/SP', 'Kia'),
    (108, 'Hyundai/Kia Genuine Oil Spec', 'Hyundai-Kia factory specification, generally aligned with ILSAC GF-6 and API SN Plus/SP', 'Genesis');
SET IDENTITY_INSERT [ManufacturerApprovals] OFF;
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.Sql("DELETE FROM [ManufacturerApprovals] WHERE [Id] BETWEEN 1 AND 108;");
        }
    }
}
