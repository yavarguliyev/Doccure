using Core.Models.Hubs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder
               .Property(x => x.Name)
               .HasMaxLength(100);

            builder
               .HasMany(x => x.Connections)
               .WithOne()
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}