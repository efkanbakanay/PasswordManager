using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetById(int Id);
        IDataResult<List<User>> GetAll();
        User GetByMail(string email);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);

    }
}
