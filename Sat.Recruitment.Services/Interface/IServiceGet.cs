using Sat.Recruitment.DataViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Services.Interface
{
    public interface IServiceGet<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetByID(int id);
    }
}
