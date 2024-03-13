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
    }
}
