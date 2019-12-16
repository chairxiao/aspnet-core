using System.ComponentModel.DataAnnotations;

namespace TestUse.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}