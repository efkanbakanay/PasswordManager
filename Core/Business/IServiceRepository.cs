using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.Business
{
    public interface IServiceRepository<T>
    {
        IDataResult<T> Get(Expression<Func<T, bool>> filter);
        IDataResult<T> GetById(int id);
        IDataResult<T> GetByIdLong(long id);
        IDataResult<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
        IResult Add(T entity);     
        IResult Update(T entity);
        IResult Delete(T entity);
        IResult IsDelete(T entity);
    }
}
