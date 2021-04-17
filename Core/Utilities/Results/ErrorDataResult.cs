using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message) //bir data ve bir mesaj içeren constructor.
        {

        }
        public ErrorDataResult(T data) : base(data, false) //mesaj vermek istemezse.
        {

        }
        public ErrorDataResult(string message) : base(default, false, message) //bir data döndürmek istemiyorsak.sadece mesaj vermewk istiyorsak.
        {

        }
        public ErrorDataResult() : base(default, false) //bir data ve mesaj döndürmek istemiyorsak.
        {

        }
    }
}
