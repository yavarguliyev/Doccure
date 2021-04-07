using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ISpecialityRepository : IRepository<Speciality>
    {
        Task<IEnumerable<Speciality>> Get();
    }
}