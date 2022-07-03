using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T>:Result,IDataResult<T>
    {
        public DataResult(T data , bool success,string messagge):base(success,messagge)
        {
            Data = data;
        }
        public DataResult(T data, bool success):base(success)
        {
            Data = data;
        }
        
        public T Data { get; }
    }
}
