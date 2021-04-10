using Entities.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstrack
{
    //generic constraint - generik kısıt anlamında. yani kısıtlamalar yapacağız. sadece veritabanımızda olan product, category gibi şeyler buraya gönderilebilir.
    //T; verdiğimiz tipe göre gönderir. product ise product, category ise category olur.
    //class dediğimiz şey referans tip olabilir anlamında.
    //IEntity dediğimizde IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
    //new(); new'lenebilir olmalı diyoruz. yani IEntity'yi devre dışı bırakıyoruz.IEntity new'lenemez çünkü interface. IEntity soyuttur ve bizim işimizi görmez. sadece IEntity'i implement eden classlar kısıtlamasını verdik.
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {

        //interface metotları default public'dir.
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //filtreleme yapmak için kullandığımız bir yapı. filter=null; filtre vermeyedebiliriz demek.
        T Get(Expression<Func<T, bool>> filter); //tek bir data getirmek için kullandık. örneğin bir şeyin detayına gitmek gibi. 
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
