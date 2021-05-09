using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstrack
{
    //Rental ile ilgili veritabanında yapacağım operasyonları içeren interface
    public interface IRentalDal : IEntityRepository<Rental>
    {
        //interface metotları default public'dir.
        List<RentalDetailDto> GetRentalDetails(); //arabanın detaylarını getirir.
    }
}
