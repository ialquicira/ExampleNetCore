using Example.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;

namespace Example.Data
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly IDbContext _context;
        private DbSet<T> _entities;

        public Repository(IDbContext context)
        {
            this._context = context;
        }

        public IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        public IQueryable<T> TableNotTracking
        {
            get
            {
                return this.Entities.AsNoTracking();
            }
        }

        public EntityEntry<T> Create(T item, string userId)
        {
            var obj = ((T)item);
            obj.CreatedBy = userId;
            obj.DateCreated = DateTime.Now;
            obj.ModifiedBy = userId;
            obj.DateModified = DateTime.Now;

            var pid = this.Entities.Add(obj);
            return pid;

        }

        public void Delete(object id, string userId)
        {
            var entity = this.Entities.Find(id);
            entity.IsDeleted = true;
            entity.DateModified = DateTime.Now;
            entity.ModifiedBy = userId;
        }

        public T Get(object Id)
        {
            var obj = this.Entities.Find(Id);
            if (obj != null)
                _context.Entry(obj).State = EntityState.Detached;
            return obj;
        }

        public IQueryable<T> GetAll(bool showDeleted = false)
        {
            if (showDeleted)
            {
                return this.Entities;
            }
            return this.Entities.Where(o => !o.IsDeleted);
        }

        public void Restore(object id, string userId)
        {
            var entity = this.Entities.Find(id);
            entity.IsDeleted = false;
            entity.DateModified = DateTime.Now;
            entity.ModifiedBy = userId;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T item, string userId)
        {
            var entity = ((T)item);
            entity.DateModified = DateTime.Now;
            entity.ModifiedBy = userId;

            _context.Entry(entity).State = EntityState.Modified;
            _context.Entry<T>(entity).Property(o => o.CreatedBy).IsModified = false;
            _context.Entry<T>(entity).Property(o => o.DateCreated).IsModified = false;
            _context.Entry<T>(entity).Property(o => o.IsDeleted).IsModified = false;
        }

        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }
    }
}