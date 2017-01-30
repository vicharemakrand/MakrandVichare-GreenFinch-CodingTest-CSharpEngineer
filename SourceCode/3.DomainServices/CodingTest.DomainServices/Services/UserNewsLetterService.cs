using CodingTest.DomainServices.Core;
using CodingTest.EntityModels;
using CodingTest.IDomainServices.Services;
using CodingTest.ServiceResponse;
using CodingTest.Utility;
using CodingTest.ViewModels;
using System;
using System.Linq;
using CodingTest.IDomainServices.AutoMapper;
using System.Collections.Generic;


namespace CodingTest.DomainServices
{
    public class UserNewsLetterService : BaseService<UserNewsLetterEntityModel, UserNewsLetterViewModel>, IUserNewsLetterService
    {
        public  ResponseResults<NewsLetterViewModel> GetUserNewsLetters(long userId)
        {
            var response = new ResponseResults<NewsLetterViewModel> { IsSucceed = true, ViewModels= new List<NewsLetterViewModel>(), Message = AppMessages.RETRIEVED_DETAILS_SUCCESSFULLY };
            try
            {
                if (userId >0)
                {
                    var userNewsLettrs = UnitOfWork.UserNewsLetterRepository.FindByUser(userId);
                    if(userNewsLettrs != null && userNewsLettrs.NewsLetterIds != null && userNewsLettrs.NewsLetterIds.Length>0)
                    {
                        var longIds = AppMethods.StringToLongList(userNewsLettrs.NewsLetterIds);

                        var models = UnitOfWork.NewsLetterRepository.GetNewsLettersByIds(longIds);
                        response.ViewModels = models.ToViewModel<NewsLetterEntityModel, NewsLetterViewModel>().ToList();
                    }
                }

                if (response.ViewModels.Count <= 0)
                {
                    response.Message = AppMessages.NO_RECORD_FOUND;
                }
            }
            catch (Exception ex)
            {
                response.IsSucceed = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
