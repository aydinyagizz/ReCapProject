using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    //generic constraint - generik kısıt anlamında. yani kısıtlamalar yapacağız. sadece veritabanımızda olan product, category gibi şeyler buraya gönderilebilir.
    //T; verdiğimiz tipe göre gönderir. product ise product, category ise category olur.
    //class dediğimiz şey referans tip olabilir anlamında.
    //IEntity dediğimizde IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
    //new(); new'lenebilir olmalı diyoruz. yani IEntity'yi devre dışı bırakıyoruz.IEntity new'lenemez çünkü interface. IEntity soyuttur ve bizim işimizi görmez. sadece IEntity'i implement eden classlar kısıtlamasını verdik.
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> //bir Entity ve bir context ver ona göre çalışacağım demek. Entity tablo anlamında yani Product gibi.
         where TEntity : class, IEntity, new()
         where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //bir classı new'lediğimizde o bellekten belli bir zamanda düzenli olarak gelir ve bellekten onu atar. using içerisine yazdığımız nesneler using bitince anında bellekten atılır. 
            //using; perfonmans açısından ekliyoruz. belleği hızlıca temizleme.
            //using; IDisposable pattern implementation of c#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); //veri kaynağını ilişkilendirme. referansı yakalamak.
                addedEntity.State = EntityState.Added; //eklenecek nesne.
                context.SaveChanges(); //ekleme işlemi.
            }
        }

        public void Delete(TEntity entity)
        {
            //bir classı new'lediğimizde o bellekten belli bir zamanda düzenli olarak gelir ve bellekten onu atar. using içerisine yazdığımız nesneler using bitince anında bellekten atılır. 
            //using; perfonmans açısından ekliyoruz. belleği hızlıca temizleme.
            //using; IDisposable pattern implementation of c#
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity); //veri kaynağını ilişkilendirme. referansı yakalamak.
                deletedEntity.State = EntityState.Deleted; //silinecek nesne.
                context.SaveChanges(); //ekleme işlemi.
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            //tek data getirecek.
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //filter==null'mı eğer null ise hepsini getir. null değil ise filitrelenmiş olarak getir.
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            //bir classı new'lediğimizde o bellekten belli bir zamanda düzenli olarak gelir ve bellekten onu atar. using içerisine yazdığımız nesneler using bitince anında bellekten atılır. 
            //using; perfonmans açısından ekliyoruz. belleği hızlıca temizleme.
            //using; IDisposable pattern implementation of c#
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); //veri kaynağını ilişkilendirme. referansı yakalamak.
                updatedEntity.State = EntityState.Modified; //güncellenecek nesne.
                context.SaveChanges(); //ekleme işlemi.
            }
        }
    }
}
