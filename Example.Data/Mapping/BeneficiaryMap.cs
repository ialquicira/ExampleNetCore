using Example.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Data.Mapping
{
    public class BeneficiaryMap : IEntityTypeConfiguration<Beneficiary>
    {
        public void Configure(EntityTypeBuilder<Beneficiary> builder)
        {
            builder.ToTable("Beneficiaries");
            builder.HasKey(x => x.BeneficiaryId);
            builder.HasOne(p => p.Employee)
                   .WithMany()
                   .HasForeignKey(f => f.EmployeeId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}