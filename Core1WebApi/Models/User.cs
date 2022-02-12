using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core1WebApi.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
    }
}
