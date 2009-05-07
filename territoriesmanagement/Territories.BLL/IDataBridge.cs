using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace Territories.BLL
{
    public interface IDataBridge<T>
    {
        T Insert(T v);
        T Update(T v);
        void Delete(T v);
        T Load(int id);
        List<KeyListItem> Search(string query, params ObjectParameter[] parameters);
        T NewObject();
        List<KeyListItem> All();
        void SaveChanges();
        
    }
}
