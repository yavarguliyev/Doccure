using Core.Enum;
using Core.Models;
using CryptoHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Data_Seed
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (!context.BloodGroups.Any())
            {
                var bloodGroups = new List<BloodGroup>
                {
                    new BloodGroup
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Name = "A-"
                    },
                    new BloodGroup
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Name = "A+"
                    },
                    new BloodGroup
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Name = "B-"
                    },
                    new BloodGroup
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Name = "B+"
                    },
                    new BloodGroup
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Name = "AB-"
                    },
                    new BloodGroup
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Name = "AB+"
                    }
                };

                foreach (var bloodGroup in bloodGroups)
                {
                    await context.BloodGroups.AddRangeAsync(bloodGroup);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Settings.Any())
            {
                var settings = new List<Setting>
                {
                    new Setting
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        ContactNumber = "+ 1 315 369 5943",
                        Address = "<p> 3556  Beech Street, San Francisco,<br> California, CA 94108 </p>",
                        Email = "doccure@example.com",
                        FooterDesc = "<p>Lorem ipsum dolor sit amet," +
                        " consectetur adipiscing " +
                        "elit, sed do eiusmod tempor incididunt ut " +
                        "labore et dolore magna aliqua. </p>",
                        FooterSite = "Doccure.com",
                        HomeBannerTitle = "<h1>Search Doctor, Make an Appointment</h1>",
                        HomeBannerSubTitle = "<p>Discover the best doctors, " +
                        "clinic & hospital the " +
                        "city nearest to you.</p>",
                        ClinicAndSpecialitiesTitle = "<h2>Clinic and Specialities</h2>",
                        ClinicAndSpecialitiesSubTitle = "<p class='sub - title'>Lorem ipsum " +
                        "dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor " +
                        "incididunt ut labore et dolore magna aliqua.</p>",
                        PopularTitle = "<h2>Book Our Doctor</h2>",
                        PopularSubTitle = "<p>Lorem Ipsum is simply dummy text </p>",
                        PopularText = "<p>It is a long established fact that a reader will be distracted by" +
                        " the readable content of a page when looking at its layout. The point of using " +
                        "Lorem Ipsum.</p><p>web page editors now use Lorem Ipsum as their default model " +
                        "text,and a search for 'lorem ipsum' will uncover many web sites still in their " +
                        "infancy.Various versions have evolved over the years, sometimes </p>",
                        AvailableTitle = "<h2 class='mt - 2'>Availabe Features in Our Clinic</h2>",
                        AvailableSubTitle = "<p>It is a long established fact that a reader will be " +
                        "distracted by the readable content of a page when looking at its layout. </p>",
                        BlogsAndNewsTitle = "<h2>Blogs and News</h2>",
                        BlogsAndNewsSubTitle = "<p class='sub - title'>Lorem ipsum dolor sit amet, " +
                        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et " +
                        "dolore magna aliqua.</p>",
                        Information = "<p class='text - muted mb - 0'>Lorem ipsum dolor sit amet, " +
                        "consectetur adipiscing elit. Vivamus sed dictum ligula, cursus blandit risus. " +
                        "Maecenas eget metus non tellus dignissim aliquam ut a ex. Maecenas sed vehicula dui, " +
                        "ac suscipit lacus. Sed finibus leo vitae lorem interdum, eu scelerisque tellus " +
                        "fermentum. Curabitur sit amet lacinia lorem. Nullam finibus pellentesque libero.</p>",
                    }
                };

                foreach (var setting in settings)
                {
                    await context.Settings.AddRangeAsync(setting);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.SettingPhotos.Any())
            {
                var settingPhotos = new List<SettingPhoto>
                {
                    new SettingPhoto
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        SettingId = 1,
                        Name = "HeaderAndInvoice",
                        Photo = null
                    },
                    new SettingPhoto
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        SettingId = 1,
                        Name = "Footer",
                        Photo = null
                    },
                    new SettingPhoto
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        SettingId = 1,
                        Name = "Available",
                        Photo = null
                    },
                    new SettingPhoto
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        SettingId = 1,
                        Name = "Patient",
                        Photo = null
                    },
                    new SettingPhoto
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        SettingId = 1,
                        Name = "AdminAndDoctor",
                        Photo = null
                    },
                };

                foreach (var settingPhoto in settingPhotos)
                {
                    await context.SettingPhotos.AddRangeAsync(settingPhoto);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.SocialMedias.Any())
            {
                var socialMedias = new List<SocialMedia>
                {
                    new SocialMedia
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        SettingId = 1,
                        Name = "Facebook",
                        Icon = "facebook-f",
                        Link = "https://www.facebook.com/"
                    },
                    new SocialMedia
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        SettingId = 1,
                        Name = "Twitter",
                        Icon = "twitter",
                        Link = "https://www.twitter.com/"
                    },
                    new SocialMedia
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        SettingId = 1,
                        Name = "Linkedin",
                        Icon = "linkedin-in",
                        Link = "https://www.linkedin.com/"
                    },
                    new SocialMedia
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        SettingId = 1,
                        Name = "Instagram",
                        Icon = "instagram",
                        Link = "https://www.instagram.com/"
                    },
                    new SocialMedia
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        SettingId = 1,
                        Name = "Dribbble",
                        Icon = "dribbble",
                        Link = "https://www.dribbble.com/"
                    }
                };

                foreach (var socialMedia in socialMedias)
                {
                    await context.SocialMedias.AddRangeAsync(socialMedia);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Privacies.Any())
            {
                var privacies = new List<Privacy>
                {
                    new Privacy
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Heading = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque vel " +
                        "sodales mauris. Nunc accumsan mi massa, ut maximus magna ultricies et:</p>" +
                        "<ol>" +
                        "<li>Integer quam odio, ullamcorper id diam in, accumsan convallis libero.Duis at " +
                        "lacinia urna.</li>" +
                        "<li>Mauris eget turpis sit amet purus pulvinar facilisis at sed lacus.</li>" +
                        "<li>Quisque malesuada volutpat orci, accumsan scelerisque lorem pulvinar vitae.</li>" +
                        "<li>Vestibulum sit amet sem aliquam, vestibulum nisi sed,sodales libero.</li>" +
                        "</ol>",
                        SubHeading = "<h4>Aenean accumsan aliquam justo, et rhoncus est ullamcorper at</h4>" +
                        "<p>Donec posuere dictum enim, vel sollicitudin orci tincidunt ac.Maecenas mattis ex eu " +
                        "elit tincidunt egestas.Vivamus posuere nunc vel metus bibendum varius.Vestibulum suscipit " +
                        "lacinia eros a aliquam.Sed dapibus arcu eget egestas hendrerit.</p>" +
                        "lacinia vitae nibh vitae, sagittis interdum lacus.Mauris lacinia leo odio, eget finibus " +
                        "lectus pharetra ut.Nullam in semper enim,id gravida nulla.</p>" +
                        "<p>Fusce gravida auctor justo,vel lobortis sem efficitur id.Cras eu eros vitae justo " +
                        "dictum tempor.</p>",
                        Body = "<h4>Etiam sed fermentum lectus. Quisque vitae ipsum libero</h4>" +
                        "<p>Phasellus sit amet vehicula arcu.Etiam pulvinar dui libero, vitae fringilla nulla " +
                        "convallis in. Fusce sagittis cursus nisl, at consectetur elit vestibulum vestibulum:</p>" +
                        "<ul>" +
                        "<li>Nunc pulvinar efficitur interdum.</li>" +
                        "<li>Donec feugiat feugiat pulvinar.</li>" +
                        "<li>Suspendisse eu risus feugiat, pellentesque arcu eu, molestie lorem.</li>" +
                        "<li>Duis non leo commodo, euismod ipsum a, feugiat libero.</li></ul>",
                        BodySubHeading = "<h4>pulvinar</h4>" +
                        "<p>Sed sollicitudin, diam nec tristique tincidunt, " +
                        "nulla ligula facilisis nunc, non condimentum tortor leo id ex.</p>" +
                        "<p>Vivamus consectetur metus at nulla efficitur mattis.Aenean egestas eu odio vestibulum " +
                        "vestibulum.Duis nulla lectus, lacinia vitae nibh vitae, sagittis interdum lacus.Mauris " +
                        "lacinia leo odio, eget finibus lectus pharetra ut.Nullam in semper enim, id gravida nulla.</p>" +
                        "<p>Donec posuere dictum enim, vel sollicitudin orci tincidunt ac.Maecenas mattis ex eu " +
                        "elit tincidunt egestas.Vivamus posuere nunc vel metus bibendum varius.Vestibulum suscipit " +
                        "lacinia eros a aliquam.Sed dapibus arcu eget egestas hendrerit.Donec posuere dictum enim, " +
                        "vel sollicitudin orci tincidunt ac.Maecenas mattis ex eu elit tincidunt egestas. " +
                        "Vivamus posuere nunc vel metus bibendum varius.Vestibulum suscipit lacinia eros a " +
                        "aliquam.Sed dapibus arcu eget egestas hendrerit.</p>",
                        Footer = "<h4>efficitur</h4>" +
                        "<p>Fusce gravida auctor justo, vel lobortis sem efficitur id.Cras eu eros vitae justo " +
                        "dictum tempor.</p>" +
                        "<p><strong>Vivamus posuere nunc vel metus bibendum varius.Vestibulum suscipit lacinia " +
                        "eros a aliquam.Sed dapibus arcu eget egestas hendrerit.Donec posuere dictum enim, " +
                        "vel sollicitudin orci tincidunt ac.</strong></p>"
                    }
                };

                foreach (var privacy in privacies)
                {
                    await context.Privacies.AddRangeAsync(privacy);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Terms.Any())
            {
                var terms = new List<Term>
                {
                    new Term
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        TermHeading = "<h3>Etiam blandit lacus</h3>" +
                        "<p>Lorem ipsum dolor sit amet,consectetur " +
                        "adipiscing elit,sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                        "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip.</p>" +
                        "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor " +
                        "incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud " +
                        "exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure " +
                        "dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. " +
                        "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit " +
                        "anim id est laborum.</p>",
                        TermSubheading = "<h4>Etiam sed fermentum lectus. Quisque vitae ipsum libero</h4>" +
                        "<p>Phasellus sit amet vehicula arcu.Etiam pulvinar dui libero, vitae fringilla " +
                        "nulla convallis in. Fusce sagittis cursus nisl, at consectetur elit vestibulum vestibulum:</p>" +
                        "<ul>" +
                        "<li>Nunc pulvinar efficitur interdum.</li>" +
                        "<li>Donec feugiat feugiat pulvinar.</li>" +
                        "<li>Suspendisse eu risus feugiat, pellentesque arcu eu,molestie lorem. </li>" +
                        "<li> Duis non leo commodo, euismod ipsum a,feugiat libero.</li>" +
                        "</ul>",
                        TermBody = "<h3>Etiam blandit lacus</h3>" +
                        "<p> Lorem ipsum dolor sit amet,consectetur adipiscing elit,sed do eiusmod tempor " +
                        "incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud " +
                        "exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure " +
                        "dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. " +
                        "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit " +
                        "anim id est laborum.</p>" +
                        "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor " +
                        "incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud " +
                        "exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute " +
                        "irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. " +
                        "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit " +
                        "anim id est laborum.</p>",
                        TermFooter = "<h3>Maecenas sit amet</h3>" +
                        "<p> Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor " +
                        "incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud " +
                        "exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure " +
                        "dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. " +
                        "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt " +
                        "mollit anim id est laborum.</p>"
                    }
                };

                foreach (var term in terms)
                {
                    await context.Terms.AddRangeAsync(term);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Admins.Any())
            {
                var admins = new List<Admin>
                {
                    new Admin
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    },
                    new Admin
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    }
                };

                foreach (var admin in admins)
                {
                    await context.Admins.AddRangeAsync(admin);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Doctors.Any())
            {
                var doctors = new List<Doctor>
                {
                    new Doctor
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Position = DoctorPosition.Dentist,
                        Type = WorkingType.Payable
                    },
                    new Doctor
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Position = DoctorPosition.Neurologist,
                        Type = WorkingType.Freelancer
                    },
                    new Doctor
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Position = DoctorPosition.Dentist,
                        Type = WorkingType.Payable
                    },
                    new Doctor
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Position = DoctorPosition.Urologist,
                        Type = WorkingType.Freelancer
                    },
                    new Doctor
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Position = DoctorPosition.Cardiologist,
                        Type = WorkingType.Payable
                    },
                    new Doctor
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Position = DoctorPosition.Dentist,
                        Type = WorkingType.Freelancer
                    },
                    new Doctor
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Position = DoctorPosition.Dentist,
                        Type = WorkingType.Payable
                    },
                    new Doctor
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Position = DoctorPosition.Orthopedics,
                        Type = WorkingType.Freelancer
                    },
                    new Doctor
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Position = DoctorPosition.Neurologist,
                        Type = WorkingType.Payable
                    },
                    new Doctor
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Position = DoctorPosition.Cardiologist,
                        Type = WorkingType.Freelancer
                    }
                };

                foreach (var doctor in doctors)
                {
                    await context.Doctors.AddRangeAsync(doctor);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Patients.Any())
            {
                var patients = new List<Patient>
                {
                    new Patient
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Type = PatientType.OldPatient,
                        BloodGroupId = 1
                    },
                    new Patient
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Type = PatientType.NewPatient,
                        BloodGroupId = 1
                    },
                    new Patient
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Type = PatientType.OldPatient,
                        BloodGroupId = 1
                    },
                    new Patient
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Type = PatientType.NewPatient,
                        BloodGroupId = 1
                    },
                    new Patient
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Type = PatientType.OldPatient,
                        BloodGroupId = 1
                    },
                    new Patient
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Type = PatientType.NewPatient,
                        BloodGroupId = 1
                    },
                    new Patient
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Type = PatientType.OldPatient,
                        BloodGroupId = 1
                    },
                    new Patient
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Type = PatientType.NewPatient,
                        BloodGroupId = 1
                    },
                    new Patient
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Type = PatientType.OldPatient,
                        BloodGroupId = 1
                    },
                    new Patient
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Type = PatientType.NewPatient,
                        BloodGroupId = 1
                    },
                    new Patient
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Type = PatientType.OldPatient,
                        BloodGroupId = 1
                    },
                    new Patient
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Type = PatientType.NewPatient,
                        BloodGroupId = 1
                    },
                };

                foreach (var patient in patients)
                {
                    await context.Patients.AddRangeAsync(patient);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Users.Any())
            {
                var users = new List<User>
                {
                    new User
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Code = new Random().Next(100000, 999999).ToString(),
                        Photo = null,
                        Fullname = "Admin Admin",
                        Slug = "admin-admin",
                        Email = "admin@admin.com",
                        Birth = new DateTime(1990, 06, 29),
                        Phone = "+994 55 904-68-23",
                        Password = Crypto.HashPassword("yavar10Yr"),
                        Biography = "<div class='about - text'>Lorem ipsum dolor sit amet, " +
                        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                        "labore et dolore magna aliqua.</div>",
                        PostalCode = "22434",
                        Address = "<p class='col-sm-10 mb-0'>4663 Agriculture Lane,<br>Miami,<br>Florida-33165,<br>United States.</p>",
                        City = "Miami",
                        State = "Florida",
                        Country = "United States",
                        Role = UserRole.Admin,
                        Gender = Gender.Male,
                        Token = Guid.NewGuid().ToString(),
                        InviteToken = null,
                        ConfirmToken = null,
                        ConnectionId = null,
                        AdminId = 1,
                        DoctorId = null,
                        PatientId = null
                    },
                    new User
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Code = new Random().Next(100000, 999999).ToString(),
                        Photo = null,
                        Fullname = "Admin Pharmacy",
                        Slug = "admin-pharmacy",
                        Email = "admin@pharmacy.com",
                        Birth = new DateTime(1990, 06, 29),
                        Phone = "+994 55 904-68-23",
                        Password = Crypto.HashPassword("yavar10Yr"),
                        Biography = "<div class='about - text'>Lorem ipsum dolor sit amet, " +
                        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                        "labore et dolore magna aliqua.</div>",
                        PostalCode = "22434",
                        Address = "<p class='col-sm-10 mb-0'>4663 Agriculture Lane,<br>Miami,<br>Florida-33165,<br>United States.</p>",
                        City = "Miami",
                        State = "Florida",
                        Country = "United States",
                        Role = UserRole.Admin_Pharmcy,
                        Gender = Gender.Male,
                        Token = Guid.NewGuid().ToString(),
                        InviteToken = null,
                        ConfirmToken = null,
                        ConnectionId = null,
                        AdminId = 2,
                        DoctorId = null,
                        PatientId = null
                    },

                    new User
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Code = new Random().Next(100000, 999999).ToString(),
                        Photo = null,
                        Fullname = "Ruby Perrin",
                        Slug = "ruby-perrin",
                        Email = "perrin.ruby@test.com",
                        Birth = new DateTime(1990, 06, 29),
                        Phone = "+994 55 904-68-23",
                        Password = Crypto.HashPassword("yavar10Yr"),
                        Biography = "<div class='about - text'>Lorem ipsum dolor sit amet, " +
                        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                        "labore et dolore magna aliqua.</div>",
                        PostalCode = "22434",
                        Address = "<p class='col-sm-10 mb-0'>4663 Agriculture Lane,<br>Miami,<br>Florida-33165,<br>United States.</p>",
                        City = "Miami",
                        State = "Florida",
                        Country = "United States",
                        Role = UserRole.Doctor,
                        Gender = Gender.Female,
                        Token = Guid.NewGuid().ToString(),
                        InviteToken = null,
                        ConfirmToken = null,
                        ConnectionId = null,
                        AdminId = null,
                        DoctorId = 1,
                        PatientId = null
                    },
                    new User
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Code = new Random().Next(100000, 999999).ToString(),
                        Photo = null,
                        Fullname = "Darren Elder",
                        Slug = "darren-elder",
                        Email = "elder.darren@test.com",
                        Birth = new DateTime(1990, 06, 29),
                        Phone = "+994 55 904-68-23",
                        Password = Crypto.HashPassword("yavar10Yr"),
                        Biography = "<div class='about - text'>Lorem ipsum dolor sit amet, " +
                        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                        "labore et dolore magna aliqua.</div>",
                        PostalCode = "22434",
                        Address = "<p class='col-sm-10 mb-0'>4663 Agriculture Lane,<br>Miami,<br>Florida-33165,<br>United States.</p>",
                        City = "Miami",
                        State = "Florida",
                        Country = "United States",
                        Role = UserRole.Doctor,
                        Gender = Gender.Male,
                        Token = Guid.NewGuid().ToString(),
                        InviteToken = null,
                        ConfirmToken = null,
                        ConnectionId = null,
                        AdminId = null,
                        DoctorId = 2,
                        PatientId = null
                    },
                    new User
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Code = new Random().Next(100000, 999999).ToString(),
                        Photo = null,
                        Fullname = "Deborah Angel",
                        Slug = "deborah-angel",
                        Email = "angel.deborah@test.com",
                        Birth = new DateTime(1990, 06, 29),
                        Phone = "+994 55 904-68-23",
                        Password = Crypto.HashPassword("yavar10Yr"),
                        Biography = "<div class='about - text'>Lorem ipsum dolor sit amet, " +
                        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                        "labore et dolore magna aliqua.</div>",
                        PostalCode = "22434",
                        Address = "<p class='col-sm-10 mb-0'>4663 Agriculture Lane,<br>Miami,<br>Florida-33165,<br>United States.</p>",
                        City = "Miami",
                        State = "Florida",
                        Country = "United States",
                        Role = UserRole.Doctor,
                        Gender = Gender.Female,
                        Token = Guid.NewGuid().ToString(),
                        InviteToken = null,
                        ConfirmToken = null,
                        ConnectionId = null,
                        AdminId = null,
                        DoctorId = 3,
                        PatientId = null
                    },
                    new User
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Code = new Random().Next(100000, 999999).ToString(),
                        Photo = null,
                        Fullname = "Sofia Brient",
                        Slug = "sofia-brient",
                        Email = "brient.sofia@test.com",
                        Birth = new DateTime(1990, 06, 29),
                        Phone = "+994 55 904-68-23",
                        Password = Crypto.HashPassword("yavar10Yr"),
                        Biography = "<div class='about - text'>Lorem ipsum dolor sit amet, " +
                        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                        "labore et dolore magna aliqua.</div>",
                        PostalCode = "22434",
                        Address = "<p class='col-sm-10 mb-0'>4663 Agriculture Lane,<br>Miami,<br>Florida-33165,<br>United States.</p>",
                        City = "Miami",
                        State = "Florida",
                        Country = "United States",
                        Role = UserRole.Doctor,
                        Gender = Gender.Female,
                        Token = Guid.NewGuid().ToString(),
                        InviteToken = null,
                        ConfirmToken = null,
                        ConnectionId = null,
                        AdminId = null,
                        DoctorId = 4,
                        PatientId = null
                    },
                    new User
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Code = new Random().Next(100000, 999999).ToString(),
                        Photo = null,
                        Fullname = "Marvin Campbell",
                        Slug = "marvin-campbell",
                        Email = "campbell.marvin@test.com",
                        Birth = new DateTime(1990, 06, 29),
                        Phone = "+994 55 904-68-23",
                        Password = Crypto.HashPassword("yavar10Yr"),
                        Biography = "<div class='about - text'>Lorem ipsum dolor sit amet, " +
                        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                        "labore et dolore magna aliqua.</div>",
                        PostalCode = "22434",
                        Address = "<p class='col-sm-10 mb-0'>4663 Agriculture Lane,<br>Miami,<br>Florida-33165,<br>United States.</p>",
                        City = "Miami",
                        State = "Florida",
                        Country = "United States",
                        Role = UserRole.Doctor,
                        Gender = Gender.Male,
                        Token = Guid.NewGuid().ToString(),
                        InviteToken = null,
                        ConfirmToken = null,
                        ConnectionId = null,
                        AdminId = null,
                        DoctorId = 5,
                        PatientId = null
                    },
                    new User
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Code = new Random().Next(100000, 999999).ToString(),
                        Photo = null,
                        Fullname = "Katherina Berthold",
                        Slug = "katherina-berthold",
                        Email = "berthold.katherina@test.com",
                        Birth = new DateTime(1990, 06, 29),
                        Phone = "+994 55 904-68-23",
                        Password = Crypto.HashPassword("yavar10Yr"),
                        Biography = "<div class='about - text'>Lorem ipsum dolor sit amet, " +
                        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                        "labore et dolore magna aliqua.</div>",
                        PostalCode = "22434",
                        Address = "<p class='col-sm-10 mb-0'>4663 Agriculture Lane,<br>Miami,<br>Florida-33165,<br>United States.</p>",
                        City = "Miami",
                        State = "Florida",
                        Country = "United States",
                        Role = UserRole.Doctor,
                        Gender = Gender.Female,
                        Token = Guid.NewGuid().ToString(),
                        InviteToken = null,
                        ConfirmToken = null,
                        ConnectionId = null,
                        AdminId = null,
                        DoctorId = 6,
                        PatientId = null
                    },
                    new User
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Code = new Random().Next(100000, 999999).ToString(),
                        Photo = null,
                        Fullname = "Linda Tobin",
                        Slug = "linda-tobin",
                        Email = "tobin.linda@test.com",
                        Birth = new DateTime(1990, 06, 29),
                        Phone = "+994 55 904-68-23",
                        Password = Crypto.HashPassword("yavar10Yr"),
                        Biography = "<div class='about - text'>Lorem ipsum dolor sit amet, " +
                        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                        "labore et dolore magna aliqua.</div>",
                        PostalCode = "22434",
                        Address = "<p class='col-sm-10 mb-0'>4663 Agriculture Lane,<br>Miami,<br>Florida-33165,<br>United States.</p>",
                        City = "Miami",
                        State = "Florida",
                        Country = "United States",
                        Role = UserRole.Doctor,
                        Gender = Gender.Female,
                        Token = Guid.NewGuid().ToString(),
                        InviteToken = null,
                        ConfirmToken = null,
                        ConnectionId = null,
                        AdminId = null,
                        DoctorId = 7,
                        PatientId = null
                    },
                    new User
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Code = new Random().Next(100000, 999999).ToString(),
                        Photo = null,
                        Fullname = "Paul Richard",
                        Slug = "richard-paul",
                        Email = "paul.richard@test.com",
                        Birth = new DateTime(1990, 06, 29),
                        Phone = "+994 55 904-68-23",
                        Password = Crypto.HashPassword("yavar10Yr"),
                        Biography = "<div class='about - text'>Lorem ipsum dolor sit amet, " +
                        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                        "labore et dolore magna aliqua.</div>",
                        PostalCode = "22434",
                        Address = "<p class='col-sm-10 mb-0'>4663 Agriculture Lane,<br>Miami,<br>Florida-33165,<br>United States.</p>",
                        City = "Miami",
                        State = "Florida",
                        Country = "United States",
                        Role = UserRole.Doctor,
                        Gender = Gender.Male,
                        Token = Guid.NewGuid().ToString(),
                        InviteToken = null,
                        ConfirmToken = null,
                        ConnectionId = null,
                        AdminId = null,
                        DoctorId = 8,
                        PatientId = null
                    },
                    new User
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Code = new Random().Next(100000, 999999).ToString(),
                        Photo = null,
                        Fullname = "John Gibbs",
                        Slug = "john-gibbs",
                        Email = "gibbs.john@test.com",
                        Birth = new DateTime(1990, 06, 29),
                        Phone = "+994 55 904-68-23",
                        Password = Crypto.HashPassword("yavar10Yr"),
                        Biography = "<div class='about - text'>Lorem ipsum dolor sit amet, " +
                        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                        "labore et dolore magna aliqua.</div>",
                        PostalCode = "22434",
                        Address = "<p class='col-sm-10 mb-0'>4663 Agriculture Lane,<br>Miami,<br>Florida-33165,<br>United States.</p>",
                        City = "Miami",
                        State = "Florida",
                        Country = "United States",
                        Role = UserRole.Doctor,
                        Gender = Gender.Male,
                        Token = Guid.NewGuid().ToString(),
                        InviteToken = null,
                        ConfirmToken = null,
                        ConnectionId = null,
                        AdminId = null,
                        DoctorId = 9,
                        PatientId = null
                    },
                    new User
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Code = new Random().Next(100000, 999999).ToString(),
                        Photo = null,
                        Fullname = "Olga Barlow",
                        Slug = "olga-barlow",
                        Email = "barlow.olga@test.com",
                        Birth = new DateTime(1990, 06, 29),
                        Phone = "+994 55 904-68-23",
                        Password = Crypto.HashPassword("yavar10Yr"),
                        Biography = "<div class='about - text'>Lorem ipsum dolor sit amet, " +
                        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                        "labore et dolore magna aliqua.</div>",
                        PostalCode = "22434",
                        Address = "<p class='col-sm-10 mb-0'>4663 Agriculture Lane,<br>Miami,<br>Florida-33165,<br>United States.</p>",
                        City = "Miami",
                        State = "Florida",
                        Country = "United States",
                        Role = UserRole.Doctor,
                        Gender = Gender.Female,
                        Token = Guid.NewGuid().ToString(),
                        InviteToken = null,
                        ConfirmToken = null,
                        ConnectionId = null,
                        AdminId = null,
                        DoctorId = 10,
                        PatientId = null
                    },

                    new User
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Code = new Random().Next(100000, 999999).ToString(),
                        Photo = null,
                        Fullname = "Richard Wilson",
                        Slug = "richard-wilson",
                        Email = "wilson.richard@test.com",
                        Birth = new DateTime(1990, 06, 29),
                        Phone = "+994 55 904-68-23",
                        Password = Crypto.HashPassword("yavar10Yr"),
                        Biography = "<div class='about - text'>Lorem ipsum dolor sit amet, " +
                        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                        "labore et dolore magna aliqua.</div>",
                        PostalCode = "22434",
                        Address = "<p class='col-sm-10 mb-0'>4663 Agriculture Lane,<br>Miami,<br>Florida-33165,<br>United States.</p>",
                        City = "Miami",
                        State = "Florida",
                        Country = "United States",
                        Role = UserRole.Patient,
                        Gender = Gender.Male,
                        Token = Guid.NewGuid().ToString(),
                        InviteToken = null,
                        ConfirmToken = null,
                        ConnectionId = null,
                        AdminId = null,
                        DoctorId = null,
                        PatientId = 1
                    },
                    new User
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Code = new Random().Next(100000, 999999).ToString(),
                        Photo = null,
                        Fullname = "Charlene Reed",
                        Slug = "charlene-reed",
                        Email = "reed.charlene@test.com",
                        Birth = new DateTime(1990, 06, 29),
                        Phone = "+994 55 904-68-23",
                        Password = Crypto.HashPassword("yavar10Yr"),
                        Biography = "<div class='about - text'>Lorem ipsum dolor sit amet, " +
                        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                        "labore et dolore magna aliqua.</div>",
                        PostalCode = "22434",
                        Address = "<p class='col-sm-10 mb-0'>4663 Agriculture Lane,<br>Miami,<br>Florida-33165,<br>United States.</p>",
                        City = "Miami",
                        State = "Florida",
                        Country = "United States",
                        Role = UserRole.Patient,
                        Gender = Gender.Female,
                        Token = Guid.NewGuid().ToString(),
                        InviteToken = null,
                        ConfirmToken = null,
                        ConnectionId = null,
                        AdminId = null,
                        DoctorId = null,
                        PatientId = 1
                    },
                    new User
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Code = new Random().Next(100000, 999999).ToString(),
                        Photo = null,
                        Fullname = "Travis Trimble",
                        Slug = "travis-trimble",
                        Email = "trimble.travis@test.com",
                        Birth = new DateTime(1990, 06, 29),
                        Phone = "+994 55 904-68-23",
                        Password = Crypto.HashPassword("yavar10Yr"),
                        Biography = "<div class='about - text'>Lorem ipsum dolor sit amet, " +
                        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                        "labore et dolore magna aliqua.</div>",
                        PostalCode = "22434",
                        Address = "<p class='col-sm-10 mb-0'>4663 Agriculture Lane,<br>Miami,<br>Florida-33165,<br>United States.</p>",
                        City = "Miami",
                        State = "Florida",
                        Country = "United States",
                        Role = UserRole.Patient,
                        Gender = Gender.Male,
                        Token = Guid.NewGuid().ToString(),
                        InviteToken = null,
                        ConfirmToken = null,
                        ConnectionId = null,
                        AdminId = null,
                        DoctorId = null,
                        PatientId = 3
                    },
                    new User
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Code = new Random().Next(100000, 999999).ToString(),
                        Photo = null,
                        Fullname = "Carl Kelly",
                        Slug = "carl-kelly",
                        Email = "kelly.carl@test.com",
                        Birth = new DateTime(1990, 06, 29),
                        Phone = "+994 55 904-68-23",
                        Password = Crypto.HashPassword("yavar10Yr"),
                        Biography = "<div class='about - text'>Lorem ipsum dolor sit amet, " +
                        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                        "labore et dolore magna aliqua.</div>",
                        PostalCode = "22434",
                        Address = "<p class='col-sm-10 mb-0'>4663 Agriculture Lane,<br>Miami,<br>Florida-33165,<br>United States.</p>",
                        City = "Miami",
                        State = "Florida",
                        Country = "United States",
                        Role = UserRole.Patient,
                        Gender = Gender.Male,
                        Token = Guid.NewGuid().ToString(),
                        InviteToken = null,
                        ConfirmToken = null,
                        ConnectionId = null,
                        AdminId = null,
                        DoctorId = null,
                        PatientId = 4
                    },
                    new User
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Code = new Random().Next(100000, 999999).ToString(),
                        Photo = null,
                        Fullname = "Michelle Fairfax",
                        Slug = "michelle-fairfax",
                        Email = "fairfax.michelle@test.com",
                        Birth = new DateTime(1990, 06, 29),
                        Phone = "+994 55 904-68-23",
                        Password = Crypto.HashPassword("yavar10Yr"),
                        Biography = "<div class='about - text'>Lorem ipsum dolor sit amet, " +
                        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                        "labore et dolore magna aliqua.</div>",
                        PostalCode = "22434",
                        Address = "<p class='col-sm-10 mb-0'>4663 Agriculture Lane,<br>Miami,<br>Florida-33165,<br>United States.</p>",
                        City = "Miami",
                        State = "Florida",
                        Country = "United States",
                        Role = UserRole.Patient,
                        Gender = Gender.Female,
                        Token = Guid.NewGuid().ToString(),
                        InviteToken = null,
                        ConfirmToken = null,
                        ConnectionId = null,
                        AdminId = null,
                        DoctorId = null,
                        PatientId = 5
                    },
                    new User
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Code = new Random().Next(100000, 999999).ToString(),
                        Photo = null,
                        Fullname = "Gina Moore",
                        Slug = "gina-moore",
                        Email = "moore.gina@test.com",
                        Birth = new DateTime(1990, 06, 29),
                        Phone = "+994 55 904-68-23",
                        Password = Crypto.HashPassword("yavar10Yr"),
                        Biography = "<div class='about - text'>Lorem ipsum dolor sit amet, " +
                        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                        "labore et dolore magna aliqua.</div>",
                        PostalCode = "22434",
                        Address = "<p class='col-sm-10 mb-0'>4663 Agriculture Lane,<br>Miami,<br>Florida-33165,<br>United States.</p>",
                        City = "Miami",
                        State = "Florida",
                        Country = "United States",
                        Role = UserRole.Patient,
                        Gender = Gender.Female,
                        Token = Guid.NewGuid().ToString(),
                        InviteToken = null,
                        ConfirmToken = null,
                        ConnectionId = null,
                        AdminId = null,
                        DoctorId = null,
                        PatientId = 6
                    },
                    new User
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Code = new Random().Next(100000, 999999).ToString(),
                        Photo = null,
                        Fullname = "Elsie Gilley",
                        Slug = "elsie-gilley",
                        Email = "gilley.elsie@test.com",
                        Birth = new DateTime(1990, 06, 29),
                        Phone = "+994 55 904-68-23",
                        Password = Crypto.HashPassword("yavar10Yr"),
                        Biography = "<div class='about - text'>Lorem ipsum dolor sit amet, " +
                        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                        "labore et dolore magna aliqua.</div>",
                        PostalCode = "22434",
                        Address = "<p class='col-sm-10 mb-0'>4663 Agriculture Lane,<br>Miami,<br>Florida-33165,<br>United States.</p>",
                        City = "Miami",
                        State = "Florida",
                        Country = "United States",
                        Role = UserRole.Patient,
                        Gender = Gender.Female,
                        Token = Guid.NewGuid().ToString(),
                        InviteToken = null,
                        ConfirmToken = null,
                        ConnectionId = null,
                        AdminId = null,
                        DoctorId = null,
                        PatientId = 7
                    },
                    new User
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Code = new Random().Next(100000, 999999).ToString(),
                        Photo = null,
                        Fullname = "Joan Gardner",
                        Slug = "joan-gardner",
                        Email = "gardner.joan@test.com",
                        Birth = new DateTime(1990, 06, 29),
                        Phone = "+994 55 904-68-23",
                        Password = Crypto.HashPassword("yavar10Yr"),
                        Biography = "<div class='about - text'>Lorem ipsum dolor sit amet, " +
                        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                        "labore et dolore magna aliqua.</div>",
                        PostalCode = "22434",
                        Address = "<p class='col-sm-10 mb-0'>4663 Agriculture Lane,<br>Miami,<br>Florida-33165,<br>United States.</p>",
                        City = "Miami",
                        State = "Florida",
                        Country = "United States",
                        Role = UserRole.Patient,
                        Gender = Gender.Female,
                        Token = Guid.NewGuid().ToString(),
                        InviteToken = null,
                        ConfirmToken = null,
                        ConnectionId = null,
                        AdminId = null,
                        DoctorId = null,
                        PatientId = 8
                    },
                    new User
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Code = new Random().Next(100000, 999999).ToString(),
                        Photo = null,
                        Fullname = "Daniel Griffing",
                        Slug = "daniel-griffing",
                        Email = "griffing.daniel@test.com",
                        Birth = new DateTime(1990, 06, 29),
                        Phone = "+994 55 904-68-23",
                        Password = Crypto.HashPassword("yavar10Yr"),
                        Biography = "<div class='about - text'>Lorem ipsum dolor sit amet, " +
                        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                        "labore et dolore magna aliqua.</div>",
                        PostalCode = "22434",
                        Address = "<p class='col-sm-10 mb-0'>4663 Agriculture Lane,<br>Miami,<br>Florida-33165,<br>United States.</p>",
                        City = "Miami",
                        State = "Florida",
                        Country = "United States",
                        Role = UserRole.Patient,
                        Gender = Gender.Male,
                        Token = Guid.NewGuid().ToString(),
                        InviteToken = null,
                        ConfirmToken = null,
                        ConnectionId = null,
                        AdminId = null,
                        DoctorId = null,
                        PatientId = 9
                    },
                    new User
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Code = new Random().Next(100000, 999999).ToString(),
                        Photo = null,
                        Fullname = "Walter Roberson",
                        Slug = "walter-roberson",
                        Email = "roberson.walter@test.com",
                        Birth = new DateTime(1990, 06, 29),
                        Phone = "+994 55 904-68-23",
                        Password = Crypto.HashPassword("yavar10Yr"),
                        Biography = "<div class='about - text'>Lorem ipsum dolor sit amet, " +
                        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                        "labore et dolore magna aliqua.</div>",
                        PostalCode = "22434",
                        Address = "<p class='col-sm-10 mb-0'>4663 Agriculture Lane,<br>Miami,<br>Florida-33165,<br>United States.</p>",
                        City = "Miami",
                        State = "Florida",
                        Country = "United States",
                        Role = UserRole.Patient,
                        Gender = Gender.Male,
                        Token = Guid.NewGuid().ToString(),
                        InviteToken = null,
                        ConfirmToken = null,
                        ConnectionId = null,
                        AdminId = null,
                        DoctorId = null,
                        PatientId = 10
                    },
                    new User
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Code = new Random().Next(100000, 999999).ToString(),
                        Photo = null,
                        Fullname = "Robert Rhodes",
                        Slug = "robert-rhodes",
                        Email = "rhodes.robert@test.com",
                        Birth = new DateTime(1990, 06, 29),
                        Phone = "+994 55 904-68-23",
                        Password = Crypto.HashPassword("yavar10Yr"),
                        Biography = "<div class='about - text'>Lorem ipsum dolor sit amet, " +
                        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                        "labore et dolore magna aliqua.</div>",
                        PostalCode = "22434",
                        Address = "<p class='col-sm-10 mb-0'>4663 Agriculture Lane,<br>Miami,<br>Florida-33165,<br>United States.</p>",
                        City = "Miami",
                        State = "Florida",
                        Country = "United States",
                        Role = UserRole.Patient,
                        Gender = Gender.Male,
                        Token = Guid.NewGuid().ToString(),
                        InviteToken = null,
                        ConfirmToken = null,
                        ConnectionId = null,
                        AdminId = null,
                        DoctorId = null,
                        PatientId = 11
                    },
                    new User
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Code = new Random().Next(100000, 999999).ToString(),
                        Photo = null,
                        Fullname = "Harry Williams",
                        Slug = "harry-williams",
                        Email = "williams.harry@test.com",
                        Birth = new DateTime(1990, 06, 29),
                        Phone = "+994 55 904-68-23",
                        Password = Crypto.HashPassword("yavar10Yr"),
                        Biography = "<div class='about - text'>Lorem ipsum dolor sit amet, " +
                        "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                        "labore et dolore magna aliqua.</div>",
                        PostalCode = "22434",
                        Address = "<p class='col-sm-10 mb-0'>4663 Agriculture Lane,<br>Miami,<br>Florida-33165,<br>United States.</p>",
                        City = "Miami",
                        State = "Florida",
                        Country = "United States",
                        Role = UserRole.Patient,
                        Gender = Gender.Male,
                        Token = Guid.NewGuid().ToString(),
                        InviteToken = null,
                        ConfirmToken = null,
                        ConnectionId = null,
                        AdminId = null,
                        DoctorId = null,
                        PatientId = 12
                    },
                };

                foreach (var user in users)
                {
                    await context.Users.AddRangeAsync(user);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Blogs.Any())
            {
                var blogs = new List<Blog>
                {
                    new Blog
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Title = "Doccure – Making your clinic painless visit?",
                        Slug = "doccure-–-making-your-clinic-painless-visit",
                        Video = "https://www.youtube.com/embed/nuVqJ_OriR8?rel=0&amp;controls=0&amp;showinfo=0",
                        Description = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                                      "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                                      "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris " +
                                      "nisi ut aliqui ex ea commodo consequat. Duis aute irure dolor in " +
                                      "reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla " +
                                      "pariatur. Excepteur sint occaecat cupidatat non proident, sunt in " +
                                      "culpa qui officia deserunt mollit anim id est laborum.</p><p>Sed ut " +
                                      "perspiciatis unde omnis iste natus error sit voluptatem accusantium " +
                                      "doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo " +
                                      "inventore veritatis et quasi architecto beatae vitae dicta sunt " +
                                      "explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut " +
                                      "odit aut fugit, sed quia consequuntur magni dolores eos qui ratione " +
                                      "voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum " +
                                      "quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam " +
                                      "eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat " +
                                      "voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem " +
                                      "ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi " +
                                      "consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate " +
                                      "velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum " +
                                      "fugiat quo voluptas nulla pariatur?</p><p>At vero eos et accusamus et " +
                                      "iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum " +
                                      "deleniti atque corrupti quos dolores et quas molestias excepturi sint " +
                                      "occaecati cupiditate non provident, similique sunt in culpa qui " +
                                      "officia deserunt mollitia animi, id est laborum et dolorum fuga. " +
                                      "Et harum quidem rerum facilis est et expedita distinctio. Nam libero " +
                                      "tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo " +
                                      "minus id quod maxime placeat facere possimus, omnis voluptas assumenda " +
                                      "est, omnis dolor repellendus. Temporibus autem quibusdam et aut " +
                                      "officiis debitis aut rerum necessitatibus saepe eveniet ut et " +
                                      "voluptates repudiandae sint et molestiae non recusandae. Itaque earum " +
                                      "rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus " +
                                      "maiores alias consequatur aut perferendis doloribus asperiores repellat.</p>",
                        Photo = null,
                        DoctorId = 1
                    },
                    new Blog
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Title = "What are the benefits of Online Doctor Booking?",
                        Slug = "what-are-the-benefits-of-online-doctor-booking",
                        Video = "https://www.youtube.com/embed/nuVqJ_OriR8?rel=0&amp;controls=0&amp;showinfo=0",
                        Description = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                                      "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                                      "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris " +
                                      "nisi ut aliqui ex ea commodo consequat. Duis aute irure dolor in " +
                                      "reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla " +
                                      "pariatur. Excepteur sint occaecat cupidatat non proident, sunt in " +
                                      "culpa qui officia deserunt mollit anim id est laborum.</p><p>Sed ut " +
                                      "perspiciatis unde omnis iste natus error sit voluptatem accusantium " +
                                      "doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo " +
                                      "inventore veritatis et quasi architecto beatae vitae dicta sunt " +
                                      "explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut " +
                                      "odit aut fugit, sed quia consequuntur magni dolores eos qui ratione " +
                                      "voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum " +
                                      "quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam " +
                                      "eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat " +
                                      "voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem " +
                                      "ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi " +
                                      "consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate " +
                                      "velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum " +
                                      "fugiat quo voluptas nulla pariatur?</p><p>At vero eos et accusamus et " +
                                      "iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum " +
                                      "deleniti atque corrupti quos dolores et quas molestias excepturi sint " +
                                      "occaecati cupiditate non provident, similique sunt in culpa qui " +
                                      "officia deserunt mollitia animi, id est laborum et dolorum fuga. " +
                                      "Et harum quidem rerum facilis est et expedita distinctio. Nam libero " +
                                      "tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo " +
                                      "minus id quod maxime placeat facere possimus, omnis voluptas assumenda " +
                                      "est, omnis dolor repellendus. Temporibus autem quibusdam et aut " +
                                      "officiis debitis aut rerum necessitatibus saepe eveniet ut et " +
                                      "voluptates repudiandae sint et molestiae non recusandae. Itaque earum " +
                                      "rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus " +
                                      "maiores alias consequatur aut perferendis doloribus asperiores repellat.</p>",
                        Photo = null,
                        DoctorId = 1
                    },
                    new Blog
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Title = "Benefits of consulting with an Online Doctor",
                        Slug = "benefits-of-consulting-with-an-online-doctor",
                        Video = "https://www.youtube.com/embed/nuVqJ_OriR8?rel=0&amp;controls=0&amp;showinfo=0",
                        Description = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                                      "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                                      "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris " +
                                      "nisi ut aliqui ex ea commodo consequat. Duis aute irure dolor in " +
                                      "reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla " +
                                      "pariatur. Excepteur sint occaecat cupidatat non proident, sunt in " +
                                      "culpa qui officia deserunt mollit anim id est laborum.</p><p>Sed ut " +
                                      "perspiciatis unde omnis iste natus error sit voluptatem accusantium " +
                                      "doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo " +
                                      "inventore veritatis et quasi architecto beatae vitae dicta sunt " +
                                      "explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut " +
                                      "odit aut fugit, sed quia consequuntur magni dolores eos qui ratione " +
                                      "voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum " +
                                      "quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam " +
                                      "eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat " +
                                      "voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem " +
                                      "ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi " +
                                      "consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate " +
                                      "velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum " +
                                      "fugiat quo voluptas nulla pariatur?</p><p>At vero eos et accusamus et " +
                                      "iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum " +
                                      "deleniti atque corrupti quos dolores et quas molestias excepturi sint " +
                                      "occaecati cupiditate non provident, similique sunt in culpa qui " +
                                      "officia deserunt mollitia animi, id est laborum et dolorum fuga. " +
                                      "Et harum quidem rerum facilis est et expedita distinctio. Nam libero " +
                                      "tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo " +
                                      "minus id quod maxime placeat facere possimus, omnis voluptas assumenda " +
                                      "est, omnis dolor repellendus. Temporibus autem quibusdam et aut " +
                                      "officiis debitis aut rerum necessitatibus saepe eveniet ut et " +
                                      "voluptates repudiandae sint et molestiae non recusandae. Itaque earum " +
                                      "rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus " +
                                      "maiores alias consequatur aut perferendis doloribus asperiores repellat.</p>",
                        Photo = null,
                        DoctorId = 1
                    },
                    new Blog
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Title = "5 Great reasons to use an Online Doctor",
                        Slug = "5-great-reasons-to-use-an-online-doctor",
                        Video = "https://www.youtube.com/embed/nuVqJ_OriR8?rel=0&amp;controls=0&amp;showinfo=0",
                        Description = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                                      "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                                      "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris " +
                                      "nisi ut aliqui ex ea commodo consequat. Duis aute irure dolor in " +
                                      "reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla " +
                                      "pariatur. Excepteur sint occaecat cupidatat non proident, sunt in " +
                                      "culpa qui officia deserunt mollit anim id est laborum.</p><p>Sed ut " +
                                      "perspiciatis unde omnis iste natus error sit voluptatem accusantium " +
                                      "doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo " +
                                      "inventore veritatis et quasi architecto beatae vitae dicta sunt " +
                                      "explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut " +
                                      "odit aut fugit, sed quia consequuntur magni dolores eos qui ratione " +
                                      "voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum " +
                                      "quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam " +
                                      "eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat " +
                                      "voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem " +
                                      "ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi " +
                                      "consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate " +
                                      "velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum " +
                                      "fugiat quo voluptas nulla pariatur?</p><p>At vero eos et accusamus et " +
                                      "iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum " +
                                      "deleniti atque corrupti quos dolores et quas molestias excepturi sint " +
                                      "occaecati cupiditate non provident, similique sunt in culpa qui " +
                                      "officia deserunt mollitia animi, id est laborum et dolorum fuga. " +
                                      "Et harum quidem rerum facilis est et expedita distinctio. Nam libero " +
                                      "tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo " +
                                      "minus id quod maxime placeat facere possimus, omnis voluptas assumenda " +
                                      "est, omnis dolor repellendus. Temporibus autem quibusdam et aut " +
                                      "officiis debitis aut rerum necessitatibus saepe eveniet ut et " +
                                      "voluptates repudiandae sint et molestiae non recusandae. Itaque earum " +
                                      "rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus " +
                                      "maiores alias consequatur aut perferendis doloribus asperiores repellat.</p>",
                        Photo = null,
                        DoctorId = 1
                    },
                    new Blog
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Title = "Online Doctor Appointment Scheduling",
                        Slug = "online-doctor-appointment-scheduling",
                        Video = "https://www.youtube.com/embed/nuVqJ_OriR8?rel=0&amp;controls=0&amp;showinfo=0",
                        Description = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                                      "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                                      "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris " +
                                      "nisi ut aliqui ex ea commodo consequat. Duis aute irure dolor in " +
                                      "reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla " +
                                      "pariatur. Excepteur sint occaecat cupidatat non proident, sunt in " +
                                      "culpa qui officia deserunt mollit anim id est laborum.</p><p>Sed ut " +
                                      "perspiciatis unde omnis iste natus error sit voluptatem accusantium " +
                                      "doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo " +
                                      "inventore veritatis et quasi architecto beatae vitae dicta sunt " +
                                      "explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut " +
                                      "odit aut fugit, sed quia consequuntur magni dolores eos qui ratione " +
                                      "voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum " +
                                      "quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam " +
                                      "eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat " +
                                      "voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem " +
                                      "ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi " +
                                      "consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate " +
                                      "velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum " +
                                      "fugiat quo voluptas nulla pariatur?</p><p>At vero eos et accusamus et " +
                                      "iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum " +
                                      "deleniti atque corrupti quos dolores et quas molestias excepturi sint " +
                                      "occaecati cupiditate non provident, similique sunt in culpa qui " +
                                      "officia deserunt mollitia animi, id est laborum et dolorum fuga. " +
                                      "Et harum quidem rerum facilis est et expedita distinctio. Nam libero " +
                                      "tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo " +
                                      "minus id quod maxime placeat facere possimus, omnis voluptas assumenda " +
                                      "est, omnis dolor repellendus. Temporibus autem quibusdam et aut " +
                                      "officiis debitis aut rerum necessitatibus saepe eveniet ut et " +
                                      "voluptates repudiandae sint et molestiae non recusandae. Itaque earum " +
                                      "rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus " +
                                      "maiores alias consequatur aut perferendis doloribus asperiores repellat.</p>",
                        Photo = null,
                        DoctorId = 1
                    },
                    new Blog
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Title = "Simple steps to make your doctor visits exceptional!",
                        Slug = "simple-steps-to-make-your-doctor-visits-exceptional",
                        Video = "https://www.youtube.com/embed/nuVqJ_OriR8?rel=0&amp;controls=0&amp;showinfo=0",
                        Description = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                                      "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                                      "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris " +
                                      "nisi ut aliqui ex ea commodo consequat. Duis aute irure dolor in " +
                                      "reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla " +
                                      "pariatur. Excepteur sint occaecat cupidatat non proident, sunt in " +
                                      "culpa qui officia deserunt mollit anim id est laborum.</p><p>Sed ut " +
                                      "perspiciatis unde omnis iste natus error sit voluptatem accusantium " +
                                      "doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo " +
                                      "inventore veritatis et quasi architecto beatae vitae dicta sunt " +
                                      "explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut " +
                                      "odit aut fugit, sed quia consequuntur magni dolores eos qui ratione " +
                                      "voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum " +
                                      "quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam " +
                                      "eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat " +
                                      "voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem " +
                                      "ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi " +
                                      "consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate " +
                                      "velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum " +
                                      "fugiat quo voluptas nulla pariatur?</p><p>At vero eos et accusamus et " +
                                      "iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum " +
                                      "deleniti atque corrupti quos dolores et quas molestias excepturi sint " +
                                      "occaecati cupiditate non provident, similique sunt in culpa qui " +
                                      "officia deserunt mollitia animi, id est laborum et dolorum fuga. " +
                                      "Et harum quidem rerum facilis est et expedita distinctio. Nam libero " +
                                      "tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo " +
                                      "minus id quod maxime placeat facere possimus, omnis voluptas assumenda " +
                                      "est, omnis dolor repellendus. Temporibus autem quibusdam et aut " +
                                      "officiis debitis aut rerum necessitatibus saepe eveniet ut et " +
                                      "voluptates repudiandae sint et molestiae non recusandae. Itaque earum " +
                                      "rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus " +
                                      "maiores alias consequatur aut perferendis doloribus asperiores repellat.</p>",
                        Photo = null,
                        DoctorId = 1
                    },
                    new Blog
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Title = "Choose your own Online Doctor Appointment",
                        Slug = "choose-your-own-online-doctor-appointment",
                        Video = "https://www.youtube.com/embed/nuVqJ_OriR8?rel=0&amp;controls=0&amp;showinfo=0",
                        Description = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                                      "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                                      "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris " +
                                      "nisi ut aliqui ex ea commodo consequat. Duis aute irure dolor in " +
                                      "reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla " +
                                      "pariatur. Excepteur sint occaecat cupidatat non proident, sunt in " +
                                      "culpa qui officia deserunt mollit anim id est laborum.</p><p>Sed ut " +
                                      "perspiciatis unde omnis iste natus error sit voluptatem accusantium " +
                                      "doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo " +
                                      "inventore veritatis et quasi architecto beatae vitae dicta sunt " +
                                      "explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut " +
                                      "odit aut fugit, sed quia consequuntur magni dolores eos qui ratione " +
                                      "voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum " +
                                      "quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam " +
                                      "eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat " +
                                      "voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem " +
                                      "ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi " +
                                      "consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate " +
                                      "velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum " +
                                      "fugiat quo voluptas nulla pariatur?</p><p>At vero eos et accusamus et " +
                                      "iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum " +
                                      "deleniti atque corrupti quos dolores et quas molestias excepturi sint " +
                                      "occaecati cupiditate non provident, similique sunt in culpa qui " +
                                      "officia deserunt mollitia animi, id est laborum et dolorum fuga. " +
                                      "Et harum quidem rerum facilis est et expedita distinctio. Nam libero " +
                                      "tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo " +
                                      "minus id quod maxime placeat facere possimus, omnis voluptas assumenda " +
                                      "est, omnis dolor repellendus. Temporibus autem quibusdam et aut " +
                                      "officiis debitis aut rerum necessitatibus saepe eveniet ut et " +
                                      "voluptates repudiandae sint et molestiae non recusandae. Itaque earum " +
                                      "rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus " +
                                      "maiores alias consequatur aut perferendis doloribus asperiores repellat.</p>",
                        Photo = null,
                        DoctorId = 1
                    },
                    new Blog
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Title = "Simple steps to visit your doctor today",
                        Slug = "simple-steps-to-visit-your-doctor-today",
                        Video = "https://www.youtube.com/embed/nuVqJ_OriR8?rel=0&amp;controls=0&amp;showinfo=0",
                        Description = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                                      "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                                      "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris " +
                                      "nisi ut aliqui ex ea commodo consequat. Duis aute irure dolor in " +
                                      "reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla " +
                                      "pariatur. Excepteur sint occaecat cupidatat non proident, sunt in " +
                                      "culpa qui officia deserunt mollit anim id est laborum.</p><p>Sed ut " +
                                      "perspiciatis unde omnis iste natus error sit voluptatem accusantium " +
                                      "doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo " +
                                      "inventore veritatis et quasi architecto beatae vitae dicta sunt " +
                                      "explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut " +
                                      "odit aut fugit, sed quia consequuntur magni dolores eos qui ratione " +
                                      "voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum " +
                                      "quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam " +
                                      "eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat " +
                                      "voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem " +
                                      "ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi " +
                                      "consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate " +
                                      "velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum " +
                                      "fugiat quo voluptas nulla pariatur?</p><p>At vero eos et accusamus et " +
                                      "iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum " +
                                      "deleniti atque corrupti quos dolores et quas molestias excepturi sint " +
                                      "occaecati cupiditate non provident, similique sunt in culpa qui " +
                                      "officia deserunt mollitia animi, id est laborum et dolorum fuga. " +
                                      "Et harum quidem rerum facilis est et expedita distinctio. Nam libero " +
                                      "tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo " +
                                      "minus id quod maxime placeat facere possimus, omnis voluptas assumenda " +
                                      "est, omnis dolor repellendus. Temporibus autem quibusdam et aut " +
                                      "officiis debitis aut rerum necessitatibus saepe eveniet ut et " +
                                      "voluptates repudiandae sint et molestiae non recusandae. Itaque earum " +
                                      "rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus " +
                                      "maiores alias consequatur aut perferendis doloribus asperiores repellat.</p>",
                        Photo = null,
                        DoctorId = 1
                    },
                    new Blog
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Title = "Online Doctoral Programs",
                        Slug = "online-doctoral-programs",
                        Video = "https://www.youtube.com/embed/nuVqJ_OriR8?rel=0&amp;controls=0&amp;showinfo=0",
                        Description = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                                      "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                                      "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris " +
                                      "nisi ut aliqui ex ea commodo consequat. Duis aute irure dolor in " +
                                      "reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla " +
                                      "pariatur. Excepteur sint occaecat cupidatat non proident, sunt in " +
                                      "culpa qui officia deserunt mollit anim id est laborum.</p><p>Sed ut " +
                                      "perspiciatis unde omnis iste natus error sit voluptatem accusantium " +
                                      "doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo " +
                                      "inventore veritatis et quasi architecto beatae vitae dicta sunt " +
                                      "explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut " +
                                      "odit aut fugit, sed quia consequuntur magni dolores eos qui ratione " +
                                      "voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum " +
                                      "quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam " +
                                      "eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat " +
                                      "voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem " +
                                      "ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi " +
                                      "consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate " +
                                      "velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum " +
                                      "fugiat quo voluptas nulla pariatur?</p><p>At vero eos et accusamus et " +
                                      "iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum " +
                                      "deleniti atque corrupti quos dolores et quas molestias excepturi sint " +
                                      "occaecati cupiditate non provident, similique sunt in culpa qui " +
                                      "officia deserunt mollitia animi, id est laborum et dolorum fuga. " +
                                      "Et harum quidem rerum facilis est et expedita distinctio. Nam libero " +
                                      "tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo " +
                                      "minus id quod maxime placeat facere possimus, omnis voluptas assumenda " +
                                      "est, omnis dolor repellendus. Temporibus autem quibusdam et aut " +
                                      "officiis debitis aut rerum necessitatibus saepe eveniet ut et " +
                                      "voluptates repudiandae sint et molestiae non recusandae. Itaque earum " +
                                      "rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus " +
                                      "maiores alias consequatur aut perferendis doloribus asperiores repellat.</p>",
                        Photo = null,
                        DoctorId = 1
                    }
                };

                foreach (var blog in blogs)
                {
                    await context.Blogs.AddRangeAsync(blog);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Features.Any())
            {
                var features = new List<Feature>
                {
                    new Feature
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        ClinicName = "Operation",
                        Photo = null
                    },
                    new Feature
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        ClinicName = "Medical",
                        Photo = null
                    },
                    new Feature
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        ClinicName = "Patient Ward",
                        Photo = null
                    },
                    new Feature
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        ClinicName = "Test Room",
                        Photo = null
                    },
                    new Feature
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        ClinicName = "ICU",
                        Photo = null
                    },
                    new Feature
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        ClinicName = "Laboratory",
                        Photo = null
                    }
                };

                foreach (var feature in features)
                {
                    await context.Features.AddRangeAsync(feature);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Specialities.Any())
            {
                var specialities = new List<Speciality>
                {
                    new Speciality
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Name = "Cardiologist",
                        Photo = null
                    },
                    new Speciality
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Name = "Dentist",
                        Photo = null
                    },
                    new Speciality
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Name = "Neurologist",
                        Photo = null
                    },
                    new Speciality
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Name = "Orthopedics",
                        Photo = null
                    },
                    new Speciality
                    {
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Name = "Urologist",
                        Photo = null
                    }
                };

                foreach (var speciality in specialities)
                {
                    await context.Specialities.AddRangeAsync(speciality);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}