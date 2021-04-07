using Core.DTOs.Main;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services.Data
{
    public interface ISpecialityService
    {
        Task<IEnumerable<SpecialityDTO>> GetAsync();
    }
}