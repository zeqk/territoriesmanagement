using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace Territories.DAL.Server
{
    public interface IGenerics<T>
    {
        T Insert(T v);
        T Update(T v);
        void Delete(T v);
        T Load(int id);
        ObjectResult<T> Search(string query, params ObjectParameter[] parameters);
        T NewObject();
        ObjectResult<T> All();
        
    }
}
