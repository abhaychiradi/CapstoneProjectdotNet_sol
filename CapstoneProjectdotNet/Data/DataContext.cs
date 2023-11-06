using CapstoneProjectdotNet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CapstoneProjectdotNet.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }

        public DbSet<Note> Notes { get; set; }

        public DbSet<User> Users { get; set; }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            // Configure one-to-many relationship between User and Note
            modelBuilder.Entity<User>()
                .HasMany(u => u.Notes)
                .WithOne(n => n.User);
            //.HasForeignKey(n => n.UserId);
    }

    }
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-BKL3FG8\\SQLEXPRESS;Initial Catalog=NotesDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            return new DataContext(optionsBuilder.Options);
        }
    }
}
