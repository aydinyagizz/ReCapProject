using Core.DataAccess.EntityFramework;
using DataAccess.Abstrack;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //IRentalDal'daki operasyonlar EfEntityRepositoryBase'da. EfEntityRepositoryBase içinde IRentalDal'ın istediği imzalar olduğu için, EfEntityRepositoryBase içinde ICarDal operasyonlar var zaten.

    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId

                             from a in context.Rentals
                             join b in context.Customers
                             on a.CustomerId equals b.CustomerId
                             select new RentalDetailDto { CarName = c.CarName, CompanyName = b.CompanyName, RentalId = r.RentalId, RentDate = r.RentDate, ReturnDate = r.RentDate };

                return result.ToList();
            }
        }
    }
}
