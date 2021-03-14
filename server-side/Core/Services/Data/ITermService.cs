using Core.DTOs.Admin.Admin_Setting;
using Core.Models;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface ITermService
    {
        Task<TermDTO> GetAsync();
        Task UpdateAsync(Term termToBeUpdated, Term term);
    }
}