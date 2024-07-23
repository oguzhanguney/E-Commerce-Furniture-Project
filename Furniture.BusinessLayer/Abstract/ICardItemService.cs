using Furniture.EntityLayer.Concrete;

namespace Furniture.BusinessLayer.Abstract
{
    public interface ICardItemService : IGenericService<CardItem>
    {
        List<CardItem> GetCardItemsWithProducts();
        List<CardItem> GetCardItemsByCardId(int cardId);
    }
}
