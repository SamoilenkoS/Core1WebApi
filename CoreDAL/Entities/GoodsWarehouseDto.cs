using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDAL.Entities
{
    public class GoodsWarehouseDto
    {
        public Guid GoodId { get; set; }
        public Guid WarehouseId { get; set; }
        public int Count { get; set; }
    }
}
