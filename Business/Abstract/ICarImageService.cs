using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file,CarImage carImage);
        IResult Update(IFormFile file,CarImage carImage);
        IResult Delete(CarImage carImage);
        IDataResult<List<CarImage>> GetAll(); 
        IDataResult<CarImage> GetById(int id);
        IDataResult<List<CarImage>> GetImagesByCarId(int carId);

    }
}
