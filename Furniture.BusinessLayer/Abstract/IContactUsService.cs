using Furniture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.BusinessLayer.Abstract
{
    public interface IContactUsService:IGenericService<ContactUs>
    {
        List<ContactUs> TGetListContactUsByTrue();
        List<ContactUs> TGetListContactUsByFalse();

        void TContactUsStatusChangeToFalse(int id);
    }
}
