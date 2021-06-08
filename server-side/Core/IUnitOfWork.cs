using Core.Repositories;
using System.Threading.Tasks;

namespace Core
{
    public interface IUnitOfWork
    {
        IAdminRepository Admin { get; }
        IChatRepository Chat { get; }
        IChatMessageRepository ChatMessage { get; }
        ICommentRepository Comment { get; }
        ICommentReplyRepository CommentReply { get; }
        IDoctorRepository Doctor { get; }
        IPatientRepository Patient { get; }
        IUserRepository User { get; }
        IReviewRepository Review { get; }
        IReviewStarRepository ReviewStar { get; }
        IReviewReplyRepository ReviewReply { get; }

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