using Sat.Recruitment.DataViewModels;
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
    public class UserTypeServiceUpdate : IServiceUpdate<UserTypeVM>
    {
        private IRepositoryWrapper _repository;
        private IServiceValidation _validator;

        public UserTypeServiceUpdate(IRepositoryWrapper repository, IServiceValidation validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public HttpResponseMessage Update(UserTypeVM user, int id)
        {
            
            if (!_validator.ValidateUserTypeID(id))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "User type not found" };
            }
            var usertype = _repository.userType.FindByCondition(ut => ut.Id == id).FirstOrDefault();

            usertype.percentage = user.percentage;
            usertype.Name= user.name;

            _repository.userType.Update(usertype);
            _repository.Save();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
