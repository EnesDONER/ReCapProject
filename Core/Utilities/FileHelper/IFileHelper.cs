using Core.Utilities.Result;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileHelper
{
    public interface IFileHelper
    {
        IResult Upload(IFormFile file, string root);
        IResult Delete(string filePath);
        IResult Update(IFormFile file, string root, string filePath);
    }
}
