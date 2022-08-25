using Microsoft.EntityFrameworkCore;
using SwapiApp.Models;

namespace SwapiApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Person> People { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Convert the array of strings as a combined comma separated text.

            // The Vehicles property
            builder.Entity<Person>()
            .Property(e => e.Vehicles)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            // The Films property
            builder.Entity<Person>()
            .Property(e => e.Films)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            // The Species property
            builder.Entity<Person>()
            .Property(e => e.Species)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            // The Starships property
            builder.Entity<Person>()
            .Property(e => e.Starships)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

        }
    }
}
