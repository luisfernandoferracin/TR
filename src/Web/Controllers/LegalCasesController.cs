using Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Controllers
{
    public class LegalCasesController : BaseController
    {
        private readonly ILegalCasesService _legalCasesServiceService;
        
        public LegalCasesController(ILegalCasesService legalCasesServiceService) 
        {
            _legalCasesServiceService = legalCasesServiceService;
        }

        [Route("list-legal-cases")]
        public async Task<IActionResult> Index()
        {
            return View(await _legalCasesServiceService.GetAll());
        }

        [Route("details-legal-case/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            var legalCaseViewModel = await _legalCasesServiceService.GetById(id);

            if (legalCaseViewModel == null)
            {
                return NotFound();
            }

            return View(legalCaseViewModel);
        }

        [Route("new-legal-case")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("new-legal-case")]
        [HttpPost]
        public async Task<IActionResult> Create(CaseViewModel legalCaseViewModel)
        {
            if (!ModelState.IsValid) return View(legalCaseViewModel);

            var result = await _legalCasesServiceService.Create(legalCaseViewModel);

            if (ResponseHasErrors(result)) return View(legalCaseViewModel);

            return RedirectToAction("Index");
        }

        [Route("edit-legal-case/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            var legalCaseViewModel = await _legalCasesServiceService.GetById(id);

            if (legalCaseViewModel == null)
            {
                return NotFound();
            }

            return View(legalCaseViewModel);
        }

        [Route("edit-legal-case/{id}")]
        [HttpPost]
        public async Task<IActionResult> Edit(string id, CaseViewModel legalCaseViewModel)
        {
            if (id != legalCaseViewModel.CaseNumber) return NotFound();

            if (!ModelState.IsValid) return View(legalCaseViewModel);

            var result = await _legalCasesServiceService.Update(id, legalCaseViewModel);

            if (ResponseHasErrors(result)) return View(await _legalCasesServiceService.GetById(id));

            return RedirectToAction("Index");
        }

        [Route("delete-legal-case/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var legalCaseViewModel = await _legalCasesServiceService.GetById(id);

            if (legalCaseViewModel == null)
            {
                return NotFound();
            }

            return View(legalCaseViewModel);
        }

        [Route("delete-legal-case/{id}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var legalCases = await _legalCasesServiceService.GetById(id);

            if (legalCases == null) return NotFound();

            var result = await _legalCasesServiceService.Delete(id);

            if (ResponseHasErrors(result)) return View(legalCases);

            return RedirectToAction("Index");
        }        
    }
}
