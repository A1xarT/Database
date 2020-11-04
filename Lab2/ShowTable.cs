using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DBManagement
{
    class ShowTable
    {
        public static string ContentOut(string Table)
        {
            return $"select * from competitions.{Table}";
        }
    }
}
