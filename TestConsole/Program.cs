using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Territories.BLL;
using Territories.Model;
//using Territories.BLL;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = { "linea 1", "linea 2" };
            Console.WriteLine(array.ToString());
            IDictionary dic = new Hashtable();
            dic.Add("larala", 1);
            Console.ReadKey();

        }
    }
}
