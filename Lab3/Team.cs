using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public class Team
    {
        public virtual int Id { get; set; }
        public virtual string TeamName { get; set; }
        public virtual string Sponsor { get; set; }
        public virtual Coach CoachKey { get; set; }
    }
    public class TeamManipulations
    {
        public static void Insert(string teamName, string sponsor, int coachID)
        {
            using (var session = DBHelper.OpenSession())
            {
                var team = new Team { TeamName = teamName, Sponsor = sponsor, CoachKey = session.Get<Coach>(coachID) };
                session.Save(team);
                session.Flush();
                session.Close();
            }
        }
        public static void Update(int id, string newTeam, string newSponsor, int newCoachID)
        {
            using (var session = DBHelper.OpenSession())
            {
                var persistent = session.Get<Team>(id);
                persistent.TeamName = newTeam;
                persistent.Sponsor = newSponsor;
                persistent.CoachKey = session.Get<Coach>(newCoachID);
                session.Update(persistent);
                session.Flush();
                session.Close();
            }
        }
        public static void Delete(int id)
        {
            using (var session = DBHelper.OpenSession())
            {
                session.Delete(session.Get<Team>(id));
                session.Flush();
                session.Close();
            }
        }
    }
}
