using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Collections.Generic;

namespace TerritoriesManagement.DataBridge
{
    public interface IDataBridge<T>
    {
        T Save(T v);
        T Insert(T v);
        T Update(T v);
        void Delete(int id);
        T Load(int id);
        IList Search2(string strCriteria, params ObjectParameter[] parameters);
        T NewObject();
        void DeleteAll();
    }
}
