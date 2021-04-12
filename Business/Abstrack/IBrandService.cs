using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstrack
{
    public interface IBrandService
    {
        List<Brand> GetAll(); //hepsini listeler.
        Brand GetById(int brandId); //ilgili brand'ı listeler.
    }
}
