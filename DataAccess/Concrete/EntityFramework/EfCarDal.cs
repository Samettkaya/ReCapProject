using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, Context>, ICarDal
    {
      

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (Context context = new Context())
            {
                var result = from cr in context.Cars.Where(filter)
                             join br in context.Brands
                             on cr.BrandId equals br.BrandId
                             join co in context.Colors
                             on cr.ColorId equals co.ColorId
                             join im in context.CarImages
                             on cr.CarId  equals im.CarId

                             select new CarDetailDto
                             {

                                 CarId = cr.CarId,
                                 CarName = cr.CarName,
                                 BrandName = br.BrandName,
                                 ColorName = co.ColorName,
                                 ModelYear = cr.ModelYear,
                                 DailyPrice = cr.DailyPrice,
                                 Description = cr.Description,
                                 ImagePath = im.ImagePath,
                                 Date = im.Date


                             };

                return result.ToList();

            }
        }
    }
    
}
