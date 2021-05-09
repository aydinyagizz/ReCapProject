using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstrack
{
    public interface ICustomerService
    {
        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();
    }
}
