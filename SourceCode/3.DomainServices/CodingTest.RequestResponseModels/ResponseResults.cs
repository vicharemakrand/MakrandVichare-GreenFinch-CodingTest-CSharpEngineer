using CodingTest.ViewModels.Core;
using System.Collections.Generic;

namespace CodingTest.ServiceResponse
{
    public class ResponseResults<VM> : BaseResponseResult  where VM: BaseViewModel
    {
        public List<VM> ViewModels { get; set; } 
    }
}
