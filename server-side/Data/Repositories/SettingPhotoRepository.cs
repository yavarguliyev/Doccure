﻿using Core.Models;
using Core.Repositories;
using Data.Errors;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Data.Repositories
{
  public class SettingPhotoRepository : Repository<SettingPhoto>, ISettingPhotoRepository
  {
    public SettingPhotoRepository(DataContext context) : base(context) { }

    private DataContext Getcontext() { return Context as DataContext; }

    public async Task<SettingPhoto> Get(string name)
    {
      return await Getcontext().SettingPhotos
                          .Where(x => x.Status)
                          .Include(x => x.Setting)
                          .FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task<IEnumerable<SettingPhoto>> Get()
    {
      var setting = await Getcontext().Settings.Where(x => x.Status).FirstOrDefaultAsync();
      if (setting == null) throw new RestException(HttpStatusCode.NotFound, "Not found");

      return await Getcontext().SettingPhotos
                          .Where(x => x.Status && x.SettingId == setting.Id)
                          .Include(x => x.Setting)
                          .ToListAsync();
    }
  }
}