namespace SixThreeTwo_shop.Common;

public class AwsS3Settings
{
  public const string SectionName = "Aws:S3";

  public string BucketName { get; set; } = string.Empty;

  public string Region { get; set; } = string.Empty;

  public string AccessKeyId { get; set; } = string.Empty;

  public string SecretAccessKey { get; set; } = string.Empty;

  public string FileUploadFolder { get; set; } = "uploads";
}
