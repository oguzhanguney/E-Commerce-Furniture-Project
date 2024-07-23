using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.EntityLayer.Concrete
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public int BrandID { get; set; }
        public Brand Brand { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public string ImageURL { get; set; }
        public bool IsApproved { get; set; }
    }
}
