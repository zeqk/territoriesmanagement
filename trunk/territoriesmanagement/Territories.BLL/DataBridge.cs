using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Territories.BLL
{
    class DataBridge<T> : IDataBridge<T>
    {

        #region IDataBridge<T> Members

        public T Insert(T v)
        {
            throw new NotImplementedException();
        }

        public T Update(T v)
        {
            throw new NotImplementedException();
        }

        public void Delete(T v)
        {
            throw new NotImplementedException();
        }

        public T Load(int id)
        {
            throw new NotImplementedException();
        }

        public List<KeyListItem> Search(string query, params System.Data.Objects.ObjectParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public T NewObject()
        {
            throw new NotImplementedException();
        }

        public List<KeyListItem> All()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
