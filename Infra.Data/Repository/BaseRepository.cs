using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly SqlServerContext _SqlServCon;

        public BaseRepository(SqlServerContext sqlServerContext)
        {
            _SqlServCon = sqlServerContext;
        }

        public void Insert(TEntity obj)
        {
            _SqlServCon.Set<TEntity>().Add(obj);
            _SqlServCon.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _SqlServCon.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _SqlServCon.SaveChanges();
        }

        public void Delete(int id)
        {
            _SqlServCon.Set<TEntity>().Remove(Select(id));
            _SqlServCon.SaveChanges();
        }

        public IList<TEntity> Select() =>
            _SqlServCon.Set<TEntity>().ToList();

        public TEntity Select(int id) =>
            _SqlServCon.Set<TEntity>().Find(id);

    }
}
