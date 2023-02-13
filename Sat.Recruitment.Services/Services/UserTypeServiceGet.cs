using Microsoft.EntityFrameworkCore;
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
    public class UserTypeServiceGet : IServiceGet<UserType>
    {
        private IRepositoryWrapper _repository;

        public UserTypeServiceGet(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<UserType>> GetAll()
        {
            var userTypes = await _repository.userType.FindAll().ToListAsync();

            if (userTypes == null)
            {
                throw new Exception("User type not founds");
            }

            List<UserType> result = new List<UserType>();
            foreach (var userType in userTypes)
            {
                result.Add(new UserType()
                {
                    Id= userType.Id,
                    Name= userType.Name,
                    percentage= userType.percentage
                });
            }

            return result;

        }

        public async Task<UserType> GetByID(int id)
        {
            var userType = await _repository.userType.FindByCondition( ut => ut.Id == id).FirstOrDefaultAsync();

            if (userType == null)
            {
                throw new Exception("User type not found");
            }

            return userType;
        }
    }
}
