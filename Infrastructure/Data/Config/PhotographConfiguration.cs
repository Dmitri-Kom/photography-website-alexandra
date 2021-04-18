using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class PhotographConfiguration : IEntityTypeConfiguration<Photograph>
    {
        public void Configure(EntityTypeBuilder<Photograph> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Url).IsRequired();
            builder.HasOne(t => t.PhotographLocation).WithMany()
                    .HasForeignKey(p => p.PhotographLocationId);
        }
    }
}