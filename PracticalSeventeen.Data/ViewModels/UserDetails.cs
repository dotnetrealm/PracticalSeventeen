using PracticalSeventeen.Data.Models;

namespace PracticalSeventeen.Data.ViewModels
{
    public class UserDetails
    {
        public User User { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
