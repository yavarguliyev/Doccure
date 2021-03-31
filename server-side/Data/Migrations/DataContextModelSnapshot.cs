﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Migrations
{
  [DbContext(typeof(DataContext))]
  partial class DataContextModelSnapshot : ModelSnapshot
  {
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
      modelBuilder
          .HasAnnotation("Relational:MaxIdentifierLength", 63)
          .HasAnnotation("ProductVersion", "5.0.4")
          .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

      modelBuilder.Entity("Core.Models.Admin", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("integer")
                      .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

            b.Property<string>("AddedBy")
                      .HasMaxLength(100)
                      .HasColumnType("character varying(100)");

            b.Property<DateTime>("AddedDate")
                      .HasColumnType("timestamp");

            b.Property<string>("ModifiedBy")
                      .HasMaxLength(100)
                      .HasColumnType("character varying(100)");

            b.Property<DateTime>("ModifiedDate")
                      .HasColumnType("timestamp");

            b.Property<bool>("Status")
                      .HasColumnType("boolean")
                      .HasDefaultValue(true);

            b.HasKey("Id");

            b.ToTable("Admins");
          });

      modelBuilder.Entity("Core.Models.Award", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("integer")
                      .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            b.Property<string>("AddedBy")
                      .HasColumnType("text");

            b.Property<DateTime>("AddedDate")
                      .HasColumnType("timestamp without time zone");

            b.Property<string>("Bio")
                      .HasColumnType("text");

            b.Property<int?>("DoctorId")
                      .HasColumnType("integer");

            b.Property<string>("ModifiedBy")
                      .HasColumnType("text");

            b.Property<DateTime>("ModifiedDate")
                      .HasColumnType("timestamp without time zone");

            b.Property<bool>("Status")
                      .HasColumnType("boolean");

            b.Property<string>("Title")
                      .HasColumnType("text");

            b.Property<string>("Year")
                      .HasColumnType("text");

            b.HasKey("Id");

            b.HasIndex("DoctorId");

            b.ToTable("Award");
          });

      modelBuilder.Entity("Core.Models.BloodGroup", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("integer")
                      .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

            b.Property<string>("AddedBy")
                      .HasMaxLength(100)
                      .HasColumnType("character varying(100)");

            b.Property<DateTime>("AddedDate")
                      .HasColumnType("timestamp");

            b.Property<string>("ModifiedBy")
                      .HasMaxLength(100)
                      .HasColumnType("character varying(100)");

            b.Property<DateTime>("ModifiedDate")
                      .HasColumnType("timestamp");

            b.Property<string>("Name")
                      .HasColumnType("text");

            b.Property<bool>("Status")
                      .HasColumnType("boolean")
                      .HasDefaultValue(true);

            b.HasKey("Id");

            b.ToTable("BloodGroups");
          });

      modelBuilder.Entity("Core.Models.Doctor", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("integer")
                      .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

            b.Property<string>("AddedBy")
                      .HasMaxLength(100)
                      .HasColumnType("character varying(100)");

            b.Property<DateTime>("AddedDate")
                      .HasColumnType("timestamp");

            b.Property<string>("ModifiedBy")
                      .HasMaxLength(100)
                      .HasColumnType("character varying(100)");

            b.Property<DateTime>("ModifiedDate")
                      .HasColumnType("timestamp");

            b.Property<int>("Position")
                      .HasColumnType("integer");

            b.Property<bool>("Status")
                      .HasColumnType("boolean")
                      .HasDefaultValue(true);

            b.Property<int>("Type")
                      .HasColumnType("integer");

            b.HasKey("Id");

            b.ToTable("Doctors");
          });

      modelBuilder.Entity("Core.Models.DoctorSocialMediaUrlLink", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("integer")
                      .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

            b.Property<string>("AddedBy")
                      .HasMaxLength(100)
                      .HasColumnType("character varying(100)");

            b.Property<DateTime>("AddedDate")
                      .HasColumnType("timestamp");

            b.Property<int>("DoctorId")
                      .HasColumnType("integer");

            b.Property<string>("FacebookURL")
                      .HasColumnType("text");

            b.Property<string>("InstagramURL")
                      .HasColumnType("text");

            b.Property<string>("LinkedinURL")
                      .HasColumnType("text");

            b.Property<string>("ModifiedBy")
                      .HasMaxLength(100)
                      .HasColumnType("character varying(100)");

            b.Property<DateTime>("ModifiedDate")
                      .HasColumnType("timestamp");

            b.Property<string>("PinterestURL")
                      .HasColumnType("text");

            b.Property<bool>("Status")
                      .HasColumnType("boolean")
                      .HasDefaultValue(true);

            b.Property<string>("TwitterURL")
                      .HasColumnType("text");

            b.HasKey("Id");

            b.HasIndex("DoctorId");

            b.ToTable("DoctorSocialMediaUrlLinks");
          });

      modelBuilder.Entity("Core.Models.Education", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("integer")
                      .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            b.Property<string>("AddedBy")
                      .HasColumnType("text");

            b.Property<DateTime>("AddedDate")
                      .HasColumnType("timestamp without time zone");

            b.Property<string>("Degree")
                      .HasColumnType("text");

            b.Property<int?>("DoctorId")
                      .HasColumnType("integer");

            b.Property<DateTime>("End")
                      .HasColumnType("timestamp without time zone");

            b.Property<string>("Institute")
                      .HasColumnType("text");

            b.Property<string>("ModifiedBy")
                      .HasColumnType("text");

            b.Property<DateTime>("ModifiedDate")
                      .HasColumnType("timestamp without time zone");

            b.Property<DateTime>("Start")
                      .HasColumnType("timestamp without time zone");

            b.Property<bool>("Status")
                      .HasColumnType("boolean");

            b.HasKey("Id");

            b.HasIndex("DoctorId");

            b.ToTable("Education");
          });

      modelBuilder.Entity("Core.Models.Experience", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("integer")
                      .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            b.Property<string>("AddedBy")
                      .HasColumnType("text");

            b.Property<DateTime>("AddedDate")
                      .HasColumnType("timestamp without time zone");

            b.Property<string>("Designation")
                      .HasColumnType("text");

            b.Property<int?>("DoctorId")
                      .HasColumnType("integer");

            b.Property<DateTime?>("End")
                      .HasColumnType("timestamp without time zone");

            b.Property<string>("ModifiedBy")
                      .HasColumnType("text");

            b.Property<DateTime>("ModifiedDate")
                      .HasColumnType("timestamp without time zone");

            b.Property<string>("Name")
                      .HasColumnType("text");

            b.Property<DateTime>("Start")
                      .HasColumnType("timestamp without time zone");

            b.Property<bool>("Status")
                      .HasColumnType("boolean");

            b.HasKey("Id");

            b.HasIndex("DoctorId");

            b.ToTable("Experience");
          });

      modelBuilder.Entity("Core.Models.Patient", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("integer")
                      .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

            b.Property<string>("AddedBy")
                      .HasMaxLength(100)
                      .HasColumnType("character varying(100)");

            b.Property<DateTime>("AddedDate")
                      .HasColumnType("timestamp");

            b.Property<int?>("BloodGroupId")
                      .HasColumnType("integer");

            b.Property<string>("ModifiedBy")
                      .HasMaxLength(100)
                      .HasColumnType("character varying(100)");

            b.Property<DateTime>("ModifiedDate")
                      .HasColumnType("timestamp");

            b.Property<bool>("Status")
                      .HasColumnType("boolean")
                      .HasDefaultValue(true);

            b.Property<int>("Type")
                      .HasColumnType("integer");

            b.HasKey("Id");

            b.HasIndex("BloodGroupId");

            b.ToTable("Patients");
          });

      modelBuilder.Entity("Core.Models.Privacy", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("integer")
                      .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

            b.Property<string>("AddedBy")
                      .HasMaxLength(100)
                      .HasColumnType("character varying(100)");

            b.Property<DateTime>("AddedDate")
                      .HasColumnType("timestamp");

            b.Property<string>("Body")
                      .HasColumnType("text");

            b.Property<string>("BodySubHeading")
                      .HasColumnType("text");

            b.Property<string>("Footer")
                      .HasColumnType("text");

            b.Property<string>("Heading")
                      .HasColumnType("text");

            b.Property<string>("ModifiedBy")
                      .HasMaxLength(100)
                      .HasColumnType("character varying(100)");

            b.Property<DateTime>("ModifiedDate")
                      .HasColumnType("timestamp");

            b.Property<bool>("Status")
                      .HasColumnType("boolean")
                      .HasDefaultValue(true);

            b.Property<string>("SubHeading")
                      .HasColumnType("text");

            b.HasKey("Id");

            b.ToTable("Privacies");
          });

      modelBuilder.Entity("Core.Models.Service", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("integer")
                      .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            b.Property<string>("AddedBy")
                      .HasColumnType("text");

            b.Property<DateTime>("AddedDate")
                      .HasColumnType("timestamp without time zone");

            b.Property<int?>("DoctorId")
                      .HasColumnType("integer");

            b.Property<string>("ModifiedBy")
                      .HasColumnType("text");

            b.Property<DateTime>("ModifiedDate")
                      .HasColumnType("timestamp without time zone");

            b.Property<string>("Name")
                      .HasColumnType("text");

            b.Property<bool>("Status")
                      .HasColumnType("boolean");

            b.HasKey("Id");

            b.HasIndex("DoctorId");

            b.ToTable("Service");
          });

      modelBuilder.Entity("Core.Models.Setting", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("integer")
                      .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

            b.Property<string>("AddedBy")
                      .HasMaxLength(100)
                      .HasColumnType("character varying(100)");

            b.Property<DateTime>("AddedDate")
                      .HasColumnType("timestamp");

            b.Property<string>("Address")
                      .HasColumnType("text");

            b.Property<string>("AvailableSubTitle")
                      .HasColumnType("text");

            b.Property<string>("AvailableTitle")
                      .HasColumnType("text");

            b.Property<string>("BlogsAndNewsSubTitle")
                      .HasColumnType("text");

            b.Property<string>("BlogsAndNewsTitle")
                      .HasColumnType("text");

            b.Property<string>("ClinicAndSpecialitiesSubTitle")
                      .HasColumnType("text");

            b.Property<string>("ClinicAndSpecialitiesTitle")
                      .HasColumnType("text");

            b.Property<string>("ContactNumber")
                      .HasColumnType("text");

            b.Property<string>("Email")
                      .HasColumnType("text");

            b.Property<string>("FooterDesc")
                      .HasColumnType("text");

            b.Property<string>("FooterSite")
                      .HasColumnType("text");

            b.Property<string>("HomeBannerSubTitle")
                      .HasColumnType("text");

            b.Property<string>("HomeBannerTitle")
                      .HasColumnType("text");

            b.Property<string>("Information")
                      .HasColumnType("text");

            b.Property<string>("ModifiedBy")
                      .HasMaxLength(100)
                      .HasColumnType("character varying(100)");

            b.Property<DateTime>("ModifiedDate")
                      .HasColumnType("timestamp");

            b.Property<string>("PopularSubTitle")
                      .HasColumnType("text");

            b.Property<string>("PopularText")
                      .HasColumnType("text");

            b.Property<string>("PopularTitle")
                      .HasColumnType("text");

            b.Property<bool>("Status")
                      .HasColumnType("boolean")
                      .HasDefaultValue(true);

            b.HasKey("Id");

            b.ToTable("Settings");
          });

      modelBuilder.Entity("Core.Models.SettingPhoto", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("integer")
                      .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

            b.Property<string>("AddedBy")
                      .HasMaxLength(100)
                      .HasColumnType("character varying(100)");

            b.Property<DateTime>("AddedDate")
                      .HasColumnType("timestamp");

            b.Property<string>("ModifiedBy")
                      .HasMaxLength(100)
                      .HasColumnType("character varying(100)");

            b.Property<DateTime>("ModifiedDate")
                      .HasColumnType("timestamp");

            b.Property<string>("Name")
                      .HasColumnType("text");

            b.Property<string>("Photo")
                      .HasColumnType("text");

            b.Property<int>("SettingId")
                      .HasColumnType("integer");

            b.Property<bool>("Status")
                      .HasColumnType("boolean")
                      .HasDefaultValue(true);

            b.HasKey("Id");

            b.HasIndex("SettingId");

            b.ToTable("SettingPhotos");
          });

      modelBuilder.Entity("Core.Models.SocialMedia", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("integer")
                      .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

            b.Property<string>("AddedBy")
                      .HasMaxLength(100)
                      .HasColumnType("character varying(100)");

            b.Property<DateTime>("AddedDate")
                      .HasColumnType("timestamp");

            b.Property<string>("Icon")
                      .HasColumnType("text");

            b.Property<string>("Link")
                      .HasColumnType("text");

            b.Property<string>("ModifiedBy")
                      .HasMaxLength(100)
                      .HasColumnType("character varying(100)");

            b.Property<DateTime>("ModifiedDate")
                      .HasColumnType("timestamp");

            b.Property<string>("Name")
                      .HasColumnType("text");

            b.Property<int>("SettingId")
                      .HasColumnType("integer");

            b.Property<bool>("Status")
                      .HasColumnType("boolean")
                      .HasDefaultValue(true);

            b.HasKey("Id");

            b.HasIndex("SettingId");

            b.ToTable("SocialMedias");
          });

      modelBuilder.Entity("Core.Models.Specialization", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("integer")
                      .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            b.Property<string>("AddedBy")
                      .HasColumnType("text");

            b.Property<DateTime>("AddedDate")
                      .HasColumnType("timestamp without time zone");

            b.Property<int?>("DoctorId")
                      .HasColumnType("integer");

            b.Property<string>("ModifiedBy")
                      .HasColumnType("text");

            b.Property<DateTime>("ModifiedDate")
                      .HasColumnType("timestamp without time zone");

            b.Property<string>("Name")
                      .HasColumnType("text");

            b.Property<bool>("Status")
                      .HasColumnType("boolean");

            b.HasKey("Id");

            b.HasIndex("DoctorId");

            b.ToTable("Specialization");
          });

      modelBuilder.Entity("Core.Models.Term", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("integer")
                      .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

            b.Property<string>("AddedBy")
                      .HasMaxLength(100)
                      .HasColumnType("character varying(100)");

            b.Property<DateTime>("AddedDate")
                      .HasColumnType("timestamp");

            b.Property<string>("ModifiedBy")
                      .HasMaxLength(100)
                      .HasColumnType("character varying(100)");

            b.Property<DateTime>("ModifiedDate")
                      .HasColumnType("timestamp");

            b.Property<bool>("Status")
                      .HasColumnType("boolean")
                      .HasDefaultValue(true);

            b.Property<string>("TermBody")
                      .HasColumnType("text");

            b.Property<string>("TermFooter")
                      .HasColumnType("text");

            b.Property<string>("TermHeading")
                      .HasColumnType("text");

            b.Property<string>("TermSubheading")
                      .HasColumnType("text");

            b.HasKey("Id");

            b.ToTable("Terms");
          });

      modelBuilder.Entity("Core.Models.User", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("integer")
                      .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

            b.Property<string>("AddedBy")
                      .HasMaxLength(100)
                      .HasColumnType("character varying(100)");

            b.Property<DateTime>("AddedDate")
                      .HasColumnType("timestamp");

            b.Property<string>("Address")
                      .HasColumnType("text");

            b.Property<int?>("AdminId")
                      .HasColumnType("integer");

            b.Property<string>("Biography")
                      .HasColumnType("text");

            b.Property<DateTime>("Birth")
                      .HasColumnType("date");

            b.Property<string>("City")
                      .HasColumnType("text");

            b.Property<string>("Code")
                      .HasColumnType("text");

            b.Property<string>("ConfirmToken")
                      .HasColumnType("text");

            b.Property<string>("ConnectionId")
                      .HasColumnType("text");

            b.Property<string>("Country")
                      .HasColumnType("text");

            b.Property<int?>("DoctorId")
                      .HasColumnType("integer");

            b.Property<string>("Email")
                      .HasMaxLength(50)
                      .HasColumnType("character varying(50)");

            b.Property<string>("Fullname")
                      .HasMaxLength(50)
                      .HasColumnType("character varying(50)");

            b.Property<int>("Gender")
                      .HasColumnType("integer");

            b.Property<string>("InviteToken")
                      .HasColumnType("text");

            b.Property<string>("ModifiedBy")
                      .HasMaxLength(100)
                      .HasColumnType("character varying(100)");

            b.Property<DateTime>("ModifiedDate")
                      .HasColumnType("timestamp");

            b.Property<string>("Password")
                      .HasMaxLength(100)
                      .HasColumnType("character varying(100)");

            b.Property<int?>("PatientId")
                      .HasColumnType("integer");

            b.Property<string>("Phone")
                      .HasColumnType("text");

            b.Property<string>("Photo")
                      .HasMaxLength(100)
                      .HasColumnType("character varying(100)");

            b.Property<string>("PostalCode")
                      .HasColumnType("text");

            b.Property<int>("Role")
                      .HasColumnType("integer");

            b.Property<string>("Slug")
                      .HasMaxLength(50)
                      .HasColumnType("character varying(50)");

            b.Property<string>("State")
                      .HasColumnType("text");

            b.Property<bool>("Status")
                      .HasColumnType("boolean")
                      .HasDefaultValue(true);

            b.Property<string>("Token")
                      .HasColumnType("text");

            b.HasKey("Id");

            b.HasIndex("AdminId");

            b.HasIndex("DoctorId");

            b.HasIndex("PatientId");

            b.ToTable("Users");
          });

      modelBuilder.Entity("Core.Models.Award", b =>
          {
            b.HasOne("Core.Models.Doctor", "Doctor")
                      .WithMany("Awards")
                      .HasForeignKey("DoctorId");

            b.Navigation("Doctor");
          });

      modelBuilder.Entity("Core.Models.DoctorSocialMediaUrlLink", b =>
          {
            b.HasOne("Core.Models.Doctor", "Doctor")
                      .WithMany("DoctorSocialMediaUrlLinks")
                      .HasForeignKey("DoctorId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.Navigation("Doctor");
          });

      modelBuilder.Entity("Core.Models.Education", b =>
          {
            b.HasOne("Core.Models.Doctor", "Doctor")
                      .WithMany("Educations")
                      .HasForeignKey("DoctorId");

            b.Navigation("Doctor");
          });

      modelBuilder.Entity("Core.Models.Experience", b =>
          {
            b.HasOne("Core.Models.Doctor", "Doctor")
                      .WithMany("Experiences")
                      .HasForeignKey("DoctorId");

            b.Navigation("Doctor");
          });

      modelBuilder.Entity("Core.Models.Patient", b =>
          {
            b.HasOne("Core.Models.BloodGroup", "BloodGroup")
                      .WithMany("Patients")
                      .HasForeignKey("BloodGroupId");

            b.Navigation("BloodGroup");
          });

      modelBuilder.Entity("Core.Models.Service", b =>
          {
            b.HasOne("Core.Models.Doctor", "Doctor")
                      .WithMany("Services")
                      .HasForeignKey("DoctorId");

            b.Navigation("Doctor");
          });

      modelBuilder.Entity("Core.Models.SettingPhoto", b =>
          {
            b.HasOne("Core.Models.Setting", "Setting")
                      .WithMany("SettingPhotos")
                      .HasForeignKey("SettingId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.Navigation("Setting");
          });

      modelBuilder.Entity("Core.Models.SocialMedia", b =>
          {
            b.HasOne("Core.Models.Setting", "Setting")
                      .WithMany("SocialMedias")
                      .HasForeignKey("SettingId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.Navigation("Setting");
          });

      modelBuilder.Entity("Core.Models.Specialization", b =>
          {
            b.HasOne("Core.Models.Doctor", "Doctor")
                      .WithMany("Specializations")
                      .HasForeignKey("DoctorId");

            b.Navigation("Doctor");
          });

      modelBuilder.Entity("Core.Models.User", b =>
          {
            b.HasOne("Core.Models.Admin", "Admin")
                      .WithMany("Users")
                      .HasForeignKey("AdminId");

            b.HasOne("Core.Models.Doctor", "Doctor")
                      .WithMany("Users")
                      .HasForeignKey("DoctorId");

            b.HasOne("Core.Models.Patient", "Patient")
                      .WithMany("Users")
                      .HasForeignKey("PatientId");

            b.Navigation("Admin");

            b.Navigation("Doctor");

            b.Navigation("Patient");
          });

      modelBuilder.Entity("Core.Models.Admin", b =>
          {
            b.Navigation("Users");
          });

      modelBuilder.Entity("Core.Models.BloodGroup", b =>
          {
            b.Navigation("Patients");
          });

      modelBuilder.Entity("Core.Models.Doctor", b =>
          {
            b.Navigation("Awards");

            b.Navigation("DoctorSocialMediaUrlLinks");

            b.Navigation("Educations");

            b.Navigation("Experiences");

            b.Navigation("Services");

            b.Navigation("Specializations");

            b.Navigation("Users");
          });

      modelBuilder.Entity("Core.Models.Patient", b =>
          {
            b.Navigation("Users");
          });

      modelBuilder.Entity("Core.Models.Setting", b =>
          {
            b.Navigation("SettingPhotos");

            b.Navigation("SocialMedias");
          });
#pragma warning restore 612, 618
    }
  }
}
