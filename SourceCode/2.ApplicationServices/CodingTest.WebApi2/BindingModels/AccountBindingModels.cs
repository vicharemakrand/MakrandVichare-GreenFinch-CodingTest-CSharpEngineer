using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CodingTest.WebApi2.Models
{
    // Models used as parameters to AccountController actions.

    public class RegisterBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        public string NewsLetterIds { get; set; }

        [Required]
        public int HeardAboutUs { get; set; }

        public string SignUpReason { get; set; }
    }

}
