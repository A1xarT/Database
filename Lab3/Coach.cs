using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public class Coach
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime Birthday { get; set; }
    }
    public class CoachManipulations
    {
        public static void Insert(string name, string date)
        {
            using (var session = DBHelper.OpenSession())
            {
                var coach = new Coach { Name = name, Birthday = DateTime.Parse(date) };
                session.Save(coach);
                session.Flush();
                session.Close();
            }
        }
        public static void Update(int id, string newName, string newDate)
        {
            using (var session = DBHelper.OpenSession())
            {
                var persistent = session.Get<Coach>(id);
                persistent.Name = newName;
                persistent.Birthday = DateTime.Parse(newDate);
                session.Update(persistent);
                session.Flush();
                session.Close();
            }
        }
        public static void Delete(int id)
        {
            using (var session = DBHelper.OpenSession())
            {
                session.Delete(session.Get<Coach>(id));
                session.Flush();
                session.Close();
            }
        }
    }
}
