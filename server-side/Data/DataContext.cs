using Core.Models;
using Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

            builder.ApplyConfiguration(new AdminConfiguration());
            builder.ApplyConfiguration(new DoctorConfiguration());
            builder.ApplyConfiguration(new PatientConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());

            builder.ApplyConfiguration(new BloodGroupConfiguration());
            builder.ApplyConfiguration(new DoctorSocialMediaUrlLinkConfiguration());
            builder.ApplyConfiguration(new SocialMediaConfiguration());
            builder.ApplyConfiguration(new SettingConfiguration());
            builder.ApplyConfiguration(new SettingPhotoConfiguration());
            builder.ApplyConfiguration(new PrivacyConfiguration());
            builder.ApplyConfiguration(new TermConfiguration());
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<BloodGroup> BloodGroups { get; set; }
        public DbSet<DoctorSocialMediaUrlLink> DoctorSocialMediaUrlLinks { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<SettingPhoto> SettingPhotos { get; set; }
        public DbSet<Privacy> Privacies { get; set; }
        public DbSet<Term> Terms { get; set; }
    }
}