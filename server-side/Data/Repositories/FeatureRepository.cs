﻿using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
  public class FeatureRepository : Repository<Feature>, IFeatureRepository
  {
    public FeatureRepository(DataContext context) : base(context) { }

    private DataContext Getcontext() { return Context as DataContext; }

    public async Task<IEnumerable<Feature>> Get()
    {
      return await Getcontext().Features.Where(x => x.Status).ToListAsync();
    }
  }
}