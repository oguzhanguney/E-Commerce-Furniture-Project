using Furniture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.BusinessLayer.Abstract
{
    public interface ICardService : IGenericService<Card>
    {
        void InitializeCard(string userId);
        Card GetCardByUserID(string userId);
        void AddToCard(string userId, int productId, int quantity);
        void DeleteFromCard(string userId, int productId);
        void ClearCard(string cardId);
    }
}
