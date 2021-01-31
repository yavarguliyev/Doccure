using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
               .HasKey(x => x.Id);

            builder
               .Property(x => x.Id)
               .ValueGeneratedOnAdd();

            builder
               .Property(x => x.Status)
               .IsRequired()
               .HasDefaultValue(true);

            builder
               .Property(x => x.ModifiedBy)
               .HasMaxLength(100);

            builder
               .Property(x => x.AddedBy)
               .HasMaxLength(100);

            builder
               .Property(x => x.Photo)
               .HasMaxLength(100);

            builder
               .Property(x => x.Fullname)
               .IsRequired()
               .HasMaxLength(50);

            builder
               .Property(x => x.Slug)
               .IsRequired()
               .HasMaxLength(50);

            builder
               .Property(x => x.Email)
               .IsRequired()
               .HasMaxLength(50);

            builder
              .Property(x => x.Password)
              .HasMaxLength(100);
        }
    }
}