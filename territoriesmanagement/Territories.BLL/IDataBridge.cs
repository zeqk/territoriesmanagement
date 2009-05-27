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
        void Delete(T v);
        T Load(int id);
        IList Search(string query, params ObjectParameter[] parameters);
        T NewObject();       
    }
}
