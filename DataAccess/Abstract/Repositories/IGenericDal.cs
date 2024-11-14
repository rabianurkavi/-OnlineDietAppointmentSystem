using System.Linq.Expressions;

namespace DataAccess.Abstract.Repositories;

public interface IGenericDal<T> where T : class
{
    void Insert(T t);
    void Update(T t);
    void Delete(T t);
    List<T> GetAll(Expression<Func<T, bool>> filter = null);
    T Get(Expression<Func<T, bool>> filter);
}