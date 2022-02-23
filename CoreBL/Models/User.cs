using System;
using System.ComponentModel.DataAnnotations;

namespace Core1WebApi.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
