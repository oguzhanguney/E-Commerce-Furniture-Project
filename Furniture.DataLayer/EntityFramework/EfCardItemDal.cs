using Furniture.DataLayer.Abstract;
using Furniture.DataLayer.Concrete;
using Furniture.DataLayer.Repository;
using Furniture.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Furniture.DataLayer.EntityFramework
{
    public class EfCardItemDal : Repository<CardItem, Context>, ICardItemDal
    {
        public List<CardItem> GetCardItemsByCardId(int cardId)
        {
            using (var context = new Context())
            {
                return context.CardItems
                            .Where(x => x.CardId == cardId)
                            .ToList();
            }
        }

        public List<CardItem> GetCardItemsWithProducts()
        {
            using (var context = new Context())
            {
                return context.CardItems
                            .Include(x => x.Product)
                            .ToList();
            }
        }
    }
}
