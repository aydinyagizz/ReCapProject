using Business.Abstrack;
using DataAccess.Abstrack;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public List<Car> GetAll()
        {
            //İş kodları
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            //her p için p'nin BrandId'si benim gönderdiğim id'ye yani BrandId'ye eşitse onları filtrele.
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            //her p için p'nin BrandId'si benim gönderdiğim id'ye yani BrandId'ye eşitse onları filtrele.
            return _carDal.GetAll(p => p.ColorId == id);
        }

        public List<Car> GetCarsByDailyPrice(int min, int max)
        {
            return _carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max); //şu fiyat aralığında listele.
        }
    }
}
