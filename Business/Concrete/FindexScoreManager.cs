using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Cashing;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FindexScoreManager : IFindexScoreService
    {
        IFindexScoreDal _findexScoreDal;

        public FindexScoreManager(IFindexScoreDal findexScoreDal)
        {
            _findexScoreDal = findexScoreDal;
        }

        [ValidationAspect(typeof(FindexScoreValidator))]
        [CacheRemoveAspect("IFindexScoreService.Get")]
        public IResult Add(FindexScore findexScore)
        {
            var result = CreateFindexScore(findexScore).Data;
            _findexScoreDal.Add(result);
            return new SuccessResult(Messages.FindexScoreAdded);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IFindexScoreService.Get")]
        public IResult Delete(FindexScore findeksScore)
        {
            _findexScoreDal.Delete(findeksScore);
            return new SuccessResult(Messages.FindexScoreDeleted);
        }

        [CacheAspect]
        public IDataResult<List<FindexScore>> GetAll()
        {
            if (DateTime.Now.Hour == 6)
            {
                return new ErrorDataResult<List<FindexScore>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<FindexScore>>(_findexScoreDal.GetAll(), Messages.FindexScoreListed);
        }

        [CacheAspect]
        public IDataResult<FindexScore> GetByCustomerId(int customerId)
        {
            var findeks = _findexScoreDal.Get(f => f.CustomerId == customerId);
            if (findeks == null)
            {
                return new ErrorDataResult<FindexScore>(Messages.FindexScoreNotFound);
            }
            return new SuccessDataResult<FindexScore>(findeks);
        }

        [CacheAspect]
        public IDataResult<FindexScore> GetById(int findexScoreId)
        {
         
            return new SuccessDataResult<FindexScore>(_findexScoreDal.Get(b => b.FindexScoreId == findexScoreId));
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CreditCardValidator))]
        [CacheRemoveAspect("IFindexScoreService.Get")]
        public IResult Update(FindexScore findeksScore)
        {
            var result = CreateFindexScore(findeksScore).Data;
            _findexScoreDal.Update(result);
            return new SuccessResult(Messages.FindexScoreUpdated);
        }

        private IDataResult<FindexScore> CreateFindexScore(FindexScore findex)
        {
            findex.Score = new Random().Next(0, 1900);

            return new SuccessDataResult<FindexScore>(findex);
        }
    }
}
