using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PracticalSeventeen.Data.Models
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Role must contains less than 50 letters")]
        [DisplayName("Role")]
        public string RoleName { get; set; } = null!;

        public ICollection<UserRole> Users { get; set; }
    }
}
