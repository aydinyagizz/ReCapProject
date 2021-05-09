using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstrack
{
    //User ile ilgili veritabanında yapacağım operasyonları içeren interface
    public interface IUserDal : IEntityRepository<User>
    {

    }
}
