using System.Linq.Expressions;
using DataAccess.Abstract.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Repositories;

public class GenericRepository<T, TContext> : IGenericDal<T> where T : class
    where TContext : DbContext, new()
{
    public void Delete(T t)
    {
        using (var context = new TContext()) //using içerisine yazdığımız nesneler using bitince anında gb gelip beni bellekten at diyor
        {
            var deleteEntity = context.Entry(t); //git veri kaynağından benim bu gönderdiğim producttan belirli bir eşleşme yap(referansı yakala)
            deleteEntity.State = EntityState.Deleted;
            context.SaveChanges(); //burdaki bütün işlemleri gerçekleştirir.
        }
    }

    public T Get(Expression<Func<T, bool>> filter)
    {
        using (var context = new TContext())
        {
            return context.Set<T>().SingleOrDefault(filter);
        }
    }

    public List<T> GetAll(Expression<Func<T, bool>> filter = null)
    {
        using (var context = new TContext())
        {
            //veri tabanındaki bütün tabloyu listeye çevir onu bana ver- select * from products döndürüyor(sqlde)
            return filter == null
                ? context.Set<T>().ToList()
                : context.Set<T>().Where(filter).ToList();
        }
    }

    public void Insert(T t)
    {
        using (var context = new TContext()) //using içerisine yazdığımız nesneler using bitince anında gb gelip beni bellekten at diyor
        {
            var addedEntity = context.Entry(t); //git veri kaynağından benim bu gönderdiğim producttan belirli bir eşleşme yap(referansı yakala)
            addedEntity.State = EntityState.Added;
            context.SaveChanges(); //burdaki bütün işlemleri gerçekleştirir.
        }
    }

    public void Update(T t)
    {
        using (var context = new TContext()) //using içerisine yazdığımız nesneler using bitince anında gb gelip beni bellekten at diyor
        {
            var updateEntity = context.Entry(t); //git veri kaynağından benim bu gönderdiğim producttan belirli bir eşleşme yap(referansı yakala)
            updateEntity.State = EntityState.Modified;
            context.SaveChanges(); //burdaki bütün işlemleri gerçekleştirir.
        }
    }
}