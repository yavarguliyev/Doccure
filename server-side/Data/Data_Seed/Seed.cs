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
                        Type = PatientType.OldPatient
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