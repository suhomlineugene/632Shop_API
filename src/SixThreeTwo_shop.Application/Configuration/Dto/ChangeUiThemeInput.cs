using System.ComponentModel.DataAnnotations;

namespace SixThreeTwo_shop.Configuration.Dto;

public class ChangeUiThemeInput
{
    [Required]
    [StringLength(32)]
    public string Theme { get; set; }
}
