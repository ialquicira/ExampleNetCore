using Example.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Example.Data
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : Entity;
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : Entity;
        int SaveChanges();
    }
}
