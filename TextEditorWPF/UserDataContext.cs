using Microsoft.EntityFrameworkCore;


namespace TextEditorWPF
{
    public class UserDataContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = dataBaseWPF.db");
        }
        public DbSet<User> Users { get; set; }
    }
}
