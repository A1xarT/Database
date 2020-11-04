using System;
using System.Collections.Generic;
using System.Text;

namespace DBManagement
{
    class Delete
    {
        public static string DeleteItem(string Table)
        {
            Console.Write("Record ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            return $"delete from competitions.{Table} where id = {id}";
        }
    }
}
