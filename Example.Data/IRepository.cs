using Example.Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace Example.Data
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> Table { get; }
        IQueryable<T> TableNotTracking { get; }
        EntityEntry<T> Create(T item, string userId);
        void Update(T item, string userId);
        void Delete(object id, string userId);
        void Restore(object id, string userId);
        T Get(object Id);
        IQueryable<T> GetAll(bool showDeleted = false);
        void Save();


    }
}