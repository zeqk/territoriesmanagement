using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Territories.DAL.Server;
using Territories.DAL;
//using Territories.BLL;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Departments db = new Departments();
            var dep1 = db.NewObject();
            dep1.Name = "prueba1";
            var dep2 = db.Insert(dep1);
            var deps = db.All();

            foreach (var dep in deps)
            {
                //Console.WriteLine(dep.IdDepartment);
            }

            Console.ReadKey();

        }
    }
}
