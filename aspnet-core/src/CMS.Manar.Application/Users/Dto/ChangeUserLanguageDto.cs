using System.ComponentModel.DataAnnotations;

namespace CMS.Manar.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}