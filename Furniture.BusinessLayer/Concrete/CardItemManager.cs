using Furniture.BusinessLayer.Abstract;
using Furniture.DataLayer.Abstract;
using Furniture.EntityLayer.Concrete;

namespace Furniture.BusinessLayer.Concrete
{
    public class CardItemManager : ICardItemService
    {
        private ICardItemDal _cardItemDal;

        public CardItemManager(ICardItemDal cardItemDal)
        {
            _cardItemDal = cardItemDal;
        }

        public List<CardItem> GetCardItemsByCardId(int cardId)
        {
            return _cardItemDal.GetCardItemsByCardId(cardId);
        }

        public List<CardItem> GetCardItemsWithProducts()
        {
            return _cardItemDal.GetCardItemsWithProducts();
        }

        public void TCreate(CardItem entity)
        {
            _cardItemDal.Create(entity);
        }

        public void TDelete(CardItem entity)
        {
            _cardItemDal.Delete(entity);
        }

        public List<CardItem> TGetAll()
        {
            return _cardItemDal.GetAll();
        }

        public CardItem TGetById(int id)
        {
            return _cardItemDal.GetById(id);
        }

        public void TUpdate(CardItem entity)
        {
            _cardItemDal.Update(entity);
        }
    }
}
