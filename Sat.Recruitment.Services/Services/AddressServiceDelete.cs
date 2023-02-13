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
    public class AddressServiceDelete : IServiceDelete
    {
        private IRepositoryWrapper _repository;
        private IServiceValidation _validator;

        public AddressServiceDelete(IRepositoryWrapper repository, IServiceValidation validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public HttpResponseMessage Delete(int id)
        {
            if (!_validator.ValidateAddressID(id))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "Address not found" };
            }

            if(!_validator.ValidateAddressInUse(id))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "Address is in use" };
            }

            var address = _repository.address.FindByCondition(a => a.Id == id).FirstOrDefault();
            _repository.address.Delete(address);
            _repository.Save();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
