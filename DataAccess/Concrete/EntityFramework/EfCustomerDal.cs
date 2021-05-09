using Core.DataAccess.EntityFramework;
using DataAccess.Abstrack;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //ICustomerDal'daki operasyonlar EfEntityRepositoryBase'da. EfEntityRepositoryBase içinde ICustomerDal'ın istediği imzalar olduğu için, EfEntityRepositoryBase içinde ICarDal operasyonlar var zaten.
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapProjectContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.UserId
                             select new CustomerDetailDto { CompanyName = c.CompanyName, CustomerId = c.CustomerId, FirstName = u.FirstName, Email = u.Email, LastName = u.LastName, Password = u.Password};

                return result.ToList();
            }
        }
    }
}
