namespace Furniture.BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        T TGetById(int id);
        List<T> TGetAll();
        void TCreate(T entity);
        void TUpdate(T entity);
        void TDelete(T entity);
    }
}
