using Furniture.EntityLayer.Concrete;

namespace Furniture.UILayer.Dtos
{
    public class CreateCardItemDto
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }

        public int Quantity { get; set; }
    }
}
