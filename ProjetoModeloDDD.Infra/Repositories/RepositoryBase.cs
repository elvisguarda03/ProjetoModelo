using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using ProjetoModeloDDD.Domain.Interfaces;
using ProjetoModeloDDD.Infra.Context;

namespace ProjetoModeloDDD.Infra.Repositories
{
    //Implementando TEntity
    //IDisposable - Serve para destruir esse objeto

    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected ProjetoModeloContext DbContext = new ProjetoModeloContext();

        public void Add(TEntity obj)
        {
            DbContext.Set<TEntity>().Add(obj);
            DbContext.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            DbContext.Entry(obj).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            DbContext.Set<TEntity>().Remove(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
