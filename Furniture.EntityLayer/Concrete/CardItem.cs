using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.EntityLayer.Concrete
{
    public class CardItem
    {
        [Key]
        public int CardItemID { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }

        public int Quantity { get; set; }
    }
}
