using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstrack
{
    //Car ile ilgili veritabanında yapacağım operasyonları içeren interface
    public interface ICarDal
    {
        //interface metotları default public'dir.
        List<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GetById(int brandId);

    }
}
