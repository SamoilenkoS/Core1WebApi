using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDAL.Entities
{
    public class GoodDto
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
