using Core.Models;
using System.Threading.Tasks;

namespace Core.Services.Common
{
    public interface IActivityService
    {
        #region email
        Task SendEmail(User user, string purpose, string titleText, string bodytext, bool btnActive, string url);
        #endregion
    }
}