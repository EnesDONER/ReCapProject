using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.DTOs;
using System.Linq.Expressions;
using DataAccess.Dtos;

namespace DataAccess.Abstract
{//CRUD işlemleri IEntityRepository tipinde referansları tutan interfacede tanıtıldı(Core->DataAccess)
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null);
        
    }
}
