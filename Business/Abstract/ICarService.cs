﻿using Core.Business;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService: ICrudService<Cars>
    {
        IDataResult<List<CarDetailsDto>> GetByCarDetails(int carId);
        IDataResult<List<ModelYearBrandNameDto>> GetModelYearBrandNameDtos();
        IDataResult<List<Cars>> GetByBrandId(int brandId);
        IDataResult<List<Cars>> GetByColorId(int colorId);
    }
}
