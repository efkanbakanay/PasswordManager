using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserPasswordDal:IEntityRepository<UserPassword>
    {
        List<UserPasswordCategoryDto> GetAllIncCategory(int userId);
        UserPasswordCategoryDto GetByIdCategoy(int Id);

        List<UserPasswordCategoryDto> GetPasswordList(string searchValue, int pageSize, int skip, string sortColumn, string sortColumnDirection, int userId);
        int GetPasswordCount(string searchValue, int pageSize, int skip, string sortColumn, string sortColumnDirection, int userId);
    }
}
