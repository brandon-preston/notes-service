using Microsoft.EntityFrameworkCore;

namespace MBP.Services.Notes.DAL.Data
{
    public class NoteContext : DbContext
    {
        public DbSet<Types.UserAccount> UserAccount { get; set; }

        public DbSet<Types.Note> Note { get; set; }

        public DbSet<Types.Exception> Exception { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = Helpers.ConfigurationHelper.ConnectionString("Notes");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}