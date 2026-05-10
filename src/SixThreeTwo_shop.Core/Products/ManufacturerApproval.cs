using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace SixThreeTwo_shop.Products;

[Table("ManufacturerApprovals")]
public class ManufacturerApproval : Entity
{
  public string Name { get; set; }
  
  public string Description { get; set; }
  
  public string ManufacturerName { get; set; }
}
