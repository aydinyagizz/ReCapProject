using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstrack
{
    //ICarService; iş katmanında kullanacağımız servis operasyonları
    public interface IRentalService
    {
        //data olanları IDataResult, data olmayanları yani voidleri IResult dedik.
        IDataResult<List<Rental>> GetAll(); //hepsini getirir.
        IResult Add(Rental rental); //yeni ürün ekleme.
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
    }
}
