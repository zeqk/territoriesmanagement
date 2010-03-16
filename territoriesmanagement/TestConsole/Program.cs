using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data.Entity;
using TerritoriesManagement.Model;
//using Territories.BLL;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TerritoriesManagement.Model.TerritoriesDataContext dm = new TerritoriesDataContext();

            List<Territory> list1 = dm.Territories.ToList();
            TerritoriesManagement.Functions.Serialize(list1, @"E:\documentos\zeqk\Visual Studio 2008\Projects\territoriesmanagement\TestConsole\bin\x86\Debug\list.xml", true);
            List<Territory> list = (List<Territory>)TerritoriesManagement.Functions.Deserialize(typeof(List<Territory>), @"E:\documentos\zeqk\Visual Studio 2008\Projects\territoriesmanagement\TestConsole\bin\x86\Debug\list.xml");
            Console.ReadKey();

        }
    }
}
