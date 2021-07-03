using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerWebApi.Application.Interfaces
{
    /// <summary>
    ///  Adapter interface
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    /// <typeparam name="K">Dto</typeparam>
    public interface IBaseAdapter<T, K>
    {
        public T DtoToEntity(K dto);

        public K EntityToDto(T entity);

        public IEnumerable<T> DtoListToEntityList(List<K> dtoList);

        public IEnumerable<K> EntityListToDtoList(List<T> entityList);
    }
}
