using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalSeventeen.Data.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name must contains less than 50 characters.")]
        [DisplayName("First name")]
        public string Firstname { get; set; } = null!;

        [Required]
        [StringLength(50, ErrorMessage = "Last name must contains less than 50 characters.")]
        [DisplayName("Last name")]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(maximumLength: 320, ErrorMessage = "Email must contains less than 320 characters.")]
        [DataType(DataType.EmailAddress)]
        [Column(TypeName = "varchar(320)")]
        [RegularExpression("/[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?/g", ErrorMessage = "Please enter valid Email address.")]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(128, ErrorMessage = "Password must contains less than 128 letters")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [StringLength(128, ErrorMessage = "Confirm Password must contains less than 128 letters")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; } = null!;

        //Relational properties
        public ICollection<UserRole>? Roles { get; set; }
    }
}
