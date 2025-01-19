using Microsoft.EntityFrameworkCore;
using Parking.Models;

namespace Parking.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Space> Spaces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.Id);  

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();  
        }

   
    }
}
