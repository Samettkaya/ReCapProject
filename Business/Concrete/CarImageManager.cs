using Business.Abstract;
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
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)

        {
            _carImageDal = carImageDal;
        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage)
        {
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.CarImageAdded);
           
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.CarImageDelete);
        }

        public IDataResult<List<CarImage>> GetAll()
        {

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImageLists);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == carImageId), Messages.CarImageList);
        }


        public IResult Update(CarImage carImage)
        {
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.CarImageUpdated);
        }
    }
}
