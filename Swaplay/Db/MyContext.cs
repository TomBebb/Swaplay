using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.VisualBasic.FileIO;
using System.IO;

namespace Swaplay.Db
{
    public sealed class MyContext: DbContext
    {

        public DbSet<GraphicsConfig> GraphicsConfigs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var myDir = Path.Join(SpecialDirectories.CurrentUserApplicationData, "Swaplay");
            Directory.CreateDirectory(myDir);
            var dbPath = Path.Join(myDir, "swaplay.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GraphicsConfig>(gc =>
            {
                gc.Property(v => v.Mode)
                .HasConversion<StringToEnumConverter<GraphicsMode>>();
            });
        }
    }
}
