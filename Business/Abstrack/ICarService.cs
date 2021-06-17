using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstrack
{
    //ICarService; iş katmanında kullanacağımız servis operasyonları
    public interface ICarService
    {
        //data olanları IDataResult, data olmayanları yani voidleri IResult dedik.
        IDataResult<List<Car>> GetAll(); //hepsini getirir.
        IDataResult<List<Car>> GetCarsByBrandId(int id); //markaya göre getirir.
        IDataResult<List<Car>> GetCarsByColorId(int id); //renge göre getirir.
        IDataResult<List<Car>> GetCarsByDailyPrice(int min, int max); //fiyat aralığına göre listele
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<Car> GetById(int carId); //sadece car döndürür. tek başına bir ürün döndürür.
        IResult Add(Car car); //yeni ürün ekleme.
        IResult Update(Car car); //yeni ürün ekleme.
    }
}
