using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess
{
    public interface IDapperRepository<T> where T : class, IEntity, new()
    {
        void Add(string proc, T entity);
        void Update(string proc, T entity);
        void Delete(string proc, int id);
        List<T> GetList(string proc);
    }
}
