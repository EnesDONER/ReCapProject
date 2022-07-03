using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarImageDal:IEntityRepository<CarImage>
    {
        List<CarImageListDto> GetCarImageList(Expression<Func<CarImageListDto, bool>> filter = null);
    }
}
