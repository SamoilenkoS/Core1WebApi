using System;
using System.ComponentModel.DataAnnotations;

namespace CoreDAL.Entities
{
    public class UserDto
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
