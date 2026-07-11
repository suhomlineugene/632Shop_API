using Abp.Domain.Services;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using SixThreeTwo_shop.Shared.Common.Dto;

namespace SixThreeTwo_shop.Shared.Common;

public interface IS3Uploader : IDomainService
{
  Task<string> UploadFileAsync(ProductFileDto file);
  
  Task DeleteFileAsync(string key);
}
