using Core;
using Core.Repositories;
using Data.Repositories;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        private AdminRepository _adminRepository;
        private ChatRepository _chatRepository;
        private ChatMessageRepository _chatMessageRepository;
        private CommentRepository _commentRepository;
        private CommentReplyRepository _commentReplyRepository;
        private DoctorRepository _doctorRepository;
        private PatientRepository _patientRepository;
        private UserRepository _userRepository;
        private ReviewRepository _reviewRepository;
        private ReviewReplyRepository _reviewReplyRepository;

        private GroupRepository _groupRepository;
        private ConnectionRepository _connectionRepository;

        private IBlogRespository _blogRespository;
        private IDoctorSocialMediaUrlLinkRepository _doctorSocialMediaUrlLinkRepository;

        private IFeatureRepository _featureRepository;
        private ISpecialityRepository _specialityRepository;
        private IPrivacyRepository _privacyRepository;
        private ISettingRepository _settingRepository;
        private ISettingPhotoRepository _settingPhotoRepository;
        private ISocialMediaRepository _socialMediaRepository;
        private ITermRepository _termRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IAdminRepository Admin => _adminRepository ??= new AdminRepository(_context);
        public IChatRepository Chat => _chatRepository ??= new ChatRepository(_context);
        public IChatMessageRepository ChatMessage => _chatMessageRepository ??= new ChatMessageRepository(_context);
        public ICommentRepository Comment => _commentRepository ??= new CommentRepository(_context);
        public ICommentReplyRepository CommentReply => _commentReplyRepository ??= new CommentReplyRepository(_context);
        public IDoctorRepository Doctor => _doctorRepository ??= new DoctorRepository(_context);
        public IPatientRepository Patient => _patientRepository ??= new PatientRepository(_context);
        public IUserRepository User => _userRepository ??= new UserRepository(_context);
        public IReviewRepository Review => _reviewRepository ??= new ReviewRepository(_context);
        public IReviewReplyRepository ReviewReply => _reviewReplyRepository ??= new ReviewReplyRepository(_context);

        public IGroupRepository Group =>_groupRepository ??= new GroupRepository(_context);
        public IConnectionRepository Connection => _connectionRepository ??= new ConnectionRepository(_context);

        public IBlogRespository Blog => _blogRespository ??= new BlogRepository(_context);
        public IDoctorSocialMediaUrlLinkRepository DoctorSocialMediaUrl => _doctorSocialMediaUrlLinkRepository ??= new DoctorSocialMediaUrlLinkRepository(_context);

        public IFeatureRepository Feature => _featureRepository ??= new FeatureRepository(_context);
        public ISpecialityRepository Speciality => _specialityRepository ??= new SpecialityRepository(_context);
        public IPrivacyRepository Privacy => _privacyRepository ??= new PrivacyRepository(_context);
        public ISettingRepository Setting => _settingRepository ??= new SettingRepository(_context);
        public ISettingPhotoRepository SettingPhoto => _settingPhotoRepository ??= new SettingPhotoRepository(_context);
        public ISocialMediaRepository SocialMedia => _socialMediaRepository ??= new SocialMediaRepository(_context);
        public ITermRepository Term => _termRepository ??= new TermRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}