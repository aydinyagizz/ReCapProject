using Business.Abstrack;
using Core.Utilities.Results;
using DataAccess.Abstrack;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        
        public IDataResult<Brand> GetById(int brandId)
        {
            //select * from Brands where BrandId=3 demek gibi. 
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == brandId));
        }
    }
}
