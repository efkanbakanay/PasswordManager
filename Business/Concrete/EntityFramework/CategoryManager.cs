using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete.EntityFramework
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
           _categoryDal= categoryDal;
        }


        [ValidationAspect(typeof(CategoryValidator), Priority = 1)]
        public IResult Add(Category category)
        {
            try
            {
                IResult result = BusinessRules.Run(CheckIfProductNameExists(category.CategoryName));

                if(result == null)
                {
                    return result;
                }



                _categoryDal.Add(category);
                return new SuccessResult(Messages.CategoryAdded);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.CategoryAddedFail);
            }
        }

        public IDataResult<Category> AddAndReturn(Category category)
        {
            try
            {
              
                return new SuccessDataResult<Category>(_categoryDal.AddAndReturn(category));

            }
            catch (Exception)
            {

                return new ErrorDataResult<Category>(Messages.GlobalFail);
            }
        }

        [LogAspect(typeof(FileLogger))]
        public IResult Delete(Category category)
        {
            try
            {
                _categoryDal.Delete(category);
                return new SuccessResult(Messages.CategoryDeleted);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.CategoryDeletedFail);
            }
        }

        public IDataResult<List<Category>> GetAll(int userId)
        {
            try
            {
                return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(x=>x.IsActive == true && x.IsDeleted == false && x.UserId == userId).ToList());
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Category>>(Messages.GlobalFail);
            }
        }

        public IDataResult<Category> GetById(int Id)
        {
            try
            {
                return new SuccessDataResult<Category>(_categoryDal.Get(x => x.Id == Id));
            }
            catch (Exception)
            {

                return new ErrorDataResult<Category>(Messages.GlobalFail);
            }
        }

        [ValidationAspect(typeof(CategoryValidator), Priority = 1)]
        public IResult Update(Category category)
        {
            try
            {
                _categoryDal.Update(category);
                return new SuccessResult(Messages.CategoryUpdated);
            }
            catch (Exception)
            {

                return new ErrorResult(Messages.CategoryUpdatedFail);
            }
        }


        private IResult CheckIfProductNameExists(string categoryName)
        {

            var result = _categoryDal.GetAll(p => p.CategoryName == categoryName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CategoryNameAlreadyExists);
            }

            return new SuccessResult();
        }

    


    }
}
