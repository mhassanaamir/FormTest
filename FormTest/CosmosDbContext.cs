using FormTest.Models;
using Microsoft.EntityFrameworkCore;

namespace FormTest
{
    public class CosmosDbContext : DbContext
    {
        public CosmosDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Form> Forms { get; set; }
        public DbSet<FormResponse> FormResponses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAutoscaleThroughput(1000);

            modelBuilder.HasDefaultContainer("Form");

            modelBuilder.Entity<Form>()
                .HasNoDiscriminator()
                .HasPartitionKey(x => x.Id)
                .HasKey(x => x.Id);

            modelBuilder.Entity<Form>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<FormResponse>()
                .HasNoDiscriminator()
                .ToContainer("FormResponse")
                .HasPartitionKey(x => x.Id)
                .HasKey(x => x.Id);

            modelBuilder.Entity<FormResponse>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
