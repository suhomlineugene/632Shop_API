using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace SixThreeTwo_shop.Products;

[Table("OilApprovals")]
public class OilApproval: Entity
{
  public string Name { get; set; }
  
  public string Description { get; set; }
  
  public StandardType StandardType { get; set; }
}
