using Furniture.DataLayer.Abstract;
using Furniture.DataLayer.Concrete;
using Furniture.DataLayer.Repository;
using Furniture.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.DataLayer.EntityFramework
{
    public class EfOrderDal : Repository<Order, Context>, IOrderDal
    {
        public List<Order> GetOrders(string userId)
        {
            using (var context = new Context())
            {
                var orders = context.Orders
                                .Include(i => i.OrderItems)
                                .ThenInclude(i => i.Product)
                                .AsQueryable();

                if (!string.IsNullOrEmpty(userId))
                {
                    orders = orders.Where(i => i.UserID == userId);
                }

                return orders.ToList();
            }
        }
    }
}
