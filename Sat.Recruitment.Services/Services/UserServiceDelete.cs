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
    public class UserServiceDelete: IServiceDelete
    {
        private IRepositoryWrapper _repository;
        private IServiceValidation _validator;

        public UserServiceDelete(IRepositoryWrapper repository, IServiceValidation validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public HttpResponseMessage Delete(int id)
        {
            if (!_validator.ValidateUserExist(id))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "User not found" };
            }

            var user = _repository.user.FindByCondition(u => u.Id == id).FirstOrDefault();
            _repository.user.Delete(user);
            _repository.Save();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
