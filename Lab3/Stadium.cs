using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public class Stadium
    {
        public virtual int Id { get; set; }
        public virtual string Location { get; set; }
        public virtual int Seats { get; set; }
    }
    class StadiumManipulations
    {
        public static void Insert(string place, int seatsNumber)
        {
            using (var session = DBHelper.OpenSession())
            {
                var stadium = new Stadium { Location = place, Seats = seatsNumber };
                session.Save(stadium);
                session.Flush();
                session.Close();
            }
        }
        public static void Update(int id, string newPlace, int newSeatsNumber)
        {
            using (var session = DBHelper.OpenSession())
            {
                var persistent = session.Get<Stadium>(id);
                persistent.Location = newPlace;
                persistent.Seats = newSeatsNumber;
                session.Update(persistent);
                session.Flush();
                session.Close();
            }
        }
        public static void Delete(int id)
        {
            using (var session = DBHelper.OpenSession())
            {
                session.Delete(session.Get<Stadium>(id));
                session.Flush();
                session.Close();
            }
        }
    }
}
