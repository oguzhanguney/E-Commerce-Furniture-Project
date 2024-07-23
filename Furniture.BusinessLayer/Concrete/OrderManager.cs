using Furniture.BusinessLayer.Abstract;
using Furniture.DataLayer.Abstract;
using Furniture.DataLayer.Concrete;
using Furniture.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public Order GetOrderByUserId(int userId)
        {
            using (var context = new Context())
            {
                return context.Set<Order>().Where(x => x.UserID == userId.ToString()).OrderByDescending(x => x.OrderID).FirstOrDefault();
            }
        }

        public List<Order> GetOrders(string userId)
        {
            return _orderDal.GetOrders(userId);
        }

        public void TCreate(Order entity)
        {
            _orderDal.Create(entity);
        }

        public void TDelete(Order entity)
        {
            throw new NotImplementedException();
        }

        public List<Order> TGetAll()
        {
            return _orderDal.GetAll();
        }

        public Order TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
