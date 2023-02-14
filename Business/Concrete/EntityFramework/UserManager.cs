using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using Core.Utilities.Security.SpecialsChar;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete.EntityFramework
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator), Priority = 1)]
        public IResult Add(User user)
        {
            try
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.UserAdded);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.UserAddedFail);
            }
        }

        [LogAspect(typeof(FileLogger))]
        public IResult Delete(User user)
        {
            try
            {
                _userDal.Delete(user);
                return new SuccessResult(Messages.UserDeleted);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.UserDeletedFail);
            }
        }

        public IDataResult<List<User>> GetAll()
        {

            try
            {
                return new SuccessDataResult<List<User>>(_userDal.GetAll().ToList());
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<User>>(Messages.GlobalFail);
            }
        }

        public IDataResult<User> GetById(int Id)
        {
            try
            {
                return new SuccessDataResult<User>(_userDal.Get(x => x.Id == Id));
            }
            catch (Exception)
            {

                return new ErrorDataResult<User>(Messages.GlobalFail);
            }
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        [ValidationAspect(typeof(UserValidator), Priority = 1)]
        public IResult Update(User user)
        {
            try
            {
                _userDal.Update(user);
                return new SuccessResult(Messages.UserUpdated);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.UserUpdatedFail);
            }
        }
    }
}
