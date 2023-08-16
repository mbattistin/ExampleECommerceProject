using ExampleECommerceProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace ExampleECommerceProject.Data
{
    public class ApplicationDbContext:DbContext
    {
        private readonly IConfiguration _configuration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            ServerVersion serverVersion = ServerVersion.AutoDetect(connectionString);

            optionsBuilder.UseMySql(connectionString, serverVersion);
        }

        public DbSet<Category> Categories { get; set; }
    }
}
