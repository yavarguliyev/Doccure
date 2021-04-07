﻿using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
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
               .ToTable("Features");
        }
    }
}