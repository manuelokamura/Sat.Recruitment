using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Sat.Recruitment.Controllers;
using Sat.Recruitment.DataViewModels;
using Sat.Recruitment.Models;
using Sat.Recruitment.Repository.Interfaces;
using Sat.Recruitment.Services.Interface;
using Sat.Recruitment.Services.Services;
using Sat.Recruitment.Test.Mock;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Http;

namespace Sat.Recruitment.Test
{
    public class UserTest
    {
        private readonly Mock<IRepositoryWrapper> _repo;
        private Mock<IServiceAdd<UserVM>> _userAddServiceMock = new Mock<IServiceAdd<UserVM>>();
        private Mock<IServiceDelete> _userDeleteServiceMock = new Mock<IServiceDelete>();
        private Mock<IServiceGet<UserVMResponse>> _userGetServiceMock = new Mock<IServiceGet<UserVMResponse>>();
        private Mock<IServiceUpdate<UserVM>> _userUpdateServiceMock = new Mock<IServiceUpdate<UserVM>>();
        private Mock<IServiceValidation> _ServiceValidator = new Mock<IServiceValidation>();

        public UserTest()
        {
            _repo = new Mock<IRepositoryWrapper>();
            _userAddServiceMock = new Mock<IServiceAdd<UserVM>>();
            _userDeleteServiceMock = new Mock<IServiceDelete>();
            _userGetServiceMock = new Mock<IServiceGet<UserVMResponse>>();
            _userUpdateServiceMock = new Mock<IServiceUpdate<UserVM>>();
        }

        [Fact]
        public void getAll_OK()
        {
            var repo = MockIRepositoryWrapper.GetMock();
            _ServiceValidator.Setup(v => v.ValidateAddressID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUser(It.IsAny<UserVM>())).Returns(true);

            UserServiceGet getUserser = new UserServiceGet(repo.Object);

            var userController = new UserController(_userAddServiceMock.Object, _userDeleteServiceMock.Object, getUserser, _userUpdateServiceMock.Object);

            var result = userController.Get();

            Assert.NotNull(result);
            Assert.IsAssignableFrom<Task<IEnumerable<UserVMResponse>>>(result);
        }

        [Fact]
        public void getById_OK()
        {
            var repo = MockIRepositoryWrapper.GetMock();
            _ServiceValidator.Setup(v => v.ValidateAddressID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUser(It.IsAny<UserVM>())).Returns(true);

            UserServiceGet getUserser = new UserServiceGet(repo.Object);

            var userController = new UserController(_userAddServiceMock.Object, _userDeleteServiceMock.Object, getUserser, _userUpdateServiceMock.Object);

            var result = userController.Get(1);

            Assert.NotNull(result);
            Assert.IsAssignableFrom<Task<UserVMResponse>>(result);
        }

        [Fact]
        public void Add_OK()
        {
            var repo = MockIRepositoryWrapper.GetMock();
            _ServiceValidator.Setup(v => v.ValidateAddressID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUser(It.IsAny<UserVM>())).Returns(true);

            UserServiceAdd addUserser = new UserServiceAdd(repo.Object, _ServiceValidator.Object);
            
            var userController = new UserController(addUserser, _userDeleteServiceMock.Object, _userGetServiceMock.Object, _userUpdateServiceMock.Object);
            var user = new UserVM()
            {
                AddressId = 1,
                Email = "Mokamura@hotmail.com",
                Money = 100,
                Name = "Test",
                Phone = "6677556688",
                UserTypeID = 1
            };

            var result = userController.Post(user);

            Assert.NotNull(result);
            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }

