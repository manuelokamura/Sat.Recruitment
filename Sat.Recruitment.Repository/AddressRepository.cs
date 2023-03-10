using Sat.Recruitment.Models;
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
    public class AddressRepository: RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(RepositoryContext repositoryContext): base(repositoryContext)
        {
        }
    }
}
