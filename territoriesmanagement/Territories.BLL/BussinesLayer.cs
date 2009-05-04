using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Territories.BLL
{
    public class BussinesLayer<T>
    {
        static private EntityConnection _connection;

        static private string _connectionString;

        static public EntityConnection Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }

        static public string ConnectionString
        {
            get 
            {
                return _connection.ConnectionString; 
            }
            set 
            {
                _connection.ConnectionString = value; 
            }
        }


    #region Constructors   

        private DataBridge dataBridgeObject;

        public BussinesLayer() 
        {
            string entityName = typeof(T).Name;
            try
            {
                dataBridgeObject = (DataBridge) Activator.CreateInstance(Type.GetType(entityName), _connection);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }

        public IDataBridge<T> GetObject()
        {
            try
            {
                return dataBridgeObject;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    #endregion
 


    }
}
