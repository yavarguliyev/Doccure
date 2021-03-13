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
                        Name = "HeaderLogo",
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
                        Name = "FooterLogo",
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
                        Name = "InvoiceLogo",
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
                        Name = "AvailableLogo",
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
                        Name = "PatientLoginLogo",
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
                        Name = "PatientRegisterLogo",
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
                        Name = "PatientForgotPasswordLogo",
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
                        Name = "PatientResetPasswordLogo",
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
                        Name = "DoctorLoginLogo",
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
                        Name = "DoctorRegisterLogo",
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
                        Name = "DoctorForgotPasswordLogo",
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
                        Name = "DoctorResetPasswordLogo",
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
                        Name = "AdminLoginLogo",
                        Photo = null
                    }
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
                    }
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
                        Fullname = "Yavar Guliyev",
                        Slug = "yavar-guliyev",
                        Email = "guliyev.yavar@gmail.com",
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
                        Fullname = "Huseyn Asadov",
                        Slug = "huseyn-asadov",
                        Email = "asadov.huseyn@gmail.com",
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
                };

                foreach (var user in users)
                {
                    await context.Users.AddRangeAsync(user);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}