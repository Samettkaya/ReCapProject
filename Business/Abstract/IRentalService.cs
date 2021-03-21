
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> Get(int carId); 
        IDataResult<List<Rental>> GetAllByCarId(int carId);
        IDataResult<List<RentalDetailDto>> GetRentalDetailsDto(int carId);

        IDataResult<List<RentalDetailDto>> GetAllRentalDetailsDto();
        IResult CheckReturnDate(int carId);
        IResult UpdateReturnDate(int carId);
        IResult IsDelivered(Rental rental);
        IResult IsRentable(Rental rental);

    }
}
