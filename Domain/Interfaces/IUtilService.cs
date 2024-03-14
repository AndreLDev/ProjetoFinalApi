using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUtilService
    {

        TResponseModel GetBenchMarkinById<TResponseModel>(int id) where TResponseModel : class;

        public Task<TResponseModel> SendEmail<TRequestModel, TResponseModel>(TRequestModel requestModel)
            where TRequestModel : class
            where TResponseModel : class;
    }
}
