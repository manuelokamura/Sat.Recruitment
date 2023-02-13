using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Repository.Interfaces
{
    public interface IRepositoryWrapper
    {
        IAddressRepository address { get; }

        IUserRepository user { get; }

        IUserTypeRepository userType { get; }

        void Save();
    }
}
