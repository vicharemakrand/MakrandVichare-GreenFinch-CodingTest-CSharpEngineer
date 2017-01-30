using AutoMapper;
using CodingTest.EntityModels;
using CodingTest.EntityModels.Core;
using CodingTest.EntityModels.Identity;
using CodingTest.ViewModels;
using CodingTest.ViewModels.Core;
using CodingTest.ViewModels.Identity;

namespace CodingTest.IDomainServices.AutoMapper
{
    public class ModelAutoMapperProfiler : Profile
    {
        public ModelAutoMapperProfiler()
        {
           CreateMap<BaseEntityModel, BaseViewModel>().ReverseMap();
           CreateMap<IdentityColumnEntityModel, IdentityColumnViewModel>().ReverseMap();

           CreateMap<UserEntityModel, IdentityUserViewModel>().ReverseMap();

           CreateMap<NewsLetterEntityModel, NewsLetterViewModel>().ReverseMap();

           CreateMap<UserNewsLetterEntityModel, UserNewsLetterViewModel>().ReverseMap();

        }
    }
}
