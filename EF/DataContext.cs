using EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF
{
    public class DataContext : DbContext
    {
        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<RentEntity> Rents { get; set; }
        public DbSet<TransportEntity> Transports { get; set; }

        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Model.GetEntityTypes()
                .SelectMany(entity => entity.GetProperties())
                .ToList()
                .ForEach(property => property.SetColumnName(property.Name.ToLower()));
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<T> DbSet<T>() where T : class
        {
            return Set<T>();
        }

        public new IQueryable<T> Query<T>() where T : class
        {
            return Set<T>();
        }
    }
}
