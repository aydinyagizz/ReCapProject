using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, string message) : base(success, message) //success ve message Result'da olduğu için ve Result'u implement ettiği için kodları tekrar yazmamak için base'den çekiyoruz.
        {
            Data = data;
        }
        public DataResult(T data, bool success) : base(success) //mesaj vermek istemediğimiz zaman Result'da tek parametreli olan constructor'a gönderiyoruz. 
        {
            Data = data;
        }
        public T Data { get; }
    }
}
