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
               .ValueGeneratedOnAdd()
               .UseIdentityAlwaysColumn();

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
              .Property(x => x.AddedDate)
              .HasColumnType("timestamp");

            builder
              .Property(x => x.ModifiedDate)
              .HasColumnType("timestamp");

            builder
               .HasOne(x => x.Admin)
               .WithMany(x => x.Users)
               .HasForeignKey(x => x.AdminId);

            builder
               .HasOne(x => x.Doctor)
               .WithMany(x => x.Users)
               .HasForeignKey(x => x.DoctorId);

            builder
               .HasOne(x => x.Patient)
               .WithMany(x => x.Users)
               .HasForeignKey(x => x.PatientId);

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

            builder
              .Property(x => x.Birth)
              .HasColumnType("date");

            builder
               .ToTable("Users");
        }
    }
}