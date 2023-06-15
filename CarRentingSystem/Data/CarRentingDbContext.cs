namespace CarRentingSystem.Data
{
    using CarRentingSystem.Data.Models;
    using CarRentingSystem.Data.Models.Abstract;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    public class CarRentingDbContext : IdentityDbContext
    {
        public CarRentingDbContext(DbContextOptions<CarRentingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; init; }

        public DbSet<Category> Categories { get; init; }

        public DbSet<Dealer> Dealers { get; init; }

        public DbSet<Logs_19118072> Logs_19118072 { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Car>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Car>()
                .HasOne(c => c.Dealer)
                .WithMany(d => d.Cars)
                .HasForeignKey(c => c.DealerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Dealer>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<Dealer>(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries();

            var currentDate = DateTime.UtcNow;

            foreach (var entityEntry in entities)
            {
                var entity = entityEntry.Entity as IBaseEntity;

                if (entity is null)
                {
                    continue;
                }

                if (entityEntry.State == EntityState.Added)
                {
                    entity.CreatedAt_19118072 = currentDate;
                }
                else
                {
                   
                    entity.ModifiedAt_19118072 = currentDate;
                }
            }

            return base.SaveChanges();
        }
    }
}
