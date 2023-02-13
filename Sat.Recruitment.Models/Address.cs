using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Sat.Recruitment.Models
{
    [ExcludeFromCodeCoverage]
    public class Address
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(35)]
        public string? street { get; set; }

        public int number { get; set; }

        [Required]
        public string? city { get; set; }

        [Required]
        public string? state { get; set; }
    }
}
