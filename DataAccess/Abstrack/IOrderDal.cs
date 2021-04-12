using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstrack
{
    //Order ile ilgili veritabanında yapacağım operasyonları içeren interface
    public interface IOrderDal:IEntityRepository<Order>
    {

    }
}
