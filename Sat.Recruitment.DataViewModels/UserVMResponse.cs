using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.DataViewModels
{
    [ExcludeFromCodeCoverage]
    public class UserVMResponse
    {
        public int id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public AddressVMResponse? Address { get; set; }
        public string? Phone { get; set; }
        public string? UserType { get; set; }
        public decimal Money { get; set; }
    }
}
