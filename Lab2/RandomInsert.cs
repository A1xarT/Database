using System;
using System.Collections.Generic;
using System.Text;

namespace DBManagement
{
    class RandomInsert
    {
        public string RandomCoachInsert()
        {
            Console.WriteLine("Number of randomized records: ");
            int number = int.Parse(Console.ReadLine());
            return $"insert into competitions.\"Тренер\" (\"Name\", \"Birthday\") " +
                "select substr(characters, (random() * length(characters) +1)::integer, 10)," +
                "timestamp '2014-01-10' + random() * (timestamp '2014-01-20' - timestamp '2014-01-10')" +
                $"from(values('ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz')) as symbols(characters), generate_series(1, {number})";
        }
    }
}
