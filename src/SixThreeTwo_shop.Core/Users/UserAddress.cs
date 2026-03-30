using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using SixThreeTwo_shop.Authorization.Users;

namespace SixThreeTwo_shop.Users;

[Table("UserAddresses")]
public class UserAddress:Entity
{
  public long UserId { get; set; }

  public string Label { get; set; }

  public string AddressLine1 { get; set; }

  public string AddressLine2 { get; set; }

  public string City { get; set; }

  public string PostalCode { get; set; }

  public string Country { get; set; }

  public bool IsDefault { get; set; }

  [ForeignKey("UserId")]
  public User User { get; set; }
}
