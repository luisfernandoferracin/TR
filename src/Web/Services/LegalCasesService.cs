using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Communication;
using Web.Extensions;
using Web.ViewModels;

namespace Web.Services
{
    public interface ILegalCasesService
    {
        Task<IEnumerable<CaseViewModel>> GetAll();
        Task<CaseViewModel> GetById(string id);
        Task<ResponseResult> Create(CaseViewModel legalCaseViewModel);
        Task<ResponseResult> Update(string id, CaseViewModel legalCaseViewModel);
        Task<ResponseResult> Delete(string id);
    }
    public class LegalCasesService : Service, ILegalCasesService
    {
        private readonly HttpClient _httpClient;

        public LegalCasesService(HttpClient httpClient,
                                 IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.LegalCasesUrl);

            _httpClient = httpClient;
        }

        public async Task<ResponseResult> Create(CaseViewModel legalCaseViewModel)
        {
            var itemContent = GetContent(legalCaseViewModel);

            var response = await _httpClient.PostAsync("/api/v1/LegalCases/", itemContent);

            if (!HandlingResponseErrors(response)) return await DeserializeResponseObject<ResponseResult>(response);

            return ReturnOk();
        }

        public async Task<ResponseResult> Update(string id, CaseViewModel legalCaseViewModel)
        {
            var itemContent = GetContent(legalCaseViewModel);

            var response = await _httpClient.PutAsync($"/api/v1/LegalCases/{id}", itemContent);

            if (!HandlingResponseErrors(response)) return await DeserializeResponseObject<ResponseResult>(response);

            return ReturnOk();
        }

        public async Task<ResponseResult> Delete(string id)
        {
            var response = await _httpClient.DeleteAsync($"/api/v1/LegalCases/{id}");

            if (!HandlingResponseErrors(response)) return await DeserializeResponseObject<ResponseResult>(response);

            return ReturnOk();
        }

        public async Task<CaseViewModel> GetById(string id)
        {
            var response = await _httpClient.GetAsync($"/api/v1/LegalCases/{id}");

            HandlingResponseErrors(response);

            return await DeserializeResponseObject<CaseViewModel>(response);
        }

        public async Task<IEnumerable<CaseViewModel>> GetAll()
        {
            var response = await _httpClient.GetAsync("/api/v1/LegalCases/list");

            HandlingResponseErrors(response);

            return await DeserializeResponseObject<IEnumerable<CaseViewModel>>(response);
        }
    }
}