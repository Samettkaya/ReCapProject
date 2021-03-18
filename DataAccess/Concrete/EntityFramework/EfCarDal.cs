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
        //public CarDetailDto GetCarDetail(int carId)
        //{
        //    //using (Context context = new Context())
        //    //{
        //    //    var result = from p in context.Cars.Where(p => p.CarId == carId)
        //    //                 join c in context.Colors
        //    //                 on p.ColorId equals c.ColorId
        //    //                 join d in context.Brands
        //    //                 on p.BrandId equals d.BrandId
        //    //                 select new CarDetailDto
        //    //                 {
        //    //                     BrandName = d.BrandName,
        //    //                     ColorName = c.ColorName,
        //    //                     DailyPrice = p.DailyPrice,
        //    //                     Description = p.Description,
        //    //                     ModelYear = p.ModelYear,
        //    //                     CarId = p.CarId
        //    //                 };
        //    //    return result.SingleOrDefault();
        //    //}
        //}

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (Context context = new Context())
            {
                var result = from cr in filter is null ? context.Cars : context.Cars.Where(filter)
                             join br in context.Brands
                             on cr.BrandId equals br.BrandId
                             join co in context.Colors
                             on cr.ColorId equals co.ColorId
                            

                             select new CarDetailDto
                             {

                                 CarId = cr.CarId,
                                 CarName = cr.CarName,
                                 BrandName = br.BrandName,
                                 ColorName = co.ColorName,
                                 ModelYear = cr.ModelYear,
                                 DailyPrice = cr.DailyPrice,
                                 Description = cr.Description,
                                 ImagePath = context.CarImages.Where(x => x.CarId == cr.CarId).FirstOrDefault().ImagePath


                             };

                return result.ToList();

            }
        }
    }
    
}
