using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;

namespace Core.DataAccess
{
    //Generic Constraint
    //class : referans tip
    //IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir
    //new() : new'lenebilir olmalı
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        T GetById(long id);
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetAll(Expression<Func<T, bool>> filter=null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void IsDelete(T entity);
    }
}
