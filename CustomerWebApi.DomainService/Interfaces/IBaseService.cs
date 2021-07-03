using CustomerWebApi.Domain.Models;
using System;
using System.Collections.Generic;

namespace CustomerWebApi.DomainService.Interfaces
{
    public interface IBaseService<T> where T : Entity
    {
        T Insert(T obj);

        T Update(T obj);

        void Delete(T obj);

        IEnumerable<T> Get();

        T Get(Guid id);
    }
}
