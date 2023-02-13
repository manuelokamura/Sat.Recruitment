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
    public class UserTypeServiceDelete : IServiceDelete
    {
        private IRepositoryWrapper _repository;
        private IServiceValidation _validator;

        public UserTypeServiceDelete(IRepositoryWrapper repository, IServiceValidation validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public HttpResponseMessage Delete(int id)
        {
            if(!_validator.ValidateUserTypeID(id)) 
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "User type is in use" };
            }

            if (!_validator.ValidateUserTypeInUse(id))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "User type not found" };
            }

            var userType = _repository.userType.FindByCondition(ut => ut.Id == id).FirstOrDefault();

            _repository.userType.Delete(userType);
            _repository.Save();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
