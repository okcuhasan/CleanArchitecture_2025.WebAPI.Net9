using CleanArchitecture_2025.Domain.Abstractions;
using CleanArchitecture_2025.Domain.Employees;
using GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture_2025.Infrastructure.Context
{
    internal sealed class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<Entity>();

            foreach (var entry in entries)
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Property(e => e.CreateAt)
                        .CurrentValue = DateTimeOffset.Now;
                }

                if(entry.State == EntityState.Modified)
                {
                    if(entry.Property(e => e.IsDeleted).CurrentValue == true)
                    {
                        entry.Property(e => e.DeleteAt)
                            .CurrentValue = DateTimeOffset.Now;
                    }
                    else
                    {
                        entry.Property(e => e.UpdateAt)
                            .CurrentValue = DateTimeOffset.Now;
                    }
                }

                if(entry.State == EntityState.Deleted)
                {
                    throw new ArgumentException("Db'den direkt silme işlemi yapamazsınız");
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
