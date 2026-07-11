using System;
using System.IO;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using Abp.UI;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;
using SixThreeTwo_shop.Shared.Common;
using SixThreeTwo_shop.Shared.Common.Dto;

namespace SixThreeTwo_shop.Common;

public class S3Uploader : DomainService, IS3Uploader
{
  private readonly IAmazonS3 _s3Client;
  private readonly string _bucketName;
  private readonly string _fileUploadFolder;

  public S3Uploader(IConfiguration configuration)
  {
    try
    {
      var settings = configuration.GetSection(AwsS3Settings.SectionName).Get<AwsS3Settings>()
                     ?? new AwsS3Settings();

      if (string.IsNullOrWhiteSpace(settings.BucketName) ||
          string.IsNullOrWhiteSpace(settings.AccessKeyId) ||
          string.IsNullOrWhiteSpace(settings.SecretAccessKey) ||
          string.IsNullOrWhiteSpace(settings.Region))
      {
        throw new AbpException("AWS S3 settings are missing or incomplete. Please check your configuration.");
      }

      _bucketName = settings.BucketName;
      _fileUploadFolder = settings.FileUploadFolder;
      _s3Client = new AmazonS3Client(settings.AccessKeyId, settings.SecretAccessKey,
        Amazon.RegionEndpoint.GetBySystemName(settings.Region));
    }
    catch (Exception ex) when (ex is not AbpException)
    {
      Logger.Error("Failed to initialize S3Uploader.", ex);
      throw new AbpException("Failed to initialize the file storage service.", ex);
    }
  }

  public async Task<string> UploadFileAsync(ProductFileDto file)
  {
    if (file == null)
    {
      throw new ArgumentNullException(nameof(file));
    }

    if (string.IsNullOrWhiteSpace(file.FileBase64))
    {
      throw new UserFriendlyException("The file content is empty.");
    }

    var extension = Path.GetExtension(file.FileName);
    var key = $"{_fileUploadFolder}/{Guid.NewGuid()}{extension}";
    var contentType = GetContentType(extension);

    byte[] bytes;
    try
    {
      bytes = Convert.FromBase64String(file.FileBase64);
    }
    catch (FormatException ex)
    {
      Logger.Error($"Invalid base64 content for file '{file.FileName}'.", ex);
      throw new UserFriendlyException("The uploaded file content is not valid.");
    }

    try
    {
      using var stream = new MemoryStream(bytes);

      var request = new PutObjectRequest
      {
        BucketName = _bucketName,
        Key = key,
        InputStream = stream,
        ContentType = contentType,
        AutoCloseStream = true
      };

      await _s3Client.PutObjectAsync(request);

      return key;
    }
    catch (AmazonS3Exception ex)
    {
      Logger.Error($"Amazon S3 error while uploading file '{file.FileName}' to bucket '{_bucketName}'.", ex);
      throw new UserFriendlyException("An error occurred while uploading the file. Please try again later.");
    }
    catch (Exception ex)
    {
      Logger.Error($"Unexpected error while uploading file '{file.FileName}'.", ex);
      throw new UserFriendlyException("An unexpected error occurred while uploading the file.");
    }
  }

  public async Task DeleteFileAsync(string key)
  {
    if (string.IsNullOrWhiteSpace(key))
    {
      throw new ArgumentNullException(nameof(key));
    }

    try
    {
      var request = new DeleteObjectRequest
      {
        BucketName = _bucketName,
        Key = key
      };

      await _s3Client.DeleteObjectAsync(request);
    }
    catch (AmazonS3Exception ex)
    {
      Logger.Error($"Amazon S3 error while deleting file '{key}' from bucket '{_bucketName}'.", ex);
      throw new UserFriendlyException("An error occurred while deleting the file. Please try again later.");
    }
    catch (Exception ex)
    {
      Logger.Error($"Unexpected error while deleting file '{key}'.", ex);
      throw new UserFriendlyException("An unexpected error occurred while deleting the file.");
    }
  }

  private static string GetContentType(string extension) => extension.ToLowerInvariant() switch
  {
    ".jpg" or ".jpeg" => "image/jpeg",
    ".png" => "image/png",
    ".gif" => "image/gif",
    ".webp" => "image/webp",
    _ => "application/octet-stream"
  };
}
