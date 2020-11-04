using System;
using System.Collections.Generic;
using System.Text;

namespace DBManagement
{
    class Model
    {
        public Dictionary<int, string> Tables = new Dictionary<int, string> { };
        public Model()
        {
            Tables.Add(1, "Команда");
            Tables.Add(2, "Тренер");
            Tables.Add(3, "Стадіон");
            Tables.Add(4, "Змагання");
            Tables.Add(5, "Результати_вправ");
            Tables.Add(6, "Команда_Змагання");
            Tables.Add(0, "Back");
        }
    }
    struct Date
    {
        public int day, month, year;
        public Date(int _day, int _month, int _year)
        {
            day = _day; month = _month; year = _year;
        }
        public string StrDate()
        {
            return $"{year}-{month}-{day}";
        }
    }
}
