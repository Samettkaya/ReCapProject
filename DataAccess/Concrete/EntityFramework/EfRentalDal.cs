﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, Context>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (Context context = new Context()) 
            {
                var result =
                     from rental in filter == null ? context.Rentals : context.Rentals.Where(filter)
                     join customer in context.Customers
                         on rental.CustomerId equals customer.CustomerId
                   
                     join car in context.Cars
                          on rental.CarId equals car.CarId
                     join brand in context.Brands
                          on car.BrandId equals brand.BrandId
                     join color in context.Colors
                          on car.ColorId equals color.ColorId
                     select new RentalDetailDto
                     {
                         RentDate = rental.RentDate,
                         ReturnDate = rental.ReturnDate,
                         RentalId = rental.RentalId,
                         BrandName = brand.BrandName,
                         CarDesctiption = car.Description,
                         ColorName = color.ColorName,
                         CompanyName = customer.CompanyName,
                         DailyPrice = car.DailyPrice,
                         ModelYear = car.ModelYear,
                         CarName=car.CarName
                     };

                return result.ToList();
            }
        }
    }
}
