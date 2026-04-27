using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SixThreeTwo_shop.Migrations
{
    /// <inheritdoc />
    public partial class SeedCarsTables : Migration
    {
        /// <inheritdoc />
         protected override void Up(MigrationBuilder migrationBuilder)
    {
        // =====================================================================
        // CAR BRANDS
        // YearFrom = brand founded / first passenger car produced
        // YearTo   = last active year (2026 for still-active brands)
        // =====================================================================

        migrationBuilder.InsertData(
            table: "CarBrands",
            columns: ["Name", "Slug", "YearFrom", "YearTo", "IsActive"],
            values: new object[,]
            {
                // American
                { "Chevrolet",    "chevrolet",    (short)1911, (short)2026, true  },
                { "Ford",         "ford",         (short)1903, (short)2026, true  },
                { "Dodge",        "dodge",        (short)1914, (short)2026, true  },
                { "Cadillac",     "cadillac",     (short)1902, (short)2026, true  },
                { "Buick",        "buick",        (short)1903, (short)2026, true  },
                { "GMC",          "gmc",          (short)1912, (short)2026, true  },
                { "Pontiac",      "pontiac",      (short)1926, (short)2010, false }, // discontinued 2010
                { "Oldsmobile",   "oldsmobile",   (short)1897, (short)2004, false }, // discontinued 2004
                { "Plymouth",     "plymouth",     (short)1928, (short)2001, false }, // discontinued 2001
                { "Lincoln",      "lincoln",      (short)1917, (short)2026, true  },
                { "Mercury",      "mercury",      (short)1938, (short)2011, false }, // discontinued 2011
                { "Chrysler",     "chrysler",     (short)1925, (short)2026, true  },
                { "Jeep",         "jeep",         (short)1941, (short)2026, true  },
                { "Ram",          "ram",          (short)2010, (short)2026, true  }, // spun off from Dodge 2010
                { "Tesla",        "tesla",        (short)2008, (short)2026, true  }, // first car delivered 2008
                // European
                { "Volkswagen",   "volkswagen",   (short)1938, (short)2026, true  },
                { "BMW",          "bmw",          (short)1916, (short)2026, true  },
                { "Mercedes-Benz","mercedes-benz",(short)1926, (short)2026, true  },
                { "Audi",         "audi",         (short)1909, (short)2026, true  },
                { "Opel",         "opel",         (short)1862, (short)2026, true  },
                { "Renault",      "renault",      (short)1899, (short)2026, true  },
                { "Peugeot",      "peugeot",      (short)1882, (short)2026, true  },
                { "Citroën",      "citroen",      (short)1919, (short)2026, true  },
                { "Fiat",         "fiat",         (short)1899, (short)2026, true  },
                { "Alfa Romeo",   "alfa-romeo",   (short)1910, (short)2026, true  },
                { "Volvo",        "volvo",        (short)1927, (short)2026, true  },
                { "Saab",         "saab",         (short)1945, (short)2012, false }, // discontinued 2012
                { "SEAT",         "seat",         (short)1950, (short)2026, true  },
                { "Škoda",        "skoda",        (short)1895, (short)2026, true  },
                { "Porsche",      "porsche",      (short)1931, (short)2026, true  },
                { "Land Rover",   "land-rover",   (short)1948, (short)2026, true  },
                { "Jaguar",       "jaguar",       (short)1922, (short)2026, true  },
                { "Mini",         "mini",         (short)1959, (short)2026, true  },
                { "Lancia",       "lancia",       (short)1906, (short)2014, false }, // withdrew from most EU markets 2014
                { "Rover",        "rover",        (short)1878, (short)2005, false }, // discontinued 2005
                // Japanese
                { "Toyota",       "toyota",       (short)1937, (short)2026, true  },
                { "Honda",        "honda",        (short)1948, (short)2026, true  },
                { "Nissan",       "nissan",       (short)1933, (short)2026, true  },
                { "Mazda",        "mazda",        (short)1920, (short)2026, true  },
                { "Subaru",       "subaru",       (short)1953, (short)2026, true  },
                { "Mitsubishi",   "mitsubishi",   (short)1917, (short)2026, true  },
                { "Lexus",        "lexus",        (short)1989, (short)2026, true  },
                { "Infiniti",     "infiniti",     (short)1989, (short)2026, true  },
                { "Acura",        "acura",        (short)1986, (short)2026, true  },
                { "Suzuki",       "suzuki",       (short)1909, (short)2026, true  },
                { "Isuzu",        "isuzu",        (short)1916, (short)2009, false }, // left US passenger market 2009
                // Korean
                { "Hyundai",      "hyundai",      (short)1967, (short)2026, true  },
                { "Kia",          "kia",          (short)1944, (short)2026, true  },
                { "Genesis",      "genesis",      (short)2015, (short)2026, true  },
            });

        // =====================================================================
        // CAR MODELS
        // We look up BrandId by slug so the migration is ID-order-independent.
        // =====================================================================

        migrationBuilder.Sql("""
            INSERT INTO [CarModels] (Name, Slug, IsActive, YearFrom, YearTo, BrandId)
            SELECT v.Name, v.Slug, v.IsActive, v.YearFrom, v.YearTo, b.Id
            FROM (VALUES
                -- CHEVROLET
                ('Impala',          'chevrolet-impala',          1, 1958, 2020, 'chevrolet'),
                ('Corvette',        'chevrolet-corvette',         1, 1953, 2026, 'chevrolet'),
                ('Camaro',          'chevrolet-camaro',           0, 1967, 2024, 'chevrolet'),
                ('Malibu',          'chevrolet-malibu',           1, 1964, 2024, 'chevrolet'),
                ('Silverado',       'chevrolet-silverado',        1, 1999, 2026, 'chevrolet'),
                ('Tahoe',           'chevrolet-tahoe',            1, 1995, 2026, 'chevrolet'),
                ('Suburban',        'chevrolet-suburban',         1, 1935, 2026, 'chevrolet'),
                ('Equinox',         'chevrolet-equinox',          1, 2005, 2026, 'chevrolet'),
                ('Traverse',        'chevrolet-traverse',         1, 2009, 2026, 'chevrolet'),
                ('Colorado',        'chevrolet-colorado',         1, 2004, 2026, 'chevrolet'),
                ('Bolt EV',         'chevrolet-bolt-ev',          1, 2017, 2026, 'chevrolet'),
                -- FORD
                ('Mustang',         'ford-mustang',               1, 1964, 2026, 'ford'),
                ('F-150',           'ford-f150',                  1, 1948, 2026, 'ford'),
                ('Explorer',        'ford-explorer',              1, 1991, 2026, 'ford'),
                ('Escape',          'ford-escape',                1, 2001, 2026, 'ford'),
                ('Ranger',          'ford-ranger',                1, 1983, 2026, 'ford'),
                ('Bronco',          'ford-bronco',                1, 1966, 2026, 'ford'),
                ('Maverick',        'ford-maverick',              1, 2022, 2026, 'ford'),
                ('Focus',           'ford-focus',                 0, 1998, 2019, 'ford'),
                ('Fusion',          'ford-fusion',                0, 2006, 2020, 'ford'),
                ('Kuga',            'ford-kuga',                  1, 2008, 2026, 'ford'),
                ('Fiesta',          'ford-fiesta',                0, 1976, 2023, 'ford'),
                ('Puma',            'ford-puma',                  1, 2019, 2026, 'ford'),
                ('Thunderbird',     'ford-thunderbird',           0, 1955, 2005, 'ford'),
                -- DODGE
                ('Charger',         'dodge-charger',              1, 1966, 2026, 'dodge'),
                ('Challenger',      'dodge-challenger',           0, 1970, 2023, 'dodge'),
                ('Durango',         'dodge-durango',              1, 1998, 2026, 'dodge'),
                ('Dart',            'dodge-dart',                 0, 1960, 2016, 'dodge'),
                -- CADILLAC
                ('Escalade',        'cadillac-escalade',          1, 1999, 2026, 'cadillac'),
                ('CT5',             'cadillac-ct5',               1, 2020, 2026, 'cadillac'),
                ('XT5',             'cadillac-xt5',               1, 2017, 2026, 'cadillac'),
                ('DeVille',         'cadillac-deville',           0, 1959, 2005, 'cadillac'),
                -- LINCOLN
                ('Navigator',       'lincoln-navigator',          1, 1998, 2026, 'lincoln'),
                ('Aviator',         'lincoln-aviator',            1, 2020, 2026, 'lincoln'),
                ('Continental',     'lincoln-continental',        0, 1940, 2020, 'lincoln'),
                -- JEEP
                ('Wrangler',        'jeep-wrangler',              1, 1986, 2026, 'jeep'),
                ('Cherokee',        'jeep-cherokee',              1, 1974, 2023, 'jeep'),
                ('Grand Cherokee',  'jeep-grand-cherokee',        1, 1993, 2026, 'jeep'),
                ('Compass',         'jeep-compass',               1, 2007, 2026, 'jeep'),
                ('Gladiator',       'jeep-gladiator',             1, 2020, 2026, 'jeep'),
                ('Renegade',        'jeep-renegade',              1, 2015, 2026, 'jeep'),
                -- TESLA
                ('Model S',         'tesla-model-s',              1, 2012, 2026, 'tesla'),
                ('Model 3',         'tesla-model-3',              1, 2017, 2026, 'tesla'),
                ('Model X',         'tesla-model-x',              1, 2015, 2026, 'tesla'),
                ('Model Y',         'tesla-model-y',              1, 2020, 2026, 'tesla'),
                ('Cybertruck',      'tesla-cybertruck',           1, 2023, 2026, 'tesla'),
                -- VOLKSWAGEN
                ('Beetle',          'vw-beetle',                  0, 1938, 2019, 'volkswagen'),
                ('Golf',            'vw-golf',                    1, 1974, 2026, 'volkswagen'),
                ('Polo',            'vw-polo',                    1, 1975, 2026, 'volkswagen'),
                ('Passat',          'vw-passat',                  1, 1973, 2026, 'volkswagen'),
                ('Tiguan',          'vw-tiguan',                  1, 2007, 2026, 'volkswagen'),
                ('Touareg',         'vw-touareg',                 1, 2002, 2026, 'volkswagen'),
                ('T-Roc',           'vw-t-roc',                   1, 2017, 2026, 'volkswagen'),
                ('ID.3',            'vw-id3',                     1, 2020, 2026, 'volkswagen'),
                ('ID.4',            'vw-id4',                     1, 2021, 2026, 'volkswagen'),
                ('Transporter',     'vw-transporter',             1, 1950, 2026, 'volkswagen'),
                ('Scirocco',        'vw-scirocco',                0, 1974, 2017, 'volkswagen'),
                -- BMW
                ('3 Series',        'bmw-3-series',               1, 1975, 2026, 'bmw'),
                ('5 Series',        'bmw-5-series',               1, 1972, 2026, 'bmw'),
                ('7 Series',        'bmw-7-series',               1, 1977, 2026, 'bmw'),
                ('1 Series',        'bmw-1-series',               1, 2004, 2026, 'bmw'),
                ('2 Series',        'bmw-2-series',               1, 2014, 2026, 'bmw'),
                ('4 Series',        'bmw-4-series',               1, 2013, 2026, 'bmw'),
                ('X1',              'bmw-x1',                     1, 2009, 2026, 'bmw'),
                ('X3',              'bmw-x3',                     1, 2003, 2026, 'bmw'),
                ('X5',              'bmw-x5',                     1, 1999, 2026, 'bmw'),
                ('X6',              'bmw-x6',                     1, 2008, 2026, 'bmw'),
                ('i4',              'bmw-i4',                     1, 2021, 2026, 'bmw'),
                ('iX',              'bmw-ix',                     1, 2021, 2026, 'bmw'),
                ('M3',              'bmw-m3',                     1, 1986, 2026, 'bmw'),
                ('M5',              'bmw-m5',                     1, 1984, 2026, 'bmw'),
                -- MERCEDES-BENZ
                ('C-Class',         'mb-c-class',                 1, 1993, 2026, 'mercedes-benz'),
                ('E-Class',         'mb-e-class',                 1, 1953, 2026, 'mercedes-benz'),
                ('S-Class',         'mb-s-class',                 1, 1972, 2026, 'mercedes-benz'),
                ('A-Class',         'mb-a-class',                 1, 1997, 2026, 'mercedes-benz'),
                ('GLC',             'mb-glc',                     1, 2015, 2026, 'mercedes-benz'),
                ('GLE',             'mb-gle',                     1, 2015, 2026, 'mercedes-benz'),
                ('GLA',             'mb-gla',                     1, 2013, 2026, 'mercedes-benz'),
                ('G-Class',         'mb-g-class',                 1, 1979, 2026, 'mercedes-benz'),
                ('EQC',             'mb-eqc',                     1, 2019, 2026, 'mercedes-benz'),
                ('EQS',             'mb-eqs',                     1, 2021, 2026, 'mercedes-benz'),
                -- AUDI
                ('A1',              'audi-a1',                    1, 2010, 2026, 'audi'),
                ('A3',              'audi-a3',                    1, 1996, 2026, 'audi'),
                ('A4',              'audi-a4',                    1, 1994, 2026, 'audi'),
                ('A5',              'audi-a5',                    1, 2007, 2026, 'audi'),
                ('A6',              'audi-a6',                    1, 1994, 2026, 'audi'),
                ('Q3',              'audi-q3',                    1, 2011, 2026, 'audi'),
                ('Q5',              'audi-q5',                    1, 2008, 2026, 'audi'),
                ('Q7',              'audi-q7',                    1, 2005, 2026, 'audi'),
                ('Q8',              'audi-q8',                    1, 2018, 2026, 'audi'),
                ('TT',              'audi-tt',                    0, 1998, 2023, 'audi'),
                ('e-tron',          'audi-e-tron',                1, 2018, 2026, 'audi'),
                -- OPEL
                ('Astra',           'opel-astra',                 1, 1991, 2026, 'opel'),
                ('Corsa',           'opel-corsa',                 1, 1982, 2026, 'opel'),
                ('Insignia',        'opel-insignia',              1, 2008, 2026, 'opel'),
                ('Mokka',           'opel-mokka',                 1, 2012, 2026, 'opel'),
                ('Kadett',          'opel-kadett',                0, 1962, 1991, 'opel'),
                -- RENAULT
                ('Clio',            'renault-clio',               1, 1990, 2026, 'renault'),
                ('Mégane',          'renault-megane',             1, 1995, 2026, 'renault'),
                ('Scenic',          'renault-scenic',             1, 1996, 2026, 'renault'),
                ('Captur',          'renault-captur',             1, 2013, 2026, 'renault'),
                ('Zoe',             'renault-zoe',                1, 2012, 2026, 'renault'),
                ('Austral',         'renault-austral',            1, 2022, 2026, 'renault'),
                -- PEUGEOT
                ('205',             'peugeot-205',                0, 1983, 1998, 'peugeot'),
                ('208',             'peugeot-208',                1, 2012, 2026, 'peugeot'),
                ('308',             'peugeot-308',                1, 2007, 2026, 'peugeot'),
                ('508',             'peugeot-508',                1, 2011, 2026, 'peugeot'),
                ('2008',            'peugeot-2008',               1, 2013, 2026, 'peugeot'),
                ('3008',            'peugeot-3008',               1, 2009, 2026, 'peugeot'),
                -- CITROËN
                ('C3',              'citroen-c3',                 1, 2002, 2026, 'citroen'),
                ('C4',              'citroen-c4',                 1, 2004, 2026, 'citroen'),
                ('Berlingo',        'citroen-berlingo',           1, 1996, 2026, 'citroen'),
                ('2CV',             'citroen-2cv',                0, 1948, 1990, 'citroen'),
                -- FIAT
                ('500',             'fiat-500',                   1, 1957, 2026, 'fiat'),
                ('Punto',           'fiat-punto',                 0, 1993, 2018, 'fiat'),
                ('Panda',           'fiat-panda',                 1, 1980, 2026, 'fiat'),
                ('Tipo',            'fiat-tipo',                  1, 1988, 2026, 'fiat'),
                -- ALFA ROMEO
                ('Giulia',          'alfa-romeo-giulia',          1, 2016, 2026, 'alfa-romeo'),
                ('Stelvio',         'alfa-romeo-stelvio',         1, 2017, 2026, 'alfa-romeo'),
                ('Tonale',          'alfa-romeo-tonale',          1, 2022, 2026, 'alfa-romeo'),
                ('Giulietta',       'alfa-romeo-giulietta',       0, 1977, 2020, 'alfa-romeo'),
                -- VOLVO
                ('S60',             'volvo-s60',                  1, 2000, 2026, 'volvo'),
                ('S90',             'volvo-s90',                  1, 2016, 2026, 'volvo'),
                ('V60',             'volvo-v60',                  1, 2010, 2026, 'volvo'),
                ('XC40',            'volvo-xc40',                 1, 2018, 2026, 'volvo'),
                ('XC60',            'volvo-xc60',                 1, 2008, 2026, 'volvo'),
                ('XC90',            'volvo-xc90',                 1, 2002, 2026, 'volvo'),
                ('240',             'volvo-240',                  0, 1974, 1993, 'volvo'),
                -- ŠKODA
                ('Octavia',         'skoda-octavia',              1, 1996, 2026, 'skoda'),
                ('Fabia',           'skoda-fabia',                1, 1999, 2026, 'skoda'),
                ('Superb',          'skoda-superb',               1, 2001, 2026, 'skoda'),
                ('Karoq',           'skoda-karoq',                1, 2017, 2026, 'skoda'),
                ('Kodiaq',          'skoda-kodiaq',               1, 2016, 2026, 'skoda'),
                ('Enyaq',           'skoda-enyaq',                1, 2021, 2026, 'skoda'),
                -- PORSCHE
                ('911',             'porsche-911',                1, 1963, 2026, 'porsche'),
                ('Cayenne',         'porsche-cayenne',            1, 2002, 2026, 'porsche'),
                ('Macan',           'porsche-macan',              1, 2014, 2026, 'porsche'),
                ('Panamera',        'porsche-panamera',           1, 2009, 2026, 'porsche'),
                ('Taycan',          'porsche-taycan',             1, 2019, 2026, 'porsche'),
                ('Boxster',         'porsche-boxster',            1, 1996, 2026, 'porsche'),
                -- LAND ROVER
                ('Defender',        'lr-defender',                1, 1983, 2026, 'land-rover'),
                ('Discovery',       'lr-discovery',               1, 1989, 2026, 'land-rover'),
                ('Discovery Sport', 'lr-discovery-sport',         1, 2015, 2026, 'land-rover'),
                ('Range Rover',     'lr-range-rover',             1, 1970, 2026, 'land-rover'),
                ('Range Rover Sport','lr-range-rover-sport',      1, 2005, 2026, 'land-rover'),
                ('Range Rover Evoque','lr-range-rover-evoque',    1, 2011, 2026, 'land-rover'),
                -- TOYOTA
                ('Corolla',         'toyota-corolla',             1, 1966, 2026, 'toyota'),
                ('Camry',           'toyota-camry',               1, 1982, 2026, 'toyota'),
                ('RAV4',            'toyota-rav4',                1, 1994, 2026, 'toyota'),
                ('Highlander',      'toyota-highlander',          1, 2001, 2026, 'toyota'),
                ('Land Cruiser',    'toyota-land-cruiser',        1, 1951, 2026, 'toyota'),
                ('Prius',           'toyota-prius',               1, 1997, 2026, 'toyota'),
                ('Yaris',           'toyota-yaris',               1, 1999, 2026, 'toyota'),
                ('Hilux',           'toyota-hilux',               1, 1968, 2026, 'toyota'),
                ('Tacoma',          'toyota-tacoma',              1, 1995, 2026, 'toyota'),
                ('C-HR',            'toyota-chr',                 1, 2016, 2026, 'toyota'),
                ('bZ4X',            'toyota-bz4x',                1, 2022, 2026, 'toyota'),
                ('Supra',           'toyota-supra',               1, 1978, 2026, 'toyota'),
                ('Celica',          'toyota-celica',              0, 1970, 2006, 'toyota'),
                ('Auris',           'toyota-auris',               0, 2006, 2019, 'toyota'),
                -- HONDA
                ('Civic',           'honda-civic',                1, 1972, 2026, 'honda'),
                ('Accord',          'honda-accord',               1, 1976, 2026, 'honda'),
                ('CR-V',            'honda-crv',                  1, 1995, 2026, 'honda'),
                ('HR-V',            'honda-hrv',                  1, 1998, 2026, 'honda'),
                ('Jazz',            'honda-jazz',                 1, 2002, 2026, 'honda'),
                -- NISSAN
                ('Qashqai',         'nissan-qashqai',             1, 2006, 2026, 'nissan'),
                ('X-Trail',         'nissan-x-trail',             1, 2001, 2026, 'nissan'),
                ('Juke',            'nissan-juke',                1, 2010, 2026, 'nissan'),
                ('Micra',           'nissan-micra',               1, 1982, 2026, 'nissan'),
                ('Leaf',            'nissan-leaf',                1, 2010, 2026, 'nissan'),
                ('Ariya',           'nissan-ariya',               1, 2021, 2026, 'nissan'),
                ('Altima',          'nissan-altima',              1, 1992, 2026, 'nissan'),
                ('Pathfinder',      'nissan-pathfinder',          1, 1985, 2026, 'nissan'),
                ('GT-R',            'nissan-gtr',                 0, 2007, 2022, 'nissan'),
                -- MAZDA
                ('3',               'mazda-3',                    1, 2003, 2026, 'mazda'),
                ('6',               'mazda-6',                    1, 2002, 2023, 'mazda'),
                ('CX-5',            'mazda-cx5',                  1, 2012, 2026, 'mazda'),
                ('CX-30',           'mazda-cx30',                 1, 2019, 2026, 'mazda'),
                ('MX-5',            'mazda-mx5',                  1, 1989, 2026, 'mazda'),
                ('RX-7',            'mazda-rx7',                  0, 1978, 2002, 'mazda'),
                -- SUBARU
                ('Impreza',         'subaru-impreza',             1, 1992, 2026, 'subaru'),
                ('Forester',        'subaru-forester',            1, 1997, 2026, 'subaru'),
                ('Outback',         'subaru-outback',             1, 1994, 2026, 'subaru'),
                ('XV / Crosstrek',  'subaru-crosstrek',           1, 2012, 2026, 'subaru'),
                ('WRX',             'subaru-wrx',                 1, 1992, 2026, 'subaru'),
                ('BRZ',             'subaru-brz',                 1, 2012, 2026, 'subaru'),
                -- HYUNDAI
                ('i10',             'hyundai-i10',                1, 2007, 2026, 'hyundai'),
                ('i20',             'hyundai-i20',                1, 2008, 2026, 'hyundai'),
                ('i30',             'hyundai-i30',                1, 2007, 2026, 'hyundai'),
                ('Tucson',          'hyundai-tucson',             1, 2004, 2026, 'hyundai'),
                ('Santa Fe',        'hyundai-santa-fe',           1, 2000, 2026, 'hyundai'),
                ('Kona',            'hyundai-kona',               1, 2017, 2026, 'hyundai'),
                ('Ioniq 5',         'hyundai-ioniq5',             1, 2021, 2026, 'hyundai'),
                ('Ioniq 6',         'hyundai-ioniq6',             1, 2022, 2026, 'hyundai'),
                ('Elantra',         'hyundai-elantra',            1, 1990, 2026, 'hyundai'),
                ('Sonata',          'hyundai-sonata',             1, 1985, 2026, 'hyundai'),
                -- KIA
                ('Picanto',         'kia-picanto',                1, 2004, 2026, 'kia'),
                ('Rio',             'kia-rio',                    1, 2000, 2026, 'kia'),
                ('Ceed',            'kia-ceed',                   1, 2006, 2026, 'kia'),
                ('Sportage',        'kia-sportage',               1, 1993, 2026, 'kia'),
                ('Sorento',         'kia-sorento',                1, 2002, 2026, 'kia'),
                ('EV6',             'kia-ev6',                    1, 2021, 2026, 'kia'),
                ('Niro',            'kia-niro',                   1, 2016, 2026, 'kia'),
                -- BUICK
                ('Skylark',         'buick-skylark',              0, 1961, 1998, 'buick'),
                ('Century',         'buick-century',              0, 1954, 2005, 'buick'),
                ('Riviera',         'buick-riviera',              0, 1963, 1999, 'buick'),
                ('LeSabre',         'buick-lesabre',              0, 1959, 2005, 'buick'),
                ('Regal',           'buick-regal',                0, 1973, 2020, 'buick'),
                ('Park Avenue',     'buick-park-avenue',          0, 1991, 2005, 'buick'),
                ('Lacrosse',        'buick-lacrosse',             0, 2005, 2019, 'buick'),
                ('Enclave',         'buick-enclave',              1, 2008, 2026, 'buick'),
                ('Encore',          'buick-encore',               1, 2013, 2026, 'buick'),
                ('Encore GX',       'buick-encore-gx',            1, 2020, 2026, 'buick'),
                ('Envision',        'buick-envision',             1, 2016, 2026, 'buick'),
                -- GMC
                ('Sierra 1500',     'gmc-sierra-1500',            1, 1999, 2026, 'gmc'),
                ('Yukon',           'gmc-yukon',                  1, 1992, 2026, 'gmc'),
                ('Yukon XL',        'gmc-yukon-xl',               1, 2000, 2026, 'gmc'),
                ('Terrain',         'gmc-terrain',                1, 2010, 2026, 'gmc'),
                ('Canyon',          'gmc-canyon',                 1, 2004, 2026, 'gmc'),
                ('Acadia',          'gmc-acadia',                 1, 2007, 2026, 'gmc'),
                ('Envoy',           'gmc-envoy',                  0, 1998, 2009, 'gmc'),
                ('Jimmy',           'gmc-jimmy',                  0, 1970, 2005, 'gmc'),
                ('Hummer EV',       'gmc-hummer-ev',              1, 2022, 2026, 'gmc'),
                -- PONTIAC (discontinued 2010)
                ('GTO',             'pontiac-gto',                0, 1964, 2006, 'pontiac'),
                ('Firebird',        'pontiac-firebird',           0, 1967, 2002, 'pontiac'),
                ('Trans Am',        'pontiac-trans-am',           0, 1969, 2002, 'pontiac'),
                ('Grand Prix',      'pontiac-grand-prix',         0, 1962, 2008, 'pontiac'),
                ('Grand Am',        'pontiac-grand-am',           0, 1973, 2005, 'pontiac'),
                ('Bonneville',      'pontiac-bonneville',         0, 1957, 2005, 'pontiac'),
                ('Aztek',           'pontiac-aztek',              0, 2001, 2005, 'pontiac'),
                ('G6',              'pontiac-g6',                 0, 2005, 2010, 'pontiac'),
                ('Solstice',        'pontiac-solstice',           0, 2006, 2010, 'pontiac'),
                -- OLDSMOBILE (discontinued 2004)
                ('Cutlass Supreme', 'oldsmobile-cutlass-supreme', 0, 1966, 1997, 'oldsmobile'),
                ('Delta 88',        'oldsmobile-delta-88',        0, 1965, 1999, 'oldsmobile'),
                ('Toronado',        'oldsmobile-toronado',        0, 1966, 1992, 'oldsmobile'),
                ('Aurora',          'oldsmobile-aurora',          0, 1995, 2003, 'oldsmobile'),
                ('Alero',           'oldsmobile-alero',           0, 1999, 2004, 'oldsmobile'),
                ('Intrigue',        'oldsmobile-intrigue',        0, 1998, 2002, 'oldsmobile'),
                ('Bravada',         'oldsmobile-bravada',         0, 1991, 2004, 'oldsmobile'),
                -- PLYMOUTH (discontinued 2001)
                ('Barracuda',       'plymouth-barracuda',         0, 1964, 1974, 'plymouth'),
                ('Road Runner',     'plymouth-road-runner',       0, 1968, 1980, 'plymouth'),
                ('Duster',          'plymouth-duster',            0, 1970, 1976, 'plymouth'),
                ('Valiant',         'plymouth-valiant',           0, 1960, 1976, 'plymouth'),
                ('Fury',            'plymouth-fury',              0, 1956, 1978, 'plymouth'),
                ('Voyager',         'plymouth-voyager',           0, 1984, 2001, 'plymouth'),
                ('Neon',            'plymouth-neon',              0, 1994, 2001, 'plymouth'),
                -- MERCURY (discontinued 2011)
                ('Cougar',          'mercury-cougar',             0, 1967, 2002, 'mercury'),
                ('Grand Marquis',   'mercury-grand-marquis',      0, 1975, 2011, 'mercury'),
                ('Mountaineer',     'mercury-mountaineer',        0, 1997, 2010, 'mercury'),
                ('Sable',           'mercury-sable',              0, 1986, 2009, 'mercury'),
                ('Milan',           'mercury-milan',              0, 2006, 2011, 'mercury'),
                ('Mariner',         'mercury-mariner',            0, 2005, 2011, 'mercury'),
                -- CHRYSLER
                ('300',             'chrysler-300',               1, 2005, 2026, 'chrysler'),
                ('Pacifica',        'chrysler-pacifica',          1, 2017, 2026, 'chrysler'),
                ('Sebring',         'chrysler-sebring',           0, 1995, 2010, 'chrysler'),
                ('PT Cruiser',      'chrysler-pt-cruiser',        0, 2001, 2010, 'chrysler'),
                ('Crossfire',       'chrysler-crossfire',         0, 2004, 2008, 'chrysler'),
                ('New Yorker',      'chrysler-new-yorker',        0, 1940, 1996, 'chrysler'),
                ('Town & Country',  'chrysler-town-and-country',  0, 1990, 2016, 'chrysler'),
                ('Voyager',         'chrysler-voyager',           0, 2020, 2023, 'chrysler'),
                -- RAM
                ('1500',            'ram-1500',                   1, 2010, 2026, 'ram'),
                ('2500',            'ram-2500',                   1, 2010, 2026, 'ram'),
                ('3500',            'ram-3500',                   1, 2010, 2026, 'ram'),
                ('ProMaster',       'ram-promaster',              1, 2014, 2026, 'ram'),
                -- SAAB (discontinued 2012)
                ('900',             'saab-900',                   0, 1978, 1998, 'saab'),
                ('9000',            'saab-9000',                  0, 1984, 1998, 'saab'),
                ('9-3',             'saab-9-3',                   0, 1998, 2012, 'saab'),
                ('9-5',             'saab-9-5',                   0, 1997, 2012, 'saab'),
                -- LANCIA (withdrew from EU markets 2014)
                ('Fulvia',          'lancia-fulvia',              0, 1963, 1976, 'lancia'),
                ('Stratos',         'lancia-stratos',             0, 1973, 1978, 'lancia'),
                ('Delta',           'lancia-delta',               0, 1979, 1994, 'lancia'),
                ('Thema',           'lancia-thema',               0, 1984, 1994, 'lancia'),
                ('Dedra',           'lancia-dedra',               0, 1989, 1999, 'lancia'),
                ('Kappa',           'lancia-kappa',               0, 1994, 2001, 'lancia'),
                ('Ypsilon',         'lancia-ypsilon',             0, 1996, 2014, 'lancia'),
                ('Lybra',           'lancia-lybra',               0, 1999, 2005, 'lancia'),
                -- ROVER (discontinued 2005)
                ('SD1',             'rover-sd1',                  0, 1976, 1986, 'rover'),
                ('800',             'rover-800',                  0, 1986, 1999, 'rover'),
                ('600',             'rover-600',                  0, 1993, 1999, 'rover'),
                ('400',             'rover-400',                  0, 1990, 1998, 'rover'),
                ('200',             'rover-200',                  0, 1984, 1999, 'rover'),
                ('75',              'rover-75',                   0, 1999, 2005, 'rover'),
                ('45',              'rover-45',                   0, 1999, 2005, 'rover'),
                ('25',              'rover-25',                   0, 1999, 2005, 'rover'),
                -- JAGUAR
                ('E-Type',          'jaguar-e-type',              0, 1961, 1975, 'jaguar'),
                ('XJ',              'jaguar-xj',                  0, 1968, 2019, 'jaguar'),
                ('XJS',             'jaguar-xjs',                 0, 1975, 1996, 'jaguar'),
                ('XK',              'jaguar-xk',                  0, 1996, 2014, 'jaguar'),
                ('S-Type',          'jaguar-s-type',              0, 1999, 2008, 'jaguar'),
                ('X-Type',          'jaguar-x-type',              0, 2001, 2009, 'jaguar'),
                ('XF',              'jaguar-xf',                  1, 2008, 2026, 'jaguar'),
                ('XE',              'jaguar-xe',                  0, 2015, 2024, 'jaguar'),
                ('F-Type',          'jaguar-f-type',              1, 2013, 2026, 'jaguar'),
                ('F-Pace',          'jaguar-f-pace',              1, 2016, 2026, 'jaguar'),
                ('E-Pace',          'jaguar-e-pace',              1, 2018, 2026, 'jaguar'),
                ('I-Pace',          'jaguar-i-pace',              1, 2018, 2026, 'jaguar'),
                -- MINI
                ('Hatch',           'mini-hatch',                 1, 2001, 2026, 'mini'),
                ('Convertible',     'mini-convertible',           1, 2004, 2026, 'mini'),
                ('Clubman',         'mini-clubman',               1, 2007, 2026, 'mini'),
                ('Countryman',      'mini-countryman',            1, 2010, 2026, 'mini'),
                ('Paceman',         'mini-paceman',               0, 2013, 2016, 'mini'),
                ('Coupe',           'mini-coupe',                 0, 2011, 2015, 'mini'),
                ('Roadster',        'mini-roadster',              0, 2012, 2015, 'mini'),
                ('Aceman',          'mini-aceman',                1, 2024, 2026, 'mini'),
                -- SEAT
                ('Ibiza',           'seat-ibiza',                 1, 1984, 2026, 'seat'),
                ('Leon',            'seat-leon',                  1, 1999, 2026, 'seat'),
                ('Arona',           'seat-arona',                 1, 2017, 2026, 'seat'),
                ('Ateca',           'seat-ateca',                 1, 2016, 2026, 'seat'),
                ('Tarraco',         'seat-tarraco',               1, 2018, 2026, 'seat'),
                ('Toledo',          'seat-toledo',                0, 1991, 2018, 'seat'),
                ('Córdoba',         'seat-cordoba',               0, 1993, 2009, 'seat'),
                ('Alhambra',        'seat-alhambra',              0, 1996, 2022, 'seat'),
                ('Mii',             'seat-mii',                   0, 2011, 2021, 'seat'),
                -- MITSUBISHI
                ('Outlander',       'mitsubishi-outlander',       1, 2001, 2026, 'mitsubishi'),
                ('Eclipse Cross',   'mitsubishi-eclipse-cross',   1, 2018, 2026, 'mitsubishi'),
                ('ASX',             'mitsubishi-asx',             1, 2010, 2026, 'mitsubishi'),
                ('Pajero',          'mitsubishi-pajero',          0, 1982, 2021, 'mitsubishi'),
                ('Galant',          'mitsubishi-galant',          0, 1969, 2012, 'mitsubishi'),
                ('Eclipse',         'mitsubishi-eclipse',         0, 1989, 2011, 'mitsubishi'),
                ('Lancer',          'mitsubishi-lancer',          0, 1973, 2017, 'mitsubishi'),
                ('Colt',            'mitsubishi-colt',            0, 1962, 2012, 'mitsubishi'),
                ('Carisma',         'mitsubishi-carisma',         0, 1995, 2004, 'mitsubishi'),
                ('Space Star',      'mitsubishi-space-star',      1, 1998, 2026, 'mitsubishi'),
                -- LEXUS
                ('ES',              'lexus-es',                   1, 1989, 2026, 'lexus'),
                ('IS',              'lexus-is',                   1, 1999, 2026, 'lexus'),
                ('GS',              'lexus-gs',                   0, 1993, 2020, 'lexus'),
                ('LS',              'lexus-ls',                   1, 1989, 2026, 'lexus'),
                ('RC',              'lexus-rc',                   1, 2014, 2026, 'lexus'),
                ('LC',              'lexus-lc',                   1, 2017, 2026, 'lexus'),
                ('NX',              'lexus-nx',                   1, 2014, 2026, 'lexus'),
                ('RX',              'lexus-rx',                   1, 1998, 2026, 'lexus'),
                ('UX',              'lexus-ux',                   1, 2018, 2026, 'lexus'),
                ('LX',              'lexus-lx',                   1, 1996, 2026, 'lexus'),
                ('RZ',              'lexus-rz',                   1, 2023, 2026, 'lexus'),
                -- INFINITI
                ('G35',             'infiniti-g35',               0, 2003, 2008, 'infiniti'),
                ('G37',             'infiniti-g37',               0, 2008, 2013, 'infiniti'),
                ('Q50',             'infiniti-q50',               1, 2014, 2026, 'infiniti'),
                ('Q60',             'infiniti-q60',               1, 2017, 2026, 'infiniti'),
                ('Q70',             'infiniti-q70',               0, 2014, 2019, 'infiniti'),
                ('QX50',            'infiniti-qx50',              1, 2019, 2026, 'infiniti'),
                ('QX55',            'infiniti-qx55',              1, 2021, 2026, 'infiniti'),
                ('QX60',            'infiniti-qx60',              1, 2013, 2026, 'infiniti'),
                ('QX80',            'infiniti-qx80',              1, 2014, 2026, 'infiniti'),
                ('FX',              'infiniti-fx',                0, 2003, 2013, 'infiniti'),
                -- ACURA
                ('Legend',          'acura-legend',               0, 1986, 1995, 'acura'),
                ('Integra',         'acura-integra',              1, 1986, 2026, 'acura'),
                ('NSX',             'acura-nsx',                  0, 1990, 2022, 'acura'),
                ('TL',              'acura-tl',                   0, 1996, 2014, 'acura'),
                ('TSX',             'acura-tsx',                  0, 2004, 2014, 'acura'),
                ('RSX',             'acura-rsx',                  0, 2002, 2006, 'acura'),
                ('TLX',             'acura-tlx',                  1, 2015, 2026, 'acura'),
                ('RDX',             'acura-rdx',                  1, 2007, 2026, 'acura'),
                ('MDX',             'acura-mdx',                  1, 2001, 2026, 'acura'),
                ('ZDX',             'acura-zdx',                  1, 2024, 2026, 'acura'),
                -- SUZUKI
                ('Alto',            'suzuki-alto',                1, 1979, 2026, 'suzuki'),
                ('Swift',           'suzuki-swift',               1, 1983, 2026, 'suzuki'),
                ('Ignis',           'suzuki-ignis',               1, 2000, 2026, 'suzuki'),
                ('Vitara',          'suzuki-vitara',              1, 1988, 2026, 'suzuki'),
                ('SX4',             'suzuki-sx4',                 1, 2006, 2026, 'suzuki'),
                ('Jimny',           'suzuki-jimny',               1, 1970, 2026, 'suzuki'),
                ('Grand Vitara',    'suzuki-grand-vitara',        0, 1998, 2015, 'suzuki'),
                ('Baleno',          'suzuki-baleno',              1, 1995, 2026, 'suzuki'),
                -- ISUZU (discontinued US passenger cars 2009)
                ('Trooper',         'isuzu-trooper',              0, 1981, 2002, 'isuzu'),
                ('Rodeo',           'isuzu-rodeo',                0, 1988, 2004, 'isuzu'),
                ('Axiom',           'isuzu-axiom',                0, 2002, 2004, 'isuzu'),
                ('Vehicross',       'isuzu-vehicross',            0, 1999, 2001, 'isuzu'),
                ('Amigo',           'isuzu-amigo',                0, 1989, 2000, 'isuzu'),
                -- GENESIS
                ('G70',             'genesis-g70',                1, 2018, 2026, 'genesis'),
                ('G80',             'genesis-g80',                1, 2017, 2026, 'genesis'),
                ('G90',             'genesis-g90',                1, 2017, 2026, 'genesis'),
                ('GV70',            'genesis-gv70',               1, 2021, 2026, 'genesis'),
                ('GV80',            'genesis-gv80',               1, 2021, 2026, 'genesis'),
                ('GV60',            'genesis-gv60',               1, 2022, 2026, 'genesis'),
                ('Electrified G80', 'genesis-electrified-g80',    1, 2022, 2026, 'genesis')
            ) AS v(Name, Slug, IsActive, YearFrom, YearTo, BrandSlug)
            INNER JOIN [CarBrands] b ON b.Slug = v.BrandSlug;
            """);

        // =====================================================================
        // VEHICLE VARIANTS
        // Lookup ModelId by Slug — robust against any IDENTITY seed order.
        // FuelType: 0=Petrol  1=Diesel  2=Hybrid/PHEV  3=Electric
        // =====================================================================

        migrationBuilder.Sql("""
            INSERT INTO [VehicleVariants] (ModelId, YearFrom, YearTo, EngineCode, EngineLabel, FuelType, Displacement, IsActive)
            SELECT m.Id, v.YearFrom, v.YearTo, v.EngineCode, v.EngineLabel, v.FuelType, v.Displacement, v.IsActive
            FROM (VALUES

                -- ==============================================================
                -- FORD MUSTANG  (slug: ford-mustang)
                -- ==============================================================
                -- Gen 1 (1964–1973)
                ('ford-mustang', 1964, 1967, '289',       '4.7L V8 289 195hp',                  0, '4727cc', 1),
                ('ford-mustang', 1964, 1966, '289HiPo',   '4.7L V8 289 Hi-Po 271hp',            0, '4727cc', 1),
                ('ford-mustang', 1967, 1970, '390GT',     '6.4L V8 390 GT 335hp',               0, '6390cc', 1),
                ('ford-mustang', 1969, 1970, 'Boss302',   '5.0L V8 Boss 302 290hp',             0, '4942cc', 1),
                ('ford-mustang', 1971, 1973, '429CJ',     '7.0L V8 429 Cobra Jet 370hp',        0, '7031cc', 1),
                -- Gen 2 Mustang II (1974–1978)
                ('ford-mustang', 1974, 1978, '2.3',       '2.3L I4 88hp',                       0, '2301cc', 1),
                ('ford-mustang', 1976, 1978, '2.8V6',     '2.8L V6 Cologne 103hp',              0, '2792cc', 1),
                -- Gen 3 Fox Body (1979–1993)
                ('ford-mustang', 1979, 1985, '2.3',       '2.3L I4 88hp',                       0, '2301cc', 1),
                ('ford-mustang', 1979, 1993, '5.0HO',     '5.0L V8 HO 225hp',                   0, '4942cc', 1),
                ('ford-mustang', 1982, 1986, '2.3T',      '2.3L I4 Turbo SVO 205hp',            0, '2301cc', 1),
                -- Gen 4 SN95 (1994–2004)
                ('ford-mustang', 1994, 2004, '3.8V6',     '3.8L V6 145hp',                      0, '3802cc', 1),
                ('ford-mustang', 1994, 2004, '4.6GT',     '4.6L V8 GT 215hp',                   0, '4601cc', 1),
                ('ford-mustang', 1996, 2004, '4.6Cobra',  '4.6L V8 Cobra 305hp',                0, '4601cc', 1),
                -- Gen 5 S197 (2005–2014)
                ('ford-mustang', 2005, 2010, '4.0V6',     '4.0L V6 210hp',                      0, '4009cc', 1),
                ('ford-mustang', 2005, 2010, '4.6GT',     '4.6L V8 GT 300hp',                   0, '4601cc', 1),
                ('ford-mustang', 2007, 2012, '5.4Shelby', '5.4L V8 Shelby GT500 500hp',         0, '5409cc', 1),
                ('ford-mustang', 2011, 2014, '3.7V6',     '3.7L V6 305hp',                      0, '3726cc', 1),
                ('ford-mustang', 2011, 2014, '5.0GT',     '5.0L V8 GT 412hp',                   0, '4951cc', 1),
                ('ford-mustang', 2013, 2014, '5.8Shelby', '5.8L V8 Shelby GT500 662hp',         0, '5861cc', 1),
                -- Gen 6 S550 (2015–2023)
                ('ford-mustang', 2015, 2023, '2.3EB',     '2.3L I4 EcoBoost 310hp',             0, '2261cc', 1),
                ('ford-mustang', 2015, 2023, '5.0GT',     '5.0L V8 GT 435hp',                   0, '4951cc', 1),
                ('ford-mustang', 2020, 2023, '5.2GT500',  '5.2L V8 Shelby GT500 760hp',         0, '5163cc', 1),
                -- Gen 7 S650 (2024–present)
                ('ford-mustang', 2024, 2026, '2.3EB',     '2.3L I4 EcoBoost 315hp',             0, '2261cc', 1),
                ('ford-mustang', 2024, 2026, '5.0GT',     '5.0L V8 GT 480hp',                   0, '4951cc', 1),
                ('ford-mustang', 2024, 2026, '5.0Dark',   '5.0L V8 Dark Horse 500hp',           0, '4951cc', 1),

                -- ==============================================================
                -- FORD F-150  (slug: ford-f150)
                -- ==============================================================
                ('ford-f150', 1975, 1996, '5.0V8',    '5.0L V8 145hp',                          0, '4942cc', 1),
                ('ford-f150', 1977, 1996, '5.8V8',    '5.8L V8 351W 156hp',                     0, '5766cc', 1),
                ('ford-f150', 1987, 1996, '5.0HO',    '5.0L V8 HO 210hp',                       0, '4942cc', 1),
                ('ford-f150', 1997, 2003, '4.2V6',    '4.2L V6 202hp',                          0, '4195cc', 1),
                ('ford-f150', 1997, 2003, '4.6V8',    '4.6L V8 Triton 220hp',                   0, '4601cc', 1),
                ('ford-f150', 1997, 2003, '5.4V8',    '5.4L V8 Triton 235hp',                   0, '5408cc', 1),
                ('ford-f150', 2004, 2008, '4.6V8',    '4.6L V8 231hp',                          0, '4601cc', 1),
                ('ford-f150', 2004, 2008, '5.4V8',    '5.4L V8 300hp',                          0, '5408cc', 1),
                ('ford-f150', 2009, 2014, '3.7V6',    '3.7L V6 302hp',                          0, '3726cc', 1),
                ('ford-f150', 2011, 2014, '3.5EB',    '3.5L EcoBoost V6 365hp',                 0, '3491cc', 1),
                ('ford-f150', 2011, 2014, '5.0V8',    '5.0L V8 360hp',                          0, '4951cc', 1),
                ('ford-f150', 2015, 2020, '2.7EB',    '2.7L EcoBoost V6 325hp',                 0, '2694cc', 1),
                ('ford-f150', 2015, 2020, '3.5EB',    '3.5L EcoBoost V6 375hp',                 0, '3491cc', 1),
                ('ford-f150', 2015, 2020, '5.0V8',    '5.0L V8 385hp',                          0, '4951cc', 1),
                ('ford-f150', 2021, 2026, '2.7EB',    '2.7L EcoBoost V6 325hp',                 0, '2694cc', 1),
                ('ford-f150', 2021, 2026, '3.5EB',    '3.5L EcoBoost V6 400hp',                 0, '3491cc', 1),
                ('ford-f150', 2021, 2026, '3.5EBHV',  '3.5L EcoBoost V6 PowerBoost Hybrid 430hp', 2, '3491cc', 1),
                ('ford-f150', 2021, 2026, '5.0V8',    '5.0L V8 400hp',                          0, '4951cc', 1),
                ('ford-f150', 2022, 2026, 'Lightning', 'Dual Motor Electric Lightning 452hp',   3, NULL,     1),

                -- ==============================================================
                -- VW GOLF  (slug: vw-golf)
                -- ==============================================================
                -- Mk1 (1974–1983)
                ('vw-golf', 1974, 1983, '1.1',       '1.1L I4 50hp',                            0, '1093cc', 1),
                ('vw-golf', 1974, 1983, '1.5D',      '1.5L I4 Diesel 50hp',                     1, '1471cc', 1),
                ('vw-golf', 1976, 1983, '1.6GTI',    '1.6L I4 GTI 110hp',                       0, '1588cc', 1),
                -- Mk2 (1983–1992)
                ('vw-golf', 1983, 1992, '1.3',       '1.3L I4 55hp',                            0, '1272cc', 1),
                ('vw-golf', 1983, 1992, '1.6D',      '1.6L I4 Diesel 54hp',                     1, '1588cc', 1),
                ('vw-golf', 1986, 1992, '1.8GTI',    '1.8L I4 GTI 107hp',                       0, '1781cc', 1),
                ('vw-golf', 1989, 1992, '1.8GTI16v', '1.8L I4 GTI 16v 139hp',                   0, '1781cc', 1),
                -- Mk3 (1991–1998)
                ('vw-golf', 1991, 1998, '1.4',       '1.4L I4 60hp',                            0, '1390cc', 1),
                ('vw-golf', 1991, 1998, '1.6',       '1.6L I4 101hp',                           0, '1598cc', 1),
                ('vw-golf', 1991, 1998, '1.9TDI',    '1.9L I4 TDI 90hp',                        1, '1896cc', 1),
                ('vw-golf', 1992, 1998, '2.0GTI',    '2.0L I4 GTI 115hp',                       0, '1984cc', 1),
                ('vw-golf', 1992, 1998, '2.8VR6',    '2.8L VR6 174hp',                          0, '2792cc', 1),
                -- Mk4 (1997–2004)
                ('vw-golf', 1997, 2004, '1.4',       '1.4L I4 75hp',                            0, '1390cc', 1),
                ('vw-golf', 1997, 2004, '1.6FSI',    '1.6L I4 FSI 110hp',                       0, '1598cc', 1),
                ('vw-golf', 1997, 2004, '1.9TDI',    '1.9L I4 TDI 100hp',                       1, '1896cc', 1),
                ('vw-golf', 1997, 2004, '2.3VR5',    '2.3L VR5 150hp',                          0, '2324cc', 1),
                ('vw-golf', 2001, 2004, '1.8TGTi',   '1.8L I4 Turbo GTI 180hp',                 0, '1781cc', 1),
                ('vw-golf', 2002, 2004, '3.2R32',    '3.2L VR6 R32 241hp',                      0, '3189cc', 1),
                -- Mk5 (2003–2009)
                ('vw-golf', 2003, 2009, '1.4FSI',    '1.4L I4 FSI 80hp',                        0, '1390cc', 1),
                ('vw-golf', 2003, 2009, '1.9TDI',    '1.9L I4 TDI 105hp',                       1, '1896cc', 1),
                ('vw-golf', 2004, 2009, '1.4TSI',    '1.4L I4 TSI 140hp',                       0, '1390cc', 1),
                ('vw-golf', 2004, 2009, '2.0TFSI',   '2.0L I4 TFSI GTI 200hp',                  0, '1984cc', 1),
                ('vw-golf', 2005, 2009, '3.2R32',    '3.2L VR6 R32 250hp',                      0, '3189cc', 1),
                -- Mk6 (2008–2013)
                ('vw-golf', 2008, 2013, '1.2TSI',    '1.2L I4 TSI 86hp',                        0, '1197cc', 1),
                ('vw-golf', 2008, 2013, '1.4TSI',    '1.4L I4 TSI 122hp',                       0, '1390cc', 1),
                ('vw-golf', 2008, 2013, '2.0TDI',    '2.0L I4 TDI 110hp',                       1, '1968cc', 1),
                ('vw-golf', 2009, 2013, '2.0TFSI',   '2.0L I4 TFSI GTI 211hp',                  0, '1984cc', 1),
                ('vw-golf', 2010, 2013, '2.0R',      '2.0L I4 TSI Golf R 270hp',                0, '1984cc', 1),
                -- Mk7 (2012–2019)
                ('vw-golf', 2012, 2019, '1.0TSI',    '1.0L I3 TSI 115hp',                       0, '999cc',  1),
                ('vw-golf', 2012, 2019, '1.4TSI',    '1.4L I4 TSI 125hp',                       0, '1395cc', 1),
                ('vw-golf', 2012, 2019, '1.5TSI',    '1.5L I4 TSI 150hp',                       0, '1498cc', 1),
                ('vw-golf', 2012, 2019, '2.0TDI',    '2.0L I4 TDI 150hp',                       1, '1968cc', 1),
                ('vw-golf', 2013, 2019, '2.0TFSI',   '2.0L I4 GTI 220hp',                       0, '1984cc', 1),
                ('vw-golf', 2013, 2019, '2.0R',      '2.0L I4 Golf R 300hp',                    0, '1984cc', 1),
                ('vw-golf', 2014, 2019, 'GTE',        '1.4L I4 PHEV GTE 204hp',                 2, '1395cc', 1),
                -- Mk8 (2020–present)
                ('vw-golf', 2020, 2026, '1.0TSI',    '1.0L I3 TSI 110hp',                       0, '999cc',  1),
                ('vw-golf', 2020, 2026, '1.5TSI',    '1.5L I4 TSI 150hp',                       0, '1498cc', 1),
                ('vw-golf', 2020, 2026, '2.0TDI',    '2.0L I4 TDI 115hp',                       1, '1968cc', 1),
                ('vw-golf', 2020, 2026, '2.0TDI150', '2.0L I4 TDI 150hp',                       1, '1968cc', 1),
                ('vw-golf', 2021, 2026, '2.0TFSI',   '2.0L I4 GTI 245hp',                       0, '1984cc', 1),
                ('vw-golf', 2021, 2026, '2.0R',      '2.0L I4 Golf R 320hp',                    0, '1984cc', 1),
                ('vw-golf', 2021, 2026, 'eHybrid',   '1.4L I4 PHEV eHybrid 245hp',              2, '1395cc', 1),

                -- ==============================================================
                -- VW PASSAT  (slug: vw-passat)
                -- ==============================================================
                ('vw-passat', 1973, 1980, '1.3',      '1.3L I4 B1 55hp',                        0, '1272cc', 1),
                ('vw-passat', 1973, 1980, '1.6',      '1.6L I4 B1 85hp',                        0, '1588cc', 1),
                ('vw-passat', 1980, 1988, '1.6',      '1.6L I4 B2 85hp',                        0, '1588cc', 1),
                ('vw-passat', 1980, 1988, '1.6D',     '1.6L I4 B2 Diesel 54hp',                 1, '1588cc', 1),
                ('vw-passat', 1988, 1993, '1.8',      '1.8L I4 B3 90hp',                        0, '1781cc', 1),
                ('vw-passat', 1988, 1993, '1.9TDI',   '1.9L I4 TDI B3 68hp',                    1, '1896cc', 1),
                ('vw-passat', 1993, 1996, '1.8',      '1.8L I4 B4 90hp',                        0, '1781cc', 1),
                ('vw-passat', 1993, 1996, '1.9TDI',   '1.9L I4 TDI B4 90hp',                    1, '1896cc', 1),
                ('vw-passat', 1996, 2001, '1.8T',     '1.8L I4 Turbo B5 150hp',                 0, '1781cc', 1),
                ('vw-passat', 1996, 2001, '2.8V6',    '2.8L V6 B5 193hp',                       0, '2771cc', 1),
                ('vw-passat', 1996, 2001, '1.9TDI',   '1.9L I4 TDI B5 110hp',                   1, '1896cc', 1),
                ('vw-passat', 2001, 2005, '2.0',      '2.0L I4 B5 115hp',                       0, '1984cc', 1),
                ('vw-passat', 2001, 2005, '2.0TDI',   '2.0L I4 TDI B5 130hp',                   1, '1968cc', 1),
                ('vw-passat', 2005, 2010, '1.6FSI',   '1.6L I4 FSI B6 115hp',                   0, '1598cc', 1),
                ('vw-passat', 2005, 2010, '2.0TFSI',  '2.0L I4 TFSI B6 200hp',                  0, '1984cc', 1),
                ('vw-passat', 2005, 2010, '2.0TDI',   '2.0L I4 TDI B6 140hp',                   1, '1968cc', 1),
                ('vw-passat', 2005, 2010, '3.2V6',    '3.2L V6 FSI B6 250hp',                   0, '3189cc', 1),
                ('vw-passat', 2010, 2015, '1.4TSI',   '1.4L I4 TSI B7 122hp',                   0, '1390cc', 1),
                ('vw-passat', 2010, 2015, '1.8TSI',   '1.8L I4 TSI B7 160hp',                   0, '1798cc', 1),
                ('vw-passat', 2010, 2015, '2.0TDI',   '2.0L I4 TDI B7 140hp',                   1, '1968cc', 1),
                ('vw-passat', 2015, 2019, '1.4TSI',   '1.4L I4 TSI B8 125hp',                   0, '1395cc', 1),
                ('vw-passat', 2015, 2019, '1.8TSI',   '1.8L I4 TSI B8 180hp',                   0, '1798cc', 1),
                ('vw-passat', 2015, 2019, '2.0TDI',   '2.0L I4 TDI B8 150hp',                   1, '1968cc', 1),
                ('vw-passat', 2015, 2019, 'GTE',      '1.4L PHEV GTE B8 218hp',                 2, '1395cc', 1),
                ('vw-passat', 2019, 2026, '1.5TSI',   '1.5L I4 TSI B8 150hp',                   0, '1498cc', 1),
                ('vw-passat', 2019, 2026, '2.0TSI',   '2.0L I4 TSI B8 190hp',                   0, '1984cc', 1),
                ('vw-passat', 2019, 2026, '2.0TDI',   '2.0L I4 TDI B8 150hp',                   1, '1968cc', 1),

                -- ==============================================================
                -- BMW 3 SERIES  (slug: bmw-3-series)
                -- ==============================================================
                ('bmw-3-series', 1975, 1983, '1.8',       '1.8L I4 320 90hp',                   0, '1766cc', 1),
                ('bmw-3-series', 1977, 1983, '2.0',       '2.0L I6 320i 122hp',                 0, '1990cc', 1),
                ('bmw-3-series', 1982, 1994, '1.6',       '1.6L I4 316 90hp',                   0, '1596cc', 1),
                ('bmw-3-series', 1982, 1994, '1.8',       '1.8L I4 318i 102hp',                 0, '1766cc', 1),
                ('bmw-3-series', 1982, 1994, '2.0',       '2.0L I6 320i 129hp',                 0, '1990cc', 1),
                ('bmw-3-series', 1985, 1991, 'M3E30',     '2.3L I4 M3 E30 200hp',               0, '2302cc', 1),
                ('bmw-3-series', 1990, 2000, '1.6',       '1.6L I4 316i E36 102hp',             0, '1596cc', 1),
                ('bmw-3-series', 1990, 2000, '1.8',       '1.8L I4 318i E36 118hp',             0, '1796cc', 1),
                ('bmw-3-series', 1990, 2000, '2.0',       '2.0L I6 320i E36 150hp',             0, '1991cc', 1),
                ('bmw-3-series', 1990, 2000, '2.5',       '2.5L I6 325i E36 192hp',             0, '2494cc', 1),
                ('bmw-3-series', 1993, 2000, '1.7TDS',    '1.7L I4 318tds Diesel 90hp',         1, '1665cc', 1),
                ('bmw-3-series', 1993, 1999, 'M3E36',     '3.0L I6 M3 E36 286hp',               0, '2990cc', 1),
                ('bmw-3-series', 1998, 2007, '1.8',       '1.8L I4 318i E46 118hp',             0, '1895cc', 1),
                ('bmw-3-series', 1998, 2007, '2.0',       '2.0L I6 320i E46 150hp',             0, '1991cc', 1),
                ('bmw-3-series', 1998, 2007, '2.5',       '2.5L I6 325i E46 192hp',             0, '2494cc', 1),
                ('bmw-3-series', 1998, 2007, '3.0',       '3.0L I6 330i E46 231hp',             0, '2979cc', 1),
                ('bmw-3-series', 1998, 2007, '2.0D',      '2.0L I4 320d E46 136hp',             1, '1951cc', 1),
                ('bmw-3-series', 2000, 2006, 'M3E46',     '3.2L I6 M3 E46 343hp',               0, '3246cc', 1),
                ('bmw-3-series', 2005, 2013, '2.0',       '2.0L I4 318i E90 143hp',             0, '1995cc', 1),
                ('bmw-3-series', 2005, 2013, '2.5',       '2.5L I6 325i E90 218hp',             0, '2494cc', 1),
                ('bmw-3-series', 2005, 2013, '3.0',       '3.0L I6 330i E90 272hp',             0, '2996cc', 1),
                ('bmw-3-series', 2005, 2013, '2.0D',      '2.0L I4 320d E90 163hp',             1, '1995cc', 1),
                ('bmw-3-series', 2007, 2013, 'M3E90',     '4.0L V8 M3 E90 420hp',               0, '3999cc', 1),
                ('bmw-3-series', 2011, 2019, '1.5T',      '1.5L I3 TwinPower 316i F30 114hp',   0, '1499cc', 1),
                ('bmw-3-series', 2011, 2019, '2.0T',      '2.0L I4 TwinPower 320i F30 184hp',   0, '1997cc', 1),
                ('bmw-3-series', 2011, 2019, '2.0T28',    '2.0L I4 TwinPower 328i F30 245hp',   0, '1997cc', 1),
                ('bmw-3-series', 2011, 2019, '3.0T',      '3.0L I6 TwinPower 335i F30 306hp',   0, '2979cc', 1),
                ('bmw-3-series', 2011, 2019, '2.0D',      '2.0L I4 320d F30 190hp',             1, '1995cc', 1),
                ('bmw-3-series', 2015, 2019, '330ePHEV',  '2.0L I4 PHEV 330e F30 252hp',        2, '1997cc', 1),
                ('bmw-3-series', 2014, 2020, 'M3F80',     '3.0L I6 TwinPower M3 F80 431hp',     0, '2979cc', 1),
                ('bmw-3-series', 2019, 2026, '2.0T',      '2.0L I4 TwinPower 320i G20 184hp',   0, '1998cc', 1),
                ('bmw-3-series', 2019, 2026, '2.0T30',    '2.0L I4 TwinPower 330i G20 258hp',   0, '1998cc', 1),
                ('bmw-3-series', 2019, 2026, '3.0M340',   '3.0L I6 TwinPower M340i G20 374hp',  0, '2998cc', 1),
                ('bmw-3-series', 2019, 2026, '2.0D',      '2.0L I4 320d G20 190hp',             1, '1995cc', 1),
                ('bmw-3-series', 2022, 2026, '330ePHEV',  '2.0L I4 PHEV 330e G20 292hp',        2, '1998cc', 1),
                ('bmw-3-series', 2021, 2026, 'M3G80',     '3.0L I6 TwinPower M3 G80 480hp',     0, '2993cc', 1),

                -- ==============================================================
                -- MERCEDES-BENZ C-CLASS  (slug: mb-c-class)
                -- ==============================================================
                ('mb-c-class', 1993, 2000, '1.8K',      '1.8L I4 Kompressor W202 143hp',        0, '1799cc', 1),
                ('mb-c-class', 1993, 2000, '2.0',       '2.0L I4 C200 W202 136hp',              0, '1998cc', 1),
                ('mb-c-class', 1993, 2000, '2.2D',      '2.2L I4 C220 Diesel W202 95hp',        1, '2155cc', 1),
                ('mb-c-class', 1993, 2000, '2.5D',      '2.5L I5 C250 Diesel W202 113hp',       1, '2497cc', 1),
                ('mb-c-class', 2000, 2007, '1.8K',      '1.8L I4 Kompressor W203 143hp',        0, '1796cc', 1),
                ('mb-c-class', 2000, 2007, '2.0',       '2.0L I4 C200 W203 163hp',              0, '1998cc', 1),
                ('mb-c-class', 2000, 2007, '2.2CDI',    '2.2L I4 CDI W203 150hp',               1, '2148cc', 1),
                ('mb-c-class', 2002, 2007, 'AMG32',     '3.2L V6 AMG C32 349hp',                0, '3199cc', 1),
                ('mb-c-class', 2007, 2014, '1.8K',      '1.8L I4 Kompressor W204 156hp',        0, '1796cc', 1),
                ('mb-c-class', 2007, 2014, '2.0T',      '2.0L I4 Turbo W204 184hp',             0, '1991cc', 1),
                ('mb-c-class', 2007, 2014, '2.2CDI',    '2.2L I4 BlueTEC W204 170hp',           1, '2143cc', 1),
                ('mb-c-class', 2011, 2014, 'AMG63',     '6.2L V8 AMG C63 457hp',                0, '6208cc', 1),
                ('mb-c-class', 2014, 2021, '1.6T',      '1.6L I4 Turbo W205 156hp',             0, '1595cc', 1),
                ('mb-c-class', 2014, 2021, '2.0T',      '2.0L I4 Turbo C200 W205 184hp',        0, '1991cc', 1),
                ('mb-c-class', 2014, 2021, '2.0T300',   '2.0L I4 Turbo C300 W205 258hp',        0, '1991cc', 1),
                ('mb-c-class', 2014, 2021, '2.0CDI',    '2.2L I4 BlueTEC C220d W205 170hp',     1, '2143cc', 1),
                ('mb-c-class', 2014, 2021, 'AMG43',     '3.0L V6 Biturbo AMG C43 390hp',        0, '2996cc', 1),
                ('mb-c-class', 2014, 2021, 'AMG63S',    '4.0L V8 Biturbo AMG C63 S 510hp',      0, '3982cc', 1),
                ('mb-c-class', 2016, 2021, 'C350ePHEV', '2.0L I4 PHEV C350e W205 279hp',        2, '1991cc', 1),
                ('mb-c-class', 2021, 2026, '1.5T',      '1.5L I4 48V MHEV C180 W206 170hp',     0, '1496cc', 1),
                ('mb-c-class', 2021, 2026, '2.0T200',   '2.0L I4 Turbo C200 W206 204hp',        0, '1991cc', 1),
                ('mb-c-class', 2021, 2026, '2.0T300',   '2.0L I4 Turbo C300 W206 258hp',        0, '1991cc', 1),
                ('mb-c-class', 2021, 2026, '2.0D',      '2.0L I4 C220d W206 200hp',             1, '1993cc', 1),
                ('mb-c-class', 2021, 2026, 'C300ePHEV', '2.0L I4 PHEV C300e W206 313hp',        2, '1991cc', 1),
                ('mb-c-class', 2021, 2026, 'AMG43',     '3.0L I6 AMG C43 W206 408hp',           0, '2999cc', 1),
                ('mb-c-class', 2023, 2026, 'AMG63E',    '2.0L I4 PHEV AMG C63 W206 680hp',      2, '1991cc', 1),

                -- ==============================================================
                -- AUDI A4  (slug: audi-a4)
                -- ==============================================================
                ('audi-a4', 1994, 2001, '1.6',       '1.6L I4 B5 100hp',                        0, '1595cc', 1),
                ('audi-a4', 1994, 2001, '1.8',       '1.8L I4 B5 125hp',                        0, '1781cc', 1),
                ('audi-a4', 1994, 2001, '1.8T',      '1.8L I4 Turbo B5 150hp',                  0, '1781cc', 1),
                ('audi-a4', 1994, 2001, '2.6V6',     '2.6L V6 B5 150hp',                        0, '2598cc', 1),
                ('audi-a4', 1994, 2001, '1.9TDI',    '1.9L I4 TDI B5 90hp',                     1, '1896cc', 1),
                ('audi-a4', 1994, 2001, '1.9TDIPD',  '1.9L I4 TDI PD B5 115hp',                 1, '1896cc', 1),
                ('audi-a4', 2000, 2004, '1.8T',      '1.8L I4 Turbo B6 150hp',                  0, '1781cc', 1),
                ('audi-a4', 2000, 2004, '3.0V6',     '3.0L V6 B6 220hp',                        0, '2976cc', 1),
                ('audi-a4', 2000, 2004, '1.9TDI',    '1.9L I4 TDI B6 130hp',                    1, '1896cc', 1),
                ('audi-a4', 2000, 2004, '2.5TDI',    '2.5L V6 TDI B6 163hp',                    1, '2496cc', 1),
                ('audi-a4', 2004, 2008, '2.0TFSI',   '2.0L I4 TFSI B7 200hp',                   0, '1984cc', 1),
                ('audi-a4', 2004, 2008, '3.2FSI',    '3.2L V6 FSI B7 255hp',                    0, '3123cc', 1),
                ('audi-a4', 2004, 2008, '2.0TDI',    '2.0L I4 TDI B7 140hp',                    1, '1968cc', 1),
                ('audi-a4', 2008, 2016, '1.8TFSI',   '1.8L I4 TFSI B8 160hp',                   0, '1798cc', 1),
                ('audi-a4', 2008, 2016, '2.0TFSI',   '2.0L I4 TFSI B8 211hp',                   0, '1984cc', 1),
                ('audi-a4', 2008, 2016, '3.0TFSI',   '3.0L V6 TFSI B8 272hp',                   0, '2994cc', 1),
                ('audi-a4', 2008, 2016, '2.0TDI',    '2.0L I4 TDI B8 143hp',                    1, '1968cc', 1),
                ('audi-a4', 2008, 2016, '2.0TDI177', '2.0L I4 TDI B8 177hp',                    1, '1968cc', 1),
                ('audi-a4', 2009, 2012, 'RS4B8',     '4.2L V8 FSI RS4 B8 450hp',                0, '4163cc', 1),
                ('audi-a4', 2015, 2026, '1.4TFSI',   '1.4L I4 TFSI B9 150hp',                   0, '1395cc', 1),
                ('audi-a4', 2015, 2026, '2.0TFSI',   '2.0L I4 TFSI B9 190hp',                   0, '1984cc', 1),
                ('audi-a4', 2015, 2026, '2.0TFSI45', '2.0L I4 TFSI B9 245hp',                   0, '1984cc', 1),
                ('audi-a4', 2015, 2026, '3.0TFSI',   '3.0L V6 TFSI B9 354hp',                   0, '2994cc', 1),
                ('audi-a4', 2015, 2026, '2.0TDI',    '2.0L I4 TDI B9 150hp',                    1, '1968cc', 1),
                ('audi-a4', 2015, 2026, '2.0TDI40',  '2.0L I4 TDI B9 190hp',                    1, '1968cc', 1),
                ('audi-a4', 2018, 2026, 'PHEV',      '1.4L I4 PHEV 45 TFSI e B9 245hp',         2, '1395cc', 1),
                ('audi-a4', 2017, 2023, 'RS4B9',     '2.9L V6 Biturbo RS4 B9 450hp',            0, '2894cc', 1),

                -- ==============================================================
                -- TOYOTA COROLLA  (slug: toyota-corolla)
                -- ==============================================================
                ('toyota-corolla', 1966, 1970, '1.1',      '1.1L I4 K10 60hp',                  0, '1077cc', 1),
                ('toyota-corolla', 1970, 1974, '1.2',      '1.2L I4 E20 73hp',                  0, '1166cc', 1),
                ('toyota-corolla', 1974, 1979, '1.2',      '1.2L I4 E30 75hp',                  0, '1166cc', 1),
                ('toyota-corolla', 1979, 1983, '1.3',      '1.3L I4 E70 75hp',                  0, '1290cc', 1),
                ('toyota-corolla', 1983, 1987, '1.3',      '1.3L I4 E80 75hp',                  0, '1295cc', 1),
                ('toyota-corolla', 1983, 1987, '1.6GT',    '1.6L I4 AE86 GT 128hp',             0, '1587cc', 1),
                ('toyota-corolla', 1987, 1991, '1.3',      '1.3L I4 E90 75hp',                  0, '1295cc', 1),
                ('toyota-corolla', 1987, 1991, '1.6',      '1.6L I4 E90 102hp',                 0, '1587cc', 1),
                ('toyota-corolla', 1991, 1995, '1.3',      '1.3L I4 E100 75hp',                 0, '1331cc', 1),
                ('toyota-corolla', 1991, 1995, '1.6',      '1.6L I4 E100 114hp',                0, '1587cc', 1),
                ('toyota-corolla', 1991, 1995, '2.0D',     '2.0L I4 Diesel 73hp',               1, '1975cc', 1),
                ('toyota-corolla', 1995, 2000, '1.3',      '1.3L I4 E110 75hp',                 0, '1331cc', 1),
                ('toyota-corolla', 1995, 2000, '1.6',      '1.6L I4 E110 110hp',                0, '1587cc', 1),
                ('toyota-corolla', 2000, 2007, '1.4',      '1.4L I4 E120 97hp',                 0, '1398cc', 1),
                ('toyota-corolla', 2000, 2007, '1.6',      '1.6L I4 E120 110hp',                0, '1598cc', 1),
                ('toyota-corolla', 2000, 2007, '2.0D',     '2.0L I4 D-4D 90hp',                 1, '1995cc', 1),
                ('toyota-corolla', 2007, 2013, '1.4',      '1.4L I4 E140 97hp',                 0, '1398cc', 1),
                ('toyota-corolla', 2007, 2013, '1.6',      '1.6L I4 E140 132hp',                0, '1598cc', 1),
                ('toyota-corolla', 2007, 2013, '2.0D',     '2.0L I4 D-4D 126hp',                1, '1998cc', 1),
                ('toyota-corolla', 2013, 2018, '1.33',     '1.33L I4 E170 99hp',                0, '1329cc', 1),
                ('toyota-corolla', 2013, 2018, '1.6',      '1.6L I4 E170 132hp',                0, '1598cc', 1),
                ('toyota-corolla', 2018, 2022, '1.2T',     '1.2L I4 Turbo 116hp',               0, '1197cc', 1),
                ('toyota-corolla', 2018, 2022, '1.8H',     '1.8L I4 Hybrid 122hp',              2, '1798cc', 1),
                ('toyota-corolla', 2018, 2022, '2.0H',     '2.0L I4 Hybrid 196hp',              2, '1987cc', 1),
                ('toyota-corolla', 2022, 2026, '1.8H',     '1.8L I4 Hybrid 140hp',              2, '1798cc', 1),
                ('toyota-corolla', 2022, 2026, '2.0H',     '2.0L I4 Hybrid 197hp',              2, '1987cc', 1),
                ('toyota-corolla', 2022, 2026, '1.6T',     '1.6L I4 Turbo GR 300hp',            0, '1618cc', 1),

                -- ==============================================================
                -- TOYOTA CAMRY  (slug: toyota-camry)
                -- ==============================================================
                ('toyota-camry', 1982, 1986, '2.0',    '2.0L I4 V10 98hp',                      0, '1994cc', 1),
                ('toyota-camry', 1986, 1991, '2.0',    '2.0L I4 V20 115hp',                     0, '1994cc', 1),
                ('toyota-camry', 1991, 1996, '2.2',    '2.2L I4 V30 136hp',                     0, '2164cc', 1),
                ('toyota-camry', 1991, 1996, '3.0V6',  '3.0L V6 V30 185hp',                     0, '2994cc', 1),
                ('toyota-camry', 1996, 2001, '2.2',    '2.2L I4 133hp',                         0, '2164cc', 1),
                ('toyota-camry', 1996, 2001, '3.0V6',  '3.0L V6 194hp',                         0, '2994cc', 1),
                ('toyota-camry', 2001, 2006, '2.4',    '2.4L I4 157hp',                         0, '2362cc', 1),
                ('toyota-camry', 2001, 2006, '3.0V6',  '3.0L V6 210hp',                         0, '2994cc', 1),
                ('toyota-camry', 2006, 2011, '2.4',    '2.4L I4 158hp',                         0, '2362cc', 1),
                ('toyota-camry', 2006, 2011, '3.5V6',  '3.5L V6 268hp',                         0, '3456cc', 1),
                ('toyota-camry', 2006, 2011, '2.4HV',  '2.4L I4 Hybrid 187hp',                  2, '2362cc', 1),
                ('toyota-camry', 2011, 2017, '2.5',    '2.5L I4 178hp',                         0, '2494cc', 1),
                ('toyota-camry', 2011, 2017, '3.5V6',  '3.5L V6 268hp',                         0, '3456cc', 1),
                ('toyota-camry', 2011, 2017, '2.5HV',  '2.5L I4 Hybrid 200hp',                  2, '2494cc', 1),
                ('toyota-camry', 2017, 2024, '2.5',    '2.5L I4 203hp',                         0, '2487cc', 1),
                ('toyota-camry', 2017, 2024, '3.5V6',  '3.5L V6 301hp',                         0, '3456cc', 1),
                ('toyota-camry', 2017, 2024, '2.5HV',  '2.5L I4 Hybrid 208hp',                  2, '2487cc', 1),
                ('toyota-camry', 2024, 2026, '2.5HV',  '2.5L I4 Hybrid 232hp',                  2, '2487cc', 1),

                -- ==============================================================
                -- HONDA CIVIC  (slug: honda-civic)
                -- ==============================================================
                ('honda-civic', 1972, 1975, '1.2',       '1.2L I4 50hp',                        0, '1169cc', 1),
                ('honda-civic', 1975, 1979, '1.5CVCC',   '1.5L I4 CVCC 63hp',                   0, '1488cc', 1),
                ('honda-civic', 1979, 1983, '1.3',       '1.3L I4 60hp',                        0, '1335cc', 1),
                ('honda-civic', 1983, 1987, '1.3',       '1.3L I4 65hp',                        0, '1342cc', 1),
                ('honda-civic', 1987, 1991, '1.4',       '1.4L I4 90hp',                        0, '1396cc', 1),
                ('honda-civic', 1987, 1991, '1.6VTEC',   '1.6L I4 VTEC 160hp',                  0, '1595cc', 1),
                ('honda-civic', 1991, 1995, '1.3',       '1.3L I4 75hp',                        0, '1343cc', 1),
                ('honda-civic', 1991, 1995, '1.6VTEC',   '1.6L I4 VTEC 125hp',                  0, '1595cc', 1),
                ('honda-civic', 1995, 2000, '1.4',       '1.4L I4 90hp',                        0, '1396cc', 1),
                ('honda-civic', 1995, 2000, '1.6VTEC',   '1.6L I4 VTEC 160hp',                  0, '1595cc', 1),
                ('honda-civic', 2000, 2005, '1.4',       '1.4L I4 90hp',                        0, '1396cc', 1),
                ('honda-civic', 2000, 2005, '1.6',       '1.6L I4 110hp',                       0, '1595cc', 1),
                ('honda-civic', 2001, 2006, '2.0TypeR',  '2.0L I4 VTEC Type-R EP3 200hp',       0, '1998cc', 1),
                ('honda-civic', 2005, 2011, '1.4',       '1.4L I4 83hp',                        0, '1339cc', 1),
                ('honda-civic', 2005, 2011, '1.8',       '1.8L I4 140hp',                       0, '1799cc', 1),
                ('honda-civic', 2005, 2011, '2.2CTDi',   '2.2L I4 CTDi Diesel 140hp',           1, '2204cc', 1),
                ('honda-civic', 2006, 2011, '2.0TypeR',  '2.0L I4 VTEC Type-R FN2 201hp',       0, '1998cc', 1),
                ('honda-civic', 2011, 2016, '1.4',       '1.4L I4 100hp',                       0, '1339cc', 1),
                ('honda-civic', 2011, 2016, '1.8',       '1.8L I4 142hp',                       0, '1798cc', 1),
                ('honda-civic', 2011, 2016, '1.6iDTEC',  '1.6L I4 iDTEC Diesel 120hp',          1, '1597cc', 1),
                ('honda-civic', 2015, 2021, '1.0T',      '1.0L I3 Turbo VTEC 129hp',            0, '988cc',  1),
                ('honda-civic', 2015, 2021, '1.5T',      '1.5L I4 Turbo VTEC 182hp',            0, '1496cc', 1),
                ('honda-civic', 2017, 2021, '2.0TypeR',  '2.0L I4 Turbo Type-R FK8 320hp',      0, '1996cc', 1),
                ('honda-civic', 2021, 2026, '1.5T',      '1.5L I4 Turbo VTEC 158hp',            0, '1498cc', 1),
                ('honda-civic', 2021, 2026, 'eHV',       '2.0L I4 e:HEV Hybrid 184hp',          2, '1993cc', 1),
                ('honda-civic', 2023, 2026, '2.0TypeR',  '2.0L I4 Turbo Type-R FL5 329hp',      0, '1996cc', 1),

                -- ==============================================================
                -- TESLA MODEL 3  (slug: tesla-model-3)
                -- ==============================================================
                ('tesla-model-3', 2017, 2020, 'SR+',    'Standard Range+ RWD 263hp',            3, NULL, 1),
                ('tesla-model-3', 2017, 2020, 'LR',     'Long Range AWD 351hp',                 3, NULL, 1),
                ('tesla-model-3', 2017, 2020, 'Perf',   'Performance AWD 450hp',                3, NULL, 1),
                ('tesla-model-3', 2021, 2023, 'SR+',    'Standard Range+ RWD 283hp',            3, NULL, 1),
                ('tesla-model-3', 2021, 2023, 'LR',     'Long Range AWD 358hp',                 3, NULL, 1),
                ('tesla-model-3', 2021, 2023, 'Perf',   'Performance AWD 480hp',                3, NULL, 1),
                ('tesla-model-3', 2024, 2026, 'RWD',    'Highland RWD 272hp',                   3, NULL, 1),
                ('tesla-model-3', 2024, 2026, 'LR',     'Highland Long Range AWD 341hp',        3, NULL, 1),
                ('tesla-model-3', 2024, 2026, 'Perf',   'Highland Performance AWD 460hp',       3, NULL, 1),

                -- ==============================================================
                -- PORSCHE 911  (slug: porsche-911)
                -- ==============================================================
                ('porsche-911', 1963, 1969, '2.0',     '2.0L H6 901 130hp',                     0, '1991cc', 1),
                ('porsche-911', 1969, 1972, '2.2',     '2.2L H6 911S 180hp',                    0, '2195cc', 1),
                ('porsche-911', 1972, 1974, '2.4',     '2.4L H6 911S 190hp',                    0, '2341cc', 1),
                ('porsche-911', 1974, 1977, '2.7RS',   '2.7L H6 Carrera RS 210hp',              0, '2687cc', 1),
                ('porsche-911', 1978, 1983, '3.0SC',   '3.0L H6 SC 188hp',                      0, '2994cc', 1),
                ('porsche-911', 1984, 1989, '3.2',     '3.2L H6 Carrera 231hp',                 0, '3164cc', 1),
                ('porsche-911', 1989, 1994, '3.6',     '3.6L H6 964 250hp',                     0, '3600cc', 1),
                ('porsche-911', 1993, 1994, '3.6T',    '3.6L H6 Turbo 964 360hp',               0, '3600cc', 1),
                ('porsche-911', 1993, 1998, '3.6',     '3.6L H6 993 272hp',                     0, '3600cc', 1),
                ('porsche-911', 1995, 1998, '3.6T',    '3.6L H6 Turbo 993 408hp',               0, '3600cc', 1),
                ('porsche-911', 1998, 2004, '3.4',     '3.4L H6 996 300hp',                     0, '3387cc', 1),
                ('porsche-911', 2000, 2005, '3.6T',    '3.6L H6 Turbo 996 420hp',               0, '3600cc', 1),
                ('porsche-911', 2004, 2008, '3.6',     '3.6L H6 997 325hp',                     0, '3596cc', 1),
                ('porsche-911', 2006, 2012, '3.8S',    '3.8L H6 997S 385hp',                    0, '3824cc', 1),
                ('porsche-911', 2009, 2012, '3.8T',    '3.8L H6 Turbo 997 500hp',               0, '3800cc', 1),
                ('porsche-911', 2011, 2019, '3.4',     '3.4L H6 991 350hp',                     0, '3436cc', 1),
                ('porsche-911', 2015, 2019, '3.0T',    '3.0L H6 Turbo 991.2 370hp',             0, '2981cc', 1),
                ('porsche-911', 2015, 2019, '3.0TT',   '3.0L H6 Turbo S 991.2 580hp',           0, '2981cc', 1),
                ('porsche-911', 2019, 2024, '3.0T',    '3.0L H6 Turbo 992 385hp',               0, '2981cc', 1),
                ('porsche-911', 2019, 2024, '3.8TT',   '3.8L H6 Turbo S 992 650hp',             0, '3745cc', 1),
                ('porsche-911', 2024, 2026, '3.6HV',   '3.6L H6 T-Hybrid 992.2 541hp',          2, '3585cc', 1),

                -- ==============================================================
                -- VOLVO XC60  (slug: volvo-xc60)
                -- ==============================================================
                ('volvo-xc60', 2008, 2012, '2.4D',     '2.4L I5 D5 185hp',                      1, '2400cc', 1),
                ('volvo-xc60', 2008, 2012, '3.0T',     '3.0L I6 Turbo T6 304hp',                0, '2953cc', 1),
                ('volvo-xc60', 2010, 2012, '2.0T',     '2.0L I4 Turbo T5 AWD 240hp',            0, '1984cc', 1),
                ('volvo-xc60', 2013, 2017, '2.0D',     '2.0L I4 D4 181hp',                      1, '1969cc', 1),
                ('volvo-xc60', 2013, 2017, '2.4D',     '2.4L I5 D5 215hp',                      1, '2400cc', 1),
                ('volvo-xc60', 2013, 2017, '2.0T',     '2.0L I4 T5 245hp',                      0, '1969cc', 1),
                ('volvo-xc60', 2013, 2017, '2.0TT',    '2.0L I4 T6 320hp',                      0, '1969cc', 1),
                ('volvo-xc60', 2017, 2021, 'B4D',      '2.0L I4 B4 Diesel 197hp',               1, '1969cc', 1),
                ('volvo-xc60', 2017, 2021, 'B5D',      '2.0L I4 B5 Diesel 235hp',               1, '1969cc', 1),
                ('volvo-xc60', 2017, 2021, 'B4P',      '2.0L I4 B4 Petrol 197hp',               0, '1969cc', 1),
                ('volvo-xc60', 2017, 2021, 'B5P',      '2.0L I4 B5 Petrol 254hp',               0, '1969cc', 1),
                ('volvo-xc60', 2017, 2021, 'B6P',      '2.0L I4 B6 Petrol AWD 300hp',           0, '1969cc', 1),
                ('volvo-xc60', 2017, 2021, 'T8PHEV',   '2.0L I4 T8 PHEV 390hp',                 2, '1969cc', 1),
                ('volvo-xc60', 2022, 2026, 'B4D',      '2.0L I4 B4 Diesel 197hp',               1, '1969cc', 1),
                ('volvo-xc60', 2022, 2026, 'B5P',      '2.0L I4 B5 Petrol 250hp',               0, '1969cc', 1),
                ('volvo-xc60', 2022, 2026, 'B6P',      '2.0L I4 B6 Petrol AWD 300hp',           0, '1969cc', 1),
                ('volvo-xc60', 2022, 2026, 'Recharge',  '2.0L I4 PHEV Recharge T8 462hp',       2, '1969cc', 1),

                -- ==============================================================
                -- HYUNDAI TUCSON  (slug: hyundai-tucson)
                -- ==============================================================
                ('hyundai-tucson', 2004, 2009, '2.0',       '2.0L I4 141hp',                    0, '1975cc', 1),
                ('hyundai-tucson', 2004, 2009, '2.7V6',     '2.7L V6 173hp',                    0, '2656cc', 1),
                ('hyundai-tucson', 2004, 2009, '2.0CRDi',   '2.0L I4 CRDi 140hp',               1, '1991cc', 1),
                ('hyundai-tucson', 2009, 2015, '1.6GDi',    '1.6L I4 GDi 135hp',                0, '1591cc', 1),
                ('hyundai-tucson', 2009, 2015, '2.0',       '2.0L I4 165hp',                    0, '1999cc', 1),
                ('hyundai-tucson', 2009, 2015, '1.7CRDi',   '1.7L I4 CRDi 116hp',               1, '1685cc', 1),
                ('hyundai-tucson', 2009, 2015, '2.0CRDi',   '2.0L I4 CRDi 136hp',               1, '1991cc', 1),
                ('hyundai-tucson', 2015, 2020, '1.6TGDi',   '1.6L I4 T-GDi 177hp',              0, '1591cc', 1),
                ('hyundai-tucson', 2015, 2020, '2.0',       '2.0L I4 155hp',                    0, '1999cc', 1),
                ('hyundai-tucson', 2015, 2020, '1.7CRDi',   '1.7L I4 CRDi 141hp',               1, '1685cc', 1),
                ('hyundai-tucson', 2015, 2020, '2.0CRDi',   '2.0L I4 CRDi 185hp',               1, '1995cc', 1),
                ('hyundai-tucson', 2020, 2026, '1.6TGDi',   '1.6L I4 T-GDi 150hp',              0, '1598cc', 1),
                ('hyundai-tucson', 2020, 2026, '1.6HEV',    '1.6L I4 HEV 230hp',                2, '1598cc', 1),
                ('hyundai-tucson', 2020, 2026, '1.6PHEV',   '1.6L I4 PHEV 265hp',               2, '1598cc', 1),
                ('hyundai-tucson', 2020, 2026, '2.0CRDi',   '2.0L I4 CRDi 186hp',               1, '1999cc', 1),

                -- ==============================================================
                -- KIA SPORTAGE  (slug: kia-sportage)
                -- ==============================================================
                ('kia-sportage', 1993, 2002, '2.0',       '2.0L I4 95hp',                       0, '1998cc', 1),
                ('kia-sportage', 1993, 2002, '2.0D',      '2.0L I4 Diesel 61hp',                1, '1998cc', 1),
                ('kia-sportage', 2004, 2010, '2.0',       '2.0L I4 141hp',                      0, '1975cc', 1),
                ('kia-sportage', 2004, 2010, '2.7V6',     '2.7L V6 175hp',                      0, '2656cc', 1),
                ('kia-sportage', 2004, 2010, '2.0CRDi',   '2.0L I4 CRDi 140hp',                 1, '1991cc', 1),
                ('kia-sportage', 2010, 2015, '1.6GDi',    '1.6L I4 GDi 135hp',                  0, '1591cc', 1),
                ('kia-sportage', 2010, 2015, '2.0',       '2.0L I4 163hp',                      0, '1999cc', 1),
                ('kia-sportage', 2010, 2015, '1.7CRDi',   '1.7L I4 CRDi 115hp',                 1, '1685cc', 1),
                ('kia-sportage', 2010, 2015, '2.0CRDi',   '2.0L I4 CRDi 136hp',                 1, '1991cc', 1),
                ('kia-sportage', 2015, 2021, '1.6TGDi',   '1.6L I4 T-GDi 177hp',                0, '1591cc', 1),
                ('kia-sportage', 2015, 2021, '2.0',       '2.0L I4 155hp',                      0, '1999cc', 1),
                ('kia-sportage', 2015, 2021, '1.6CRDi',   '1.6L I4 CRDi 136hp',                 1, '1598cc', 1),
                ('kia-sportage', 2015, 2021, '2.0CRDi',   '2.0L I4 CRDi 185hp',                 1, '1999cc', 1),
                ('kia-sportage', 2021, 2026, '1.6TGDi',   '1.6L I4 T-GDi 150hp',                0, '1598cc', 1),
                ('kia-sportage', 2021, 2026, '1.6HEV',    '1.6L I4 HEV 230hp',                  2, '1598cc', 1),
                ('kia-sportage', 2021, 2026, '1.6PHEV',   '1.6L I4 PHEV 265hp',                 2, '1598cc', 1),
                ('kia-sportage', 2021, 2026, '2.0CRDi',   '2.0L I4 CRDi 186hp',                 1, '1999cc', 1),

                -- ==============================================================
                -- MAZDA MX-5  (slug: mazda-mx5)
                -- ==============================================================
                ('mazda-mx5', 1989, 1998, '1.6NA',   '1.6L I4 NA 116hp',                        0, '1597cc', 1),
                ('mazda-mx5', 1994, 1998, '1.8NA',   '1.8L I4 NA 131hp',                        0, '1839cc', 1),
                ('mazda-mx5', 1998, 2005, '1.6NB',   '1.6L I4 NB 110hp',                        0, '1597cc', 1),
                ('mazda-mx5', 1998, 2005, '1.8NB',   '1.8L I4 NB 146hp',                        0, '1839cc', 1),
                ('mazda-mx5', 2005, 2015, '2.0NC',   '2.0L I4 NC 160hp',                        0, '1999cc', 1),
                ('mazda-mx5', 2015, 2023, '1.5ND',   '1.5L I4 ND 131hp',                        0, '1496cc', 1),
                ('mazda-mx5', 2015, 2023, '2.0ND',   '2.0L I4 ND 184hp',                        0, '1998cc', 1),
                ('mazda-mx5', 2024, 2026, '1.5ND',   '1.5L I4 ND 132hp',                        0, '1496cc', 1),
                ('mazda-mx5', 2024, 2026, '2.0ND',   '2.0L I4 ND 190hp',                        0, '1998cc', 1),

                -- ==============================================================
                -- SUBARU WRX  (slug: subaru-wrx)
                -- ==============================================================
                ('subaru-wrx', 1992, 1996, '2.0T',     '2.0L H4 Turbo GC WRX 220hp',            0, '1994cc', 1),
                ('subaru-wrx', 1994, 2000, '2.0TS',    '2.0L H4 Turbo STi 280hp',               0, '1994cc', 1),
                ('subaru-wrx', 2000, 2007, '2.0TWrx',  '2.0L H4 Turbo GD WRX 227hp',            0, '1994cc', 1),
                ('subaru-wrx', 2003, 2007, '2.0TS',    '2.0L H4 Turbo STi GD 265hp',            0, '1994cc', 1),
                ('subaru-wrx', 2007, 2014, '2.5TWrx',  '2.5L H4 Turbo WRX 265hp',               0, '2457cc', 1),
                ('subaru-wrx', 2007, 2014, '2.5TS',    '2.5L H4 Turbo STi 305hp',               0, '2457cc', 1),
                ('subaru-wrx', 2014, 2021, '2.0TDit',  '2.0L H4 DIT WRX 268hp',                 0, '1998cc', 1),
                ('subaru-wrx', 2014, 2021, '2.5TS',    '2.5L H4 Turbo STi 305hp',               0, '2457cc', 1),
                ('subaru-wrx', 2021, 2026, '2.4T',     '2.4L H4 Turbo WRX 271hp',               0, '2387cc', 1),
                ('subaru-wrx', 2021, 2026, '2.4TS',    '2.4L H4 Turbo WRX STi 350hp',           0, '2387cc', 1),

                -- ==============================================================
                -- BUICK ENCLAVE  (slug: buick-enclave)
                -- ==============================================================
                ('buick-enclave', 2008, 2017, '3.6V6',   '3.6L V6 288hp',                        0, '3564cc', 1),
                ('buick-enclave', 2018, 2026, '3.6V6',   '3.6L V6 310hp',                        0, '3564cc', 1),
                ('buick-enclave', 2018, 2026, '2.0T',    '2.0L I4 Turbo 230hp',                  0, '1998cc', 1),

                -- ==============================================================
                -- BUICK ENCORE  (slug: buick-encore)
                -- ==============================================================
                ('buick-encore', 2013, 2022, '1.4T',    '1.4L I4 Turbo 138hp',                   0, '1364cc', 1),
                ('buick-encore', 2020, 2026, '1.2T',    '1.2L I3 Turbo 137hp',                   0, '1199cc', 1),
                ('buick-encore', 2020, 2026, '1.3T',    '1.3L I3 Turbo 155hp',                   0, '1308cc', 1),

                -- ==============================================================
                -- BUICK ENCORE GX  (slug: buick-encore-gx)
                -- ==============================================================
                ('buick-encore-gx', 2020, 2026, '1.2T',  '1.2L I3 Turbo 137hp',                 0, '1199cc', 1),
                ('buick-encore-gx', 2020, 2026, '1.3T',  '1.3L I3 Turbo 155hp',                 0, '1308cc', 1),

                -- ==============================================================
                -- BUICK ENVISION  (slug: buick-envision)
                -- ==============================================================
                ('buick-envision', 2016, 2020, '2.0T',   '2.0L I4 Turbo 252hp',                  0, '1998cc', 1),
                ('buick-envision', 2021, 2026, '2.0T',   '2.0L I4 Turbo 228hp',                  0, '1998cc', 1),

                -- ==============================================================
                -- BUICK LACROSSE  (slug: buick-lacrosse)
                -- ==============================================================
                ('buick-lacrosse', 2005, 2009, '3.8V6',  '3.8L V6 200hp',                        0, '3791cc', 1),
                ('buick-lacrosse', 2010, 2016, '2.4',    '2.4L I4 182hp',                        0, '2384cc', 1),
                ('buick-lacrosse', 2010, 2016, '3.6V6',  '3.6L V6 304hp',                        0, '3564cc', 1),
                ('buick-lacrosse', 2017, 2019, '2.5HV',  '2.5L I4 Hybrid eAssist 194hp',         2, '2457cc', 1),
                ('buick-lacrosse', 2017, 2019, '3.6V6',  '3.6L V6 310hp',                        0, '3564cc', 1),

                -- ==============================================================
                -- BUICK REGAL  (slug: buick-regal)
                -- ==============================================================
                ('buick-regal', 1973, 1987, '3.8V6',    '3.8L V6 165hp',                         0, '3791cc', 1),
                ('buick-regal', 1988, 1996, '3.8V6',    '3.8L V6 170hp',                         0, '3791cc', 1),
                ('buick-regal', 1997, 2004, '3.8V6',    '3.8L V6 197hp',                         0, '3791cc', 1),
                ('buick-regal', 2011, 2017, '2.0T',     '2.0L I4 Turbo 259hp',                   0, '1998cc', 1),
                ('buick-regal', 2018, 2020, '2.0T',     '2.0L I4 Turbo 250hp',                   0, '1998cc', 1),
                ('buick-regal', 2018, 2020, '2.0THV',   '2.0L I4 Turbo eAssist Hybrid 259hp',    2, '1998cc', 1),

                -- ==============================================================
                -- BUICK CENTURY  (slug: buick-century)
                -- ==============================================================
                ('buick-century', 1954, 1981, '3.8V6',  '3.8L V6 110hp',                         0, '3791cc', 1),
                ('buick-century', 1982, 1996, '2.5',    '2.5L I4 110hp',                         0, '2474cc', 1),
                ('buick-century', 1982, 1996, '3.3V6',  '3.3L V6 160hp',                         0, '3294cc', 1),
                ('buick-century', 1997, 2005, '3.1V6',  '3.1L V6 175hp',                         0, '3136cc', 1),

                -- ==============================================================
                -- GMC SIERRA 1500  (slug: gmc-sierra-1500)
                -- ==============================================================
                ('gmc-sierra-1500', 1999, 2006, '4.3V6',  '4.3L V6 200hp',                       0, '4293cc', 1),
                ('gmc-sierra-1500', 1999, 2006, '4.8V8',  '4.8L V8 275hp',                       0, '4807cc', 1),
                ('gmc-sierra-1500', 1999, 2006, '5.3V8',  '5.3L V8 285hp',                       0, '5328cc', 1),
                ('gmc-sierra-1500', 1999, 2006, '6.0V8',  '6.0L V8 300hp',                       0, '5967cc', 1),
                ('gmc-sierra-1500', 2007, 2013, '4.3V6',  '4.3L V6 195hp',                       0, '4293cc', 1),
                ('gmc-sierra-1500', 2007, 2013, '5.3V8',  '5.3L V8 315hp',                       0, '5328cc', 1),
                ('gmc-sierra-1500', 2007, 2013, '6.2V8',  '6.2L V8 403hp',                       0, '6162cc', 1),
                ('gmc-sierra-1500', 2014, 2018, '4.3V6',  '4.3L V6 285hp',                       0, '4293cc', 1),
                ('gmc-sierra-1500', 2014, 2018, '5.3V8',  '5.3L V8 355hp',                       0, '5328cc', 1),
                ('gmc-sierra-1500', 2014, 2018, '6.2V8',  '6.2L V8 420hp',                       0, '6162cc', 1),
                ('gmc-sierra-1500', 2019, 2026, '2.7T',   '2.7L I4 Turbo 310hp',                 0, '2686cc', 1),
                ('gmc-sierra-1500', 2019, 2026, '5.3V8',  '5.3L V8 355hp',                       0, '5328cc', 1),
                ('gmc-sierra-1500', 2019, 2026, '6.2V8',  '6.2L V8 420hp',                       0, '6162cc', 1),
                ('gmc-sierra-1500', 2021, 2026, '3.0D',   '3.0L I6 Duramax Diesel 277hp',        1, '2996cc', 1),

                -- ==============================================================
                -- GMC YUKON  (slug: gmc-yukon)
                -- ==============================================================
                ('gmc-yukon', 1992, 1999, '5.7V8',  '5.7L V8 255hp',                             0, '5737cc', 1),
                ('gmc-yukon', 2000, 2006, '4.8V8',  '4.8L V8 275hp',                             0, '4807cc', 1),
                ('gmc-yukon', 2000, 2006, '5.3V8',  '5.3L V8 285hp',                             0, '5328cc', 1),
                ('gmc-yukon', 2007, 2014, '5.3V8',  '5.3L V8 320hp',                             0, '5328cc', 1),
                ('gmc-yukon', 2015, 2020, '5.3V8',  '5.3L V8 355hp',                             0, '5328cc', 1),
                ('gmc-yukon', 2015, 2020, '6.2V8',  '6.2L V8 420hp',                             0, '6162cc', 1),
                ('gmc-yukon', 2021, 2026, '5.3V8',  '5.3L V8 355hp',                             0, '5328cc', 1),
                ('gmc-yukon', 2021, 2026, '6.2V8',  '6.2L V8 420hp',                             0, '6162cc', 1),
                ('gmc-yukon', 2021, 2026, '3.0D',   '3.0L I6 Duramax Diesel 277hp',              1, '2996cc', 1),

                -- ==============================================================
                -- GMC TERRAIN  (slug: gmc-terrain)
                -- ==============================================================
                ('gmc-terrain', 2010, 2017, '2.4',    '2.4L I4 182hp',                           0, '2384cc', 1),
                ('gmc-terrain', 2010, 2017, '3.0V6',  '3.0L V6 264hp',                           0, '2953cc', 1),
                ('gmc-terrain', 2018, 2026, '1.5T',   '1.5L I4 Turbo 170hp',                     0, '1490cc', 1),
                ('gmc-terrain', 2018, 2026, '2.0T',   '2.0L I4 Turbo 252hp',                     0, '1998cc', 1),
                ('gmc-terrain', 2018, 2026, '1.6D',   '1.6L I4 Diesel 137hp',                    1, '1598cc', 1),

                -- ==============================================================
                -- GMC CANYON  (slug: gmc-canyon)
                -- ==============================================================
                ('gmc-canyon', 2004, 2012, '2.8',    '2.8L I4 175hp',                            0, '2770cc', 1),
                ('gmc-canyon', 2004, 2012, '3.5V5',  '3.5L I5 220hp',                            0, '3460cc', 1),
                ('gmc-canyon', 2015, 2022, '2.5',    '2.5L I4 200hp',                            0, '2457cc', 1),
                ('gmc-canyon', 2015, 2022, '3.6V6',  '3.6L V6 308hp',                            0, '3564cc', 1),
                ('gmc-canyon', 2015, 2022, '2.8D',   '2.8L I4 Duramax Diesel 181hp',             1, '2776cc', 1),
                ('gmc-canyon', 2023, 2026, '2.7T',   '2.7L I4 Turbo 310hp',                      0, '2686cc', 1),

                -- ==============================================================
                -- PONTIAC FIREBIRD / TRANS AM  (slug: pontiac-firebird / pontiac-trans-am)
                -- ==============================================================
                ('pontiac-firebird', 1967, 1969, '5.7V8',  '5.7L V8 400 CID 325hp',              0, '5737cc', 1),
                ('pontiac-firebird', 1970, 1981, '6.6V8',  '6.6L V8 400 CID 300hp',              0, '6604cc', 1),
                ('pontiac-firebird', 1982, 1992, '5.0V8',  '5.0L V8 HO 165hp',                   0, '4999cc', 1),
                ('pontiac-firebird', 1993, 2002, '3.8V6',  '3.8L V6 200hp',                      0, '3791cc', 1),
                ('pontiac-firebird', 1993, 2002, '5.7V8',  '5.7L V8 LT1 275hp',                  0, '5737cc', 1),
                ('pontiac-trans-am', 1969, 1981, '6.6V8',  '6.6L V8 SD-455 310hp',               0, '6604cc', 1),
                ('pontiac-trans-am', 1982, 1992, '5.0V8',  '5.0L V8 TPI 205hp',                  0, '4999cc', 1),
                ('pontiac-trans-am', 1993, 2002, '5.7V8',  '5.7L V8 LS1 305hp',                  0, '5737cc', 1),

                -- ==============================================================
                -- PONTIAC GTO  (slug: pontiac-gto)
                -- ==============================================================
                ('pontiac-gto', 1964, 1967, '6.4V8',  '6.4L V8 389 CID 360hp',                   0, '6376cc', 1),
                ('pontiac-gto', 1968, 1971, '6.6V8',  '6.6L V8 400 CID 366hp',                   0, '6604cc', 1),
                ('pontiac-gto', 2004, 2006, '5.7V8',  '5.7L V8 LS1 350hp',                       0, '5665cc', 1),
                ('pontiac-gto', 2004, 2006, '6.0V8',  '6.0L V8 LS2 400hp',                       0, '5967cc', 1),

                -- ==============================================================
                -- PONTIAC GRAND PRIX  (slug: pontiac-grand-prix)
                -- ==============================================================
                ('pontiac-grand-prix', 1962, 1987, '6.6V8',  '6.6L V8 400 CID 265hp',            0, '6604cc', 1),
                ('pontiac-grand-prix', 1988, 1996, '3.4V6',  '3.4L V6 210hp',                    0, '3350cc', 1),
                ('pontiac-grand-prix', 1997, 2003, '3.8V6',  '3.8L V6 200hp',                    0, '3791cc', 1),
                ('pontiac-grand-prix', 1997, 2003, '3.8SCV6','3.8L V6 SC 240hp',                  0, '3791cc', 1),
                ('pontiac-grand-prix', 2004, 2008, '3.8V6',  '3.8L V6 200hp',                    0, '3791cc', 1),
                ('pontiac-grand-prix', 2004, 2008, '5.3V8',  '5.3L V8 GXP 303hp',                0, '5328cc', 1),

                -- ==============================================================
                -- CHRYSLER 300  (slug: chrysler-300)
                -- ==============================================================
                ('chrysler-300', 2005, 2010, '2.7V6',  '2.7L V6 190hp',                          0, '2736cc', 1),
                ('chrysler-300', 2005, 2010, '3.5V6',  '3.5L V6 250hp',                          0, '3518cc', 1),
                ('chrysler-300', 2005, 2010, '5.7V8',  '5.7L V8 HEMI 340hp',                     0, '5654cc', 1),
                ('chrysler-300', 2005, 2010, '6.1V8',  '6.1L V8 SRT8 425hp',                     0, '6059cc', 1),
                ('chrysler-300', 2011, 2023, '3.6V6',  '3.6L V6 Pentastar 292hp',                0, '3604cc', 1),
                ('chrysler-300', 2011, 2023, '5.7V8',  '5.7L V8 HEMI 363hp',                     0, '5654cc', 1),
                ('chrysler-300', 2012, 2023, '6.4V8',  '6.4L V8 SRT8 470hp',                     0, '6417cc', 1),
                ('chrysler-300', 2023, 2026, '3.6V6',  '3.6L V6 Pentastar 300hp',                0, '3604cc', 1),

                -- ==============================================================
                -- CHRYSLER PACIFICA  (slug: chrysler-pacifica)
                -- ==============================================================
                ('chrysler-pacifica', 2017, 2026, '3.6V6',   '3.6L V6 Pentastar 287hp',          0, '3604cc', 1),
                ('chrysler-pacifica', 2017, 2026, '3.6PHEV',  '3.6L V6 PHEV 260hp',              2, '3604cc', 1),

                -- ==============================================================
                -- CHRYSLER SEBRING  (slug: chrysler-sebring)
                -- ==============================================================
                ('chrysler-sebring', 1995, 2000, '2.0',    '2.0L I4 132hp',                      0, '1996cc', 1),
                ('chrysler-sebring', 1995, 2000, '2.5V6',  '2.5L V6 163hp',                      0, '2497cc', 1),
                ('chrysler-sebring', 2001, 2006, '2.4',    '2.4L I4 150hp',                      0, '2360cc', 1),
                ('chrysler-sebring', 2001, 2006, '2.7V6',  '2.7L V6 200hp',                      0, '2736cc', 1),
                ('chrysler-sebring', 2007, 2010, '2.4',    '2.4L I4 173hp',                      0, '2360cc', 1),
                ('chrysler-sebring', 2007, 2010, '2.7V6',  '2.7L V6 189hp',                      0, '2736cc', 1),
                ('chrysler-sebring', 2007, 2010, '3.5V6',  '3.5L V6 235hp',                      0, '3518cc', 1),

                -- ==============================================================
                -- RAM 1500  (slug: ram-1500)
                -- ==============================================================
                ('ram-1500', 2010, 2018, '3.6V6',  '3.6L V6 Pentastar 305hp',                    0, '3604cc', 1),
                ('ram-1500', 2010, 2018, '5.7V8',  '5.7L V8 HEMI 395hp',                         0, '5654cc', 1),
                ('ram-1500', 2014, 2018, '3.0D',   '3.0L V6 EcoDiesel 240hp',                    1, '2987cc', 1),
                ('ram-1500', 2019, 2026, '3.6V6',  '3.6L V6 Pentastar 305hp',                    0, '3604cc', 1),
                ('ram-1500', 2019, 2026, '5.7V8',  '5.7L V8 HEMI 395hp',                         0, '5654cc', 1),
                ('ram-1500', 2019, 2026, '5.7ETORQ','5.7L V8 HEMI eTorque MHEV 395hp',           2, '5654cc', 1),
                ('ram-1500', 2020, 2026, '3.0D',   '3.0L V6 EcoDiesel 260hp',                    1, '2987cc', 1),
                ('ram-1500', 2024, 2026, 'REV',    'Dual Motor Electric REV 654hp',               3, NULL,     1),

                -- ==============================================================
                -- RAM 2500  (slug: ram-2500)
                -- ==============================================================
                ('ram-2500', 2010, 2018, '5.7V8',  '5.7L V8 HEMI 383hp',                         0, '5654cc', 1),
                ('ram-2500', 2010, 2018, '6.4V8',  '6.4L V8 HEMI 410hp',                         0, '6417cc', 1),
                ('ram-2500', 2010, 2018, '6.7D',   '6.7L I6 Cummins Diesel 370hp',               1, '6690cc', 1),
                ('ram-2500', 2019, 2026, '6.4V8',  '6.4L V8 HEMI 410hp',                         0, '6417cc', 1),
                ('ram-2500', 2019, 2026, '6.7D',   '6.7L I6 Cummins Diesel 400hp',               1, '6690cc', 1),

                -- ==============================================================
                -- SAAB 9-3  (slug: saab-9-3)
                -- ==============================================================
                ('saab-9-3', 1998, 2002, '2.0T',   '2.0L I4 Turbo 150hp',                        0, '1985cc', 1),
                ('saab-9-3', 1998, 2002, '2.0HOT',  '2.0L I4 Turbo HOT 200hp',                   0, '1985cc', 1),
                ('saab-9-3', 2003, 2007, '1.8T',   '1.8L I4 Turbo 150hp',                        0, '1796cc', 1),
                ('saab-9-3', 2003, 2007, '2.0T',   '2.0L I4 Turbo 175hp',                        0, '1998cc', 1),
                ('saab-9-3', 2003, 2007, '2.8TV6',  '2.8L V6 Turbo Aero 250hp',                  0, '2792cc', 1),
                ('saab-9-3', 2003, 2007, '1.9TDI',  '1.9L I4 TDI 120hp',                         1, '1910cc', 1),
                ('saab-9-3', 2008, 2012, '1.8T',   '1.8L I4 Turbo 150hp',                        0, '1796cc', 1),
                ('saab-9-3', 2008, 2012, '2.0T',   '2.0L I4 Turbo 210hp',                        0, '1998cc', 1),
                ('saab-9-3', 2008, 2012, '2.8TV6',  '2.8L V6 Turbo Aero 280hp',                  0, '2792cc', 1),
                ('saab-9-3', 2008, 2012, '1.9TDI',  '1.9L I4 TDI 150hp',                         1, '1910cc', 1),

                -- ==============================================================
                -- SAAB 9-5  (slug: saab-9-5)
                -- ==============================================================
                ('saab-9-5', 1997, 2005, '2.0T',   '2.0L I4 Turbo 150hp',                        0, '1985cc', 1),
                ('saab-9-5', 1997, 2005, '2.3T',   '2.3L I4 Turbo Aero 230hp',                   0, '2290cc', 1),
                ('saab-9-5', 1997, 2005, '3.0V6T',  '3.0L V6 Turbo 200hp',                       0, '2962cc', 1),
                ('saab-9-5', 2006, 2010, '2.3T',   '2.3L I4 Turbo 260hp',                        0, '2290cc', 1),
                ('saab-9-5', 2006, 2010, '2.8TV6',  '2.8L V6 Turbo Aero 260hp',                  0, '2792cc', 1),
                ('saab-9-5', 2006, 2010, '1.9TDI',  '1.9L I4 TDI 150hp',                         1, '1910cc', 1),
                ('saab-9-5', 2010, 2012, '2.0T',   '2.0L I4 Turbo 220hp',                        0, '1998cc', 1),
                ('saab-9-5', 2010, 2012, '2.8TV6',  '2.8L V6 Turbo 300hp',                       0, '2792cc', 1),

                -- ==============================================================
                -- SAAB 900  (slug: saab-900)
                -- ==============================================================
                ('saab-900', 1978, 1994, '2.0T',   '2.0L I4 Turbo 145hp',                        0, '1985cc', 1),
                ('saab-900', 1978, 1994, '2.0',    '2.0L I4 100hp',                              0, '1985cc', 1),
                ('saab-900', 1994, 1998, '2.0T',   '2.0L I4 Turbo 185hp',                        0, '1985cc', 1),
                ('saab-900', 1994, 1998, '2.3',    '2.3L I4 150hp',                              0, '2290cc', 1),
                ('saab-900', 1994, 1998, '2.5V6',  '2.5L V6 170hp',                              0, '2498cc', 1),

                -- ==============================================================
                -- JAGUAR XF  (slug: jaguar-xf)
                -- ==============================================================
                ('jaguar-xf', 2008, 2015, '2.7D',   '2.7L V6 TDV6 Diesel 207hp',                 1, '2720cc', 1),
                ('jaguar-xf', 2008, 2015, '3.0D',   '3.0L V6 TDV6 Diesel 275hp',                 1, '2993cc', 1),
                ('jaguar-xf', 2008, 2015, '3.0V6',  '3.0L V6 Supercharged 340hp',                0, '2993cc', 1),
                ('jaguar-xf', 2008, 2015, '5.0V8',  '5.0L V8 385hp',                             0, '5000cc', 1),
                ('jaguar-xf', 2008, 2015, '5.0SCV8','5.0L V8 Supercharged XFR 510hp',            0, '5000cc', 1),
                ('jaguar-xf', 2015, 2026, '2.0D',   '2.0L I4 Ingenium Diesel 180hp',             1, '1999cc', 1),
                ('jaguar-xf', 2015, 2026, '3.0D',   '3.0L V6 TDV6 Diesel 300hp',                 1, '2993cc', 1),
                ('jaguar-xf', 2015, 2026, '2.0T',   '2.0L I4 Ingenium Turbo 250hp',              0, '1997cc', 1),
                ('jaguar-xf', 2015, 2026, '3.0SC',  '3.0L V6 Supercharged 380hp',                0, '2995cc', 1),

                -- ==============================================================
                -- JAGUAR F-PACE  (slug: jaguar-f-pace)
                -- ==============================================================
                ('jaguar-f-pace', 2016, 2020, '2.0D',  '2.0L I4 Ingenium Diesel 180hp',          1, '1999cc', 1),
                ('jaguar-f-pace', 2016, 2020, '3.0D',  '3.0L V6 TDV6 Diesel 300hp',              1, '2993cc', 1),
                ('jaguar-f-pace', 2016, 2020, '2.0T',  '2.0L I4 Turbo 250hp',                    0, '1997cc', 1),
                ('jaguar-f-pace', 2016, 2020, '3.0SC', '3.0L V6 SC 380hp',                       0, '2995cc', 1),
                ('jaguar-f-pace', 2021, 2026, '2.0D',  '2.0L I4 Diesel 204hp',                   1, '1999cc', 1),
                ('jaguar-f-pace', 2021, 2026, '2.0T',  '2.0L I4 P250 Turbo 249hp',               0, '1997cc', 1),
                ('jaguar-f-pace', 2021, 2026, '3.0T',  '3.0L I6 P400 Mild Hybrid 400hp',         2, '2995cc', 1),
                ('jaguar-f-pace', 2021, 2026, 'PHEV',  '2.0L I4 PHEV P400e 404hp',               2, '1997cc', 1),

                -- ==============================================================
                -- JAGUAR F-TYPE  (slug: jaguar-f-type)
                -- ==============================================================
                ('jaguar-f-type', 2013, 2019, '3.0V6',  '3.0L V6 SC 340hp',                      0, '2995cc', 1),
                ('jaguar-f-type', 2013, 2019, '3.0SV6',  '3.0L V6 SC S 380hp',                   0, '2995cc', 1),
                ('jaguar-f-type', 2013, 2019, '5.0V8R',  '5.0L V8 SC R 550hp',                   0, '5000cc', 1),
                ('jaguar-f-type', 2020, 2026, '2.0T',   '2.0L I4 Turbo P300 296hp',              0, '1997cc', 1),
                ('jaguar-f-type', 2020, 2026, '5.0V8',  '5.0L V8 SC P450 450hp',                 0, '5000cc', 1),
                ('jaguar-f-type', 2020, 2026, '5.0V8R',  '5.0L V8 SC R 575hp',                   0, '5000cc', 1),

                -- ==============================================================
                -- JAGUAR I-PACE  (slug: jaguar-i-pace)
                -- ==============================================================
                ('jaguar-i-pace', 2018, 2026, 'EV400',  'Dual Motor EV400 400hp',                 3, NULL,     1),

                -- ==============================================================
                -- JAGUAR XJ  (slug: jaguar-xj)
                -- ==============================================================
                ('jaguar-xj', 1968, 1986, '4.2',    '4.2L I6 Series I-III 245hp',                0, '4235cc', 1),
                ('jaguar-xj', 1986, 1994, '3.6',    '3.6L I6 XJ40 221hp',                        0, '3590cc', 1),
                ('jaguar-xj', 1994, 2003, '3.2',    '3.2L I6 X300 231hp',                        0, '3239cc', 1),
                ('jaguar-xj', 1994, 2003, '4.0SC',  '4.0L I6 SC X300 322hp',                     0, '3980cc', 1),
                ('jaguar-xj', 2003, 2009, '3.5V8',  '3.5L V8 X350 258hp',                        0, '3555cc', 1),
                ('jaguar-xj', 2003, 2009, '4.2V8',  '4.2L V8 X350 305hp',                        0, '4196cc', 1),
                ('jaguar-xj', 2009, 2019, '3.0D',   '3.0L V6 Diesel 275hp',                      1, '2993cc', 1),
                ('jaguar-xj', 2009, 2019, '3.0SC',  '3.0L V6 SC 340hp',                          0, '2993cc', 1),
                ('jaguar-xj', 2009, 2019, '5.0V8',  '5.0L V8 385hp',                             0, '5000cc', 1),
                ('jaguar-xj', 2009, 2019, '5.0SCV8','5.0L V8 SC XJR 550hp',                      0, '5000cc', 1),

                -- ==============================================================
                -- MINI HATCH  (slug: mini-hatch)
                -- ==============================================================
                ('mini-hatch', 2001, 2006, '1.6',    '1.6L I4 R50 90hp',                         0, '1598cc', 1),
                ('mini-hatch', 2001, 2006, '1.6SC',  '1.6L I4 SC Cooper S R53 170hp',            0, '1598cc', 1),
                ('mini-hatch', 2006, 2013, '1.6',    '1.6L I4 R56 120hp',                        0, '1598cc', 1),
                ('mini-hatch', 2006, 2013, '1.6T',   '1.6L I4 Turbo Cooper S R56 184hp',         0, '1598cc', 1),
                ('mini-hatch', 2006, 2013, '1.6JCW',  '1.6L I4 JCW R56 211hp',                  0, '1598cc', 1),
                ('mini-hatch', 2006, 2013, '1.6D',   '1.6L I4 Diesel Cooper D 112hp',            1, '1598cc', 1),
                ('mini-hatch', 2014, 2018, '1.2T',   '1.2L I3 Turbo Cooper F56 102hp',           0, '1198cc', 1),
                ('mini-hatch', 2014, 2018, '2.0T',   '2.0L I4 Turbo Cooper S F56 192hp',         0, '1998cc', 1),
                ('mini-hatch', 2014, 2018, '2.0JCW',  '2.0L I4 JCW F56 231hp',                  0, '1998cc', 1),
                ('mini-hatch', 2014, 2018, '1.5D',   '1.5L I3 Diesel Cooper D 116hp',            1, '1496cc', 1),
                ('mini-hatch', 2018, 2026, '1.5T',   '1.5L I3 Turbo Cooper F56 136hp',           0, '1499cc', 1),
                ('mini-hatch', 2018, 2026, '2.0T',   '2.0L I4 Turbo Cooper S F56 178hp',         0, '1998cc', 1),
                ('mini-hatch', 2018, 2026, '2.0JCW',  '2.0L I4 JCW F56 231hp',                  0, '1998cc', 1),
                ('mini-hatch', 2023, 2026, 'EV',     'Electric Cooper SE 184hp',                 3, NULL,     1),

                -- ==============================================================
                -- MINI COUNTRYMAN  (slug: mini-countryman)
                -- ==============================================================
                ('mini-countryman', 2010, 2016, '1.6',    '1.6L I4 R60 122hp',                   0, '1598cc', 1),
                ('mini-countryman', 2010, 2016, '1.6T',   '1.6L I4 Turbo Cooper S R60 184hp',    0, '1598cc', 1),
                ('mini-countryman', 2010, 2016, '2.0D',   '2.0L I4 Diesel Cooper D R60 112hp',   1, '1995cc', 1),
                ('mini-countryman', 2017, 2023, '1.5T',   '1.5L I3 Turbo Cooper F60 136hp',      0, '1499cc', 1),
                ('mini-countryman', 2017, 2023, '2.0T',   '2.0L I4 Turbo Cooper S F60 192hp',    0, '1998cc', 1),
                ('mini-countryman', 2017, 2023, '2.0D',   '2.0L I4 Diesel Cooper SD F60 190hp',  1, '1995cc', 1),
                ('mini-countryman', 2017, 2023, 'PHEV',   '1.5L I3 PHEV Cooper SE F60 224hp',    2, '1499cc', 1),
                ('mini-countryman', 2024, 2026, '1.5T',   '1.5L I3 Turbo C U25 170hp',           0, '1499cc', 1),
                ('mini-countryman', 2024, 2026, '2.0T',   '2.0L I4 Turbo CS U25 204hp',          0, '1998cc', 1),
                ('mini-countryman', 2024, 2026, 'EV',     'Electric SE All4 313hp',               3, NULL,     1),

                -- ==============================================================
                -- SEAT LEON  (slug: seat-leon)
                -- ==============================================================
                ('seat-leon', 1999, 2005, '1.4',    '1.4L I4 Mk1 75hp',                          0, '1390cc', 1),
                ('seat-leon', 1999, 2005, '1.8T',   '1.8L I4 Turbo Mk1 180hp',                   0, '1781cc', 1),
                ('seat-leon', 1999, 2005, '1.9TDI', '1.9L I4 TDI Mk1 110hp',                     1, '1896cc', 1),
                ('seat-leon', 2005, 2012, '1.4TSI', '1.4L I4 TSI Mk2 125hp',                     0, '1390cc', 1),
                ('seat-leon', 2005, 2012, '2.0TFSI', '2.0L I4 TFSI Mk2 200hp',                   0, '1984cc', 1),
                ('seat-leon', 2005, 2012, '2.0TDI', '2.0L I4 TDI Mk2 170hp',                     1, '1968cc', 1),
                ('seat-leon', 2012, 2020, '1.0TSI', '1.0L I3 TSI Mk3 115hp',                     0, '999cc',  1),
                ('seat-leon', 2012, 2020, '1.4TSI', '1.4L I4 TSI Mk3 125hp',                     0, '1395cc', 1),
                ('seat-leon', 2012, 2020, '2.0TFSI', '2.0L I4 TFSI Cupra Mk3 300hp',             0, '1984cc', 1),
                ('seat-leon', 2012, 2020, '2.0TDI', '2.0L I4 TDI Mk3 150hp',                     1, '1968cc', 1),
                ('seat-leon', 2020, 2026, '1.0TSI', '1.0L I3 TSI Mk4 110hp',                     0, '999cc',  1),
                ('seat-leon', 2020, 2026, '1.5TSI', '1.5L I4 TSI Mk4 150hp',                     0, '1498cc', 1),
                ('seat-leon', 2020, 2026, '2.0TSI', '2.0L I4 Cupra Mk4 310hp',                   0, '1984cc', 1),
                ('seat-leon', 2020, 2026, '2.0TDI', '2.0L I4 TDI Mk4 150hp',                     1, '1968cc', 1),
                ('seat-leon', 2020, 2026, 'eHybrid', '1.4L I4 PHEV eHybrid 204hp',               2, '1395cc', 1),

                -- ==============================================================
                -- SEAT IBIZA  (slug: seat-ibiza)
                -- ==============================================================
                ('seat-ibiza', 1984, 1993, '1.2',    '1.2L I4 Mk1 60hp',                         0, '1193cc', 1),
                ('seat-ibiza', 1993, 2002, '1.4',    '1.4L I4 Mk2 60hp',                         0, '1390cc', 1),
                ('seat-ibiza', 1993, 2002, '1.8T',   '1.8L I4 Turbo GTi 156hp',                  0, '1781cc', 1),
                ('seat-ibiza', 2002, 2008, '1.4',    '1.4L I4 Mk3 85hp',                         0, '1390cc', 1),
                ('seat-ibiza', 2002, 2008, '1.9TDI', '1.9L I4 TDI 130hp',                        1, '1896cc', 1),
                ('seat-ibiza', 2008, 2017, '1.2TSI', '1.2L I4 TSI Mk4 105hp',                    0, '1197cc', 1),
                ('seat-ibiza', 2008, 2017, '1.4TSI', '1.4L I4 TSI Mk4 150hp',                    0, '1390cc', 1),
                ('seat-ibiza', 2008, 2017, '1.6TDI', '1.6L I4 TDI Mk4 105hp',                    1, '1598cc', 1),
                ('seat-ibiza', 2017, 2026, '1.0TSI', '1.0L I3 TSI Mk5 95hp',                     0, '999cc',  1),
                ('seat-ibiza', 2017, 2026, '1.5TSI', '1.5L I4 TSI Mk5 150hp',                    0, '1498cc', 1),
                ('seat-ibiza', 2017, 2026, '1.0TDI', '1.0L I3 TDI Mk5 80hp',                     1, '999cc',  1),

                -- ==============================================================
                -- SEAT ATECA  (slug: seat-ateca)
                -- ==============================================================
                ('seat-ateca', 2016, 2026, '1.0TSI', '1.0L I3 TSI 115hp',                        0, '999cc',  1),
                ('seat-ateca', 2016, 2026, '1.5TSI', '1.5L I4 TSI 150hp',                        0, '1498cc', 1),
                ('seat-ateca', 2016, 2026, '2.0TSI', '2.0L I4 TSI 190hp',                        0, '1984cc', 1),
                ('seat-ateca', 2016, 2026, '2.0TDI', '2.0L I4 TDI 150hp',                        1, '1968cc', 1),

                -- ==============================================================
                -- MITSUBISHI OUTLANDER  (slug: mitsubishi-outlander)
                -- ==============================================================
                ('mitsubishi-outlander', 2001, 2006, '2.0',    '2.0L I4 136hp',                   0, '1997cc', 1),
                ('mitsubishi-outlander', 2001, 2006, '2.4',    '2.4L I4 160hp',                   0, '2378cc', 1),
                ('mitsubishi-outlander', 2006, 2012, '2.0',    '2.0L I4 138hp',                   0, '1997cc', 1),
                ('mitsubishi-outlander', 2006, 2012, '2.4',    '2.4L I4 170hp',                   0, '2378cc', 1),
                ('mitsubishi-outlander', 2006, 2012, '3.0V6',  '3.0L V6 220hp',                   0, '2998cc', 1),
                ('mitsubishi-outlander', 2006, 2012, '2.0D',   '2.0L I4 Diesel 140hp',            1, '1968cc', 1),
                ('mitsubishi-outlander', 2012, 2021, '2.0',    '2.0L I4 150hp',                   0, '1998cc', 1),
                ('mitsubishi-outlander', 2012, 2021, '2.4PHEV','2.4L I4 PHEV 224hp',              2, '2359cc', 1),
                ('mitsubishi-outlander', 2012, 2021, '2.2D',   '2.2L I4 Diesel 150hp',            1, '2268cc', 1),
                ('mitsubishi-outlander', 2021, 2026, '2.5',    '2.5L I4 181hp',                   0, '2488cc', 1),
                ('mitsubishi-outlander', 2021, 2026, '2.4PHEV','2.4L I4 PHEV 248hp',              2, '2359cc', 1),

                -- ==============================================================
                -- MITSUBISHI LANCER  (slug: mitsubishi-lancer)
                -- ==============================================================
                ('mitsubishi-lancer', 1973, 1979, '1.4',    '1.4L I4 A70 73hp',                  0, '1410cc', 1),
                ('mitsubishi-lancer', 1988, 1994, '1.5',    '1.5L I4 C70 92hp',                  0, '1468cc', 1),
                ('mitsubishi-lancer', 1995, 2003, '1.5',    '1.5L I4 CS 92hp',                   0, '1468cc', 1),
                ('mitsubishi-lancer', 1995, 2003, '2.0T',   '2.0L I4 Turbo Evo VI 280hp',        0, '1997cc', 1),
                ('mitsubishi-lancer', 2003, 2007, '2.0',    '2.0L I4 CS 136hp',                  0, '1997cc', 1),
                ('mitsubishi-lancer', 2003, 2007, '2.0T',   '2.0L I4 Turbo Evo VIII 280hp',      0, '1997cc', 1),
                ('mitsubishi-lancer', 2007, 2017, '1.5',    '1.5L I4 CY 109hp',                  0, '1499cc', 1),
                ('mitsubishi-lancer', 2007, 2017, '2.0',    '2.0L I4 CY 154hp',                  0, '1997cc', 1),
                ('mitsubishi-lancer', 2007, 2017, '2.0T',   '2.0L I4 Turbo Evo X 295hp',         0, '1997cc', 1),

                -- ==============================================================
                -- MITSUBISHI ECLIPSE CROSS  (slug: mitsubishi-eclipse-cross)
                -- ==============================================================
                ('mitsubishi-eclipse-cross', 2018, 2021, '1.5T',   '1.5L I4 Turbo 163hp',        0, '1499cc', 1),
                ('mitsubishi-eclipse-cross', 2018, 2021, '2.2D',   '2.2L I4 Diesel 150hp',       1, '2268cc', 1),
                ('mitsubishi-eclipse-cross', 2022, 2026, '2.4PHEV','2.4L I4 PHEV 188hp',          2, '2359cc', 1),
                ('mitsubishi-eclipse-cross', 2022, 2026, '1.5T',   '1.5L I4 Turbo 163hp',        0, '1499cc', 1),

                -- ==============================================================
                -- LEXUS IS  (slug: lexus-is)
                -- ==============================================================
                ('lexus-is', 1999, 2005, '2.0',    '2.0L I6 IS200 155hp',                        0, '1988cc', 1),
                ('lexus-is', 1999, 2005, '3.0',    '3.0L I6 IS300 215hp',                        0, '2997cc', 1),
                ('lexus-is', 2005, 2013, '2.5V6',  '2.5L V6 IS250 208hp',                        0, '2499cc', 1),
                ('lexus-is', 2005, 2013, '3.5V6',  '3.5L V6 IS350 311hp',                        0, '3456cc', 1),
                ('lexus-is', 2013, 2020, '2.0T',   '2.0L I4 Turbo IS200t 241hp',                 0, '1998cc', 1),
                ('lexus-is', 2013, 2020, '2.5V6',  '2.5L V6 IS250 208hp',                        0, '2499cc', 1),
                ('lexus-is', 2013, 2020, '3.5V6',  '3.5L V6 IS350 311hp',                        0, '3456cc', 1),
                ('lexus-is', 2013, 2020, '3.5F',   '3.5L V6 IS-F 423hp',                         0, '3456cc', 1),
                ('lexus-is', 2020, 2026, '2.0T',   '2.0L I4 Turbo IS300 241hp',                  0, '1998cc', 1),
                ('lexus-is', 2020, 2026, '3.5V6',  '3.5L V6 IS350 311hp',                        0, '3456cc', 1),
                ('lexus-is', 2020, 2026, '3.5F',   '3.5L V6 IS500 F Sport 472hp',                0, '3456cc', 1),

                -- ==============================================================
                -- LEXUS RX  (slug: lexus-rx)
                -- ==============================================================
                ('lexus-rx', 1998, 2003, '3.0V6',  '3.0L V6 RX300 223hp',                        0, '2994cc', 1),
                ('lexus-rx', 2003, 2009, '3.3V6',  '3.3L V6 RX330/350 230hp',                    0, '3311cc', 1),
                ('lexus-rx', 2003, 2009, '3.3HV',  '3.3L V6 Hybrid RX400h 268hp',                2, '3311cc', 1),
                ('lexus-rx', 2009, 2015, '3.5V6',  '3.5L V6 RX350 276hp',                        0, '3456cc', 1),
                ('lexus-rx', 2009, 2015, '3.5HV',  '3.5L V6 Hybrid RX450h 299hp',                2, '3456cc', 1),
                ('lexus-rx', 2015, 2022, '3.5V6',  '3.5L V6 RX350 295hp',                        0, '3456cc', 1),
                ('lexus-rx', 2015, 2022, '3.5HV',  '3.5L V6 Hybrid RX450h 308hp',                2, '3456cc', 1),
                ('lexus-rx', 2015, 2022, '3.5PHEV', '3.5L V6 PHEV RX450hL 308hp',                2, '3456cc', 1),
                ('lexus-rx', 2022, 2026, '2.5HV',  '2.5L I4 Hybrid RX350h 246hp',                2, '2487cc', 1),
                ('lexus-rx', 2022, 2026, '2.4T',   '2.4L I4 Turbo RX350 275hp',                  0, '2393cc', 1),
                ('lexus-rx', 2022, 2026, '2.5PHEV', '2.5L I4 PHEV RX450h+ 309hp',                2, '2487cc', 1),

                -- ==============================================================
                -- LEXUS NX  (slug: lexus-nx)
                -- ==============================================================
                ('lexus-nx', 2014, 2021, '2.0T',   '2.0L I4 Turbo NX200t 235hp',                 0, '1998cc', 1),
                ('lexus-nx', 2014, 2021, '2.5HV',  '2.5L I4 Hybrid NX300h 197hp',                2, '2494cc', 1),
                ('lexus-nx', 2021, 2026, '2.5HV',  '2.5L I4 Hybrid NX350h 240hp',                2, '2487cc', 1),
                ('lexus-nx', 2021, 2026, '2.4T',   '2.4L I4 Turbo NX350 275hp',                  0, '2393cc', 1),
                ('lexus-nx', 2021, 2026, '2.5PHEV', '2.5L I4 PHEV NX450h+ 309hp',                2, '2487cc', 1),

                -- ==============================================================
                -- LEXUS ES  (slug: lexus-es)
                -- ==============================================================
                ('lexus-es', 1989, 1997, '2.5V6',  '2.5L V6 ES250 156hp',                        0, '2507cc', 1),
                ('lexus-es', 1997, 2006, '3.0V6',  '3.0L V6 ES300 210hp',                        0, '2994cc', 1),
                ('lexus-es', 2006, 2012, '3.5V6',  '3.5L V6 ES350 272hp',                        0, '3456cc', 1),
                ('lexus-es', 2012, 2018, '3.5V6',  '3.5L V6 ES350 268hp',                        0, '3456cc', 1),
                ('lexus-es', 2012, 2018, '2.5HV',  '2.5L I4 Hybrid ES300h 200hp',                2, '2494cc', 1),
                ('lexus-es', 2018, 2026, '3.5V6',  '3.5L V6 ES350 302hp',                        0, '3456cc', 1),
                ('lexus-es', 2018, 2026, '2.5HV',  '2.5L I4 Hybrid ES300h 215hp',                2, '2487cc', 1),

                -- ==============================================================
                -- INFINITI Q50  (slug: infiniti-q50)
                -- ==============================================================
                ('infiniti-q50', 2014, 2016, '3.7V6',  '3.7L V6 328hp',                          0, '3696cc', 1),
                ('infiniti-q50', 2014, 2016, '2.0T',   '2.0L I4 Turbo 208hp',                    0, '1991cc', 1),
                ('infiniti-q50', 2014, 2016, '3.5HV',  '3.5L V6 Hybrid 360hp',                   2, '3498cc', 1),
                ('infiniti-q50', 2016, 2026, '2.0T',   '2.0L I4 Turbo 208hp',                    0, '1991cc', 1),
                ('infiniti-q50', 2016, 2026, '3.0TT',  '3.0L V6 TwinTurbo Red Sport 400hp',      0, '2997cc', 1),
                ('infiniti-q50', 2016, 2026, '3.5HV',  '3.5L V6 Hybrid 364hp',                   2, '3498cc', 1),

                -- ==============================================================
                -- INFINITI QX60  (slug: infiniti-qx60)
                -- ==============================================================
                ('infiniti-qx60', 2013, 2020, '3.5V6',  '3.5L V6 265hp',                         0, '3498cc', 1),
                ('infiniti-qx60', 2013, 2020, '2.5HV',  '2.5L I4 Hybrid 250hp',                  2, '2488cc', 1),
                ('infiniti-qx60', 2021, 2026, '3.5V6',  '3.5L V6 295hp',                         0, '3498cc', 1),

                -- ==============================================================
                -- INFINITI QX80  (slug: infiniti-qx80)
                -- ==============================================================
                ('infiniti-qx80', 2014, 2020, '5.6V8',  '5.6L V8 400hp',                         0, '5552cc', 1),
                ('infiniti-qx80', 2021, 2026, '5.6V8',  '5.6L V8 400hp',                         0, '5552cc', 1),
                ('infiniti-qx80', 2021, 2026, '3.5TT',  '3.5L V6 TwinTurbo 450hp',               0, '3498cc', 1),

                -- ==============================================================
                -- ACURA TLX  (slug: acura-tlx)
                -- ==============================================================
                ('acura-tlx', 2015, 2020, '2.4',    '2.4L I4 206hp',                             0, '2356cc', 1),
                ('acura-tlx', 2015, 2020, '3.5V6',  '3.5L V6 290hp',                             0, '3471cc', 1),
                ('acura-tlx', 2021, 2026, '2.0T',   '2.0L I4 Turbo 272hp',                       0, '1995cc', 1),
                ('acura-tlx', 2021, 2026, '3.0TT',  '3.0L V6 Type S TwinTurbo 355hp',            0, '2997cc', 1),

                -- ==============================================================
                -- ACURA MDX  (slug: acura-mdx)
                -- ==============================================================
                ('acura-mdx', 2001, 2006, '3.5V6',  '3.5L V6 265hp',                             0, '3471cc', 1),
                ('acura-mdx', 2007, 2013, '3.7V6',  '3.7L V6 300hp',                             0, '3664cc', 1),
                ('acura-mdx', 2014, 2020, '3.5V6',  '3.5L V6 290hp',                             0, '3471cc', 1),
                ('acura-mdx', 2014, 2020, '3.0HV',  '3.0L V6 Hybrid Sport Hybrid 321hp',         2, '2999cc', 1),
                ('acura-mdx', 2021, 2026, '3.5V6',  '3.5L V6 290hp',                             0, '3471cc', 1),
                ('acura-mdx', 2021, 2026, '3.0HV',  '3.0L V6 Hybrid 320hp',                      2, '2999cc', 1),
                ('acura-mdx', 2021, 2026, '3.0TS',  '3.0L V6 Type S Turbo 355hp',                0, '2997cc', 1),

                -- ==============================================================
                -- ACURA RDX  (slug: acura-rdx)
                -- ==============================================================
                ('acura-rdx', 2007, 2012, '2.3T',   '2.3L I4 Turbo 240hp',                       0, '2254cc', 1),
                ('acura-rdx', 2013, 2018, '3.5V6',  '3.5L V6 273hp',                             0, '3471cc', 1),
                ('acura-rdx', 2019, 2026, '2.0T',   '2.0L I4 Turbo 272hp',                       0, '1995cc', 1),
                ('acura-rdx', 2019, 2026, '2.0TPHEV','2.0L I4 PHEV 302hp',                        2, '1995cc', 1),

                -- ==============================================================
                -- SUZUKI SWIFT  (slug: suzuki-swift)
                -- ==============================================================
                ('suzuki-swift', 1983, 1989, '1.0',    '1.0L I3 45hp',                           0, '993cc',  1),
                ('suzuki-swift', 1989, 2003, '1.0',    '1.0L I3 55hp',                           0, '993cc',  1),
                ('suzuki-swift', 1989, 2003, '1.3',    '1.3L I4 83hp',                           0, '1298cc', 1),
                ('suzuki-swift', 2004, 2010, '1.3',    '1.3L I4 92hp',                           0, '1328cc', 1),
                ('suzuki-swift', 2004, 2010, '1.6',    '1.6L I4 Sport 125hp',                    0, '1586cc', 1),
                ('suzuki-swift', 2010, 2017, '1.2',    '1.2L I4 94hp',                           0, '1242cc', 1),
                ('suzuki-swift', 2010, 2017, '1.4T',   '1.4L I4 Turbo Sport 140hp',              0, '1373cc', 1),
                ('suzuki-swift', 2010, 2017, '1.3D',   '1.3L I4 Diesel 75hp',                    1, '1248cc', 1),
                ('suzuki-swift', 2017, 2026, '1.0T',   '1.0L I3 Turbo Boosterjet 112hp',         0, '998cc',  1),
                ('suzuki-swift', 2017, 2026, '1.2HV',  '1.2L I4 Dualjet Mild Hybrid 90hp',       2, '1197cc', 1),
                ('suzuki-swift', 2017, 2026, '1.4T',   '1.4L I4 Turbo Sport 129hp',              0, '1373cc', 1),

                -- ==============================================================
                -- SUZUKI VITARA  (slug: suzuki-vitara)
                -- ==============================================================
                ('suzuki-vitara', 1988, 1998, '1.6',    '1.6L I4 80hp',                          0, '1590cc', 1),
                ('suzuki-vitara', 1998, 2005, '1.6',    '1.6L I4 94hp',                          0, '1590cc', 1),
                ('suzuki-vitara', 1998, 2005, '2.0V6',  '2.0L V6 136hp',                         0, '1997cc', 1),
                ('suzuki-vitara', 2015, 2026, '1.0T',   '1.0L I3 Turbo Boosterjet 112hp',        0, '998cc',  1),
                ('suzuki-vitara', 2015, 2026, '1.4T',   '1.4L I4 Turbo Boosterjet 140hp',        0, '1373cc', 1),
                ('suzuki-vitara', 2015, 2026, '1.6D',   '1.6L I4 Diesel 120hp',                  1, '1598cc', 1),
                ('suzuki-vitara', 2019, 2026, '1.4THV', '1.4L I4 Turbo Mild Hybrid 129hp',       2, '1373cc', 1),

                -- ==============================================================
                -- SUZUKI JIMNY  (slug: suzuki-jimny)
                -- ==============================================================
                ('suzuki-jimny', 1970, 1998, '0.8',    '0.8L I2 45hp LJ/SJ',                     0, '797cc',  1),
                ('suzuki-jimny', 1998, 2018, '1.3',    '1.3L I4 85hp JB43',                      0, '1298cc', 1),
                ('suzuki-jimny', 2018, 2026, '1.5',    '1.5L I4 102hp JB74',                     0, '1462cc', 1),

                -- ==============================================================
                -- ISUZU TROOPER  (slug: isuzu-trooper)
                -- ==============================================================
                ('isuzu-trooper', 1981, 1991, '2.3',    '2.3L I4 100hp',                         0, '2254cc', 1),
                ('isuzu-trooper', 1992, 1997, '3.2V6',  '3.2L V6 175hp',                         0, '3165cc', 1),
                ('isuzu-trooper', 1998, 2002, '3.5V6',  '3.5L V6 215hp',                         0, '3494cc', 1),
                ('isuzu-trooper', 1998, 2002, '3.0D',   '3.0L I4 Diesel 155hp',                  1, '2999cc', 1),

                -- ==============================================================
                -- ISUZU RODEO  (slug: isuzu-rodeo)
                -- ==============================================================
                ('isuzu-rodeo', 1988, 1997, '2.6',    '2.6L I4 120hp',                           0, '2559cc', 1),
                ('isuzu-rodeo', 1988, 1997, '3.1V6',  '3.1L V6 120hp',                           0, '3098cc', 1),
                ('isuzu-rodeo', 1998, 2004, '2.2',    '2.2L I4 130hp',                           0, '2198cc', 1),
                ('isuzu-rodeo', 1998, 2004, '3.2V6',  '3.2L V6 205hp',                           0, '3165cc', 1),

                -- ==============================================================
                -- GENESIS G80  (slug: genesis-g80)
                -- ==============================================================
                ('genesis-g80', 2017, 2020, '2.0T',   '2.0L I4 Turbo 245hp',                     0, '1998cc', 1),
                ('genesis-g80', 2017, 2020, '3.3TT',  '3.3L V6 TwinTurbo 370hp',                 0, '3342cc', 1),
                ('genesis-g80', 2017, 2020, '5.0V8',  '5.0L V8 420hp',                           0, '4969cc', 1),
                ('genesis-g80', 2020, 2026, '2.5T',   '2.5L I4 Turbo 300hp',                     0, '2497cc', 1),
                ('genesis-g80', 2020, 2026, '3.5TT',  '3.5L V6 TwinTurbo 375hp',                 0, '3470cc', 1),
                ('genesis-g80', 2021, 2026, 'EV',     'Dual Motor Electric 365hp',               3, NULL,     1),

                -- ==============================================================
                -- GENESIS G70  (slug: genesis-g70)
                -- ==============================================================
                ('genesis-g70', 2018, 2026, '2.0T',   '2.0L I4 Turbo 252hp',                     0, '1998cc', 1),
                ('genesis-g70', 2018, 2026, '3.3TT',  '3.3L V6 TwinTurbo 365hp',                 0, '3342cc', 1),

                -- ==============================================================
                -- GENESIS G90  (slug: genesis-g90)
                -- ==============================================================
                ('genesis-g90', 2017, 2022, '3.3TT',  '3.3L V6 TwinTurbo 365hp',                 0, '3342cc', 1),
                ('genesis-g90', 2017, 2022, '5.0V8',  '5.0L V8 420hp',                           0, '4969cc', 1),
                ('genesis-g90', 2022, 2026, '3.5TT',  '3.5L V6 TwinTurbo 375hp',                 0, '3470cc', 1),
                ('genesis-g90', 2022, 2026, '3.5TTHV', '3.5L V6 TwinTurbo E-SC 409hp',           2, '3470cc', 1),

                -- ==============================================================
                -- GENESIS GV70  (slug: genesis-gv70)
                -- ==============================================================
                ('genesis-gv70', 2021, 2026, '2.5T',   '2.5L I4 Turbo 300hp',                    0, '2497cc', 1),
                ('genesis-gv70', 2021, 2026, '3.5TT',  '3.5L V6 TwinTurbo 380hp',                0, '3470cc', 1),
                ('genesis-gv70', 2023, 2026, 'EV',     'Dual Motor Electric 429hp',               3, NULL,     1),

                -- ==============================================================
                -- GENESIS GV80  (slug: genesis-gv80)
                -- ==============================================================
                ('genesis-gv80', 2021, 2026, '2.5T',   '2.5L I4 Turbo 300hp',                    0, '2497cc', 1),
                ('genesis-gv80', 2021, 2026, '3.5TT',  '3.5L V6 TwinTurbo 375hp',                0, '3470cc', 1),
                ('genesis-gv80', 2021, 2026, '3.0D',   '3.0L I6 Diesel 278hp',                   1, '2999cc', 1),

                -- ==============================================================
                -- GENESIS GV60  (slug: genesis-gv60)
                -- ==============================================================
                ('genesis-gv60', 2022, 2026, 'RWD',    'Single Motor RWD 228hp',                 3, NULL,     1),
                ('genesis-gv60', 2022, 2026, 'AWD',    'Dual Motor AWD 314hp',                   3, NULL,     1),
                ('genesis-gv60', 2022, 2026, 'Perf',   'Dual Motor Performance AWD 429hp',       3, NULL,     1)

            ) AS v(ModelSlug, YearFrom, YearTo, EngineCode, EngineLabel, FuelType, Displacement, IsActive)
            INNER JOIN [CarModels] m ON m.Slug = v.ModelSlug;
            """);
    }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
    {
        // Remove variants first (FK dependency)
        migrationBuilder.Sql("""
            DELETE vv
            FROM [VehicleVariants] vv
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

        migrationBuilder.Sql("""
            DELETE m
            FROM [CarModels] m
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

        migrationBuilder.Sql("""
            DELETE FROM [CarBrands]
            WHERE Slug IN (
                'chevrolet','ford','dodge','cadillac','buick','gmc','pontiac',
                'oldsmobile','plymouth','lincoln','mercury','chrysler','jeep',
                'ram','tesla','volkswagen','bmw','mercedes-benz','audi','opel',
                'renault','peugeot','citroen','fiat','alfa-romeo','volvo','saab',
                'seat','skoda','porsche','land-rover','jaguar','mini','lancia',
                'rover','toyota','honda','nissan','mazda','subaru','mitsubishi',
                'lexus','infiniti','acura','suzuki','isuzu','hyundai','kia','genesis'
            );
            """);
    }
    }
}
