using System;
using System.Collections.Generic;
using System.Text;

namespace DBManagement
{
    class Insert
    {
        public static string InsertItem(string Table)
        {
            return $"insert into competitions.{Table}";
        }
        public string InsertTeam()
        {
            string TeamName, Sponsor; int Coach;
            Console.Write("TeamName: ");
            TeamName = Console.ReadLine();
            Console.Write("Sponsor: ");
            Sponsor = Console.ReadLine();
            Console.Write("Coach ID: ");
            Coach = int.Parse(Console.ReadLine());
            return $"(\"Sponsor\", \"TeamName\", \"Тренер_key\") VALUES('{Sponsor}', '{TeamName}', {Coach});";
        }
        public string InsertCoach()
        {
            string Name, Birthday; int day, month, year;
            Console.Write("Name: ");
            Name = Console.ReadLine();
            Console.WriteLine("Birthday: ");
            Console.Write("Day: ");
            day = int.Parse(Console.ReadLine());
            Console.Write("Month: ");
            month = int.Parse(Console.ReadLine());
            Console.Write("Year: ");
            year = int.Parse(Console.ReadLine());
            Birthday = year.ToString() + '-' + month.ToString() + '-' + day.ToString();
            return $"(\"Name\", \"Birthday\") VALUES('{Name}', '{Birthday}');";
        }
        public string InsertStadium()
        {
            string Location; int SeatsNumber;
            Console.Write("Location: ");
            Location = Console.ReadLine();
            Console.Write("Seats number: ");
            SeatsNumber = int.Parse(Console.ReadLine());
            return $"(\"Seats number\", \"Location\") VALUES({SeatsNumber}, '{Location}');";
        }
        public string InsertCompetition()
        {
            string Arbiter, Date, Time; int Duration, StadiumFkey;
            Console.Write("Arbiter: ");
            Arbiter = Console.ReadLine();
            Console.Write("Duration: ");
            Duration = int.Parse(Console.ReadLine());
            Console.Write("Stadium key: ");
            StadiumFkey = int.Parse(Console.ReadLine());
            Console.Write("Date: ");
            Date = Console.ReadLine();
            Console.Write("Time: ");
            Time = Console.ReadLine();
            return $"(\"Arbiter\", \"Elapsed Time\", \"Date\", \"Time\", \"Стадіон_key\") VALUES('{Arbiter}', " +
                $"{Duration},'{Date}','{Time}', {StadiumFkey});";
        }
        public string InsertResults()
        {
            string ExName; int Points, Team_Comp_key;
            Console.Write("Exercise name: ");
            ExName = Console.ReadLine();
            Console.Write("Team_Competition key: ");
            Team_Comp_key = int.Parse(Console.ReadLine());
            Console.Write("Points: ");
            Points = int.Parse(Console.ReadLine());
            return $"(\"Points\", \"ExerciseName\", \"Команда_Змагання_key\") VALUES({Points},'{ExName}',{Team_Comp_key});";
        }
        public string InsertTeam_Competition()
        {
            int TeamKey, CompKey, Place, TotalPoints;
            Console.Write("Team key: ");
            TeamKey = int.Parse(Console.ReadLine());
            Console.Write("Competition key: ");
            CompKey = int.Parse(Console.ReadLine());
            Console.Write("Place: ");
            Place = int.Parse(Console.ReadLine());
            Console.Write("Total Points: ");
            TotalPoints = int.Parse(Console.ReadLine());
            return $"(\"Команда_key\", \"Змагання_key\", \"Place\", \"TotalPoints\") VALUES({TeamKey}, {CompKey}, {Place}, {TotalPoints});";
        }
    }
}
