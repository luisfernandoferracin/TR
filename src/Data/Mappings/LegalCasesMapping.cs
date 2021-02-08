using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class LegalCasesMapping : IEntityTypeConfiguration<Case>
    {
        public void Configure(EntityTypeBuilder<Case> builder)
        {
            builder.HasKey(p => p.CaseNumber);

            builder.Property(p => p.CaseNumber)
                .IsRequired()
                .HasColumnType("varchar(24)");                     

            builder.ToTable("LegalCases");
        }
    }
}