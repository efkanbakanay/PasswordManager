using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete.EntityFramework
{
    public class UserPasswordManager : IUserPasswordService
    {

        IUserPasswordDal _userPasswordDal;
        public UserPasswordManager(IUserPasswordDal userPasswordDal)
        {
            _userPasswordDal = userPasswordDal;
        }

        [ValidationAspect(typeof(UserPasswordValidator), Priority = 1)]
        public IResult Add(UserPassword userPassword)
        {
            try
            {
                _userPasswordDal.Add(userPassword);
                return new SuccessResult(Messages.PasswordAdded);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.PasswordAddedFail);
            }
        }

        [LogAspect(typeof(FileLogger))]
        public IResult Delete(UserPassword userPassword)
        {
            try
            {
                _userPasswordDal.Delete(userPassword);
                return new SuccessResult(Messages.PasswordDeleted);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.PasswordDeletedFail);
            }
        }

        public IDataResult<UserPassword> GetById(int Id)
        {
            try
            {
                return new SuccessDataResult<UserPassword>(_userPasswordDal.Get(x => x.Id == Id));
            }
            catch (Exception)
            {

                return new ErrorDataResult<UserPassword>(Messages.GlobalFail);
            }
        }

        public IDataResult<List<UserPassword>> GetAll(int userId)
        {
            try
            {
                return new SuccessDataResult<List<UserPassword>>(_userPasswordDal.GetAll(x=>x.IsActive == true && x.IsDeleted == false && x.UserId == userId).ToList());
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<UserPassword>>(Messages.GlobalFail);
            }
        }

        public IDataResult<List<UserPassword>> GetListByCategory(int categoryId)
        {
            try
            {
                return new SuccessDataResult<List<UserPassword>>(_userPasswordDal.GetAll(x=>x.CategoryId == categoryId).ToList());
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<UserPassword>>(Messages.GlobalFail);
            }
        }

        [ValidationAspect(typeof(UserPasswordValidator), Priority = 1)]
        public IResult Update(UserPassword userPassword)
        {
            try
            {
                _userPasswordDal.Update(userPassword);
                return new SuccessResult(Messages.PasswordUpdated);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.PasswordUpdatedFail);
            }
        }

        public IDataResult<List<UserPasswordCategoryDto>> GetAllIncCategory(int userId)
        {
            try
            {
                return new SuccessDataResult<List<UserPasswordCategoryDto>>(_userPasswordDal.GetAllIncCategory(userId).ToList());
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<UserPasswordCategoryDto>>(Messages.GlobalFail);
            }
        }

        public IDataResult<UserPasswordCategoryDto> GetByIdCategoy(int Id)
        {
            try
            {
                return new SuccessDataResult<UserPasswordCategoryDto>(_userPasswordDal.GetByIdCategoy(Id));
            }
            catch (Exception)
            {

                return new ErrorDataResult<UserPasswordCategoryDto>(Messages.GlobalFail);
            }
        }

        public IDataResult<List<UserPasswordCategoryDto>> GetPasswordList(string searchValue, int pageSize, int skip, string sortColumn, string sortColumnDirection, int userId)
        {
            try
            {
                return new SuccessDataResult<List<UserPasswordCategoryDto>>(_userPasswordDal.GetPasswordList(searchValue,pageSize,skip,sortColumn,sortColumnDirection, userId).ToList());
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<UserPasswordCategoryDto>>(Messages.GlobalFail);
            }
        }

        public IDataResult<int> GetPasswordCount(string searchValue, int pageSize, int skip, string sortColumn, string sortColumnDirection, int userId)
        {
            return new SuccessDataResult<int>(_userPasswordDal.GetPasswordCount(searchValue, pageSize, skip, sortColumn, sortColumnDirection, userId));
        }
    }
}
