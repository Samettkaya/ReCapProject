using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Cashing;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.BusinessRules;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

using System.Collections.Generic;


namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarService _carService;
        IFindexScoreService _findexScoreService;
        public RentalManager(IRentalDal rentalDal, ICarService carService, IFindexScoreService findexScoreService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _findexScoreService = findexScoreService;

        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(IsCarCanBeRented(rental), CheckFindeksScore(rental));

            if (result != null)
            {
                return result;
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }


        [SecuredOperation("admin")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
            IResult result = BusinessRules.Run(IsCarCanBeRented(rental), CheckFindeksScore(rental));

            if (result != null)
            {
                return result;
            }

            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdate);
        }




        [SecuredOperation("admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDelete);
        }


        [CacheRemoveAspect("IRentalService.Get")]
        public IResult DeliverCar(Rental rental)
        {
            var result = BusinessRules.Run(CheckIfCarAlreadyDelivered(rental.RentalId));
            if (result != null)
            {
                return result;
            }

            Rental updatedCar = _rentalDal.Get(x => x.RentalId == rental.RentalId);
            updatedCar.ReturnDate = rental.ReturnDate;
            _rentalDal.Update(updatedCar);
            return new SuccessResult(Messages.CarDelivered);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<List<Rental>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(rental => rental.CarId == carId));
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(b => b.RentalId == rentalId));
        }

        public IDataResult<List<RentalDetailDto>> GetDeliveredRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.ReturnDate != null));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsByRentalId(int rentalId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(m => m.RentalId == rentalId));
        }

        public IDataResult<List<RentalDetailDto>> GetUndeliveredRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.ReturnDate == null));
        }

        public IResult IsCarCanBeRented(Rental rental)
        {
            var result = GetByCarId(rental.CarId).Data;
            if (result != null)
            {
                foreach (var rentalCar in result)
                {
                    if (rental.RentDate >= rentalCar.RentDate && rental.RentDate <= rentalCar.ReturnDate)
                    {
                        return new ErrorResult("Bu tarihler arasında araç daha önce kiralanmış");
                    }
                    if (rental.RentDate > rental.ReturnDate)
                    {
                        return new ErrorResult("Kiralama tarihi dönüş tarihinden büyük olamaz");
                    }
                }
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarAlreadyDelivered(int rentalId)
        {
            if (_rentalDal.Get(x => x.RentalId == rentalId && x.ReturnDate == null) == null)
                return new ErrorResult(Messages.CarAlreadyDelivered);
            return new SuccessResult();
        }

        private IResult CheckFindeksScore(Rental rental)
        {
            var car = _carService.GetById(rental.CarId).Data;
            var findeks = _findexScoreService.GetByCustomerId(rental.CustomerId).Data;

            if (findeks == null)
            {
                return new ErrorResult(Messages.FindeksScoreNotFound);
            }

            if (findeks.Score < car.FindexScore)
            {
                return new ErrorResult(Messages.FindeksScoreInsufficient);
            }
            return new SuccessResult();
        }

    }
}
