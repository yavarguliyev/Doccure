using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
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
                .Property(x => x.Sent)
                .HasMaxLength(100);

            builder
                .Property(x => x.Received)
                .HasMaxLength(100);

            builder
                .Property(x => x.File)
                .HasMaxLength(100);

            builder
               .Property(x => x.IsSeen)
               .IsRequired()
               .HasDefaultValue(false);

            builder
               .HasOne(x => x.User)
               .WithMany(x => x.Chats)
               .HasForeignKey(x => x.UserId);

            builder
               .ToTable("Chats");
        }
    }
}