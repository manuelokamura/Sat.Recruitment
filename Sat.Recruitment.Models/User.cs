using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Sat.Recruitment.Models
{
    [ExcludeFromCodeCoverage]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string? Name { get; set; }

        [EmailAddress]
        [Required]
        public string? Email { get; set; }

        public int AddressId { get; set; }
        public Address? Address { get; set; }

        [Phone]
        [Required]
        public string? Phone { get; set; }

        public int UserTypeID { get; set; }
        public UserType? UserType { get; set; }

        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Money { get; set; }

    }
}