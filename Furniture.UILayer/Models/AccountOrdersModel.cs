using Furniture.EntityLayer.Concrete;

namespace Furniture.UILayer.Models
{
    public class AccountOrdersModel
    {
        public List<OrderItem> OrderItems { get; set; }
        public List<Order> Orders { get; set; }
        public OrderItem OrderItem { get; set; }
    }
}
