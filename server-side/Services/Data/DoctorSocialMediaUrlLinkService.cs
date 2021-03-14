using Core;
using Core.Models;
using Core.Services.Data;
using System;
using System.Threading.Tasks;

namespace Services.Data
{
    public class DoctorSocialMediaUrlLinkService : IDoctorSocialMediaUrlLinkService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorSocialMediaUrlLinkService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DoctorSocialMediaUrlLink> GetAsync(int id)
        {
            return await _unitOfWork.DoctorSocialMediaUrl.Get(id);
        }

        public async Task CreateAsync(DoctorSocialMediaUrlLink newUrlLink)
        {
            newUrlLink.Status = true;
            newUrlLink.AddedDate = DateTime.Now;
            newUrlLink.ModifiedDate = DateTime.Now;
            newUrlLink.AddedBy = "System";
            newUrlLink.ModifiedBy = "System";

            newUrlLink.FacebookURL = "https://www.facebook.com/";
            newUrlLink.TwitterURL = "https://www.twitter.com/";
            newUrlLink.InstagramURL = "https://www.pinterest.com/";
            newUrlLink.PinterestURL = "https://www.instagram.com/";
            newUrlLink.LinkedinURL = "https://www.linkedin.com/";

            newUrlLink.DoctorId = newUrlLink.DoctorId;

            await _unitOfWork.DoctorSocialMediaUrl.AddAsync(newUrlLink);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(DoctorSocialMediaUrlLink urlLinkToBeUpdated, DoctorSocialMediaUrlLink urlLink)
        {
            urlLinkToBeUpdated.Id = urlLinkToBeUpdated.Id;
            urlLinkToBeUpdated.Status = true;
            urlLinkToBeUpdated.AddedDate = urlLinkToBeUpdated.AddedDate;
            urlLinkToBeUpdated.ModifiedDate = DateTime.Now;
            urlLinkToBeUpdated.AddedBy = urlLinkToBeUpdated.AddedBy;
            urlLinkToBeUpdated.ModifiedBy = urlLinkToBeUpdated.ModifiedBy;

            urlLinkToBeUpdated.FacebookURL = urlLink.FacebookURL != null ? urlLink.FacebookURL : urlLinkToBeUpdated.FacebookURL;
            urlLinkToBeUpdated.TwitterURL = urlLink.TwitterURL != null ? urlLink.TwitterURL : urlLinkToBeUpdated.TwitterURL;
            urlLinkToBeUpdated.InstagramURL = urlLink.InstagramURL != null ? urlLink.InstagramURL : urlLinkToBeUpdated.InstagramURL;
            urlLinkToBeUpdated.PinterestURL = urlLink.PinterestURL != null ? urlLink.PinterestURL : urlLinkToBeUpdated.PinterestURL;
            urlLinkToBeUpdated.LinkedinURL = urlLink.LinkedinURL != null ? urlLink.LinkedinURL : urlLinkToBeUpdated.LinkedinURL;

            urlLinkToBeUpdated.DoctorId = urlLinkToBeUpdated.DoctorId;

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(DoctorSocialMediaUrlLink urlLink)
        {
            _unitOfWork.DoctorSocialMediaUrl.Remove(urlLink);
            await _unitOfWork.CommitAsync();
        }
    }
}