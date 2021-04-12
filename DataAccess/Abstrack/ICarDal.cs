using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstrack
{
    //Car ile ilgili veritabanında yapacağım operasyonları içeren interface
    public interface ICarDal : IEntityRepository<Car>
    {
        //interface metotları default public'dir.

        List<CarDetailDto> GetCarDetails(); //arabanın detaylarını getirir.
    } 
}
