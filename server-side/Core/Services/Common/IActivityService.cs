using Core.Models;
using System.Threading.Tasks;

namespace Core.Services.Common
{
    public interface IActivityService
    {
        #region email
        Task SendEmail(User user, string purpose, string titleText, string bodytext, bool btnActivve, string btnText, string url);
        #endregion
    }
}