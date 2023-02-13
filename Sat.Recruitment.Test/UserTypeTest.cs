using Microsoft.AspNetCore.Mvc;
using Moq;
using Sat.Recruitment.Controllers;
using Sat.Recruitment.DataViewModels;
using Sat.Recruitment.Models;
using Sat.Recruitment.Services.Interface;
using Sat.Recruitment.Services.Services;
using Sat.Recruitment.Test.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Test
{
    public class UserTypeTest
    {

        private readonly Mock<IServiceAdd<UserTypeVM>> _addService;
        private readonly Mock<IServiceDelete> _deleteService;
        private readonly Mock<IServiceGet<UserType>> _getService;
        private readonly Mock<IServiceUpdate<UserTypeVM>> _updateService;
        private Mock<IServiceValidation> _ServiceValidator = new Mock<IServiceValidation>();

        public UserTypeTest()
        {
            _addService = new Mock<IServiceAdd<UserTypeVM>>();
            _deleteService = new Mock<IServiceDelete>();
            _getService = new Mock<IServiceGet<UserType>>();
            _updateService = new Mock<IServiceUpdate<UserTypeVM>>();
        }


        [Fact]
        public void getAll_OK()
        {
            var repo = MockIRepositoryWrapper.GetMock();
            _ServiceValidator.Setup(v => v.ValidateAddressID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUser(It.IsAny<UserVM>())).Returns(true);

            UserTypeServiceGet getUserTypeSer = new UserTypeServiceGet(repo.Object);

            var userTypeController = new UserTypeController(_addService.Object, _deleteService.Object, getUserTypeSer, _updateService.Object);

            var result = userTypeController.Get();

            Assert.NotNull(result);
            Assert.IsAssignableFrom<Task<IEnumerable<UserType>>>(result);
        }

        [Fact]
        public void getById_OK()
        {
            var repo = MockIRepositoryWrapper.GetMock();
            _ServiceValidator.Setup(v => v.ValidateAddressID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUser(It.IsAny<UserVM>())).Returns(true);

            UserTypeServiceGet getUserTypeSer = new UserTypeServiceGet(repo.Object);

            var userTypeController = new UserTypeController(_addService.Object, _deleteService.Object, getUserTypeSer, _updateService.Object);

            var result = userTypeController.Get(1);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<Task<UserType>>(result);
        }

        [Fact]
        public void Add_OK()
        {
            var repo = MockIRepositoryWrapper.GetMock();
            _ServiceValidator.Setup(v => v.ValidateAddressID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUser(It.IsAny<UserVM>())).Returns(true);

            UserTypeServiceAdd addUserTypeSer = new UserTypeServiceAdd(repo.Object);

            var userTypeController = new UserTypeController(addUserTypeSer, _deleteService.Object, _getService.Object, _updateService.Object);
            var userType = new UserTypeVM()
            {
                name = "Test",
                percentage = 0
            };

            var result = userTypeController.Post(userType);

            Assert.NotNull(result);
            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }

        [Fact]
        public void Delete_Ok()
        {
            var repo = MockIRepositoryWrapper.GetMock();
            _ServiceValidator.Setup(v => v.ValidateAddressID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUser(It.IsAny<UserVM>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeInUse(It.IsAny<int>())).Returns(true);

            UserTypeServiceDelete deleteUserTypeSer = new UserTypeServiceDelete(repo.Object,_ServiceValidator.Object);

            var userTypeController = new UserTypeController(_addService.Object, deleteUserTypeSer, _getService.Object, _updateService.Object);
            var result = userTypeController.Delete(1);

            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }

        [Fact]
        public void Delete_InvalidId()
        {
            var repo = MockIRepositoryWrapper.GetMock();
            _ServiceValidator.Setup(v => v.ValidateAddressID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeID(It.IsAny<int>())).Returns(false);
            _ServiceValidator.Setup(v => v.ValidateUser(It.IsAny<UserVM>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeInUse(It.IsAny<int>())).Returns(true);

            UserTypeServiceDelete deleteUserTypeSer = new UserTypeServiceDelete(repo.Object, _ServiceValidator.Object);

            var userTypeController = new UserTypeController(_addService.Object, deleteUserTypeSer, _getService.Object, _updateService.Object);
            var result = userTypeController.Delete(1);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public void Delete_IdInUse()
        {
            var repo = MockIRepositoryWrapper.GetMock();
            _ServiceValidator.Setup(v => v.ValidateAddressID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUser(It.IsAny<UserVM>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeInUse(It.IsAny<int>())).Returns(false);

            UserTypeServiceDelete deleteUserTypeSer = new UserTypeServiceDelete(repo.Object, _ServiceValidator.Object);

            var userTypeController = new UserTypeController(_addService.Object, deleteUserTypeSer, _getService.Object, _updateService.Object);

            var result = userTypeController.Delete(1);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public void Update_Ok()
        {
            var repo = MockIRepositoryWrapper.GetMock();
            _ServiceValidator.Setup(v => v.ValidateAddressID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUser(It.IsAny<UserVM>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeInUse(It.IsAny<int>())).Returns(true);

            UserTypeServiceUpdate updateUserTypeSer = new UserTypeServiceUpdate(repo.Object, _ServiceValidator.Object);

            var userType = new UserTypeVM()
            {
                name= "Test",
                percentage=0
            };

            var userTypeController = new UserTypeController(_addService.Object, _deleteService.Object, _getService.Object, updateUserTypeSer);
            var result = userTypeController.Put(1, userType);

            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }

        [Fact]
        public void Update_InvalidId()
        {
            var repo = MockIRepositoryWrapper.GetMock();
            _ServiceValidator.Setup(v => v.ValidateAddressID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeID(It.IsAny<int>())).Returns(false);
            _ServiceValidator.Setup(v => v.ValidateUser(It.IsAny<UserVM>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeInUse(It.IsAny<int>())).Returns(true);

            UserTypeServiceUpdate updateUserTypeSer = new UserTypeServiceUpdate(repo.Object, _ServiceValidator.Object);
            var userType = new UserTypeVM()
            {
                name = "Test",
                percentage = 0
            };
            var userTypeController = new UserTypeController(_addService.Object, _deleteService.Object, _getService.Object, updateUserTypeSer);
            var result = userTypeController.Put(1, userType);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }
    }
}
