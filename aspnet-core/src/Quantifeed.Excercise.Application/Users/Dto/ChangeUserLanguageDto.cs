using System.ComponentModel.DataAnnotations;

namespace Quantifeed.Excercise.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}