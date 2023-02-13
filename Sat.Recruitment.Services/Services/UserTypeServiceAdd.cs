using Sat.Recruitment.DataViewModels;
using Sat.Recruitment.Models;
using Sat.Recruitment.Repository.Interfaces;
using Sat.Recruitment.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Services.Services
{
    public class UserTypeServiceAdd : IServiceAdd<UserTypeVM>
    {
        private IRepositoryWrapper _repository;

        public UserTypeServiceAdd(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public HttpResponseMessage Add(UserTypeVM entity)
        {
            var userType = new UserType()
            {
                Name = entity.name,
                percentage= entity.percentage
            };

            _repository.userType.Create(userType);
            _repository.Save();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}
