using AutoMapper;
using Core;
using Core.DTOs.Admin.Admin_Setting;
using Core.Models;
using Core.Services.Data;
using System;
using System.Threading.Tasks;

namespace Services.Data
{
  public class TermService : ITermService
  {
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public TermService(IMapper mapper, IUnitOfWork unitOfWork)
    {
      _mapper = mapper;
      _unitOfWork = unitOfWork;
    }

    public async Task<TermDTO> GetAsync()
    {
      return _mapper.Map<TermDTO>(await _unitOfWork.Term.Get());
    }

    public async Task UpdateAsync(Term termToBeUpdated, Term term)
    {
      termToBeUpdated.Id = termToBeUpdated.Id;
      termToBeUpdated.Status = true;
      termToBeUpdated.AddedDate = termToBeUpdated.AddedDate;
      termToBeUpdated.ModifiedDate = DateTime.Now;
      termToBeUpdated.AddedBy = termToBeUpdated.AddedBy;
      termToBeUpdated.ModifiedBy = termToBeUpdated.ModifiedBy;

      termToBeUpdated.TermHeading = term.TermHeading ?? termToBeUpdated.TermHeading;
      termToBeUpdated.TermSubheading = term.TermSubheading ?? termToBeUpdated.TermSubheading;
      termToBeUpdated.TermBody = term.TermBody ?? termToBeUpdated.TermBody;
      termToBeUpdated.TermFooter = term.TermFooter ?? termToBeUpdated.TermFooter;

      await _unitOfWork.CommitAsync();
    }
  }
}