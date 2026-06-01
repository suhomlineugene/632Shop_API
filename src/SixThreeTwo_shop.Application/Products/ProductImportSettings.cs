namespace SixThreeTwo_shop.Products;

public class ProductImportSettings
{
  public const string SectionName = "ProductImport";
  
  public const int DefaultChunkSize = 1000;

  public int ChunkSize { get; set; } = DefaultChunkSize;
}
