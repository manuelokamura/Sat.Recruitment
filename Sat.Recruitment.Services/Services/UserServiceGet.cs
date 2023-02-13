using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.DataViewModels;
using Sat.Recruitment.Repository.Interfaces;
using Sat.Recruitment.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Services.Services
{
    public class UserServiceGet: IServiceGet<UserVMResponse>
    {
        private IRepositoryWrapper _repository;

        public UserServiceGet(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserVMResponse>> GetAll()
        {
            var users = await _repository.user.FindAll().ToListAsync();

            if(users == null)
            {
                throw new Exception("User not founds");
            }

            List< UserVMResponse > result= new List< UserVMResponse >();
            foreach(var user in users)
            {
                result.Add(new UserVMResponse()
                {
                    id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Money = user.Money,
                    Phone = user.Phone,
                    UserType = _repository.userType.FindByCondition(ut => ut.Id == user.UserTypeID).Select(ut => ut.Name).FirstOrDefault(),
                    Address = _repository.address.FindByCondition(addr => addr.Id == user.AddressId).Select(address => new AddressVMResponse()
                    {
                        Id = address.Id,
                        city = address.city,
                        state = address.state,
                        number = address.number,
                        street = address.street
                    }).FirstOrDefault()
                });
            }
            
            return result;
        }
        public async Task<UserVMResponse> GetByID(int id)
        {
            var user = await _repository.user.FindByCondition(u => u.Id == id).FirstOrDefaultAsync();
            if(user == null)
            {
                throw new Exception("User not found");
            }

            var response = new UserVMResponse()
            {
                id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Money = user.Money,
                Phone = user.Phone,
                UserType = _repository.userType.FindByCondition(ut => ut.Id == user.UserTypeID).Select(ut => ut.Name).FirstOrDefault(),
                Address = _repository.address.FindByCondition(addr => addr.Id == user.AddressId).Select(address => new AddressVMResponse()
                {
                    Id = address.Id,
                    city = address.city,
                    state = address.state,
                    number = address.number,
                    street = address.street
                }).FirstOrDefault()
            };
            return response;
        }
    }
}
