using System;
using System.Linq;
using CodingTest.Utility;
using StructureMap.Attributes;
using CodingTest.ViewModels.Core;
using CodingTest.IDomainServices.Core;
using CodingTest.EntityModels.Core;
using CodingTest.ServiceResponse;
using CodingTest.IRepositories.Core;
using CodingTest.IDomainServices.AutoMapper;

namespace CodingTest.DomainServices.Core
{
    public abstract class BaseService<T,VM> : IBaseService<T,VM> where T: IdentityColumnEntityModel where VM: IdentityColumnViewModel
    {
        [SetterProperty]
        public IBaseRepository<T> BaseRepository
        {
            get; set;
        }

        [SetterProperty]
        public IUnitOfWork UnitOfWork
        {
            get; set;
        }

        public virtual ResponseResults<VM> GetAll()
        {
            var response = new ResponseResults<VM>() { IsSucceed  =true, Message = AppMessages.RETRIEVED_DETAILS_SUCCESSFULLY};
            try
            {
                var models = UnitOfWork.SetDbContext(BaseRepository).GetAll();
                response.ViewModels = models.ToViewModel<T, VM>().ToList();
            }
            catch (Exception ex)
            {
                response.IsSucceed = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public virtual ResponseResult<VM> GetById(long id)
        {
            var response = new ResponseResult<VM>() { IsSucceed = true, Message = AppMessages.RETRIEVED_DETAILS_SUCCESSFULLY };
            try
            {
                var model = UnitOfWork.SetDbContext(BaseRepository).FindById(id);
                response.ViewModel = model.ToViewModel<T, VM>();
            }
            catch (Exception ex)
            {
                response.IsSucceed = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public virtual ResponseResult<VM> Save(VM viewModel)
        {
            var response = new ResponseResult<VM>() { IsSucceed = true, Message = AppMessages.SAVED_DETAILS_SUCCESSFULLY };
            try
            {
                T model = viewModel.ToEntityModel<T,VM>();
            
                if (viewModel.Id == 0)
                {
                    UnitOfWork.SetDbContext(BaseRepository).Add(model);
                }
                else
                {
                    UnitOfWork.SetDbContext(BaseRepository).Update(model);
                }

                response.ViewModel = model.ToViewModel<T, VM>();
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
