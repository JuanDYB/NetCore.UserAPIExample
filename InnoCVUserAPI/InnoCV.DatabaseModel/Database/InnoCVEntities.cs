using InnoCV.DatabaseModel.Database.Configuration;
using InnoCV.DatabaseModel.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace InnoCV.DatabaseModel.Database
{
    public class InnoCVEntities : DbContext
    {
        public string ConnectionString;

        public InnoCVEntities(string ConnectionString) : base()
        {
            this.ConnectionString = ConnectionString;
            Database.EnsureCreated();
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder OsptionsBuilder)
        {
            OsptionsBuilder.UseSqlite(this.ConnectionString);
            base.OnConfiguring(OsptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            this.AddModelConfiguration(ModelBuilder);
            base.OnModelCreating(ModelBuilder);
        }

        private void AddModelConfiguration(ModelBuilder ModelBuilder)
        {
            ModelBuilder.ApplyConfiguration(new T_USER_Configuration());
        }

        public DbSet<T_USER> T_USER { get; set; }
    }
}
