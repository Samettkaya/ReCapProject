using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
 
    public interface IFindexScoreService
    {
        IResult Add(FindexScore findexScore);
        IResult Update(FindexScore findexScore);
        IResult Delete(FindexScore findexScore);
        IDataResult<List<FindexScore>> GetAll();
        IDataResult<FindexScore> GetById(int findexScoreId);
        IDataResult<FindexScore> GetByCustomerId(int customerId);
    }
}
