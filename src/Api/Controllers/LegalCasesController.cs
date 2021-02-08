using Api.Controllers;
using Api.ViewModels;
using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/LegalCases")]
    public class LegalCasesController : MainController
    {
        private readonly ILegalCasesRepository _legalCasesRepository;
        private readonly ILegalCasesService _legalCasesService;
        private readonly IMapper _mapper;

        public LegalCasesController(ILegalCasesRepository legalCasesRepository, 
                                     IMapper mapper, 
                                     ILegalCasesService legalCasesService,
                                     INotifier notifier) : base(notifier)
        {
            _legalCasesRepository = legalCasesRepository;
            _mapper = mapper;
            _legalCasesService = legalCasesService;
        }

        [HttpGet("list")]
        public async Task<IEnumerable<CaseViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<CaseViewModel>>(await _legalCasesRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<CaseViewModel> GetById(string id)
        {
            return await GetLegalCasesById(id); 
        }

        [HttpPost]
        public async Task<IActionResult> Create(CaseViewModel caseViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);            

            await _legalCasesService.Create(_mapper.Map<Case>(caseViewModel));

            return CustomResponse(caseViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, CaseViewModel caseViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _legalCasesService.Update(id, _mapper.Map<Case>(caseViewModel));

            return CustomResponse(caseViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _legalCasesService.Delete(id);

            return CustomResponse(new object());
        }

        private async Task<CaseViewModel> GetLegalCasesById(string id)
        {
            return _mapper.Map<CaseViewModel>(await _legalCasesRepository.GetById(id));
        }

    }
}