using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public class Competition
    {
        public virtual int Id { get; set; }
        public virtual string Arbiter { get; set; }
        public virtual int ElapsedTime { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual DateTime Time { get; set; }
        public virtual Stadium StadiumKey { get; set; }
    }
    public class CompetitionManipulations
    {
        public static void Insert(string _arbiter, int elapsed, string _date, string _time, int stadiumID)
        {
            using (var session = DBHelper.OpenSession())
            {
                var competition = new Competition
                {
                    Arbiter = _arbiter, Date = DateTime.Parse(_date), Time = DateTime.Parse(_time), ElapsedTime = elapsed, 
                    StadiumKey = session.Get<Stadium>(stadiumID)};
                session.Save(competition);
                session.Flush();
                session.Close();
            }
        }
        public static void Update(int id, string newArbiter, int newElapsed, string newDate, string newTime, int newStadiumID)
        {
            using (var session = DBHelper.OpenSession())
            {
                var persistent = session.Get<Competition>(id);
                persistent.Date = DateTime.Parse(newDate);
                persistent.Time = DateTime.Parse(newTime);
                persistent.ElapsedTime = newElapsed;
                persistent.Arbiter = newArbiter;
                persistent.StadiumKey = session.Get<Stadium>(newStadiumID);
                session.Update(persistent);
                session.Flush();
                session.Close();
            }
        }
        public static void Delete(int id)
        {
            using (var session = DBHelper.OpenSession())
            {
                session.Delete(session.Get<Competition>(id));
                session.Flush();
                session.Close();
            }
        }
    }
}
