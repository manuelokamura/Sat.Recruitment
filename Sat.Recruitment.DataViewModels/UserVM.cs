using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Sat.Recruitment.DataViewModels
{
    [ExcludeFromCodeCoverage]
    public class UserVM
    {
        [Required(ErrorMessage = "The name is required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The email is required.")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "The address is required")]
        public int AddressId { get; set; }

        [Required(ErrorMessage = "The phone is required.")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "The user tipe is required.")]
        public int UserTypeID { get; set; }

        public decimal Money { get; set; }
    }
}