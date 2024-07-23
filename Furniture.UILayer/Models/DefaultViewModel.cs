using Furniture.EntityLayer.Concrete;

namespace Furniture.UILayer.Models
{
    public class DefaultViewModel
    {
        public List<Product> GetLast8 { get; set; }
        public List<Product> GetSalonSet { get; set; }
        public List<Product> GetMostViewedProducts { get; set; }
        public List<Product> GetRecommendedProducts { get; set; }
    }
}
