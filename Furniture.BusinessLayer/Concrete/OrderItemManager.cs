using Furniture.BusinessLayer.Abstract;
using Furniture.DataLayer.Concrete;
using Furniture.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Furniture.BusinessLayer.Concrete
{
    public class OrderItemManager : IOrderItemService
    {

        public void TCreate(OrderItem entity)
        {
            using (var context = new Context())
            {
                context.Set<OrderItem>().Add(entity);
                context.SaveChanges();
            }
        }

        public List<OrderItem> GetOrdersByUserId(int userId)
        {
            using (var context = new Context())
            {
                return context.Set<OrderItem>()
                    .Where(x => x.Order.UserID == userId.ToString())
                    .Include(x => x.Product)
                    .Include(y => y.Order)
                    .OrderByDescending(z => z.Order.OrderID).
                    ToList();
            }
        }

        public void TDelete(OrderItem entity)
        {
            throw new NotImplementedException();
        }

        public List<OrderItem> TGetAll()
        {
            throw new NotImplementedException();
        }

        public OrderItem TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(OrderItem entity)
        {
            throw new NotImplementedException();
        }

        public List<OrderItem> GetOrdersByOrderId(int orderId)
        {
            using (var context = new Context())
            {
                return context.Set<OrderItem>().Where(x => x.OrderId == orderId).Include(x => x.Order).Include(x => x.Product).OrderByDescending(y => y.OrderId).ToList();
            }
        }
    }
}
