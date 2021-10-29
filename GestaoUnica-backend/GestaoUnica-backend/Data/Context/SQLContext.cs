using GestaoUnica_backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GestaoUnica_backend.Context
{
    public class SQLContext: DbContext
    {
        private readonly IConfiguration _config;

        public SQLContext()
        {
            
        }
        public SQLContext(DbContextOptions<SQLContext> options, IConfiguration configuration)
            :base(options)
        {
            _config = configuration;
        }

        public DbSet<User> Usuarios { get; set; }
        public DbSet<Role> Regras { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("Connection"));
        }
    }
}
