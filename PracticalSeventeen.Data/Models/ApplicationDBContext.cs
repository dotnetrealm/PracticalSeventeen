using Microsoft.EntityFrameworkCore;

namespace PracticalSeventeen.Data.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //create composite primary key for bridge table b/w users and roles
            modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.RoleId, ur.UserId });

            //Data Seeders
            modelBuilder.SeedUsers();
            modelBuilder.SeedRoles();
            modelBuilder.SeedUserRoles();
            modelBuilder.SeedStudents();
        }

    }
}
