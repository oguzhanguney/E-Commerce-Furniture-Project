using Furniture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.DataLayer.Abstract
{
    public interface ICardDal: IRepository<Card>
    {
        Card GetByUserID(string userId);
        void DeleteFromCard(int cardId, int productId);
        void ClearCard(string cardId);
    }
}
