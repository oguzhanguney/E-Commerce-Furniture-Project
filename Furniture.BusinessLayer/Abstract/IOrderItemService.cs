using Furniture.EntityLayer.Concrete;

namespace Furniture.BusinessLayer.Abstract
{
	public interface IOrderItemService : IGenericService<OrderItem>
	{
        List<OrderItem> GetOrdersByUserId(int userId);
        List<OrderItem> GetOrdersByOrderId(int orderId);
    }
}
