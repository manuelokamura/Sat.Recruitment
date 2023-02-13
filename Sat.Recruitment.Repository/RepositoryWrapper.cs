using Sat.Recruitment.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Repository
{
    [ExcludeFromCodeCoverage]
    public class RepositoryWrapper : IRepositoryWrapper
    {
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        private RepositoryContext _repoContext;
        private IAddressRepository _address;
        private IUserRepository _user;
        private IUserTypeRepository _userType;

        public IAddressRepository address
        {
            get
            {
                if (_address == null)
                {
                    _address = new AddressRepository(_repoContext);
                }
                return _address;
            }
        }

        public IUserRepository user
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }

        public IUserTypeRepository userType
        {
            get
            {
                if (_userType == null)
                {
                    _userType = new UserTypeRepository(_repoContext);
                }
                return _userType;
            }
        }


        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
