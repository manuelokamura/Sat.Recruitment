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
    public class MockIUserRepository
    {

        public static Mock<IUserRepository> GetMock()
        {
            var mock = new Mock<IUserRepository>();
            var user = new List<Models.User>()
            {
                new Models.User()
                {
                    Id= 1,
                    Address= new Address() {},
                    Email = "A",
                    Money=0,
                    Phone="0",
                    Name = "A",
                    UserTypeID=0
                }
            };

            mock.Setup(m => m.FindByCondition((It.IsAny<Expression<Func<Models.User, bool>>>()))).Returns(() => user.AsQueryable());
            mock.Setup(m => m.FindAll()).Returns(() => user.AsQueryable());


            return mock;
        }
    }
}
