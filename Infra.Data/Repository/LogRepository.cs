using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository
{
    public class LogRepository : BaseRepository<Log>, ILogRepository
    {
        private readonly IBaseRepository<Produto> _produtoRepository;

        public LogRepository(SqlServerContext sqlServerContext, IBaseRepository<Produto> produtoRepository) : base(sqlServerContext)
        {
            _produtoRepository = produtoRepository;
        }

        public override void Insert(Log obj)
        {
            obj.Produto = _produtoRepository.Select(obj.IdProduto);

            _SqlServCon.Set<Log>().Add(obj);
            _SqlServCon.SaveChanges();
        }
        public override void Update(Log obj)
        {
            obj.Produto = _produtoRepository.Select(obj.IdProduto);

            _SqlServCon.Entry(obj).State = EntityState.Modified;
            _SqlServCon.SaveChanges();
        }

        public override IList<Log> Select()
        {
            return _SqlServCon.Set<Log>().Include(log => log.Produto).ToList();
        }

        public override Log Select(int id)
        {
            return _SqlServCon.Set<Log>().Include(log => log.Produto).FirstOrDefault(log => log.Id == id);
        }
    }
}
