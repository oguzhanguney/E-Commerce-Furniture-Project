using Furniture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.DataLayer.Abstract
{
    public interface IContactUsDal:IRepository<ContactUs>
    {
        //Status'u true olan mesajları getirmek için:
        List<ContactUs> GetListContactUsByTrue();
        List<ContactUs> GetListContactUsByFalse();

        void ContactUsStatusChangeToFalse(int id);
    }
}
