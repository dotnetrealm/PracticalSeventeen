using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PracticalSeventeen.Data.ViewModels
{
    public class Credential
    {
        [Required]
        [StringLength(320, ErrorMessage = "Email must contains less than 320 letters")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Please enter valid Email address.")]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(128, ErrorMessage = "Password must contains less than 128 letters")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }
    }
}
