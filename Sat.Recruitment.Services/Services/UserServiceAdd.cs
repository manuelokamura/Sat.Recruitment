using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.DataViewModels;
using Sat.Recruitment.Models;
using Sat.Recruitment.Repository;
using Sat.Recruitment.Repository.Interfaces;
using Sat.Recruitment.Services.Interface;
using System.Net;
using System.Web.Http;

namespace Sat.Recruitment.Services.Services
{
    public class UserServiceAdd : IServiceAdd<UserVM>
    {
        private IRepositoryWrapper _repository;
        private IServiceValidation _Validator;

        public UserServiceAdd(IRepositoryWrapper repository, IServiceValidation validator)
        {
            _repository = repository;
            _Validator = validator;
        }

        public HttpResponseMessage Add(UserVM userVM)
        {

            if (!_Validator.ValidateAddressID(userVM.AddressId))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase= "Invalid Address ID" };
            }

            if (!_Validator.ValidateUserTypeID(userVM.UserTypeID)) 
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "Invalid User type ID" };
            }

            if (!_Validator.ValidateUser(userVM))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest) { ReasonPhrase = "User is duplicated" };
            }

            decimal percentage = _repository.userType.FindByCondition(ut => ut.Id == userVM.UserTypeID).Select(ut => ut.percentage).FirstOrDefault();
            userVM.Money = userVM.Money + userVM.Money * percentage;
         
            var user = new User()
            {
                Name = userVM.Name,
                AddressId = userVM.AddressId,
                Email = userVM.Email,
                Money = userVM.Money,
                Phone = userVM.Phone,
                UserTypeID = userVM.UserTypeID
            };
            _repository.user.Create(user);
            _repository.Save();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
    
}

