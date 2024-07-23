using Furniture.EntityLayer.Concrete;

namespace Furniture.UILayer.Models
{
    public class ProductListModel
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public ProductCardViewModel ProductCardViewModel { get; set; }
    }
}
