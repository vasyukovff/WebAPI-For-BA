using Microsoft.EntityFrameworkCore;
using WebAPIForBA.Models;

namespace WebAPIForBA
{
    public class PostgreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=webApiForBA;Username=postgres;Password=root");
        }

        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<ProfileModel> Profiles { get; set; }
    }
}
