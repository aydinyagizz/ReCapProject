using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        //bu kurallar bir constructor'ın içine yazılır.
        public CarValidator()
        {
            RuleFor(c => c.CarName).NotEmpty(); //CarName'i boş geçilemez.
            RuleFor(c => c.CarName).MinimumLength(2); //CarName'i minimum 2 karakter olmalıdır.
            RuleFor(c => c.DailyPrice).NotEmpty();//DailyPrice'de boş geçilemez.
            RuleFor(c => c.DailyPrice).GreaterThan(0); //DailyPrice 0'dan büyük olmalıdır.
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(10).When(c => c.ColorId == 1); //DailyPrice'nin başlangıç fiyatı 10 olmalı ama ColorId'si 1 olunca.
            //Olmayan bir kuralı biz yazabiliriz.
            RuleFor(p => p.CarName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı."); //CarName A harfi ile başlamalı.
            //WithMessage(); Kendi hata mesajını yazıyorsun. Kullanıcının gördüğü hata mesajını.
        }

        private bool StartWithA(string arg) //kendi kuralımız. ture ve false döndürür.
        {
            return arg.StartsWith("A");
        }
    }
}
