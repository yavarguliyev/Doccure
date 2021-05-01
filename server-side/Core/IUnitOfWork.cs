using Core.Repositories;
using System.Threading.Tasks;

namespace Core
{
    public interface IUnitOfWork
    {
        IAdminRepository Admin { get; }
        IChatRepository Chat { get; }
        ICommentRepository Comment { get; }
        ICommentReplyRepository CommentReply { get; }
        IDoctorRepository Doctor { get; }
        IPatientRepository Patient { get; }
        IUserRepository User { get; }

        IBlogRespository Blog { get; }
        IDoctorSocialMediaUrlLinkRepository DoctorSocialMediaUrl { get; }

        IFeatureRepository Feature { get; }
        ISpecialityRepository Speciality { get; }
        IPrivacyRepository Privacy { get; }
        ISettingRepository Setting { get; }
        ISettingPhotoRepository SettingPhoto { get; }
        ISocialMediaRepository SocialMedia { get; }
        ITermRepository Term { get; }

        Task<int> CommitAsync();
    }
}