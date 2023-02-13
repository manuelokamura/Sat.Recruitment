using Moq;
using Sat.Recruitment.Models;
using Sat.Recruitment.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Test.Mock
{
    public class MockIUserTypeRepository
    {
        public static Mock<IUserTypeRepository> GetMock()
        {
            var mock = new Mock<IUserTypeRepository>();
            var userType = new List<UserType>()
            {
                new UserType()
                {
                    Id= 1,
                    Name="A",
                    percentage=0
                }
            };

            mock.Setup(m => m.FindByCondition((It.IsAny<Expression<Func<UserType, bool>>>()))).Returns(() => userType.AsQueryable<UserType>());
            mock.Setup(m => m.FindAll()).Returns(() => userType.AsQueryable<UserType>());


            return mock;
        }
    }
}
