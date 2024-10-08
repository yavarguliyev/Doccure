﻿using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
  public class SpecialityRepository : Repository<Speciality>, ISpecialityRepository
  {
    public SpecialityRepository(DataContext context) : base(context) { }

    private DataContext Getcontext() { return Context as DataContext; }

    public async Task<IEnumerable<Speciality>> Get()
    {
      return await Getcontext().Specialities.Where(x => x.Status).ToListAsync();
    }
  }
}