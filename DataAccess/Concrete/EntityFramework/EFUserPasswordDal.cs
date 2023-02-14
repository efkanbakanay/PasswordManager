using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFUserPasswordDal : EfEntityRepositoryBase<UserPassword, ManagerContext>, IUserPasswordDal
    {
        public List<UserPasswordCategoryDto> GetAllIncCategory(int userId)
        {
            using (ManagerContext context = new ManagerContext())
            {
                var result = (from u in context.UserPasswords
                              join c in context.Categories
                              on u.CategoryId equals c.Id
                              where u.UserId == userId
                              select new UserPasswordCategoryDto
                              {
                                  Id = u.Id,
                                  UserId = u.UserId,
                                  CategoryId= u.CategoryId,
                                  CategoryName = c.CategoryName,
                                  RecordDefinition = u.RecordDefinition,
                                  URL = u.URL,
                                  UserName = u.UserName,
                                  Password = u.Password,
                                  CreatedAt = Convert.ToDateTime(u.CreatedAt).ToString("dd/MM/yyyy"),
                                  

                              }).ToList();

                return result;
            }
        }

        public UserPasswordCategoryDto GetByIdCategoy(int Id)
        {
            using (ManagerContext context = new ManagerContext())
            {
                var result = (from u in context.UserPasswords
                              join c in context.Categories
                              on u.CategoryId equals c.Id
                              where u.Id == Id
                              select new UserPasswordCategoryDto
                              {
                                  Id = u.Id,
                                  UserId = u.UserId,
                                  CategoryId = u.CategoryId,
                                  CategoryName = c.CategoryName,
                                  RecordDefinition = u.RecordDefinition,
                                  URL = u.URL,
                                  UserName = u.UserName,
                                  Password = u.Password,
                                  CreatedAt = Convert.ToDateTime(u.CreatedAt).ToString("dd/MM/yyyy"),


                              }).FirstOrDefault();

                return result;
            }
        }

        public int GetPasswordCount(string searchValue, int pageSize, int skip, string sortColumn, string sortColumnDirection, int userId)
        {
            using (ManagerContext context = new ManagerContext())
            {
                var result = (from u in context.UserPasswords
                              join c in context.Categories
                              on u.CategoryId equals c.Id
                              where u.UserId == userId
                              select new UserPasswordCategoryDto
                              {
                                  Id = u.Id,
                                  UserId = u.UserId,
                                  CategoryId = u.CategoryId,
                                  CategoryName = c.CategoryName,
                                  RecordDefinition = u.RecordDefinition,
                                  URL = u.URL,
                                  UserName = u.UserName,
                                  Password = u.Password,
                                  CreatedAt = Convert.ToDateTime(u.CreatedAt).ToString("dd/MM/yyyy"),


                              });

                if (!string.IsNullOrEmpty(searchValue))
                {
                    result = result.Where(m => m.RecordDefinition.Contains(searchValue)
                                                || m.CategoryName.Contains(searchValue)
                                                || m.UserName.Contains(searchValue));
                }




                return result.Count();
            }
        }

        public List<UserPasswordCategoryDto> GetPasswordList(string searchValue, int pageSize, int skip, string sortColumn, string sortColumnDirection, int userId)
        {
            using (ManagerContext context = new ManagerContext())
            {
                var result = (from u in context.UserPasswords
                              join c in context.Categories
                              on u.CategoryId equals c.Id
                              where u.UserId == userId
                              select new UserPasswordCategoryDto
                              {
                                  Id = u.Id,
                                  UserId = u.UserId,
                                  CategoryId = u.CategoryId,
                                  CategoryName = c.CategoryName,
                                  RecordDefinition = u.RecordDefinition,
                                  URL = u.URL,
                                  UserName = u.UserName,
                                  Password = u.Password,
                                  CreatedAt = Convert.ToDateTime(u.CreatedAt).ToString("dd/MM/yyyy"),


                              });

                if (!string.IsNullOrEmpty(searchValue))
                {
                    result = result.Where(m => m.RecordDefinition.Contains(searchValue)
                                                || m.CategoryName.Contains(searchValue)
                                                || m.UserName.Contains(searchValue));
                }




                return result.Skip(skip).Take(pageSize).ToList();
            }
        }
    }
}
