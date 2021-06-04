using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
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
               .HasOne(x => x.Doctor)
               .WithMany(x => x.ReviewsDoctors)
               .HasForeignKey(x => x.DoctorId)
               .OnDelete(DeleteBehavior.Cascade);

            builder
               .HasOne(x => x.Patient)
               .WithMany(x => x.ReviewsPatients)
               .HasForeignKey(x => x.PatientId)
               .OnDelete(DeleteBehavior.Cascade);

            builder
               .ToTable("Reviews");
        }
    }
}