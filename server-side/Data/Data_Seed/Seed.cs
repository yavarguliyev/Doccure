using Core.Enum;
using Core.Models;
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
            if (!context.Admins.Any())
            {
                var admins = new List<Admin>
                {
                    new Admin
                    {
                        Id = 1,
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
                        Id = 1,
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
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
                        Id = 1,
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
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
                        Id = 1,
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Photo = null,
                        Fullname = "Admin Admin",
                        Slug = "admin-admin",
                        Email = "admin@admin.com",
                        Password = "AQAAAAEAACcQAAAAELB7TBk46Z3TyT+O+sVA9CCYGk98WMFtfACeDo3crYvfVnDiqKIz2way+ZvJ5f0ewg==",
                        Role = UserRole.Admin,
                        Gender = Gender.Male,
                        Birth = new DateTime(1990, 06, 29),
                        Token = null,
                        InviteToken = null,
                        ConfirmToken = null,
                        ConnectionId = null,
                        AdminId = 1,
                        DoctorId = null,
                        PatientId = null
                    },

                    new User
                    {
                        Id = 2,
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Photo = null,
                        Fullname = "Yavar Guliyev",
                        Slug = "yavar-guliyev",
                        Email = "guliyev.yavar@gmail.com",
                        Password = "AQAAAAEAACcQAAAAELB7TBk46Z3TyT+O+sVA9CCYGk98WMFtfACeDo3crYvfVnDiqKIz2way+ZvJ5f0ewg==",
                        Role = UserRole.Doctor,
                        Gender = Gender.Male,
                        Birth = new DateTime(1990, 06, 29),
                        Token = null,
                        InviteToken = null,
                        ConfirmToken = null,
                        ConnectionId = null,
                        AdminId = null,
                        DoctorId = 1,
                        PatientId = null
                    },

                    new User
                    {
                        Id = 3,
                        Status = true,
                        AddedBy = "System",
                        ModifiedBy = "System",
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Photo = null,
                        Fullname = "Huseyn Asadov",
                        Slug = "huseyn-asadov",
                        Email = "asadov.huseyn@gmail.com",
                        Password = "AQAAAAEAACcQAAAAELB7TBk46Z3TyT+O+sVA9CCYGk98WMFtfACeDo3crYvfVnDiqKIz2way+ZvJ5f0ewg==",
                        Role = UserRole.Patient,
                        Gender = Gender.Male,
                        Birth = new DateTime(1990, 06, 29),
                        Token = null,
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