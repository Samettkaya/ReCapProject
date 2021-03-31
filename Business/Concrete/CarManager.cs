using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results.Abstract;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Aspects.Autofac.Cashing;
using Business.BusinessAspects.Autofac;
using System.Linq.Expressions;
using System.Reflection;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("car.add,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
         
        }

        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.CarName.Length < 2)
            {
                throw new Exception("");
            }
            Add(car);
            return null;
        }

        [SecuredOperation("car.delete,admin")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDelete);
                
        }

        public IDataResult<List<Car>> GetAll()
        {

            if (DateTime.Now.Hour==05)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarListed);
        }

      

   
        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>( _carDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<Car>> GetByModelYear(string year)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(filter));
        }

        public IDataResult<List<CarDetailDto>> GetCarsBySelect(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId & c.BrandId == brandId));
        }

      

        //public IDataResult<List<CarDetailDto>> GetCarsDetails(FilterDto filterDto)
        //{
        //    Expression propertyExp, someValue, containsMethodExp, combinedExp;
        //    Expression<Func<Car, bool>> exp = c => true, oldExp;
        //    MethodInfo method;
        //    var parameterExp = Expression.Parameter(typeof(Car), "type");
        //    foreach (PropertyInfo propertyInfo in filterDto.GetType().GetProperties())
        //    {
        //        if (propertyInfo.GetValue(filterDto, null) != null)
        //        {
        //            oldExp = exp;
        //            propertyExp = Expression.Property(parameterExp, propertyInfo.Name);
        //            method = typeof(int).GetMethod("Equals", new[] { typeof(int) });
        //            someValue = Expression.Constant(filterDto.GetType().GetProperty(propertyInfo.Name).GetValue(filterDto, null), typeof(int));
        //            containsMethodExp = Expression.Call(propertyExp, method, someValue);
        //            exp = Expression.Lambda<Func<Car, bool>>(containsMethodExp, parameterExp);
        //            combinedExp = Expression.AndAlso(exp.Body, oldExp.Body);
        //            exp = Expression.Lambda<Func<Car, bool>>(combinedExp, exp.Parameters[0]);
        //        }
        //    }
        //    return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(exp));
        //}

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            List<CarDetailDto> carDetails = _carDal.GetCarDetails(p => p.BrandId == brandId);
            if (carDetails == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.GetErrorCarMessage);
            }
            else
            {
                return new SuccessDataResult<List<CarDetailDto>>(carDetails, Messages.GetErrorCarMessage);
            }
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            List<CarDetailDto> carDetails = _carDal.GetCarDetails(p => p.ColorId == colorId);
            if (carDetails == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>();
            }
            else
            {
                return new SuccessDataResult<List<CarDetailDto>>(carDetails);
            }
        }

        [SecuredOperation("car.update,admin")]
        [CacheRemoveAspect("ICarService.Update")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            if (car.DailyPrice>0)
            {
                _carDal.Update(car);
                //Console.WriteLine("Araba başarıyla güncellendi.");
                return new SuccessResult(Messages.CarUpdated);
            }
            else
            {
                //Console.WriteLine($"Lütfen fiyat kısmı 0'dan büyük giriniz. Girdiğiniz değer : {car.DailyPrice}");
                return new ErrorResult(Messages.CarPriceInvalid);
            }
        }

        public IDataResult<List<CarDetailsDto>> GetAllCarDetail()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetail());
        }
    }
}
