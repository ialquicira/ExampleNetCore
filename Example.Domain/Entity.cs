using System;

namespace Example.Domain
{
    public class Entity : IEntity
    {
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsDeleted { get; set; }
    }

    public interface IDel
    {
        bool IsDeleted { get; set; }
    }
    public interface IEntity : IDel
    {
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
        DateTime? DateCreated { get; set; }
        DateTime? DateModified { get; set; }
    }
}