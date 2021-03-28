using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Helpers;
using Core.Utilities.BusinessRules;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExpired(carImage.CarId), CheckIfImageExtensionValid(file));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageExists(carImage.ImageId));
            if (result != null)
            {
                return result;
            }
            string path = GetById(carImage.ImageId).Data.ImagePath;
            FileHelper.Delete(path);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarHaveNoImage(carId));
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.ImageId == id),Messages.CarImageListed);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExpired(carImage.CarId),
                CheckIfImageExtensionValid(file),
                CheckIfImageExists(carImage.ImageId));
            if (result != null)
            {
                return result;
            }
            carImage.Date = DateTime.Now;
            string OldPath = GetById(carImage.ImageId).Data.ImagePath;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdate);
        }
        private IResult CheckIfImageLimitExpired(int carId)
        {
            int result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
                return new ErrorResult(Messages.CarImageAddingLimit);
            return new SuccessResult();
        }
        private IResult CheckIfImageExtensionValid(IFormFile file)
        {
            bool isValidFileExtension = Messages.ValidImageFileTypes.Any(i => i == Path.GetExtension(file.FileName).ToUpper());
            if (!isValidFileExtension)
                return new ErrorResult(Messages.CarImageAdded);
            return new SuccessResult();

        }

        private List<CarImage> CheckIfCarHaveNoImage(int carId)
        {
            string path = Directory.GetCurrentDirectory() + @"\wwwroot\Images\default.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (!result.Any())
                return new List<CarImage> { new CarImage { CarId = carId, ImagePath = path } };
            return result;
        }
        private IResult CheckIfImageExists(int id)
        {
            if (_carImageDal.IsExist(id))
                return new SuccessResult();
            return new ErrorResult(Messages.CarImageAddingLimit);
        }
    }
}