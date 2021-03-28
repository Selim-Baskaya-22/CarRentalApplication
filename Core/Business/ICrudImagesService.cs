using Core.Entites;
using Core.Entites.Abstract;
using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Business
{
    public interface ICrudImagesService<TEntity> where TEntity:class , IEntity, new()
    {
        IDataResult<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null);
        IDataResult<TEntity> GetById(int id);
        IResult Add(IFormFile formFile, TEntity entity);
        IResult Update(IFormFile formFile, TEntity entity);
        IResult Delete(TEntity entity);
    }
}
