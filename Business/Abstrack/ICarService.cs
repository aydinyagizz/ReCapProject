using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstrack
{
    //ICarService; iş katmanında kullanacağımız servis operasyonları
    public interface ICarService
    {
        List<Car> GetAll();
    }
}
