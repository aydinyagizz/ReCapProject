using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //IResult'ın somut sınıfı.
    public class Result : IResult
    {
        public Result(bool success, string message) : this(success)  //this demek class'ın kendisi demek. İki parametre gönderen biri için Result'un tek parametreli Constructor'ına success'i yolla diyoruz ve kodu tekrar etmekten, yazmaktan kurtuluyoruz.
        {
            Message = message;
        }

        public Result(bool success) //Mesaj kısmını boş da bırakabilir.
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
