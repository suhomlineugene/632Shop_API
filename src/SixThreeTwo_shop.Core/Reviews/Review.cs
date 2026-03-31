using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using SixThreeTwo_shop.Authorization.Users;
using SixThreeTwo_shop.Orders;
using SixThreeTwo_shop.Products;

namespace SixThreeTwo_shop.Reviews;

[Table("Reviews")]
public class Review : Entity
{
  public int Rating { get;set; }

  public string Title { get; set; }

  public string Body { get; set; }

  public int ProductId { get; set; }

  public int OrderId { get; set; }

  public long UserId { get; set; }

  [ForeignKey("UserId")]
  public User User { get; set; }

  [ForeignKey("OrderId")]
  public Order Order { get; set; }

  [ForeignKey("ProductId")]
  public Product Product { get; set; }
}
