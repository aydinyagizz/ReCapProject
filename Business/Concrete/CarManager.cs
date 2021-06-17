using Business.Abstrack;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstrack;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IColorService _colorService;
        private EfCarDal efCarDal;

        public CarManager(EfCarDal efCarDal)
        {
            this.efCarDal = efCarDal;
        }

        public CarManager(ICarDal carDal, IColorService colorService)
        {
            _carDal = carDal;
            _colorService = colorService;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            //Business Codes - iş kodları          
            IResult result = BusinessRules.Run(CheckIfCarCountOfColorCorrect(car.ColorId), CheckIfCarNameExists(car.CarName), CheckIfColorLimitExceded());

            if (result != null)
            {
                return result;
            }

            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);

        }

        public IDataResult<List<Car>> GetAll()
        {
            //İş kodları

            if (DateTime.Now.Hour == 1)
            {
                //MaintenanceTime; bakım zamanı demek
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            //her p için p'nin BrandId'si benim gönderdiğim id'ye yani BrandId'ye eşitse onları filtrele.
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }

        public IDataResult<List<Car>> GetCarsByDailyPrice(int min, int max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max)); //şu fiyat aralığında listele.
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            //Bir renkte en fazla 15 ürün bulunabilir.
            //select count(*) from cars where colorId = 1 
            var result = _carDal.GetAll(c => c.ColorId == car.ColorId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.CarCountOfColorError);
            }
            throw new NotImplementedException();
        }


        private IResult CheckIfCarCountOfColorCorrect(int colorId) //color'daki ürün sayısının kurallara uygunluğunun doğrulanması.
        {
            //Bir renkte en fazla 15 ürün bulunabilir.
            //select count(*) from cars where colorId = 1 
            var result = _carDal.GetAll(c => c.ColorId == colorId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.CarCountOfColorError);
            }
            return new SuccessResult();
        }


        private IResult CheckIfCarNameExists(string carName) //ürün ismi daha önce eklenmiş mi eklenmemiş mi.
        {
            //aynı isimde başka bir ürün eklenemez.
            var result = _carDal.GetAll(c => c.CarName == carName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExists);
            }
            return new SuccessResult();
        }


        private IResult CheckIfColorLimitExceded()
        {
            //eğer mevcut renk categorisi sayısı 15'i geçtiyse sisteme yeni ürün eklenemez.
            var result = _colorService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
