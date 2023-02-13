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
    public class UserServiceUpdate: IServiceUpdate<UserVM>
    {
        private IRepositoryWrapper _repository;
        private IServiceValidation _Validator;

        public UserServiceUpdate(IRepositoryWrapper repository, IServiceValidation validator)
        {
            _repository = repository;
            _Validator = validator;
        }

        public HttpResponseMessage Update(UserVM userVM, int id)
        {
            if (!_Validator.ValidateAddressID(userVM.AddressId))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "Invalid Address ID" };
            }

            if (!_Validator.ValidateUserTypeID(userVM.UserTypeID))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "Invalid User type ID" };
            }

            if (!_Validator.ValidateUser(userVM))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "User is duplicated" };
            }
            
            if (!_Validator.ValidateUserExist(id))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "User not found" };
            }

            var userDB = _repository.user.FindByCondition(u => u.Id == id).FirstOrDefault();
            userDB.AddressId = userVM.AddressId;
            userDB.Email = userVM.Email;
            userDB.Money = userVM.Money;
            userDB.Name = userVM.Name;
            userDB.Phone = userVM.Phone;
            userDB.UserTypeID = userVM.UserTypeID;

            _repository.user.Update(userDB);
            _repository.Save();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        
    }
}
