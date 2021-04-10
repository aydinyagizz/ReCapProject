using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstrack
{
    //Car ile ilgili veritabanında yapacağım operasyonları içeren interface
    public interface IBrandDal:IEntityRepository<Brand>
    {
        //interface metotları default public'dir.
    }
}
