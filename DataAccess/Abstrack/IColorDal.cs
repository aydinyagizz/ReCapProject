using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstrack
{
    //Car ile ilgili veritabanında yapacağım operasyonları içeren interface
    public interface IColorDal:IEntityRepository<Color>
    {
        //interface metotları default public'dir.
    }
}
