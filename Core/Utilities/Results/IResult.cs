using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //temel voidler için başlangıç. voidleri IResult yapısıyla süsleyeceğiz.
    //IResult içerisinde bir tane işlem sonucu, bir tane de kullanıcıyı bilgilendirmek adına mesaj olsun.
    public interface IResult
    {
        bool Success { get; } //get; sadece okunabilir demek.
        string Message { get; } //get; sadece okunabilir demek.
    }
}
