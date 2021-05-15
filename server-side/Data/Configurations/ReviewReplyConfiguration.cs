using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ReviewReplyConfiguration : IEntityTypeConfiguration<ReviewReply>
    {
        public void Configure(EntityTypeBuilder<ReviewReply> builder)
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
               .HasOne(x => x.Review)
               .WithMany(x => x.ReviewReplies)
               .HasForeignKey(x => x.ReviewId);

            builder
               .HasOne(x => x.Doctor)
               .WithMany(x => x.ReviewRepliesDoctor)
               .HasForeignKey(x => x.DoctorId);

            builder
               .HasOne(x => x.Patient)
               .WithMany(x => x.ReviewRepliesPatient)
               .HasForeignKey(x => x.PatientId);

            builder
               .ToTable("ReviewReplies");
        }
    }
}