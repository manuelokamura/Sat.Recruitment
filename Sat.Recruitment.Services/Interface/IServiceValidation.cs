using Sat.Recruitment.DataViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Services.Interface
{
    public interface IServiceValidation
    {
        public bool ValidateUser(UserVM userVM);

        public bool ValidateAddressID(int id);

        public bool ValidateUserTypeID(int id);

        public bool ValidateAddressInUse(int id);

        public bool ValidateUserTypeInUse(int id);

        public bool ValidateUserExist(int id);
    }
}
