using Furniture.BusinessLayer.Abstract;
using Furniture.DataLayer.Abstract;
using Furniture.DataLayer.Concrete;
using Furniture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.BusinessLayer.Concrete
{
    public class CardManager : ICardService
    {
        private ICardDal _cardDal;

        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }

        public void AddToCard(string userId, int productId, int quantity)
        {
            var card = GetCardByUserID(userId);
            if (card != null)
            {
                var index = card.CardItems.FindIndex(i => i.ProductId == productId);

                if (index < 0)
                {
                    card.CardItems.Add(new CardItem()
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        CardId = card.CardID,
                    });
                }
                else
                {
                    card.CardItems[index].Quantity += quantity;
                }

                _cardDal.Update(card);
            }
        }

        public void ClearCard(string cardId)
        {
            _cardDal.ClearCard(cardId);
        }

        public void DeleteFromCard(string userId, int productId)
        {
            throw new NotImplementedException();
        }

        public Card GetCardByUserID(string userId)
        {
            return _cardDal.GetByUserID(userId);
        }

        public void InitializeCard(string userId)
        {
            throw new NotImplementedException();
        }

        public void TCreate(Card entity)
        {
            _cardDal.Create(entity);
        }

        public void TDelete(Card entity)
        {
            throw new NotImplementedException();
        }

        public List<Card> TGetAll()
        {
            throw new NotImplementedException();
        }

        public Card TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Card entity)
        {
            throw new NotImplementedException();
        }
    }
}
