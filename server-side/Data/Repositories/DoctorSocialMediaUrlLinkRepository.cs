using Core.Models;
using Core.Repositories;
using Data.Errors;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Data.Repositories
{
  public class DoctorSocialMediaUrlLinkRepository : Repository<DoctorSocialMediaUrlLink>, IDoctorSocialMediaUrlLinkRepository
  {
    public DoctorSocialMediaUrlLinkRepository(DataContext context) : base(context) { }

    private DataContext Getcontext() { return Context as DataContext; }

    public async Task<DoctorSocialMediaUrlLink> Get(int id)
    {
      var doctor = await Getcontext().Doctors
                                .Where(x => x.Status)
                                .FirstOrDefaultAsync(x => x.Id == id);

      if (doctor == null) throw new RestException(HttpStatusCode.NotFound, "Not found!");

      return await Getcontext().DoctorSocialMediaUrlLinks
                          .Where(x => x.Status)
                          .FirstOrDefaultAsync(x => x.DoctorId == doctor.Id);
    }
  }
}