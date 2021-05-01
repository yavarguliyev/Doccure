using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
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
                .Property(x => x.Text)
                .HasMaxLength(100);

            builder
               .HasOne(x => x.User)
               .WithMany(x => x.Comments)
               .HasForeignKey(x => x.UserId);

            builder
               .HasOne(x => x.Blog)
               .WithMany(x => x.Comments)
               .HasForeignKey(x => x.BlogId);

            builder
               .Property(x => x.IsReply)
               .IsRequired()
               .HasDefaultValue(false);

            builder
               .ToTable("Comments");
        }
    }
}