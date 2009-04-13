using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Territories.DAL;

namespace Territories.BLL.Servers
{
    public interface IGenerics<T>
    {
        T Insert(T v);
        T Update(T v);
        void Delete(T v);
        T Load(int id);
        List<T> Search(string query, object[] parameters);
        T NewObject();
        List<T> All();
        
    }
}
