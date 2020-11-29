using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class TeamComp
    {
        public virtual int Id { get; set; }
        public virtual int Place { get; set; }
        public virtual int Points { get; set; }
        public virtual Team TeamKey { get; set; }
        public virtual Competition CompetitionKey { get; set; }
    }
    public class TeamCompManipulations
    {
        public static void Insert(int _place, int _points, int teamID, int competitionID)
        {
            using (var session = DBHelper.OpenSession())
            {
                var TeamComp = new TeamComp { Place = _place, Points = _place, CompetitionKey = session.Get<Competition>(competitionID), 
                    TeamKey = session.Get<Team>(teamID) };
                session.Save(TeamComp);
                session.Flush();
                session.Close();
            }
        }
        public static void Update(int id, int newPlace, int newPoints, int newTeamID, int newCompetitionID)
        {
            using (var session = DBHelper.OpenSession())
            {
                var persistent = session.Get<TeamComp>(id);
                persistent.Place = newPlace;
                persistent.Points = newPoints;
                persistent.CompetitionKey = session.Get<Competition>(newCompetitionID);
                persistent.TeamKey = session.Get<Team>(newTeamID);
                session.Update(persistent);
                session.Flush();
                session.Close();
            }
        }
        public static void Delete(int id)
        {
            using (var session = DBHelper.OpenSession())
            {
                session.Delete(session.Get<TeamComp>(id));
                session.Flush();
                session.Close();
            }
        }
    }
}
