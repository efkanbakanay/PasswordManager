using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<Category> GetById(int Id);
        IDataResult<List<Category>> GetAll(int userId);
        IResult Add(Category category);
        IDataResult<Category> AddAndReturn(Category category);
        IResult Delete(Category category);
        IResult Update(Category category);

        
    }
}