        [Fact]
        public void Add_InvalidAddress()
        {

            var repo = MockIRepositoryWrapper.GetMock();
            _ServiceValidator.Setup(v => v.ValidateAddressID(It.IsAny<int>())).Returns(false);
            UserServiceAdd addUserser = new UserServiceAdd(repo.Object, _ServiceValidator.Object);

            var userController = new UserController(addUserser, _userDeleteServiceMock.Object, _userGetServiceMock.Object, _userUpdateServiceMock.Object);
            var user = new UserVM()
            {
                AddressId = 1,
                Email = "Mokamura@hotmail.com",
                Money = 100,
                Name = "Test",
                Phone = "6677556688",
                UserTypeID = 1
            };

            var result = userController.Post(user);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public void Add_InvalidUserType()
        {
            var repo = MockIRepositoryWrapper.GetMock();
            _ServiceValidator.Setup(v => v.ValidateAddressID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeID(It.IsAny<int>())).Returns(false);
            _ServiceValidator.Setup(v => v.ValidateUser(It.IsAny<UserVM>())).Returns(true);

            UserServiceAdd addUserser = new UserServiceAdd(repo.Object, _ServiceValidator.Object);

            var userController = new UserController(addUserser, _userDeleteServiceMock.Object, _userGetServiceMock.Object, _userUpdateServiceMock.Object);
            var user = new UserVM()
            {
                AddressId = 1,
                Email = "Mokamura@hotmail.com",
                Money = 100,
                Name = "Test",
                Phone = "6677556688",
                UserTypeID = 1
            };

            var result = userController.Post(user);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public void Add_ExistUser()
        {
            var repo = MockIRepositoryWrapper.GetMock();
            _ServiceValidator.Setup(v => v.ValidateAddressID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUser(It.IsAny<UserVM>())).Returns(false);

            UserServiceAdd addUserser = new UserServiceAdd(repo.Object, _ServiceValidator.Object);

            var userController = new UserController(addUserser, _userDeleteServiceMock.Object, _userGetServiceMock.Object, _userUpdateServiceMock.Object);
            var user = new UserVM()
            {
                AddressId = 1,
                Email = "Mokamura@hotmail.com",
                Money = 100,
                Name = "Test",
                Phone = "6677556688",
                UserTypeID = 1
            };

            var result = userController.Post(user);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public void Update_OK()
        {
            var repo = MockIRepositoryWrapper.GetMock();
            _ServiceValidator.Setup(v => v.ValidateAddressID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUser(It.IsAny<UserVM>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserExist(It.IsAny<int>())).Returns(true);
            UserServiceUpdate updateUserSer = new UserServiceUpdate(repo.Object,_ServiceValidator.Object);

            var userController = new UserController(_userAddServiceMock.Object, _userDeleteServiceMock.Object, _userGetServiceMock.Object, updateUserSer);
            var user = new UserVM()
            {
                AddressId = 1,
                Email = "Mokamura@hotmail.com",
                Money = 100,
                Name = "Test",
                Phone = "6677556688",
                UserTypeID = 1
            };

            var result = userController.Put(1,user);

            Assert.NotNull(result);
            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }

        [Fact]
        public void Update_InvalidAddress()
        {
            var repo = MockIRepositoryWrapper.GetMock();
            _ServiceValidator.Setup(v => v.ValidateAddressID(It.IsAny<int>())).Returns(false);
            _ServiceValidator.Setup(v => v.ValidateUserTypeID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUser(It.IsAny<UserVM>())).Returns(true);
            UserServiceUpdate updateUserSer = new UserServiceUpdate(repo.Object, _ServiceValidator.Object);

            var userController = new UserController(_userAddServiceMock.Object, _userDeleteServiceMock.Object, _userGetServiceMock.Object, updateUserSer);
            var user = new UserVM()
            {
                AddressId = 1,
                Email = "Mokamura@hotmail.com",
                Money = 100,
                Name = "Test",
                Phone = "6677556688",
                UserTypeID = 1
            };

            var result = userController.Put(1, user);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public void Update_InvalidUserTypeID()
        {
            var repo = MockIRepositoryWrapper.GetMock();
            _ServiceValidator.Setup(v => v.ValidateAddressID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeID(It.IsAny<int>())).Returns(false);
            _ServiceValidator.Setup(v => v.ValidateUser(It.IsAny<UserVM>())).Returns(true);
            UserServiceUpdate updateUserSer = new UserServiceUpdate(repo.Object, _ServiceValidator.Object);

            var userController = new UserController(_userAddServiceMock.Object, _userDeleteServiceMock.Object, _userGetServiceMock.Object, updateUserSer);
            var user = new UserVM()
            {
                AddressId = 1,
                Email = "Mokamura@hotmail.com",
                Money = 100,
                Name = "Test",
                Phone = "6677556688",
                UserTypeID = 1
            };

            var result = userController.Put(1, user);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public void Update_InvalidUser()
        {
            var repo = MockIRepositoryWrapper.GetMock();
            _ServiceValidator.Setup(v => v.ValidateAddressID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUser(It.IsAny<UserVM>())).Returns(false);
            UserServiceUpdate updateUserSer = new UserServiceUpdate(repo.Object, _ServiceValidator.Object);

            var userController = new UserController(_userAddServiceMock.Object, _userDeleteServiceMock.Object, _userGetServiceMock.Object, updateUserSer);
            var user = new UserVM()
            {
                AddressId = 1,
                Email = "Mokamura@hotmail.com",
                Money = 100,
                Name = "Test",
                Phone = "6677556688",
                UserTypeID = 1
            };

            var result = userController.Put(1, user);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public void Update_UserNoExist()
        {
            var repo = MockIRepositoryWrapper.GetMock();
            _ServiceValidator.Setup(v => v.ValidateAddressID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUser(It.IsAny<UserVM>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserExist(It.IsAny<int>())).Returns(false);

            UserServiceUpdate updateUserSer = new UserServiceUpdate(repo.Object, _ServiceValidator.Object);

            var userController = new UserController(_userAddServiceMock.Object, _userDeleteServiceMock.Object, _userGetServiceMock.Object, updateUserSer);
            var user = new UserVM()
            {
                AddressId = 1,
                Email = "Mokamura@hotmail.com",
                Money = 100,
                Name = "Test",
                Phone = "6677556688",
                UserTypeID = 1
            };

            var result = userController.Put(1, user);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public void Delete_OK()
        {
            var repo = MockIRepositoryWrapper.GetMock();
            _ServiceValidator.Setup(v => v.ValidateAddressID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUser(It.IsAny<UserVM>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserExist(It.IsAny<int>())).Returns(true);
            UserServiceDelete deleteUserSer = new UserServiceDelete(repo.Object, _ServiceValidator.Object);

            var userController = new UserController(_userAddServiceMock.Object, deleteUserSer, _userGetServiceMock.Object, _userUpdateServiceMock.Object);
            var user = new UserVM()
            {
                AddressId = 1,
                Email = "Mokamura@hotmail.com",
                Money = 100,
                Name = "Test",
                Phone = "6677556688",
                UserTypeID = 1
            };

            var result = userController.Delete(1);

            Assert.NotNull(result);
            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }
        [Fact]
        public void Delete_InValidUser()
        {
            var repo = MockIRepositoryWrapper.GetMock();
            _ServiceValidator.Setup(v => v.ValidateAddressID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUser(It.IsAny<UserVM>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserExist(It.IsAny<int>())).Returns(false);
            UserServiceDelete deleteUserSer = new UserServiceDelete(repo.Object, _ServiceValidator.Object);

            var userController = new UserController(_userAddServiceMock.Object, deleteUserSer, _userGetServiceMock.Object, _userUpdateServiceMock.Object);
            var user = new UserVM()
            {
                AddressId = 1,
                Email = "Mokamura@hotmail.com",
                Money = 100,
                Name = "Test",
                Phone = "6677556688",
                UserTypeID = 1
            };

            var result = userController.Delete(1);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }
    }
}