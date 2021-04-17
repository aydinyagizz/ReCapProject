using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T> : IResult  // T; hangi tipi döndüreceğimizi bana söyle diyoruz. Mesaj ile işlem sonucunu IResult içerdiği için IResult implementasyonusun diyoruz.
    {
        //Mesaj ile işlem sonucu dışında bir de T türünde data olacak. 
        T Data { get; } //örneğin ürünlerimiz.
    }
}
