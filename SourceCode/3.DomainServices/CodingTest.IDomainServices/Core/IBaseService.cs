using CodingTest.EntityModels.Core;
using CodingTest.ServiceResponse;
using CodingTest.ViewModels.Core;

namespace CodingTest.IDomainServices.Core
{
    public interface IBaseService<T,VM>  where T : BaseEntityModel where VM : BaseViewModel
    {
        ResponseResults<VM> GetAll();
        ResponseResult<VM> GetById(long id);
        ResponseResult<VM> Save(VM viewModel);
    }
}
