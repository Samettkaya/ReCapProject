using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal brandDal)
        {
            _colorDal = brandDal;
        }
        public IResult Add(Color entity)
        {
            _colorDal.Add(entity);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDelete);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorListed);
        }

        public IDataResult<Color> GetById(int colorId)
        {
          
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == colorId), Messages.ColorListed);
        
        }
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new  SuccessResult(Messages.ColorUpdated);
        }

      
    }
}
