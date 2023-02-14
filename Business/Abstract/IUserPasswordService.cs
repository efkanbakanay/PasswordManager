using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserPasswordService
    {
        IDataResult<UserPassword> GetById(int Id);
        IDataResult<UserPasswordCategoryDto> GetByIdCategoy(int Id);
        IDataResult<List<UserPassword>> GetAll(int userId);
        IDataResult<List<UserPasswordCategoryDto>> GetAllIncCategory(int userId);
        IDataResult<List<UserPassword>> GetListByCategory(int categoryId);
        IDataResult<List<UserPasswordCategoryDto>> GetPasswordList(string searchValue, int pageSize, int skip, string sortColumn, string sortColumnDirection, int userId);
        IDataResult<int> GetPasswordCount(string searchValue, int pageSize, int skip, string sortColumn, string sortColumnDirection, int userId);
        IResult Add(UserPassword userPassword);
        IResult Delete(UserPassword userPassword);
        IResult Update(UserPassword userPassword);
    }
}
