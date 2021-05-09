using Business.Abstrack;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstrack;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            //Business Codes - iş kodları

            if (rental.ReturnDate == null)
            {
                return new ErrorResult(Messages.ReturnCar);
                
            }

            _rentalDal.Add(rental);

            return new SuccessResult(Messages.RentalAdded);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            //İş kodları

            if (DateTime.Now.Hour == 21)
            {
                //MaintenanceTime; bakım zamanı demek
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalAdded);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }
    }
}
