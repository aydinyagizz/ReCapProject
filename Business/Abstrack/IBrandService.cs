using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstrack
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll(); //hepsini listeler.
        IDataResult<Brand> GetById(int brandId); //ilgili brand'ı listeler.
    }
}
