using Moq;
using Sat.Recruitment.Models;
using Sat.Recruitment.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Sat.Recruitment.Test.Mock
{
    public class MockIAddressRepository
    {
        public static Mock<IAddressRepository> GetMock()
        {
            var mock = new Mock<IAddressRepository>();
            var addr = new List<Address>()
            {
                new Address()
                {
                    city="A",
                    Id=1,
                    number=1,
                    state="A",
                    street="A"
                }
            };

            mock.Setup(m => m.FindByCondition((It.IsAny<Expression<Func<Address, bool>>>()))).Returns(() => addr.AsQueryable<Address>());
            mock.Setup(m => m.FindAll()).Returns(() => addr.AsQueryable<Address>());
           

            return mock;
        }

            

    }
}
