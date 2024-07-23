using Furniture.BusinessLayer.Abstract;
using Furniture.DataLayer.Abstract;
using Furniture.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.BusinessLayer.Concrete
{
    public class ContactUsManager : IContactUsService
    {
        //dependency injection:
        IContactUsDal _contactUsDal;

        public ContactUsManager(IContactUsDal contactUsDal)
        {
            _contactUsDal = contactUsDal;
        }

        public void TContactUsStatusChangeToFalse(int id)
        {
            throw new NotImplementedException();
        }

        public void TCreate(ContactUs entity)
        {
            _contactUsDal.Create(entity);
        }

        public void TDelete(ContactUs entity)
        {
            _contactUsDal.Delete(entity);
        }

        public List<ContactUs> TGetAll()
        {
            return _contactUsDal.GetAll();
        }

        public ContactUs TGetById(int id)
        {
            return _contactUsDal.GetById(id);
        }

        public List<ContactUs> TGetListContactUsByFalse()
        {
            return _contactUsDal.GetListContactUsByFalse();
        }

        public List<ContactUs> TGetListContactUsByTrue()
        {
            return _contactUsDal.GetListContactUsByTrue();
        }

        public void TUpdate(ContactUs entity)
        {
            throw new NotImplementedException();
        }
    }
}
