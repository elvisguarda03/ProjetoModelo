using System;
using System.Collections.Generic;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _produtoService;

        public AppServiceBase(IServiceBase<TEntity> produtoService)
        {
            _produtoService = produtoService;
        }

        public void Add(TEntity obj)
        {
            _produtoService.Add(obj);
        }

        public TEntity GetById(int id)
        {
            return _produtoService.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _produtoService.GetAll();
        }

        public void Update(TEntity obj)
        {
            _produtoService.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _produtoService.Remove(obj);
        }

        public void Dispose()
        {
            _produtoService.Dispose();
        }
    }
}
