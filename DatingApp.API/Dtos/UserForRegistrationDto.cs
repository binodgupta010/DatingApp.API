using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserForRegistrationDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(20,MinimumLength=4,ErrorMessage="You must provide password between charactor 4 to 20")]
        public string Password { get; set; }
    }
}