using Sat.Recruitment.DataViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Services.Interface
{
    public interface IServiceUpdate<T>
    {
        public HttpResponseMessage Update(T user, int id);

    }
}
