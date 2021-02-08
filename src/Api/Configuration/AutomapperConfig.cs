using Api.ViewModels;
using AutoMapper;
using Business.Models;

namespace Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Case, CaseViewModel>().ReverseMap();
        }
    }
}