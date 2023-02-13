using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.DataViewModels;
using Sat.Recruitment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Services.Interface
{
    public interface IServiceAdd<T>
    {
        public HttpResponseMessage Add(T entity);

    }
}
