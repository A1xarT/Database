using System;
using System.Collections.Generic;
using System.Text;

namespace DBManagement
{
    class SQL_Tool
    {
        public string DoSQL1()
        {
            string NameLike, SponsorLike; Date BirthB, BirthT;
            Console.WriteLine("Пошук команд та їх тренерів за назвою команди, спонсором та датою народження тренера команди");
            Console.Write("TeamName like: ");
            NameLike = Console.ReadLine();
            Console.Write("Sponsor like: ");
            SponsorLike = Console.ReadLine();
            Console.WriteLine("Проміжок дати народження");
            Console.WriteLine("Нижня границя");
            Console.Write("Day: ");
            BirthB.day = int.Parse(Console.ReadLine());
            Console.Write("Month: ");
            BirthB.month = int.Parse(Console.ReadLine());
            Console.Write("Year: ");
            BirthB.year = int.Parse(Console.ReadLine());

            Console.WriteLine("Верхня границя");
            Console.Write("Day: ");
            BirthT.day = int.Parse(Console.ReadLine());
            Console.Write("Month: ");
            BirthT.month = int.Parse(Console.ReadLine());
            Console.Write("Year: ");
            BirthT.year = int.Parse(Console.ReadLine());
            return $"select \"TeamName\", \"Sponsor\", \"Name\" as \"CoachName\", \"Birthday\" as \"CoachBirthday\" from " +
                $"competitions.\"Команда\" inner join competitions.\"Тренер\" as tr " +
                $"on tr.id = \"Тренер_key\" where \"TeamName\" like '{NameLike}' and \"Sponsor\" like '{SponsorLike}' and " +
                $"tr.\"Birthday\" >= '{BirthB.StrDate()}' and tr.\"Birthday\" <= '{BirthT.StrDate()}'; ";
        }
        public string DoSQL2()
        {
            Console.WriteLine("Пошук стадіонів та змагань за кількістю місць, на яких заплановані змагання у заданий проміжок дати та часу");
            Date dateB, dateT; int numberMin, numberMax; string timeMin, timeMax;
            Console.Write("Мінімальна кількість місць: ");
            numberMin = int.Parse(Console.ReadLine());
            Console.Write("Максимальна кількість місць: ");
            numberMax = int.Parse(Console.ReadLine());
            Console.WriteLine("Проміжок дати");

            Console.WriteLine("Нижня границя");
            Console.Write("Day: ");
            dateB.day = int.Parse(Console.ReadLine());
            Console.Write("Month: ");
            dateB.month = int.Parse(Console.ReadLine());
            Console.Write("Year: ");
            dateB.year = int.Parse(Console.ReadLine());

            Console.WriteLine("Верхня границя");
            Console.Write("Day: ");
            dateT.day = int.Parse(Console.ReadLine());
            Console.Write("Month: ");
            dateT.month = int.Parse(Console.ReadLine());
            Console.Write("Year: ");
            dateT.year = int.Parse(Console.ReadLine());
            Console.Write("Мінімальний час початку: ");
            timeMin = Console.ReadLine();
            Console.Write("Максимальний час початку: ");
            timeMax = Console.ReadLine();
            return "select \"Стадіон\".id, \"Seats number\", \"Date\", \"Time\" from competitions.\"Стадіон\"" +
                $"inner join competitions.\"Змагання\" as Zm on Zm.\"Стадіон_key\" = \"Стадіон\".id where \"Date\" <= '{dateT.StrDate()}' " +
                $"and \"Date\" >= '{dateB.StrDate()}' and \"Time\" <= '{timeMax}' and \"Time\" >= '{timeMin}' and " +
                $"\"Seats number\" <= {numberMax} and \"Seats number\" >= {numberMin}";
        }
        public string DoSQL3()
        {
            Console.WriteLine("Пошук команд і змагань за загальною кількістю очок, тривалістю змагань і арбітром");
            int minPoints, maxPoints, minDur, maxDur; string Arb;
            Console.Write("Мінімальна кількість очок: ");
            minPoints = int.Parse(Console.ReadLine());
            Console.Write("Максимальна кількість очок: ");
            maxPoints = int.Parse(Console.ReadLine());
            Console.Write("Мінімальна тривалість змагання: ");
            minDur = int.Parse(Console.ReadLine());
            Console.Write("Максимальна тривалість змагання: ");
            maxDur = int.Parse(Console.ReadLine());
            Console.Write("Arbiter like: ");
            Arb = Console.ReadLine();
            return $"select \"Команда\".\"TeamName\", Kz.\"Змагання_key\" as \"Змагання\", \"TotalPoints\", \"Elapsed Time\" " +
                $"as \"Duration\", \"Arbiter\" from competitions.\"Команда\" inner join competitions.\"Команда_Змагання\" " +
                $"as Kz on Kz.\"Команда_key\" = \"Команда\".id inner join competitions.\"Змагання\" as Zm on " +
                $"Zm.id = Kz.\"Змагання_key\" where \"Arbiter\" like '{Arb}' and \"Elapsed Time\" >= {minDur} and " +
                $"\"Elapsed Time\" <= {maxDur }and \"TotalPoints\" >= {minPoints} and \"TotalPoints\" <= {maxPoints}";
        }
    }
}
