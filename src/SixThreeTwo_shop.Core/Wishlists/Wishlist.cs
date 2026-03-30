using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using SixThreeTwo_shop.Authorization.Users;
using SixThreeTwo_shop.Products;

namespace SixThreeTwo_shop.Wishlists;

[Table("Wishlists")]
public class Wishlist: Entity
{
  public int ProductId { get; set; }

  public long UserId { get; set; }

  public DateTime CreatedOn { get; set; }

  [ForeignKey("ProductId")]
  public Product Product { get; set; }

  [ForeignKey("UserId")]
  public User User { get; set; }
}
