using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProject.Domain.Entities;

namespace MyProject.Infrastructure.Data.Configurations;

public class HomeChoreConfiguration : IEntityTypeConfiguration<HomeChore>
{
    public void Configure(EntityTypeBuilder<HomeChore> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(t => t.Priority)
            .HasConversion<int>();
    }
}
