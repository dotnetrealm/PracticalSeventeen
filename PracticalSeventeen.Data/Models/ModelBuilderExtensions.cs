using Microsoft.EntityFrameworkCore;

namespace PracticalSeventeen.Data.Models
{
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Seed Users table data
        /// </summary>
        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User() { Id = 1, Firstname = "Bhavin", LastName = "Kareliya", Email = "bhavin@gmail.com", Password = "123123" },
                    new User() { Id = 2, Firstname = "Jil", LastName = "Patel", Email = "jil@gmail.com", Password = "123123" },
                    new User() { Id = 3, Firstname = "Vipul", LastName = "Kumar", Email = "vipul@gmail.com", Password = "123123" },
                    new User() { Id = 4, Firstname = "Abhi", LastName = "Dasadiya", Email = "abhi@gmail.com", Password = "123123" },
                    new User() { Id = 5, Firstname = "Jay", LastName = "Gohel", Email = "jay@gmail.com", Password = "123123" }
                );
        }

        /// <summary>
        /// Seed Roles table data
        /// </summary>
        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                    new Role() { Id = 1, RoleName = "User" },
                    new Role() { Id = 2, RoleName = "Admin" }
                );
        }

        /// <summary>
        /// Seed UserRoles table data
        /// </summary>
        public static void SeedUserRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasData(
                    new UserRole() { UserId = 1, RoleId = 2 },
                    new UserRole() { UserId = 2, RoleId = 2 },
                    new UserRole() { UserId = 3, RoleId = 1 },
                    new UserRole() { UserId = 4, RoleId = 1 },
                    new UserRole() { UserId = 5, RoleId = 1 }
                );
        }

        /// <summary>
        /// Seed Students table data
        /// </summary>
        public static void SeedStudents(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student() { Id = 1, FirstName = "Bhavin", LastName = "Kareliya", MobileNumber = "1231231231", Gender = 'M', Address = "Rajkot", DOB = Convert.ToDateTime("2002-02-09").Date },
                new Student() { Id = 2, FirstName = "Jil", LastName = "Patel", MobileNumber = "1231231231", Gender = 'M', Address = "Rajkot", DOB = Convert.ToDateTime("2001-01-01").Date },
                new Student() { Id = 3, FirstName = "Vipul", LastName = "Kumar", MobileNumber = "1231231231", Gender = 'M', Address = "Rajkot", DOB = Convert.ToDateTime("1999-07-07").Date },
                new Student() { Id = 4, FirstName = "Jay", LastName = "Gohel", MobileNumber = "1231231231", Gender = 'M', Address = "Rajkot", DOB = Convert.ToDateTime("2000-04-12").Date }
            );
        }
    }
}
