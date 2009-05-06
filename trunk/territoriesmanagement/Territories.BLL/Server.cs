using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Territories.Model;
//TODO: cuando salga c# 4.0 se va a poder usar, porq no pemirte acceder a las propiedades del objeto de tipo var
//hay q usar el tipo dynamic
namespace Territories.BLL
{
    public static class Server
    {
        static public TerritoriesDataContext db = new TerritoriesDataContext();
        

        static private string serverClass;

        public static Object ExecuteQuery(string type, string method, params object[] parameters)
        {
            
            serverClass = "Territories.BLL.Servers." + type;
            try
            {                
                object server = Activator.CreateInstance(Type.GetType(serverClass),db);
                

                return Type.GetType(serverClass).InvokeMember(method, BindingFlags.InvokeMethod, null, server, parameters);
                

            }
            catch (Exception e) 
            {
                
                throw e;
            }
        }

        public static void ExecuteCommand(string type, string method, params object[] parameters)
        {
            
            serverClass = "Territories.BLL.EntityFramework." + type + "Server";
            try
            {
                object server = Activator.CreateInstance(Type.GetType(serverClass), db);
                //Constructor
                //Type.GetType(type).InvokeMember("DepartmentServer", BindingFlags.InvokeMethod,null, null, new TerritoriesDataContext[] { db });

                Type.GetType(serverClass).InvokeMember(method, BindingFlags.InvokeMethod, null, server, parameters);
                

            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}
