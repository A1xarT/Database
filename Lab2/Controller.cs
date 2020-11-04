using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace DBManagement
{
    class Controller
    {
        public NpgsqlCommand cmd;
        NpgsqlDataReader rdr;
        NpgsqlConnection con;
        Insert insert;
        Update update;
        Delete delete;
        RandomInsert randomInsert;
        SQL_Tool sqlTool;
        string password = "80601653";
        public Controller()
        {
            insert = new Insert();
            update = new Update();
            delete = new Delete();
            randomInsert = new RandomInsert();
            sqlTool = new SQL_Tool();
            connectDB();
        }
        private void connectDB()
        {
            var cs = $"Host=localhost;Username=postgres;Password={password};Database=DB_Lab1";
            con = new NpgsqlConnection(cs);
            con.Open();
            cmd = new NpgsqlCommand();
            cmd.Connection = con;
        }
        public int MainMenuChoice()
        {
            int userChoice;
            while (!int.TryParse(Console.ReadLine(), out userChoice) || (userChoice <= 0) || (userChoice >= 8))
                View.WrongNumber();
            return userChoice;
        }
        public int TableChoice()
        {
            View.PrintTables();
            int userChoice;
            while (!(int.TryParse(Console.ReadLine(), out userChoice)) || (userChoice < 0) || (userChoice >= 7))
                View.WrongNumber();
            return userChoice;
        }
        public int SqlChoice()
        {
            int choice = int.Parse(Console.ReadLine());
            while (choice > 3 || choice < 0)
            {
                View.WrongNumber();
                choice = int.Parse(Console.ReadLine());
            }
            return choice;
        }
        public List<string> ExecuteReading(int dbPart)
        {
            rdr = cmd.ExecuteReader();
            List<string> lst = new List<string> { };
            switch (dbPart)
            {
                case 1:
                    while (rdr.Read())
                    {
                        lst.Add($" Sponsor: {rdr.GetString(0)}, id: {rdr.GetInt32(1).ToString()}, TeamName: {rdr.GetString(2)}, " +
                            $"Тренер_key: {rdr.GetInt32(3).ToString()}");
                    }
                    break;
                case 2:
                    while (rdr.Read())
                    {
                        lst.Add($" id: {rdr.GetInt32(0).ToString()}, Name: {rdr.GetString(1).ToString()}, Birthday: {rdr.GetDate(2).ToString()}");
                    }
                    break;
                case 3:
                    while (rdr.Read())
                    {
                        lst.Add($" Seats number: {rdr.GetInt32(0).ToString()}, Location: {rdr.GetString(1).ToString()}, id: {rdr.GetInt32(2).ToString()}");
                    }
                    break;
                case 4:
                    while (rdr.Read())
                    {
                        lst.Add($" Arbiter: {rdr.GetString(0)}, Elapsed Time: {rdr.GetInt32(1).ToString()}, id: {rdr.GetInt32(2).ToString()}, " +
                            $"Date: {rdr.GetDate(3).ToString()}, Time: {rdr.GetTimeSpan(4).ToString()}, Стадіон_key: {rdr.GetInt32(5).ToString()}");
                    }
                    break;
                case 5:
                    while (rdr.Read())
                    {
                        lst.Add($" Points: {rdr.GetInt32(0).ToString()}, id: {rdr.GetInt32(1).ToString()}, ExerciseName: {rdr.GetString(2)}, " +
                            $"Команда_Змагання_key: {rdr.GetInt32(3).ToString()}");
                    }
                    break;
                case 6:
                    while (rdr.Read())
                    {
                        lst.Add($" id: {rdr.GetInt32(0).ToString()}, Команда_key: {rdr.GetInt32(1).ToString()}, Змагання_key: " +
                            $"{rdr.GetInt32(2).ToString()}, Place: {rdr.GetInt32(3).ToString()}, TotalPoints: {rdr.GetInt32(4).ToString()}");
                    }
                    break;
            }
            rdr.Close();
            return lst;
        }
        public void ExecuteInserting(int dbPart)
        {
            switch (dbPart)
            {
                case 1:
                    cmd.CommandText += insert.InsertTeam();
                    break;
                case 2:
                    cmd.CommandText += insert.InsertCoach();
                    break;
                case 3:
                    cmd.CommandText += insert.InsertStadium();
                    break;
                case 4:
                    cmd.CommandText += insert.InsertCompetition();
                    break;
                case 5:
                    cmd.CommandText += insert.InsertResults();
                    break;
                case 6:
                    cmd.CommandText += insert.InsertTeam_Competition();
                    break;
            }
            ExecuteQuery(cmd);
        }
        public void ExecuteUpdating(int dbPart)
        {
            switch (dbPart)
            {
                case 1:
                    cmd.CommandText += update.UpdateTeam();
                    break;
                case 2:
                    cmd.CommandText += update.UpdateCoach();
                    break;
                case 3:
                    cmd.CommandText += update.UpdateStadium();
                    break;
                case 4:
                    cmd.CommandText += update.UpdateCompetition();
                    break;
                case 5:
                    cmd.CommandText += update.UpdateResults();
                    break;
                case 6:
                    cmd.CommandText += update.UpdateTeam_Competition();
                    break;
            }
            ExecuteQuery(cmd);
        }
        public void ExecuteDeleting()
        {
            ExecuteQuery(cmd);
        }
        public List<string> ExecuteSQL(int choice, ref long ms)
        {
            switch(choice)
            {
                case 1:
                    cmd.CommandText = sqlTool.DoSQL1();
                    break;
                case 2:
                    cmd.CommandText = sqlTool.DoSQL2();
                    break;
                case 3:
                    cmd.CommandText = sqlTool.DoSQL3();
                    break;
            }
            System.Diagnostics.Stopwatch ExecutingTime = System.Diagnostics.Stopwatch.StartNew();
            rdr = cmd.ExecuteReader();
            ExecutingTime.Stop();
            ms = ExecutingTime.ElapsedMilliseconds;
            List<string> records = new List<string> { };
            List<string> parameters;
            switch (choice)
            {
                case 1:
                    while (rdr.Read())
                    {
                        parameters = new List<string> { rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetDate(3).ToString() };
                        records.Add($"Team = {parameters[0]}, Sponsor = {parameters[1]}, CoachName = {parameters[2]}, CoachBirthday = {parameters[3]}");
                    }
                    break;
                case 2:
                    while (rdr.Read())
                    {
                        parameters = new List<string> { rdr.GetInt32(0).ToString(), rdr.GetInt32(1).ToString(),
                                        rdr.GetDate(2).ToString(), rdr.GetTimeSpan(3).ToString() };
                        records.Add($"id = {parameters[0]}, Seats number = {parameters[1]}, Date = {parameters[2]}, " +
                            $"Time = {parameters[3]}");
                    }
                    break;
                case 3:
                    while (rdr.Read())
                    {
                        parameters = new List<string> { rdr.GetString(0), rdr.GetInt32(1).ToString(),
                                        rdr.GetInt32(2).ToString(), rdr.GetInt32(3).ToString(), rdr.GetString(4) };
                        records.Add($"Team = {parameters[0]}, Competition ID = {parameters[1]}, " +
                            $"Total Points = {parameters[2]}, Duration = {parameters[3]}, Arbiter = {parameters[4]}");
                    }
                    break;
            }
            if (rdr != null)
                rdr.Close();
            return records;
        }
        public void ExecuteRandomCoachInsert()
        {
            cmd.CommandText = randomInsert.RandomCoachInsert();
            ExecuteQuery(cmd);
        }
        public void ExecuteQuery(NpgsqlCommand _cmd)
        {
            try
            {
                _cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Помилка перехоплена");
            }
        }
    }
}
