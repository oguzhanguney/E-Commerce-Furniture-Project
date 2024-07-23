using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.EntityLayer.Concrete
{
    public class Card
    {
        [Key]
        public int CardID { get; set; }
        public string UserID { get; set; } //TCKN

        public List<CardItem> CardItems { get; set; }
    }
}
