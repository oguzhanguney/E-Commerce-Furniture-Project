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
    public class EfCardDal : Repository<Card, Context>, ICardDal
    {
        public override void Update(Card entity)
        {
            using (var context = new Context())
            {
                context.Cards.Update(entity);
                context.SaveChanges();
            }
        }

        public Card GetByUserID(string userId)
        {
            using (var context = new Context())
            {
                return context
                            .Cards
                            .Include(i => i.CardItems)
                            .ThenInclude(i => i.Product)
                            .FirstOrDefault(i => i.UserID == userId);
            }
        }
        public void DeleteFromCard(int cardId, int productId)
        {
            using (var context = new Context())
            {
                context.Database.ExecuteSql($"delete from CardItem where CardId={cardId} And ProductId={productId}");
            }
        }

        public void ClearCard(string cardId)
        {
			using (var context = new Context())
			{
				var entity = context.CardItems.Where(i => i.CardId == Convert.ToInt32(cardId)).ToList();
				context.Set<CardItem>().RemoveRange(entity);
				context.SaveChanges();
			}
		}
    }
}
