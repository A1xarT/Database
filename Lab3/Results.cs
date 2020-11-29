using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Results
    {
        public virtual int Id { get; set; }
        public virtual string Exercise { get; set; }
        public virtual int Points { get; set; }
        public virtual TeamComp TeamCompKey { get; set; }
    }
    public class ResultsManipulations
    {
        public static void Insert(string _exercise, int _points, int teamCompID)
        {
            using (var session = DBHelper.OpenSession())
            {
                var results = new Results { Points = _points, Exercise = _exercise, TeamCompKey = session.Get<TeamComp>(teamCompID) };
                session.Save(results);
                session.Flush();
                session.Close();
            }
        }
        public static void Update(int id, string newExercise, int newPoints, int newTeamCompID)
        {
            using (var session = DBHelper.OpenSession())
            {
                var persistent = session.Get<Results>(id);
                persistent.Exercise = newExercise;
                persistent.Points = newPoints;
                persistent.TeamCompKey = session.Get<TeamComp>(newTeamCompID);
                session.Update(persistent);
                session.Flush();
                session.Close();
            }
        }
        public static void Delete(int id)
        {
            using (var session = DBHelper.OpenSession())
            {
                session.Delete(session.Get<Results>(id));
                session.Flush();
                session.Close();
            }
        }
    }
}
