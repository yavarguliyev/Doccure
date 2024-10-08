﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Migrations
{
  public partial class Initial : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Admins",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
            AddedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            ModifiedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            AddedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Admins", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "BloodGroups",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
            Name = table.Column<string>(type: "text", nullable: true),
            AddedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            ModifiedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            AddedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_BloodGroups", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Doctors",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
            Type = table.Column<int>(type: "integer", nullable: false),
            Position = table.Column<int>(type: "integer", nullable: false),
            AddedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            ModifiedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            AddedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Doctors", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Features",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
            ClinicName = table.Column<string>(type: "text", nullable: true),
            Photo = table.Column<string>(type: "text", nullable: true),
            AddedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            ModifiedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            AddedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Features", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Privacies",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
            Heading = table.Column<string>(type: "text", nullable: true),
            SubHeading = table.Column<string>(type: "text", nullable: true),
            Body = table.Column<string>(type: "text", nullable: true),
            BodySubHeading = table.Column<string>(type: "text", nullable: true),
            Footer = table.Column<string>(type: "text", nullable: true),
            AddedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            ModifiedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            AddedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Privacies", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Settings",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
            ContactNumber = table.Column<string>(type: "text", nullable: true),
            Address = table.Column<string>(type: "text", nullable: true),
            Email = table.Column<string>(type: "text", nullable: true),
            FooterDesc = table.Column<string>(type: "text", nullable: true),
            FooterSite = table.Column<string>(type: "text", nullable: true),
            HomeBannerTitle = table.Column<string>(type: "text", nullable: true),
            HomeBannerSubTitle = table.Column<string>(type: "text", nullable: true),
            ClinicAndSpecialitiesTitle = table.Column<string>(type: "text", nullable: true),
            ClinicAndSpecialitiesSubTitle = table.Column<string>(type: "text", nullable: true),
            PopularTitle = table.Column<string>(type: "text", nullable: true),
            PopularSubTitle = table.Column<string>(type: "text", nullable: true),
            PopularText = table.Column<string>(type: "text", nullable: true),
            AvailableTitle = table.Column<string>(type: "text", nullable: true),
            AvailableSubTitle = table.Column<string>(type: "text", nullable: true),
            BlogsAndNewsTitle = table.Column<string>(type: "text", nullable: true),
            BlogsAndNewsSubTitle = table.Column<string>(type: "text", nullable: true),
            Information = table.Column<string>(type: "text", nullable: true),
            AddedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            ModifiedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            AddedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Settings", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Specialities",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
            Name = table.Column<string>(type: "text", nullable: true),
            Photo = table.Column<string>(type: "text", nullable: true),
            AddedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            ModifiedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            AddedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Specialities", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Terms",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
            TermHeading = table.Column<string>(type: "text", nullable: true),
            TermSubheading = table.Column<string>(type: "text", nullable: true),
            TermBody = table.Column<string>(type: "text", nullable: true),
            TermFooter = table.Column<string>(type: "text", nullable: true),
            AddedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            ModifiedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            AddedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Terms", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "Patients",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
            Type = table.Column<int>(type: "integer", nullable: false),
            BloodGroupId = table.Column<int>(type: "integer", nullable: true),
            AddedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            ModifiedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            AddedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Patients", x => x.Id);
            table.ForeignKey(
                      name: "FK_Patients_BloodGroups_BloodGroupId",
                      column: x => x.BloodGroupId,
                      principalTable: "BloodGroups",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "Award",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            Title = table.Column<string>(type: "text", nullable: true),
            Year = table.Column<string>(type: "text", nullable: true),
            Bio = table.Column<string>(type: "text", nullable: true),
            DoctorId = table.Column<int>(type: "integer", nullable: true),
            AddedBy = table.Column<string>(type: "text", nullable: true),
            ModifiedBy = table.Column<string>(type: "text", nullable: true),
            AddedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
            ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
            Status = table.Column<bool>(type: "boolean", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Award", x => x.Id);
            table.ForeignKey(
                      name: "FK_Award_Doctors_DoctorId",
                      column: x => x.DoctorId,
                      principalTable: "Doctors",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "Blogs",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
            Title = table.Column<string>(type: "text", nullable: true),
            Slug = table.Column<string>(type: "text", nullable: true),
            Video = table.Column<string>(type: "text", nullable: true),
            Description = table.Column<string>(type: "text", nullable: true),
            Photo = table.Column<string>(type: "text", nullable: true),
            DoctorId = table.Column<int>(type: "integer", nullable: false),
            AddedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            ModifiedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            AddedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Blogs", x => x.Id);
            table.ForeignKey(
                      name: "FK_Blogs_Doctors_DoctorId",
                      column: x => x.DoctorId,
                      principalTable: "Doctors",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "DoctorSocialMediaUrlLinks",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
            FacebookURL = table.Column<string>(type: "text", nullable: true),
            TwitterURL = table.Column<string>(type: "text", nullable: true),
            InstagramURL = table.Column<string>(type: "text", nullable: true),
            PinterestURL = table.Column<string>(type: "text", nullable: true),
            LinkedinURL = table.Column<string>(type: "text", nullable: true),
            DoctorId = table.Column<int>(type: "integer", nullable: false),
            AddedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            ModifiedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            AddedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_DoctorSocialMediaUrlLinks", x => x.Id);
            table.ForeignKey(
                      name: "FK_DoctorSocialMediaUrlLinks_Doctors_DoctorId",
                      column: x => x.DoctorId,
                      principalTable: "Doctors",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "Education",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            Degree = table.Column<string>(type: "text", nullable: true),
            Institute = table.Column<string>(type: "text", nullable: true),
            Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
            End = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
            DoctorId = table.Column<int>(type: "integer", nullable: true),
            AddedBy = table.Column<string>(type: "text", nullable: true),
            ModifiedBy = table.Column<string>(type: "text", nullable: true),
            AddedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
            ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
            Status = table.Column<bool>(type: "boolean", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Education", x => x.Id);
            table.ForeignKey(
                      name: "FK_Education_Doctors_DoctorId",
                      column: x => x.DoctorId,
                      principalTable: "Doctors",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "Experience",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            Name = table.Column<string>(type: "text", nullable: true),
            Designation = table.Column<string>(type: "text", nullable: true),
            Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
            End = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
            DoctorId = table.Column<int>(type: "integer", nullable: true),
            AddedBy = table.Column<string>(type: "text", nullable: true),
            ModifiedBy = table.Column<string>(type: "text", nullable: true),
            AddedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
            ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
            Status = table.Column<bool>(type: "boolean", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Experience", x => x.Id);
            table.ForeignKey(
                      name: "FK_Experience_Doctors_DoctorId",
                      column: x => x.DoctorId,
                      principalTable: "Doctors",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "Service",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            Name = table.Column<string>(type: "text", nullable: true),
            DoctorId = table.Column<int>(type: "integer", nullable: true),
            AddedBy = table.Column<string>(type: "text", nullable: true),
            ModifiedBy = table.Column<string>(type: "text", nullable: true),
            AddedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
            ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
            Status = table.Column<bool>(type: "boolean", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Service", x => x.Id);
            table.ForeignKey(
                      name: "FK_Service_Doctors_DoctorId",
                      column: x => x.DoctorId,
                      principalTable: "Doctors",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "Specialization",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            Name = table.Column<string>(type: "text", nullable: true),
            DoctorId = table.Column<int>(type: "integer", nullable: true),
            AddedBy = table.Column<string>(type: "text", nullable: true),
            ModifiedBy = table.Column<string>(type: "text", nullable: true),
            AddedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
            ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
            Status = table.Column<bool>(type: "boolean", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Specialization", x => x.Id);
            table.ForeignKey(
                      name: "FK_Specialization_Doctors_DoctorId",
                      column: x => x.DoctorId,
                      principalTable: "Doctors",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "SettingPhotos",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
            Name = table.Column<string>(type: "text", nullable: true),
            Photo = table.Column<string>(type: "text", nullable: true),
            PhotoURL = table.Column<string>(type: "text", nullable: true),
            SettingId = table.Column<int>(type: "integer", nullable: false),
            AddedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            ModifiedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            AddedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_SettingPhotos", x => x.Id);
            table.ForeignKey(
                      name: "FK_SettingPhotos_Settings_SettingId",
                      column: x => x.SettingId,
                      principalTable: "Settings",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "SocialMedias",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
            Icon = table.Column<string>(type: "text", nullable: true),
            Name = table.Column<string>(type: "text", nullable: true),
            Link = table.Column<string>(type: "text", nullable: true),
            SettingId = table.Column<int>(type: "integer", nullable: false),
            AddedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            ModifiedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            AddedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_SocialMedias", x => x.Id);
            table.ForeignKey(
                      name: "FK_SocialMedias_Settings_SettingId",
                      column: x => x.SettingId,
                      principalTable: "Settings",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "Users",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
            Code = table.Column<string>(type: "text", nullable: true),
            Photo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            PhotoURL = table.Column<string>(type: "text", nullable: true),
            Fullname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
            Slug = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
            Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
            Birth = table.Column<DateTime>(type: "date", nullable: false),
            Phone = table.Column<string>(type: "text", nullable: true),
            Password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            Biography = table.Column<string>(type: "text", nullable: true),
            PostalCode = table.Column<string>(type: "text", nullable: true),
            Address = table.Column<string>(type: "text", nullable: true),
            City = table.Column<string>(type: "text", nullable: true),
            State = table.Column<string>(type: "text", nullable: true),
            Country = table.Column<string>(type: "text", nullable: true),
            Role = table.Column<int>(type: "integer", nullable: false),
            Gender = table.Column<int>(type: "integer", nullable: false),
            Token = table.Column<string>(type: "text", nullable: true),
            InviteToken = table.Column<string>(type: "text", nullable: true),
            ConfirmToken = table.Column<string>(type: "text", nullable: true),
            ConnectionId = table.Column<string>(type: "text", nullable: true),
            AdminId = table.Column<int>(type: "integer", nullable: true),
            DoctorId = table.Column<int>(type: "integer", nullable: true),
            PatientId = table.Column<int>(type: "integer", nullable: true),
            AddedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            ModifiedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            AddedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Users", x => x.Id);
            table.ForeignKey(
                      name: "FK_Users_Admins_AdminId",
                      column: x => x.AdminId,
                      principalTable: "Admins",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
            table.ForeignKey(
                      name: "FK_Users_Doctors_DoctorId",
                      column: x => x.DoctorId,
                      principalTable: "Doctors",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_Users_Patients_PatientId",
                      column: x => x.PatientId,
                      principalTable: "Patients",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "Chats",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
            DoctorId = table.Column<int>(type: "integer", nullable: false),
            PatientId = table.Column<int>(type: "integer", nullable: false),
            InviteToken = table.Column<string>(type: "text", nullable: true),
            AddedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            ModifiedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            AddedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Chats", x => x.Id);
            table.ForeignKey(
                      name: "FK_Chats_Users_DoctorId",
                      column: x => x.DoctorId,
                      principalTable: "Users",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_Chats_Users_PatientId",
                      column: x => x.PatientId,
                      principalTable: "Users",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "Comments",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
            UserId = table.Column<int>(type: "integer", nullable: false),
            BlogId = table.Column<int>(type: "integer", nullable: false),
            Text = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            IsReply = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
            AddedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            ModifiedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            AddedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Comments", x => x.Id);
            table.ForeignKey(
                      name: "FK_Comments_Blogs_BlogId",
                      column: x => x.BlogId,
                      principalTable: "Blogs",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_Comments_Users_UserId",
                      column: x => x.UserId,
                      principalTable: "Users",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "Reviews",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
            RateStar = table.Column<string>(type: "text", nullable: true),
            RateNumber = table.Column<int>(type: "integer", nullable: false),
            Text = table.Column<string>(type: "text", nullable: true),
            IsReply = table.Column<bool>(type: "boolean", nullable: false),
            Recommendation = table.Column<int>(type: "integer", nullable: false),
            DoctorId = table.Column<int>(type: "integer", nullable: false),
            PatientId = table.Column<int>(type: "integer", nullable: false),
            AddedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            ModifiedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            AddedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Reviews", x => x.Id);
            table.ForeignKey(
                      name: "FK_Reviews_Users_DoctorId",
                      column: x => x.DoctorId,
                      principalTable: "Users",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_Reviews_Users_PatientId",
                      column: x => x.PatientId,
                      principalTable: "Users",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "ChatMessages",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
            DoctorContent = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            PatientContent = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            Photo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            PhotoURL = table.Column<string>(type: "text", nullable: true),
            IsSeen = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
            ChatId = table.Column<int>(type: "integer", nullable: false),
            AddedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            ModifiedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            AddedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_ChatMessages", x => x.Id);
            table.ForeignKey(
                      name: "FK_ChatMessages_Chats_ChatId",
                      column: x => x.ChatId,
                      principalTable: "Chats",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "CommentReplies",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
            CommentId = table.Column<int>(type: "integer", nullable: false),
            UserId = table.Column<int>(type: "integer", nullable: false),
            Text = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            AddedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            ModifiedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            AddedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_CommentReplies", x => x.Id);
            table.ForeignKey(
                      name: "FK_CommentReplies_Comments_CommentId",
                      column: x => x.CommentId,
                      principalTable: "Comments",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_CommentReplies_Users_UserId",
                      column: x => x.UserId,
                      principalTable: "Users",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "ReviewReplies",
          columns: table => new
          {
            Id = table.Column<int>(type: "integer", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
            Text = table.Column<string>(type: "text", nullable: true),
            PatientId = table.Column<int>(type: "integer", nullable: true),
            DoctorId = table.Column<int>(type: "integer", nullable: true),
            ReviewId = table.Column<int>(type: "integer", nullable: false),
            AddedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            ModifiedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
            AddedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: false),
            Status = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_ReviewReplies", x => x.Id);
            table.ForeignKey(
                      name: "FK_ReviewReplies_Reviews_ReviewId",
                      column: x => x.ReviewId,
                      principalTable: "Reviews",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_ReviewReplies_Users_DoctorId",
                      column: x => x.DoctorId,
                      principalTable: "Users",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_ReviewReplies_Users_PatientId",
                      column: x => x.PatientId,
                      principalTable: "Users",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateIndex(
          name: "IX_Award_DoctorId",
          table: "Award",
          column: "DoctorId");

      migrationBuilder.CreateIndex(
          name: "IX_Blogs_DoctorId",
          table: "Blogs",
          column: "DoctorId");

      migrationBuilder.CreateIndex(
          name: "IX_ChatMessages_ChatId",
          table: "ChatMessages",
          column: "ChatId");

      migrationBuilder.CreateIndex(
          name: "IX_Chats_DoctorId",
          table: "Chats",
          column: "DoctorId");

      migrationBuilder.CreateIndex(
          name: "IX_Chats_PatientId",
          table: "Chats",
          column: "PatientId");

      migrationBuilder.CreateIndex(
          name: "IX_CommentReplies_CommentId",
          table: "CommentReplies",
          column: "CommentId");

      migrationBuilder.CreateIndex(
          name: "IX_CommentReplies_UserId",
          table: "CommentReplies",
          column: "UserId");

      migrationBuilder.CreateIndex(
          name: "IX_Comments_BlogId",
          table: "Comments",
          column: "BlogId");

      migrationBuilder.CreateIndex(
          name: "IX_Comments_UserId",
          table: "Comments",
          column: "UserId");

      migrationBuilder.CreateIndex(
          name: "IX_DoctorSocialMediaUrlLinks_DoctorId",
          table: "DoctorSocialMediaUrlLinks",
          column: "DoctorId");

      migrationBuilder.CreateIndex(
          name: "IX_Education_DoctorId",
          table: "Education",
          column: "DoctorId");

      migrationBuilder.CreateIndex(
          name: "IX_Experience_DoctorId",
          table: "Experience",
          column: "DoctorId");

      migrationBuilder.CreateIndex(
          name: "IX_Patients_BloodGroupId",
          table: "Patients",
          column: "BloodGroupId");

      migrationBuilder.CreateIndex(
          name: "IX_ReviewReplies_DoctorId",
          table: "ReviewReplies",
          column: "DoctorId");

      migrationBuilder.CreateIndex(
          name: "IX_ReviewReplies_PatientId",
          table: "ReviewReplies",
          column: "PatientId");

      migrationBuilder.CreateIndex(
          name: "IX_ReviewReplies_ReviewId",
          table: "ReviewReplies",
          column: "ReviewId");

      migrationBuilder.CreateIndex(
          name: "IX_Reviews_DoctorId",
          table: "Reviews",
          column: "DoctorId");

      migrationBuilder.CreateIndex(
          name: "IX_Reviews_PatientId",
          table: "Reviews",
          column: "PatientId");

      migrationBuilder.CreateIndex(
          name: "IX_Service_DoctorId",
          table: "Service",
          column: "DoctorId");

      migrationBuilder.CreateIndex(
          name: "IX_SettingPhotos_SettingId",
          table: "SettingPhotos",
          column: "SettingId");

      migrationBuilder.CreateIndex(
          name: "IX_SocialMedias_SettingId",
          table: "SocialMedias",
          column: "SettingId");

      migrationBuilder.CreateIndex(
          name: "IX_Specialization_DoctorId",
          table: "Specialization",
          column: "DoctorId");

      migrationBuilder.CreateIndex(
          name: "IX_Users_AdminId",
          table: "Users",
          column: "AdminId");

      migrationBuilder.CreateIndex(
          name: "IX_Users_DoctorId",
          table: "Users",
          column: "DoctorId");

      migrationBuilder.CreateIndex(
          name: "IX_Users_PatientId",
          table: "Users",
          column: "PatientId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Award");

      migrationBuilder.DropTable(
          name: "ChatMessages");

      migrationBuilder.DropTable(
          name: "CommentReplies");

      migrationBuilder.DropTable(
          name: "DoctorSocialMediaUrlLinks");

      migrationBuilder.DropTable(
          name: "Education");

      migrationBuilder.DropTable(
          name: "Experience");

      migrationBuilder.DropTable(
          name: "Features");

      migrationBuilder.DropTable(
          name: "Privacies");

      migrationBuilder.DropTable(
          name: "ReviewReplies");

      migrationBuilder.DropTable(
          name: "Service");

      migrationBuilder.DropTable(
          name: "SettingPhotos");

      migrationBuilder.DropTable(
          name: "SocialMedias");

      migrationBuilder.DropTable(
          name: "Specialities");

      migrationBuilder.DropTable(
          name: "Specialization");

      migrationBuilder.DropTable(
          name: "Terms");

      migrationBuilder.DropTable(
          name: "Chats");

      migrationBuilder.DropTable(
          name: "Comments");

      migrationBuilder.DropTable(
          name: "Reviews");

      migrationBuilder.DropTable(
          name: "Settings");

      migrationBuilder.DropTable(
          name: "Blogs");

      migrationBuilder.DropTable(
          name: "Users");

      migrationBuilder.DropTable(
          name: "Admins");

      migrationBuilder.DropTable(
          name: "Doctors");

      migrationBuilder.DropTable(
          name: "Patients");

      migrationBuilder.DropTable(
          name: "BloodGroups");
    }
  }
}
