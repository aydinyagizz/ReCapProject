using DataAccess.Abstrack;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars; //global değişkenlerin adları genellikle _ ile verilir.

        public InMemoryCarDal() //constructor
        {
            //veritabanı varmış gibi simüle ediyoruz.
            _cars = new List<Car> //ürünleri barındıran liste 
            {
                new Car{CarId=1, BrandId=1, CarName="Opel", ColorId=1, DailyPrice=500, Description="2020 model", ModelYear=2020},
                new Car{CarId=2, BrandId=1, CarName="Mercedes", ColorId=2, DailyPrice=1500, Description="2021 model", ModelYear=2021},
                new Car{CarId=3, BrandId=2, CarName="Toyota", ColorId=3, DailyPrice=2500, Description="2022 model", ModelYear=2022},
                new Car{CarId=4, BrandId=2, CarName="BMW", ColorId=4, DailyPrice=3500, Description="2023 model", ModelYear=2023},
                new Car{CarId=5, BrandId=2, CarName="Audi", ColorId=5, DailyPrice=4500, Description="2024 model", ModelYear=2024},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            //LINQ - Language Integrated Query - Dile Gömülü Sorgulama.
            //SingleOrDefault(); ürünleri tek tek dolaşmaya yarar. =>; Lambda işareti denir. p; tek tek dolaşırken verdiğimiz takma isim.
            Car carToDelete = _cars.SingleOrDefault(p=>p.CarId == car.CarId);
            //her p için p nin Id'si benim parametre ile gönderdiğim ürünün Id'sine eşitse onun referansını carToDelete'ye eşitle diyoruz.
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars; //tümünü döndürür.
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int brandId)
        {
            //where; içindeki şarta uyan bütün elemanları yeni bir liste haline getirir ve onu döndürür.
            return _cars.Where(p => p.BrandId == brandId).ToList();
        }

        public void Update(Car car)
        {
            //SingleOrDefault(); ürünleri tek tek dolaşmaya yarar. =>; Lambda işareti denir. p; tek tek dolaşırken verdiğimiz takma isim.
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            //her p için p nin Id'si benim parametre ile gönderdiğim ürünün Id'sine eşitse onun referansını productToDelete'ye eşitle diyoruz.

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.CarName = car.CarName;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

        }
    }
}
