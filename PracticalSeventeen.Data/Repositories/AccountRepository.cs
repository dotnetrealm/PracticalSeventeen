using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PracticalSeventeen.Data.Interfaces;
using PracticalSeventeen.Data.Models;
using PracticalSeventeen.Data.ViewModels;

namespace PracticalSeventeen.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDBContext _db;

        public AccountRepository(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<UserDetails> GetUserByEmailPasswordAsync(string email, string password)
        {
            var clientIdParameter = new SqlParameter("@ClientId", 4);
            var user =await  _db.Users.Where(u => u.Email == email && u.Password == password)
                                .Join(_db.UserRoles, user => user.Id, userrole => userrole.UserId, (user, userroles) => new { user, userroles })
                                .Join(_db.Roles, userrole => userrole.userroles.RoleId, role => role.Id, (userrole, role) => new { userrole, role })
                                .Select(userrole => new UserDetails{ User = userrole.userrole.user, Role = userrole.role.RoleName }).FirstOrDefaultAsync();
            return user;
        }
    }
}
