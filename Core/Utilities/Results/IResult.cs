using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IResult
    {

        public string Message { get; }
        public bool Success { get; }
    }
}
