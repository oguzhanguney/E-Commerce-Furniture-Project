using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.EntityLayer.Concrete
{
    public class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        [Key]
        public int OrderID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string UserID { get; set; } // TCKN
        public DateTime CreatedDate { get; set; }
        public int PostalCode { get; set; }
        public string OrderNote { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
