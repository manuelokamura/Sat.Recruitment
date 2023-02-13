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
    public class AddressServiceAdd : IServiceAdd<AddressVM>
    {

        private IRepositoryWrapper _repository;

        public AddressServiceAdd(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        public HttpResponseMessage Add(AddressVM entity)
        {
            var address = new Address()
            {
                city= entity.city,
                state=entity.state,
                number=entity.number,
                street=entity.street
            };

            _repository.address.Create(address);
            _repository.Save();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
