using PracticalSeventeen.Data.Models;
using PracticalSeventeen.Data.ViewModels;

namespace PracticalSeventeen.Data.Interfaces
{
    public interface IAccountRepository
    {
        /// <summary>
        /// return User object if by matchin email and password
        /// </summary>
        /// <param name="email">The user email address.</param>
        /// <param name="password">Password of related email</param>
        /// <returns>User object</returns>
        Task<UserDetails> GetUserByEmailPasswordAsync(string email, string password);
    }
}
