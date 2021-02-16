using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Colors colors)
        {
            if (colors.ColorId<0)
            {
                return new ErrorResult(ErrorMessages.CouldntColorAdded);
            }
            _colorDal.Add(colors);
            return new SuccessResult(SuccessMessages.ColorAdded);
        }

        public IResult Delete(Colors colors)
        {
            if (colors.ColorId < 0)
            {
                return new ErrorResult(ErrorMessages.CouldntColorDeleted);
            }
            _colorDal.Delete(colors);
            return new SuccessResult(SuccessMessages.ColorDeleted);
        }

        public IDataResult<List<Colors>> GetAll()
        {

            return new SuccessDataResult<List<Colors>>(_colorDal.GetAll(), SuccessMessages.ColorListed);
        }

        public IDataResult<Colors> GetById(int id)
        {
            return new SuccessDataResult<Colors>(_colorDal.GetById(c=>c.ColorId==id),SuccessMessages.ColorListed);
        }

        public IResult Update(Colors colors)
        {
            if (colors.ColorId < 0)
            {
                return new ErrorResult(ErrorMessages.CouldntColorUpdated);
            }
            _colorDal.Delete(colors);
            return new SuccessResult(SuccessMessages.ColorUpdated);
        }
    }       
}
