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
        List<Car> GetAll(); //hepsini getirir.
        List<Car> GetCarsByBrandId(int id); //markaya göre getirir.
        List<Car> GetCarsByColorId(int id); //renge göre getirir.
        List<Car> GetCarsByDailyPrice(int min, int max); //fiyat aralığına göre listele
        List<CarDetailDto> GetCarDetails();
    }
}
