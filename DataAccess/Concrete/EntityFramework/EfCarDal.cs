using DataAccess.Abstrack;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            //bir classı new'lediğimizde o bellekten belli bir zamanda düzenli olarak gelir ve bellekten onu atar. using içerisine yazdığımız nesneler using bitince anında bellekten atılır. 
            //using; perfonmans açısından ekliyoruz. belleği hızlıca temizleme.
            //using; IDisposable pattern implementation of c#
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var addedEntity = context.Entry(entity); //veri kaynağını ilişkilendirme. referansı yakalamak.
                addedEntity.State = EntityState.Added; //eklenecek nesne.
                context.SaveChanges(); //ekleme işlemi.
            }
        }

        public void Delete(Car entity)
        {
            //bir classı new'lediğimizde o bellekten belli bir zamanda düzenli olarak gelir ve bellekten onu atar. using içerisine yazdığımız nesneler using bitince anında bellekten atılır. 
            //using; perfonmans açısından ekliyoruz. belleği hızlıca temizleme.
            //using; IDisposable pattern implementation of c#
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var deletedEntity = context.Entry(entity); //veri kaynağını ilişkilendirme. referansı yakalamak.
                deletedEntity.State = EntityState.Deleted; //silinecek nesne.
                context.SaveChanges(); //ekleme işlemi.
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            //tek data getirecek.
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                //filter==null'mı eğer null ise hepsini getir. null değil ise filitrelenmiş olarak getir.
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            //bir classı new'lediğimizde o bellekten belli bir zamanda düzenli olarak gelir ve bellekten onu atar. using içerisine yazdığımız nesneler using bitince anında bellekten atılır. 
            //using; perfonmans açısından ekliyoruz. belleği hızlıca temizleme.
            //using; IDisposable pattern implementation of c#
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var updatedEntity = context.Entry(entity); //veri kaynağını ilişkilendirme. referansı yakalamak.
                updatedEntity.State = EntityState.Modified; //güncellenecek nesne.
                context.SaveChanges(); //ekleme işlemi.
            }
        }
    }
}
