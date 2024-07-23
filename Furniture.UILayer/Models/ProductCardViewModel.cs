using Furniture.EntityLayer.Concrete;

namespace Furniture.UILayer.Models
{
    public class ProductCardViewModel
    {
        public Product Product { get; set; }
        public CardItem CardItem { get; set; }
        public List<Product> Products { get; set; }
    }
}
