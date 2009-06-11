using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace Territories.BLL
{
    public interface IDataBridge<T>
    {
        T Save(T v);
        T Insert(T v);
        T Update(T v);
        void Delete(int id);
        T Load(int id);
        IList Search(string strCriteria, params ObjectParameter[] parameters);
        T NewObject();       
    }
}
