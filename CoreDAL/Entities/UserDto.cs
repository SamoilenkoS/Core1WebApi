using System;
using System.ComponentModel.DataAnnotations;

namespace CoreDAL.Entities
{
    public class UserDto
    {
        [Key]
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
