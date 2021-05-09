using Core.DataAccess.EntityFramework;
using DataAccess.Abstrack;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //ICarDal'daki operasyonlar EfEntityRepositoryBase'da. EfEntityRepositoryBase içinde ICarDal'ın istediği imzalar olduğu için, EfEntityRepositoryBase içinde ICarDal operasyonlar var zaten.
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            //iki tabloyu join etme işlemi.
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId

                             from a in context.Cars
                             join d in context.Colors
                             on a.ColorId equals d.ColorId

                             select new CarDetailDto {CarId = c.CarId, BrandName = b.BrandName, ColorName = d.ColorName, CarName = c.CarName, DailyPrice = c.DailyPrice, ModelYear = c.ModelYear };           
                return result.ToList();
            }
        }
    }
}
