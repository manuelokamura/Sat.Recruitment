using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Services.Interface
{
    public interface IServiceDelete
    {
        public HttpResponseMessage Delete(int id);
    }
}
