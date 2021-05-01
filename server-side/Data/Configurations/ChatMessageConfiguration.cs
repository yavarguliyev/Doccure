using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
    {
        public void Configure(EntityTypeBuilder<ChatMessage> builder)
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
                .Property(x => x.DoctorContent)
                .HasMaxLength(100);

            builder
                .Property(x => x.PatientContent)
                .HasMaxLength(100);

            builder
                .Property(x => x.Photo)
                .HasMaxLength(100);

            builder
               .Property(x => x.IsSeen)
               .IsRequired()
               .HasDefaultValue(false);

            builder
               .HasOne(x => x.Chat)
               .WithMany(x => x.ChatMessages)
               .HasForeignKey(x => x.ChatId);

            builder
               .ToTable("ChatMessages");
        }
    }
}