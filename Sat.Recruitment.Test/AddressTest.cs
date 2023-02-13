using Microsoft.AspNetCore.Mvc;
using Moq;
using Sat.Recruitment.Controllers;
using Sat.Recruitment.DataViewModels;
using Sat.Recruitment.Models;
using Sat.Recruitment.Repository.Interfaces;
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
    public class AddressTest
    {
        private readonly Mock<IServiceAdd<AddressVM>> _addService;
        private readonly Mock<IServiceDelete> _deleteService;
        private readonly Mock<IServiceGet<Address>> _getService;
        private readonly Mock<IServiceUpdate<AddressVM>> _updateService;
        private Mock<IServiceValidation> _ServiceValidator = new Mock<IServiceValidation>();

        public AddressTest()
        {
            _addService = new Mock<IServiceAdd<AddressVM>>();
            _deleteService = new Mock<IServiceDelete>();
            _getService = new Mock<IServiceGet<Address>>();
            _updateService = new Mock<IServiceUpdate<AddressVM>>();
            _ServiceValidator = new Mock<IServiceValidation>();
        }

        [Fact]
        public void Add_OK()
        {
            var repo = MockIRepositoryWrapper.GetMock();
            _ServiceValidator.Setup(v => v.ValidateAddressID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUser(It.IsAny<UserVM>())).Returns(true);

            AddressServiceAdd addAddressSer = new AddressServiceAdd(repo.Object);

            var addressController = new AddressController(addAddressSer,_deleteService.Object, _getService.Object,_updateService.Object);
            var address = new AddressVM()
            {
                city="A",
                state="A",
                number=1,
                street="A"
            };

            var result = addressController.Post(address);

            Assert.NotNull(result);
            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }

        [Fact]
        public void Delete_OK()
        {
            var repo = MockIRepositoryWrapper.GetMock();
            _ServiceValidator.Setup(v => v.ValidateAddressID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUser(It.IsAny<UserVM>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateAddressInUse(It.IsAny<int>())).Returns(true);


            AddressServiceDelete addAddressSer = new AddressServiceDelete(repo.Object,_ServiceValidator.Object);

            var addressController = new AddressController(_addService.Object, addAddressSer, _getService.Object, _updateService.Object);

            var result = addressController.Delete(1);

            Assert.NotNull(result);
            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }

        [Fact]
        public void Delete_InvalidAddressID()
        {
            var repo = MockIRepositoryWrapper.GetMock();
            _ServiceValidator.Setup(v => v.ValidateAddressID(It.IsAny<int>())).Returns(false);
            _ServiceValidator.Setup(v => v.ValidateUserTypeID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUser(It.IsAny<UserVM>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateAddressInUse(It.IsAny<int>())).Returns(true);

            AddressServiceDelete addAddressSer = new AddressServiceDelete(repo.Object, _ServiceValidator.Object);

            var addressController = new AddressController(_addService.Object, addAddressSer, _getService.Object, _updateService.Object);

            var result = addressController.Delete(1);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public void Delete_AddressIdInUse()
        {
            var repo = MockIRepositoryWrapper.GetMock();
            _ServiceValidator.Setup(v => v.ValidateAddressID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUser(It.IsAny<UserVM>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateAddressInUse(It.IsAny<int>())).Returns(false);

            AddressServiceDelete addAddressSer = new AddressServiceDelete(repo.Object, _ServiceValidator.Object);

            var addressController = new AddressController(_addService.Object, addAddressSer, _getService.Object, _updateService.Object);

            var result = addressController.Delete(1);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }


        [Fact]
        public void Update_OK()
        {
            var repo = MockIRepositoryWrapper.GetMock();
            _ServiceValidator.Setup(v => v.ValidateAddressID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUserTypeID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUser(It.IsAny<UserVM>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateAddressInUse(It.IsAny<int>())).Returns(true);

            AddressServiceUpdate addAddressSer = new AddressServiceUpdate(repo.Object, _ServiceValidator.Object);

            var addressController = new AddressController(_addService.Object, _deleteService.Object, _getService.Object, addAddressSer);

            var addr = new AddressVM()
            {
                city = "A",
                state = "A",
                number = 0,
                street="A"

            };

            var result = addressController.Put(1, addr);

            Assert.NotNull(result);
            Assert.Equal(typeof(OkObjectResult), result.GetType());
        }

        [Fact]
        public void Update_InvalidAddressID()
        {
            var repo = MockIRepositoryWrapper.GetMock();
            _ServiceValidator.Setup(v => v.ValidateAddressID(It.IsAny<int>())).Returns(false);
            _ServiceValidator.Setup(v => v.ValidateUserTypeID(It.IsAny<int>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateUser(It.IsAny<UserVM>())).Returns(true);
            _ServiceValidator.Setup(v => v.ValidateAddressInUse(It.IsAny<int>())).Returns(true);

            AddressServiceUpdate addAddressSer = new AddressServiceUpdate(repo.Object, _ServiceValidator.Object);

            var addressController = new AddressController(_addService.Object, _deleteService.Object, _getService.Object, addAddressSer);

            var addr = new AddressVM()
            {
                city = "A",
                state = "A",
                number = 0,
                street = "A"

            };

            var result = addressController.Put(1,addr);

            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

    }
}
