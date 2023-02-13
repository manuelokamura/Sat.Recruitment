using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.DataViewModels;
using Sat.Recruitment.Models;
using Sat.Recruitment.Repository.Interfaces;
using Sat.Recruitment.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Services.Services
{
    public class AddressServiceGet : IServiceGet<Address>
    {
        private IRepositoryWrapper _repository;

        public AddressServiceGet(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Address>> GetAll()
        {
            var address = await _repository.address.FindAll().ToListAsync();

            if (address == null)
            {
                throw new Exception("Address not founds");
            }

            List<Address> result = new List<Address>();
            foreach (var addr in address)
            {
                result.Add(new Address()
                {
                    city = addr.city,
                    state = addr.state,
                    street= addr.street,
                    number= addr.number,
                    Id=addr.Id
                });
            }

            return result;
        }

        public async Task<Address> GetByID(int id)
        {
            var address = await _repository.address.FindByCondition( a => a.Id == id ).FirstOrDefaultAsync();

            if (address == null)
            {
                throw new Exception("Address not found");
            }
            return address;
        }
    }
}
