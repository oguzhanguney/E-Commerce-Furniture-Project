using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.EntityLayer.Concrete
{
    public class OrderItem
    {
        [Key]
        public int OrderItemID { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
