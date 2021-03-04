﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [SecuredOperation("brand")]
        [ValidationAspect(typeof(BrandValidator))]

        public IResult Add(Brand brand)
        {
         
                _brandDal.Add(brand);
                
                return new SuccessResult(Messages.BrandAdded);
            
         
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
           
            return new SuccessResult(Messages.BrandDelete);

        }

        [SecuredOperation("brand")]
        public IDataResult<List<Brand>> GetAll()
        {
            
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandListed);

        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>( _brandDal.Get(b => b.BrandId == brandId),Messages.BrandList);
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult  Update(Brand brand)
        {
            if (brand.BrandName.Length > 2)
            {
                _brandDal.Update(brand);
               
                return new SuccessResult(Messages.BrandUpdate);
            }
            else
            {
               
                return new ErrorResult(Messages.BrandNameInvalid);
            }

        }
    }
}