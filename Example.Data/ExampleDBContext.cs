using Example.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Reflection;

namespace Example.Data
{
    public class ExampleDBContext : DbContext, IDbContext
    {
        public ExampleDBContext(DbContextOptions<ExampleDBContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                                  .Where(type => !String.IsNullOrEmpty(type.Namespace))
                                  .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                                   type.BaseType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }

        DbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }


        EntityEntry<TEntity> IDbContext.Entry<TEntity>(TEntity entity)
        {
            return base.Entry<TEntity>(entity);
        }
    }
}
