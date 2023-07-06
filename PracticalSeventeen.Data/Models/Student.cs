using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalSeventeen.Data.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name must contains less than 50 letters")]
        [DisplayName("First name")]
        public string FirstName { get; set; } = null!;

        [StringLength(50, ErrorMessage = "Last name must contains less than 50 letters")]
        [DisplayName("Middle name")]
        public string? MiddleName { get; set; }

        [DisplayName("Last name")]
        public string LastName { get; set; } = null!;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd", ApplyFormatInEditMode = true)]
        [Range(typeof(DateOnly), "1800-01-01", "2023-01-01", ErrorMessage = "Please select valid Birthdate (1800/01/01 - 2022/12/31)")]
        [DisplayName("Date of Birth")]
        [Column(TypeName ="date")]
        public DateTime DOB { get; set; }

        [Required]
        public bool Gender { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10, MinimumLength =10)]
        [DisplayName("Mobile number")]
        public string MobileNumber { get; set; }

        [MaxLength(100, ErrorMessage = "Last name must contains less than 100 letters")]
        public string? Address { get; set; }
    }
}
