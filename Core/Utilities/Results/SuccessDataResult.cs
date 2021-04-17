using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message) //bir data ve bir mesaj içeren constructor.
        {

        }
        public SuccessDataResult(T data) : base(data, true) //mesaj vermek istemezse.
        {

        }
        public SuccessDataResult(string message) : base(default, true, message) //bir data döndürmek istemiyorsak.sadece mesaj vermewk istiyorsak.
        {

        }
        public SuccessDataResult() : base(default, true) //bir data ve mesaj döndürmek istemiyorsak.
        {

        }
    }
}
