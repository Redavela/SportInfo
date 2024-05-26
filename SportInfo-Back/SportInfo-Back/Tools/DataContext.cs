
using Microsoft.EntityFrameworkCore;
using SportInfo_Back.Models;

namespace SportInfo_Back.Tools
{
    public class DataContext: DbContext
    {

        #region Properties

        private readonly IConfiguration configuration;
        public DataContext(IConfiguration configuration) { 
            this.configuration = configuration;
        }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(configuration.GetConnectionString("DevConnection"));
        }

        public DbSet<User> Users { get; set; }
    }
}
