using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.DataViewModels
{
    [ExcludeFromCodeCoverage]
    public class AddressVMResponse
    {
        public int Id { get; set; }

        public string? street { get; set; }

        public int number { get; set; }

        public string? city { get; set; }

        public string? state { get; set; }
    }
}
