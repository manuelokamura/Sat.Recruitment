using Microsoft.EntityFrameworkCore;
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
    public class AddressServiceUpdate : IServiceUpdate<AddressVM>
    {
        private IRepositoryWrapper _repository;
        private IServiceValidation _Validator;

        public AddressServiceUpdate(IRepositoryWrapper repository, IServiceValidation validator)
        {
            _repository = repository;
            _Validator = validator;
        }
        public HttpResponseMessage Update(AddressVM addr, int id)
        {
            if (!_Validator.ValidateAddressID(id))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "Address not found" };
            }
            var address = _repository.address.FindByCondition(a => a.Id == id).FirstOrDefault();
            address.Id = id;
            address.number = addr.number;
            address.state = addr.state;
            address.city = addr.city;
            address.street= addr.street;

            _repository.address.Update(address);
            _repository.Save();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
