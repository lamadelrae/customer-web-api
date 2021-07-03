using CustomerWebApi.Application.Dtos;
using System;
using System.Collections.Generic;

namespace CustomerWebApi.Application.Interfaces
{
    public interface IBaseApplicationService<T> where T : Dto
    {
        T Add(T obj);

        T Update(T obj);

        void Delete(Guid id);

        IEnumerable<T> Get();

        T Get(Guid id);
    }
}
