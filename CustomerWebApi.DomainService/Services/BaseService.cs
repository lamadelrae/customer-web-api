using CustomerWebApi.Domain.Models;
using CustomerWebApi.DomainService.Interfaces;
using CustomerWebApi.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerWebApi.DomainService.Services
{
    public class BaseService<T> : IBaseService<T> where T : Entity
    {
        protected readonly IBaseRepository<T> _baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public void Delete(T obj)
        {
            _baseRepository.Delete(obj);
        }

        public IEnumerable<T> Get()
        {
            return _baseRepository.Get();
        }

        public T Get(Guid id)
        {
            return _baseRepository.Get(id);
        }

        public T Insert(T obj)
        {
            _baseRepository.Insert(obj);
            return obj;
        }

        public T Update(T obj)
        {
            _baseRepository.Update(obj);
            return obj;
        }
    }
}
