using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace Sat.Recruitment.Models
{
    [ExcludeFromCodeCoverage]
    public class UserType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Name { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal percentage { get; set; }
    }
}
