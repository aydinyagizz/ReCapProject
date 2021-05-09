using Core.DataAccess.EntityFramework;
using DataAccess.Abstrack;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //IUserDal'daki operasyonlar EfEntityRepositoryBase'da. EfEntityRepositoryBase içinde IUserDal'ın istediği imzalar olduğu için, EfEntityRepositoryBase içinde ICarDal operasyonlar var zaten.
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapProjectContext>, IUserDal
    {

    }
}
