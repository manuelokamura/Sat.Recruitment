using Moq;
using Sat.Recruitment.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Test.Mock
{
    internal class MockIRepositoryWrapper
    {
        public static Mock<IRepositoryWrapper> GetMock()
        {
            var mock = new Mock<IRepositoryWrapper>();
            var addressRepoMock = MockIAddressRepository.GetMock();
            var userRepoMock = MockIUserRepository.GetMock();
            var userTypeRepoMock = MockIUserTypeRepository.GetMock();

            mock.Setup(m => m.user).Returns(() => userRepoMock.Object);
            mock.Setup(m => m.address).Returns(() => addressRepoMock.Object);
            mock.Setup(m => m.userType).Returns(() => userTypeRepoMock.Object);
            mock.Setup(m => m.Save()).Callback(() => { return; });

            return mock;
        }
     }
}
