using System;
using System.Collections.Generic;
using System.Text;

namespace DBManagement
{
    class Update
    {
        int id;
        public static string UpdateItem(string Table)
        {
            return $"UPDATE competitions.{Table}";
        }
        public string UpdateTeam()
        {
            string TeamName, Sponsor; int Coach;
            Console.Write("Record ID to change: ");
            id = int.Parse(Console.ReadLine());
            Console.Write("TeamName: ");
            TeamName = Console.ReadLine();
            Console.Write("Sponsor: ");
            Sponsor = Console.ReadLine();
            Console.Write("Coach ID: ");
            Coach = int.Parse(Console.ReadLine());
            return $" SET \"Sponsor\"='{Sponsor}', \"TeamName\"='{TeamName}', \"Тренер_key\"={Coach} where id = {id};";
        }
        public string UpdateCoach()
        {
            string Name, Birthday; int day, month, year;
            Console.Write("Record ID to change: ");
            id = int.Parse(Console.ReadLine());
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
            return $" SET \"Name\"='{Name}', \"Birthday\"='{Birthday}' where id = {id};";
        }
        public string UpdateStadium()
        {
            string Location; int SeatsNumber;
            Console.Write("Record ID to change: ");
            id = int.Parse(Console.ReadLine());
            Console.Write("Location: ");
            Location = Console.ReadLine();
            Console.Write("Seats number: ");
            SeatsNumber = int.Parse(Console.ReadLine());
            return $" SET \"Location\"='{Location}', \"Seats number\"={SeatsNumber} where id = {id};";
        }
        public string UpdateCompetition()
        {
            string Arbiter, Date, Time; int Duration, StadiumFkey;
            Console.Write("Record ID to change: ");
            id = int.Parse(Console.ReadLine());
            Console.Write("Arbiter: ");
            Arbiter = Console.ReadLine();
            Console.Write("Duration: ");
            Duration = int.Parse(Console.ReadLine());
            Console.Write("Stadium key: ");
            StadiumFkey = int.Parse(Console.ReadLine());
            Console.Write("Date: ");
            Date = Console.ReadLine();
            Console.Write("TIme: ");
            Time = Console.ReadLine();
            return $" SET \"Arbiter\"='{Arbiter}', \"Date\"='{Date}', \"Time\"='{Time}', " +
                $"\"Elapsed Time\"={Duration}, \"Стадіон_key\"={StadiumFkey} where id = {id};";
        }
        public string UpdateResults()
        {
            string ExName; int Points, Team_Comp_key;
            Console.Write("Record ID to change: ");
            id = int.Parse(Console.ReadLine());
            Console.Write("Exercise name: ");
            ExName = Console.ReadLine();
            Console.Write("Team_Competition key: ");
            Team_Comp_key = int.Parse(Console.ReadLine());
            Console.Write("Points: ");
            Points = int.Parse(Console.ReadLine());
            return $" SET \"ExerciseName\"='{ExName}', \"Points\"={Points}, " +
                $"\"Команда_Змагання_key\"={Team_Comp_key} where id = {id};";
        }
        public string UpdateTeam_Competition()
        {
            int TeamKey, CompKey, Place, TotalPoints;
            Console.Write("Record ID to change: ");
            id = int.Parse(Console.ReadLine());
            Console.Write("Team key: ");
            TeamKey = int.Parse(Console.ReadLine());
            Console.Write("Competition key: ");
            CompKey = int.Parse(Console.ReadLine());
            Console.Write("Place: ");
            Place = int.Parse(Console.ReadLine());
            Console.Write("Total Points: ");
            TotalPoints = int.Parse(Console.ReadLine());
            return $" SET \"TotalPoints\"={TotalPoints}, \"Place\"={Place}, " +
                $"\"Команда_key\"={TeamKey}, \"Змагання_key\"={CompKey} where id = {id};";
        }
    }
}
