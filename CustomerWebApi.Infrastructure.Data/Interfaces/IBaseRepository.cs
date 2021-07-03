using CustomerWebApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerWebApi.Infrastructure.Data.Interfaces
{
    public interface IBaseRepository<T> where T : Entity
    {
        List<T> Get();

        T Get(Guid id);

        void Insert(T obj);

        void Update(T obj);

        void Delete(T obj);
    }
}
