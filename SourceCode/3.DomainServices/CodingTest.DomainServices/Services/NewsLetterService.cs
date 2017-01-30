using CodingTest.DomainServices.Core;
using CodingTest.EntityModels;
using CodingTest.IDomainServices.Services;
using CodingTest.ServiceResponse;
using CodingTest.Utility;
using CodingTest.ViewModels;
using System;
using System.Linq;
using CodingTest.IDomainServices.AutoMapper;
using CodingTest.Utility.ParamViewModels;
using System.Collections.Generic;

namespace CodingTest.DomainServices
{
    public class NewsLetterService : BaseService<NewsLetterEntityModel, NewsLetterViewModel>, INewsLetterService
    {

        public  ResponseResults<NewsLetterViewModel> GetTopNewsLetters(long userId)
        {
            var response = new ResponseResults<NewsLetterViewModel>() { IsSucceed = true, Message = AppMessages.RETRIEVED_DETAILS_SUCCESSFULLY };
            try
            {
                var models = UnitOfWork.NewsLetterRepository.PageAll(0, 10);
                response.ViewModels = models.ToViewModel<NewsLetterEntityModel, NewsLetterViewModel>().ToList();

                if (response.ViewModels!= null && response.ViewModels.Count >0 && userId > 0)
                {
                    var userNewsLetterLookUp = UnitOfWork.UserNewsLetterRepository.Get(o => o.UserId == userId);
                    if (userNewsLetterLookUp != null && userNewsLetterLookUp.NewsLetterIds != null && userNewsLetterLookUp.NewsLetterIds.Length > 0)
                    {
                        response.ViewModels.ForEach(o => o.IsSubscribed = userNewsLetterLookUp.NewsLetterIds.Contains(o.Id.ToString()));
                    }
                }

                if (response.ViewModels == null || response.ViewModels.Count <=0)
                {
                    response.Message = AppMessages.NO_RECORD_FOUND;
                    response.ViewModels = new List<NewsLetterViewModel>();
                }
            }
            catch (Exception ex)
            {
                response.IsSucceed = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public ResponseResults<NewsLetterViewModel> GetNewsLetters(SearchNewLetterViewModel searchParam)
        {
            var response = new ResponseResults<NewsLetterViewModel> { IsSucceed = true, Message = AppMessages.RETRIEVED_DETAILS_SUCCESSFULLY };
            try
            {
                var models = UnitOfWork.NewsLetterRepository.GetNewsLetters(searchParam);
                response.ViewModels = models.ToViewModel<NewsLetterEntityModel, NewsLetterViewModel>().ToList();

                if (response.ViewModels != null && response.ViewModels.Count > 0 && searchParam.UserId>0)
                {
                    var userNewsLetterLookUp = UnitOfWork.UserNewsLetterRepository.Get(o => o.UserId == searchParam.UserId);
                    if (userNewsLetterLookUp != null && userNewsLetterLookUp.NewsLetterIds != null && userNewsLetterLookUp.NewsLetterIds.Length > 0)
                    {
                        response.ViewModels.ForEach(o => o.IsSubscribed = userNewsLetterLookUp.NewsLetterIds.Contains(o.Id.ToString()));
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
