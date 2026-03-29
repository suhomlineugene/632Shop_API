using System.ComponentModel.DataAnnotations;

namespace 632Shop.Users.Dto;

public class ChangeUserLanguageDto
{
    [Required]
    public string LanguageName { get; set; }
}