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
    public class ServiceValidation :IServiceValidation
    {
        private IRepositoryWrapper _repository;

        public ServiceValidation(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public bool ValidateAddressID(int id)
        {
            if (_repository.address.FindByCondition(addr => addr.Id == id).FirstOrDefault() == null)
            {
                return false;
            }
            return true;
            
        }

        public bool ValidateAddressInUse(int id)
        {
            if (_repository.user.FindByCondition(u => u.AddressId == id).FirstOrDefault() != null)
            {
                return false;
            }
            return true;
        }

        public bool ValidateUserTypeID(int id)
        {
            if (_repository.userType.FindByCondition(ut => ut.Id == id).FirstOrDefault() == null)
            {
                return false;
            }
            return true;
        }

        public bool ValidateUserTypeInUse(int id)
        {
            if (_repository.userType.FindByCondition(ut => ut.Id == id).FirstOrDefault() == null)
            {
                return false;
            }
            return true;
        }

        public bool ValidateUser(UserVM userVM)
        {
            if (_repository.user.FindByCondition(u => u.Email == userVM.Email || u.Phone == userVM.Phone).FirstOrDefault() != null)
            {
                return false;
            }

            if (_repository.user.FindByCondition(u => u.Name == userVM.Name && u.AddressId == userVM.AddressId).FirstOrDefault() != null)
            {
                return false;
            }
            return true;
        }

        public bool ValidateUserExist(int id) 
        {
            if (_repository.user.FindByCondition(u => u.Id == id).FirstOrDefault() == null)
            {
                return false;
            }
            return true;
        }

    }
}
