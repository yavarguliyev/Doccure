using Core.Models;
using CryptoHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enum;

namespace Data.Data_Seed
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            #region main tables
            if (!context.Admins.Any())
            {
                var admins = new List<Admin>
                {
                    new Admin {},
                    new Admin {}
                };
                foreach (var admin in admins)
                {
                    admin.Status = true;
                    admin.AddedBy = "System";
                    admin.ModifiedBy = "System";
                    admin.AddedDate = DateTime.Now;
                    admin.ModifiedDate = DateTime.Now;

                    await context.Admins.AddRangeAsync(admin);
                    await context.SaveChangesAsync();
                }
            }

            if (!context.Doctors.Any())
            {
                #region doctor
                var doctors = new List<Doctor>
                {
                    new Doctor
                    {
                        Position = DoctorPosition.Dentist,
                        Type = WorkingType.Payable
                    },
                    new Doctor
                    {
                        Position = DoctorPosition.Neurologist,
                        Type = WorkingType.Freelancer
                    },
                    new Doctor
                    {
                        Position = DoctorPosition.Dentist,
                        Type = WorkingType.Payable
                    },
                    new Doctor
                    {
                        Position = DoctorPosition.Urologist,
                        Type = WorkingType.Freelancer
                    },
                    new Doctor
                    {
                        Position = DoctorPosition.Cardiologist,
                        Type = WorkingType.Payable
                    },
                    new Doctor
                    {
                        Position = DoctorPosition.Dentist,
                        Type = WorkingType.Freelancer
                    },
                    new Doctor
                    {
                        Position = DoctorPosition.Dentist,
                        Type = WorkingType.Payable
                    },
                    new Doctor
                    {
                        Position = DoctorPosition.Orthopedics,
                        Type = WorkingType.Freelancer
                    },
                    new Doctor
                    {
                        Position = DoctorPosition.Neurologist,
                        Type = WorkingType.Payable
                    },
                    new Doctor
                    {
                        Position = DoctorPosition.Cardiologist,
                        Type = WorkingType.Freelancer
                    }
                };
                foreach (var doctor in doctors)
                {
                    doctor.Status = true;
                    doctor.AddedBy = "System";
                    doctor.ModifiedBy = "System";
                    doctor.AddedDate = DateTime.Now;
                    doctor.ModifiedDate = DateTime.Now;

                    await context.Doctors.AddRangeAsync(doctor);
                    await context.SaveChangesAsync();
                }
                #endregion

                #region doctor social urls
                if (!context.DoctorSocialMediaUrlLinks.Any())
                {
                    var url = new List<DoctorSocialMediaUrlLink>
                    {
                        new DoctorSocialMediaUrlLink
                        {
                            DoctorId = 1
                        },
                        new DoctorSocialMediaUrlLink
                        {
                            DoctorId = 2
                        },
                        new DoctorSocialMediaUrlLink
                        {
                            DoctorId = 3
                        },
                        new DoctorSocialMediaUrlLink
                        {
                            DoctorId = 4
                        },
                        new DoctorSocialMediaUrlLink
                        {
                            DoctorId = 5
                        },
                        new DoctorSocialMediaUrlLink
                        {
                            DoctorId = 6
                        },
                        new DoctorSocialMediaUrlLink
                        {
                            DoctorId = 7
                        },
                        new DoctorSocialMediaUrlLink
                        {
                            DoctorId = 8
                        },
                        new DoctorSocialMediaUrlLink
                        {
                            DoctorId = 9
                        },
                        new DoctorSocialMediaUrlLink
                        {
                            DoctorId = 10
                        }
                    };
                    foreach (var social in url)
                    {
                        social.Status = true;
                        social.AddedBy = "System";
                        social.ModifiedBy = "System";
                        social.AddedDate = DateTime.Now;
                        social.ModifiedDate = DateTime.Now;

                        social.FacebookURL = "https://www.facebook.com/";
                        social.TwitterURL = "https://www.twitter.com/";
                        social.LinkedinURL = "https://www.linkedin.com/";
                        social.InstagramURL = "https://www.instagram.com/";
                        social.PinterestURL = "https://www.pinterest.com/";

                        await context.DoctorSocialMediaUrlLinks.AddRangeAsync(social);
                        await context.SaveChangesAsync();
                    }
                }
                #endregion
            }

            if (!context.BloodGroups.Any())
            {
                #region blood groups
                var bloodGroups = new List<BloodGroup>
                {
                    new BloodGroup
                    {
                        Name = "A-"
                    },
                    new BloodGroup
                    {
                        Name = "A+"
                    },
                    new BloodGroup
                    {
                        Name = "B-"
                    },
                    new BloodGroup
                    {
                        Name = "B+"
                    },
                    new BloodGroup
                    {
                        Name = "AB-"
                    },
                    new BloodGroup
                    {
                        Name = "AB+"
                    }
                };
                foreach (var bloodGroup in bloodGroups)
                {
                    bloodGroup.Status = true;
                    bloodGroup.AddedBy = "System";
                    bloodGroup.ModifiedBy = "System";
                    bloodGroup.AddedDate = DateTime.Now;
                    bloodGroup.ModifiedDate = DateTime.Now;

                    await context.BloodGroups.AddRangeAsync(bloodGroup);
                    await context.SaveChangesAsync();
                }
                #endregion

                #region patients
                if (!context.Patients.Any())
                {
                    var patients = new List<Patient>
                    {
                        new Patient
                        {
                            BloodGroupId = 1
                        },
                        new Patient
                        {
                            BloodGroupId = 1
                        },
                        new Patient
                        {
                            BloodGroupId = 1
                        },
                        new Patient
                        {
                            BloodGroupId = 1
                        },
                        new Patient
                        {
                            BloodGroupId = 1
                        },
                        new Patient
                        {
                            BloodGroupId = 1
                        },
                        new Patient
                        {
                            BloodGroupId = 1
                        },
                        new Patient
                        {
                            BloodGroupId = 1
                        },
                        new Patient
                        {
                            BloodGroupId = 1
                        },
                        new Patient
                        {
                            BloodGroupId = 1
                        },
                        new Patient
                        {
                            BloodGroupId = 1
                        },
                        new Patient
                        {
                            BloodGroupId = 1
                        },
                    };
                    foreach (var patient in patients)
                    {
                        patient.Status = true;
                        patient.AddedBy = "System";
                        patient.ModifiedBy = "System";
                        patient.AddedDate = DateTime.Now;
                        patient.ModifiedDate = DateTime.Now;

                        await context.Patients.AddRangeAsync(patient);
                        await context.SaveChangesAsync();
                    }
                }
                #endregion
            }

            if (!context.Users.Any())
            {
                #region users
                var users = new List<User>
                {
                    #region admins
                    new User
                    {
                        Fullname = "Admin Admin",
                        Slug = "admin-admin",
                        Email = "admin@admin.com",
                        Role = UserRole.Admin,
                        Gender = Gender.Male,
                        AdminId = 1,
                        DoctorId = null,
                        PatientId = null
                    },
                    new User
                    {
                        Fullname = "Admin Pharmacy",
                        Slug = "admin-pharmacy",
                        Email = "admin@pharmacy.com",
                        Role = UserRole.Admin_Pharmcy,
                        Gender = Gender.Male,
                        AdminId = 2,
                        DoctorId = null,
                        PatientId = null
                    },
                    #endregion

                    #region doctors
                    new User
                    {
                        Fullname = "Ruby Perrin",
                        Slug = "ruby-perrin",
                        Email = "perrin.ruby@doccure.com",
                        Role = UserRole.Doctor,
                        Gender = Gender.Female,
                        AdminId = null,
                        DoctorId = 1,
                        PatientId = null
                    },
                    new User
                    {
                        Fullname = "Darren Elder",
                        Slug = "darren-elder",
                        Email = "elder.darren@doccure.com",
                        Role = UserRole.Doctor,
                        Gender = Gender.Male,
                        AdminId = null,
                        DoctorId = 2,
                        PatientId = null
                    },
                    new User
                    {
                        Fullname = "Deborah Angel",
                        Slug = "deborah-angel",
                        Email = "angel.deborah@doccure.com",
                        Role = UserRole.Doctor,
                        Gender = Gender.Female,
                        AdminId = null,
                        DoctorId = 3,
                        PatientId = null
                    },
                    new User
                    {
                        Fullname = "Sofia Brient",
                        Slug = "sofia-brient",
                        Email = "brient.sofia@doccure.com",
                        Role = UserRole.Doctor,
                        Gender = Gender.Female,
                        AdminId = null,
                        DoctorId = 4,
                        PatientId = null
                    },
                    new User
                    {
                        Fullname = "Marvin Campbell",
                        Slug = "marvin-campbell",
                        Email = "campbell.marvin@doccure.com",
                        Role = UserRole.Doctor,
                        Gender = Gender.Male,
                        AdminId = null,
                        DoctorId = 5,
                        PatientId = null
                    },
                    new User
                    {
                        Fullname = "Katherina Berthold",
                        Slug = "katherina-berthold",
                        Email = "berthold.katherina@doccure.com",
                        Role = UserRole.Doctor,
                        Gender = Gender.Female,
                        AdminId = null,
                        DoctorId = 6,
                        PatientId = null
                    },
                    new User
                    {
                        Fullname = "Linda Tobin",
                        Slug = "linda-tobin",
                        Email = "tobin.linda@doccure.com",
                        Role = UserRole.Doctor,
                        Gender = Gender.Female,
                        AdminId = null,
                        DoctorId = 7,
                        PatientId = null
                    },
                    new User
                    {
                        Fullname = "Paul Richard",
                        Slug = "richard-paul",
                        Email = "paul.richard@doccure.com",
                        Role = UserRole.Doctor,
                        Gender = Gender.Male,
                        AdminId = null,
                        DoctorId = 8,
                        PatientId = null
                    },
                    new User
                    {
                        Fullname = "John Gibbs",
                        Slug = "john-gibbs",
                        Email = "gibbs.john@doccure.com",
                        Role = UserRole.Doctor,
                        Gender = Gender.Male,
                        AdminId = null,
                        DoctorId = 9,
                        PatientId = null
                    },
                    new User
                    {
                        Fullname = "Olga Barlow",
                        Slug = "olga-barlow",
                        Email = "barlow.olga@doccure.com",
                        Role = UserRole.Doctor,
                        Gender = Gender.Female,
                        AdminId = null,
                        DoctorId = 10,
                        PatientId = null
                    },
                    #endregion

                    #region patients
                    new User
                    {
                        Fullname = "Richard Wilson",
                        Slug = "richard-wilson",
                        Email = "wilson.richard@doccure.com",
                        Role = UserRole.Patient,
                        Gender = Gender.Male,
                        AdminId = null,
                        DoctorId = null,
                        PatientId = 1
                    },
                    new User
                    {
                        Fullname = "Charlene Reed",
                        Slug = "charlene-reed",
                        Email = "reed.charlene@doccure.com",
                        Role = UserRole.Patient,
                        Gender = Gender.Female,
                        AdminId = null,
                        DoctorId = null,
                        PatientId = 2
                    },
                    new User
                    {
                        Fullname = "Travis Trimble",
                        Slug = "travis-trimble",
                        Email = "trimble.travis@doccure.com",
                        Role = UserRole.Patient,
                        Gender = Gender.Male,
                        AdminId = null,
                        DoctorId = null,
                        PatientId = 3
                    },
                    new User
                    {
                        Fullname = "Carl Kelly",
                        Slug = "carl-kelly",
                        Email = "kelly.carl@doccure.com",
                        Role = UserRole.Patient,
                        Gender = Gender.Male,
                        AdminId = null,
                        DoctorId = null,
                        PatientId = 4
                    },
                    new User
                    {
                        Fullname = "Michelle Fairfax",
                        Slug = "michelle-fairfax",
                        Email = "fairfax.michelle@doccure.com",
                        Role = UserRole.Patient,
                        Gender = Gender.Female,
                        AdminId = null,
                        DoctorId = null,
                        PatientId = 5
                    },
                    new User
                    {
                        Fullname = "Gina Moore",
                        Slug = "gina-moore",
                        Email = "moore.gina@doccure.com",
                        Role = UserRole.Patient,
                        Gender = Gender.Female,
                        AdminId = null,
                        DoctorId = null,
                        PatientId = 6
                    },
                    new User
                    {
                        Fullname = "Elsie Gilley",
                        Slug = "elsie-gilley",
                        Email = "gilley.elsie@doccure.com",
                        Role = UserRole.Patient,
                        Gender = Gender.Female,
                        AdminId = null,
                        DoctorId = null,
                        PatientId = 7
                    },
                    new User
                    {
                        Fullname = "Joan Gardner",
                        Slug = "joan-gardner",
                        Email = "gardner.joan@doccure.com",
                        Role = UserRole.Patient,
                        Gender = Gender.Female,
                        AdminId = null,
                        DoctorId = null,
                        PatientId = 8
                    },
                    new User
                    {
                        Fullname = "Daniel Griffing",
                        Slug = "daniel-griffing",
                        Email = "griffing.daniel@doccure.com",
                        Role = UserRole.Patient,
                        Gender = Gender.Male,
                        AdminId = null,
                        DoctorId = null,
                        PatientId = 9
                    },
                    new User
                    {
                        Fullname = "Walter Roberson",
                        Slug = "walter-roberson",
                        Email = "roberson.walter@doccure.com",
                        Role = UserRole.Patient,
                        Gender = Gender.Male,
                        AdminId = null,
                        DoctorId = null,
                        PatientId = 10
                    },
                    new User
                    {
                        Fullname = "Robert Rhodes",
                        Slug = "robert-rhodes",
                        Email = "rhodes.robert@doccure.com",
                        Role = UserRole.Patient,
                        Gender = Gender.Male,
                        AdminId = null,
                        DoctorId = null,
                        PatientId = 11
                    },
                    new User
                    {
                        Fullname = "Harry Williams",
                        Slug = "harry-williams",
                        Email = "williams.harry@doccure.com",
                        Role = UserRole.Patient,
                        Gender = Gender.Male,
                        AdminId = null,
                        DoctorId = null,
                        PatientId = 12
                    },
                    #endregion
                };
                foreach (var user in users)
                {
                    user.Status = true;
                    user.AddedBy = "System";
                    user.ModifiedBy = "System";
                    user.AddedDate = DateTime.Now;
                    user.ModifiedDate = DateTime.Now;

                    user.Code = new Random().Next(100000, 999999).ToString();
                    user.Token = Guid.NewGuid().ToString();
                    user.Password = Crypto.HashPassword("yavar10Yr");
                    user.Photo = null;
                    user.InviteToken = null;
                    user.ConfirmToken = null;
                    user.ConnectionId = null;
                    user.Biography = "<div class='about - text'>Lorem ipsum dolor sit amet, " +
                                     "consectetur adipiscing elit, sed do eiusmod tempor incididunt ut " +
                                     "labore et dolore magna aliqua.</div>";
                    user.PostalCode = "22434";
                    user.Address = "<p class='col-sm-10 mb-0'>4663 Agriculture Lane,<br>Miami,<br>Florida-33165,<br>United States.</p>";
                    user.City = "Miami";
                    user.State = "Florida";
                    user.Country = "United States";
                    user.Phone = "+994 55 904-68-23";
                    user.Birth = new DateTime(1990, 06, 29);

                    await context.Users.AddRangeAsync(user);
                    await context.SaveChangesAsync();
                }
                #endregion

                #region chat
                if (!context.Chats.Any())
                {
                    var chats = new List<Chat>
                    {
                        new Chat
                        {
                            DoctorId = 3,
                            PatientId = 13,
                        },
                        new Chat
                        {
                            DoctorId = 3,
                            PatientId = 14,
                        },
                        new Chat
                        {
                            DoctorId = 3,
                            PatientId = 15,
                        },
                        new Chat
                        {
                            DoctorId = 4,
                            PatientId = 14,
                        },
                        new Chat
                        {
                            DoctorId = 5,
                            PatientId = 14,
                        },
                    };
                    foreach (var chat in chats)
                    {
                        chat.Status = true;
                        chat.AddedBy = "System";
                        chat.ModifiedBy = "System";
                        chat.AddedDate = DateTime.Now;
                        chat.ModifiedDate = DateTime.Now;

                        await context.Chats.AddRangeAsync(chat);
                        await context.SaveChangesAsync();
                    }

                    #region chat messages
                    if (!context.ChatMessages.Any())
                    {
                        var chatMessages = new List<ChatMessage>
                        {
                            new ChatMessage
                            {
                                DoctorContent = "I'm just looking around. Are you there? That time!",
                                PatientContent = null,
                            },
                            new ChatMessage
                            {
                                DoctorContent = null,
                                PatientContent = "Hello. What can I do for you?",
                            },
                            new ChatMessage
                            {
                                DoctorContent = "I did not ask you to do something",
                                PatientContent = null,
                            },
                            new ChatMessage
                            {
                                DoctorContent = null,
                                PatientContent = "Then, what do you exactly want?",
                            },
                            new ChatMessage
                            {
                                DoctorContent = "I am asking you, are you there?",
                                PatientContent = null,
                            },
                            new ChatMessage
                            {
                                DoctorContent = null,
                                PatientContent = "Why do you ask?",
                            },
                            new ChatMessage
                            {
                                DoctorContent = "Come on man, answer me",
                                PatientContent = null,
                            },
                            new ChatMessage
                            {
                                DoctorContent = null,
                                PatientContent = "Why?",
                            }
                        };
                        foreach (var chatMessage in chatMessages)
                        {
                            chatMessage.Status = true;
                            chatMessage.AddedBy = "System";
                            chatMessage.ModifiedBy = "System";
                            chatMessage.AddedDate = DateTime.Now;
                            chatMessage.ModifiedDate = DateTime.Now;

                            chatMessage.Photo = null;
                            chatMessage.IsSeen = true;
                            chatMessage.ChatId = 1;

                            await context.ChatMessages.AddRangeAsync(chatMessage);
                            await context.SaveChangesAsync();
                        }
                    }
                    #endregion
                }
                #endregion

                #region review
                if (!context.Reviews.Any())
                {
                    var reviews = new List<Review>
                    {
                        new Review
                        {
                            IsReply = true,
                            PatientId = 13,
                            Recommendation = DoctorRecommendation.Yes
                        },
                        new Review
                        {
                            IsReply = false,
                            PatientId = 14,
                            Recommendation = DoctorRecommendation.Select
                        },
                    };
                    foreach (var review in reviews)
                    {
                        review.Status = true;
                        review.AddedBy = "System";
                        review.ModifiedBy = "System";
                        review.AddedDate = DateTime.Now;
                        review.ModifiedDate = DateTime.Now;

                        review.DoctorId = 3;
                        review.Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do " +
                                      "eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad " +
                                      "minim veniam, quis nostrud exercitation. Curabitur non nulla sit amet nisl " +
                                      "tempus";

                        await context.Reviews.AddRangeAsync(review);
                        await context.SaveChangesAsync();
                    }

                    if (!context.ReviewStars.Any())
                    {
                        var reviewStars = new List<ReviewStar>
                        {
                            new ReviewStar
                            {
                                Star = "fa-star filled,fa-star filled,fa-star filled,fa-star filled,fa-star",
                            },
                            new ReviewStar
                            {
                                Star = "fa-star filled,fa-star filled,fa-star filled,fa-star filled,fa-star filled",
                            },
                        };
                        foreach (var reviewStar in reviewStars)
                        {
                            reviewStar.Status = true;
                            reviewStar.AddedBy = "System";
                            reviewStar.ModifiedBy = "System";
                            reviewStar.AddedDate = DateTime.Now;
                            reviewStar.ModifiedDate = DateTime.Now;

                            reviewStar.DoctorId = 3;
                            reviewStar.Number = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(reviewStar.Star.Length * reviewStar.Star.Split(",").Count()) / 10));

                            await context.ReviewStars.AddRangeAsync(reviewStar);
                            await context.SaveChangesAsync();
                        }
                    }

                    if (!context.ReviewReplies.Any())
                    {
                        var reviewReplies = new List<ReviewReply>
                        {
                            new ReviewReply
                            {
                                DoctorId = 3,
                                PatientId = null
                            },
                            new ReviewReply
                            {
                                DoctorId = null,
                                PatientId = 13
                            }
                        };
                        foreach (var reviewReply in reviewReplies)
                        {
                            reviewReply.ReviewId = 1;
                            reviewReply.Status = true;
                            reviewReply.AddedBy = "System";
                            reviewReply.ModifiedBy = "System";
                            reviewReply.AddedDate = DateTime.Now;
                            reviewReply.ModifiedDate = DateTime.Now;

                            reviewReply.Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do " +
                                               "eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad " +
                                               "minim veniam, quis nostrud exercitation. Curabitur non nulla sit amet nisl " +
                                               "tempus";

                            await context.ReviewReplies.AddRangeAsync(reviewReply);
                            await context.SaveChangesAsync();
                        }
                    }
                }
                #endregion

                #region blogs
                if (!context.Blogs.Any())
                {
                    var blogs = new List<Blog>
                    {
                        new Blog
                        {
                            Title = "Doccure – Making your clinic painless visit?",
                            Slug = "doccure-–-making-your-clinic-painless-visit",
                            DoctorId = 1
                        },
                        new Blog
                        {
                            Title = "What are the benefits of Online Doctor Booking?",
                            Slug = "what-are-the-benefits-of-online-doctor-booking",
                            DoctorId = 2
                        },
                        new Blog
                        {
                            Title = "Benefits of consulting with an Online Doctor",
                            Slug = "benefits-of-consulting-with-an-online-doctor",
                            DoctorId = 3
                        },
                        new Blog
                        {
                            Title = "5 Great reasons to use an Online Doctor",
                            Slug = "5-great-reasons-to-use-an-online-doctor",
                            DoctorId = 4
                        },
                        new Blog
                        {
                            Title = "Online Doctor Appointment Scheduling",
                            Slug = "online-doctor-appointment-scheduling",
                            DoctorId = 5
                        },
                        new Blog
                        {
                            Title = "Simple steps to make your doctor visits exceptional!",
                            Slug = "simple-steps-to-make-your-doctor-visits-exceptional",
                            DoctorId = 6
                        },
                        new Blog
                        {
                            Title = "Choose your own Online Doctor Appointment",
                            Slug = "choose-your-own-online-doctor-appointment",
                            DoctorId = 7
                        },
                        new Blog
                        {
                            Title = "Simple steps to visit your doctor today",
                            Slug = "simple-steps-to-visit-your-doctor-today",
                            DoctorId = 8
                        },
                        new Blog
                        {
                            Title = "5 Great reasons to use an Online Doctor",
                            Slug = "5-great-reasons-to-use-an-online-doctor",
                            DoctorId = 9
                        },
                        new Blog
                        {
                            Title = "Online Doctoral Programs",
                            Slug = "online-doctoral-programs",
                            DoctorId = 10
                        }
                    };
                    foreach (var blog in blogs)
                    {
                        blog.Status = true;
                        blog.AddedBy = "System";
                        blog.ModifiedBy = "System";
                        blog.AddedDate = DateTime.Now;
                        blog.ModifiedDate = DateTime.Now;

                        blog.Photo = null;
                        blog.Video = "https://www.youtube.com/embed/nuVqJ_OriR8?rel=0&amp;controls=0&amp;showinfo=0";
                        blog.Description = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
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
                                          "maiores alias consequatur aut perferendis doloribus asperiores repellat.</p>";

                        await context.Blogs.AddRangeAsync(blog);
                        await context.SaveChangesAsync();
                    }

                    #region comments
                    if (!context.Comments.Any())
                    {
                        var comments = new List<Comment>
                        {
                            new Comment
                            {
                                UserId = 13,
                                BlogId = 1,
                                IsReply = true
                            },
                            new Comment
                            {
                                UserId = 14,
                                BlogId = 1,
                                IsReply = false
                            },
                            new Comment
                            {
                                UserId = 15,
                                BlogId = 1,
                                IsReply = false
                            },
                            new Comment
                            {
                                UserId = 16,
                                BlogId = 2,
                                IsReply = true
                            },
                            new Comment
                            {
                                UserId = 17,
                                BlogId = 2,
                                IsReply = false
                            },
                            new Comment
                            {
                                UserId = 18,
                                BlogId = 2,
                                IsReply = false
                            },
                        };
                        foreach (var comment in comments)
                        {
                            comment.Status = true;
                            comment.AddedBy = "System";
                            comment.ModifiedBy = "System";
                            comment.AddedDate = DateTime.Now;
                            comment.ModifiedDate = DateTime.Now;

                            comment.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";

                            await context.Comments.AddRangeAsync(comment);
                            await context.SaveChangesAsync();
                        }

                        if (!context.CommentReplies.Any())
                        {
                            var commenReply = new List<CommentReply>
                            {
                                new CommentReply
                                {
                                    CommentId = 1,
                                    UserId = 15
                                },
                                new CommentReply
                                {
                                    CommentId = 4,
                                    UserId = 17
                                }
                            };
                            foreach (var commentReply in commenReply)
                            {
                                commentReply.Status = true;
                                commentReply.AddedBy = "System";
                                commentReply.ModifiedBy = "System";
                                commentReply.AddedDate = DateTime.Now;
                                commentReply.ModifiedDate = DateTime.Now;

                                commentReply.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";

                                await context.CommentReplies.AddRangeAsync(commentReply);
                                await context.SaveChangesAsync();
                            }
                        }
                    }
                    #endregion
                }
                #endregion
            }
            #endregion

            #region settings
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

                if (!context.SettingPhotos.Any())
                {
                    var settingPhotos = new List<SettingPhoto>
                    {
                        new SettingPhoto
                        {
                            Name = "HeaderAndInvoice",
                        },
                        new SettingPhoto
                        {
                            Name = "Footer",
                        },
                        new SettingPhoto
                        {
                            Name = "Available",
                        },
                        new SettingPhoto
                        {
                            Name = "Patient",
                        },
                        new SettingPhoto
                        {
                            Name = "AdminAndDoctor",
                        }
                    };
                    foreach (var settingPhoto in settingPhotos)
                    {
                        settingPhoto.Status = true;
                        settingPhoto.AddedBy = "System";
                        settingPhoto.ModifiedBy = "System";
                        settingPhoto.AddedDate = DateTime.Now;
                        settingPhoto.ModifiedDate = DateTime.Now;

                        settingPhoto.SettingId = 1;
                        settingPhoto.Photo = null;

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
                            Name = "Facebook",
                            Icon = "facebook-f",
                            Link = "https://www.facebook.com/"
                        },
                        new SocialMedia
                        {
                            Name = "Twitter",
                            Icon = "twitter",
                            Link = "https://www.twitter.com/"
                        },
                        new SocialMedia
                        {
                            Name = "Linkedin",
                            Icon = "linkedin-in",
                            Link = "https://www.linkedin.com/"
                        },
                        new SocialMedia
                        {
                            Name = "Instagram",
                            Icon = "instagram",
                            Link = "https://www.instagram.com/"
                        },
                        new SocialMedia
                        {
                            Name = "Dribbble",
                            Icon = "dribbble",
                            Link = "https://www.dribbble.com/"
                        }
                    };
                    foreach (var socialMedia in socialMedias)
                    {
                        socialMedia.Status = true;
                        socialMedia.AddedBy = "System";
                        socialMedia.ModifiedBy = "System";
                        socialMedia.AddedDate = DateTime.Now;
                        socialMedia.ModifiedDate = DateTime.Now;

                        socialMedia.SettingId = 1;

                        await context.SocialMedias.AddRangeAsync(socialMedia);
                        await context.SaveChangesAsync();
                    }
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

            if (!context.Features.Any())
            {
                var features = new List<Feature>
                {
                    new Feature
                    {
                        ClinicName = "Operation"
                    },
                    new Feature
                    {
                        ClinicName = "Medical"
                    },
                    new Feature
                    {
                        ClinicName = "Patient Ward"
                    },
                    new Feature
                    {
                        ClinicName = "Test Room"
                    },
                    new Feature
                    {
                        ClinicName = "ICU"
                    },
                    new Feature
                    {
                        ClinicName = "Laboratory"
                    }
                };
                foreach (var feature in features)
                {
                    feature.Status = true;
                    feature.AddedBy = "System";
                    feature.ModifiedBy = "System";
                    feature.AddedDate = DateTime.Now;
                    feature.ModifiedDate = DateTime.Now;

                    feature.Photo = null;

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
                        Name = "Cardiologist"
                    },
                    new Speciality
                    {
                        Name = "Dentist"
                    },
                    new Speciality
                    {
                        Name = "Neurologist"
                    },
                    new Speciality
                    {
                        Name = "Orthopedics"
                    },
                    new Speciality
                    {
                        Name = "Urologist"
                    }
                };
                foreach (var speciality in specialities)
                {
                    speciality.Status = true;
                    speciality.AddedBy = "System";
                    speciality.ModifiedBy = "System";
                    speciality.AddedDate = DateTime.Now;
                    speciality.ModifiedDate = DateTime.Now;

                    speciality.Photo = null;

                    await context.Specialities.AddRangeAsync(speciality);
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
            #endregion
        }
    }
}