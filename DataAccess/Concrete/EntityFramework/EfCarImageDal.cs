using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, ReCapDbContext>, ICarImageDal
    {
        public List<CarImageListDto> GetCarImageList(Expression<Func<CarImageListDto, bool>> filter = null)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from ci in context.CarImages
                             join ca in context.Cars on ci.CarId equals ca.Id
                             select new CarImageListDto()
                             {
                                 CarId = ca.Id,
                                 ImagePath = ci.ImagePath
                             };
                return filter == null
                ? result.ToList()
                : result.Where(filter).ToList();
            };
        }
    }
}
