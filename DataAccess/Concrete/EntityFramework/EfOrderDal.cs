using Core.DataAccess.EntityFramework;
using DataAccess.Abstrack;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //ICarDal'daki operasyonlar EfEntityRepositoryBase'da. EfEntityRepositoryBase içinde ICarDal'ın istediği imzalar olduğu için, EfEntityRepositoryBase içinde ICarDal operasyonlar var zaten.
    public class EfOrderDal : EfEntityRepositoryBase<Order, ReCapProjectContext>, IOrderDal
    {

    }
}
