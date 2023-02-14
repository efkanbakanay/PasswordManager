using Core.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Core.DataAccess.Dapper
{
    public class DapperRepositoryBase<T> : IDapperRepository<T>
       where T : class, IEntity, new()
    {


        private readonly DapperContext _context;

        public DapperRepositoryBase(DapperContext context)
        {
            _context = context;
        }


        public void Add(string proc, T entity)
        {
            using (IDbConnection dbConnection = _context.EgitimConnection)
            {
                dbConnection.Execute(proc, entity, commandType: CommandType.StoredProcedure);
            };
        }

        public void Delete(string proc, int id)
        {
            using (IDbConnection dbConnection = _context.EgitimConnection)
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@FormID", id);

                dbConnection.Execute(proc, param, commandType: CommandType.StoredProcedure);
            };
        }


        public List<T> GetList(string proc)
        {
            using (IDbConnection dbConnection = _context.EgitimConnection)
            {
                var list = dbConnection.Query<T>(proc, commandType: CommandType.StoredProcedure);
                return list.ToList();
            }
        }

        public void Update(string proc, T entity)
        {
            using (IDbConnection dbConnection = _context.EgitimConnection)
            {
                dbConnection.Execute(proc, entity, commandType: CommandType.StoredProcedure);
            };
        }
    }
}
