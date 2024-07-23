using Furniture.EntityLayer.Concrete;

namespace Furniture.DataLayer.Abstract
{
    public interface ICardItemDal : IRepository<CardItem>
    {
        List<CardItem> GetCardItemsWithProducts();
        List<CardItem> GetCardItemsByCardId(int cardId);
    }
}
