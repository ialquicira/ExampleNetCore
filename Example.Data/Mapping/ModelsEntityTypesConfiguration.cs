using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Data.Mapping
{
    public abstract class ModelsEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : class
    {
        protected ModelsEntityTypeConfiguration()
        {
            PostInitialize();
        }

        public void Configure(EntityTypeBuilder<T> builder)
        {
            PostInitialize();
        }

        protected virtual void PostInitialize()
        {
        }
    }
}