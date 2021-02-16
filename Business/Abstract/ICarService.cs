using Core.Business;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService: ICrudService<Cars>
    {
        IDataResult<List<CarDetailsDto>> GetCarDetails();
        IDataResult<List<ModelYearBrandNameDto>> GetModelYearBrandNameDtos();
    }
}
