using System.ComponentModel.DataAnnotations;

namespace SixThreeTwo_shop.Users.Dto;

public class ChangeUserLanguageDto
{
    [Required]
    public string LanguageName { get; set; }
}