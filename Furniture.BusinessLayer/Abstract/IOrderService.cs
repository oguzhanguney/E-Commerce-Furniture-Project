using Furniture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.BusinessLayer.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
        List<Order> GetOrders(string userId);
        Order GetOrderByUserId(int userId);
	}
}
