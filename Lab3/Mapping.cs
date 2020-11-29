using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;

using Npgsql;
namespace Lab3
{
    class CoachMap : ClassMap<Coach>
    {
        public CoachMap()
        {
            Schema("competitions");
            Table($"\"Тренер\"");
            Id(x => x.Id).GeneratedBy.Custom("trigger-identity");
            Map(x => x.Name, "\"Name\"");
            Map(x => x.Birthday, "\"Birthday\"").CustomType("Date");
        }
    }
    class TeamMap: ClassMap<Team>
    {
        public TeamMap()
        {
            Schema("competitions");
            Table("\"Команда\"");
            Id(x => x.Id).GeneratedBy.Custom("trigger-identity");
            Map(x => x.TeamName, "\"TeamName\"").Unique();
            Map(x => x.Sponsor, "\"Sponsor\"");
            References(x => x.CoachKey).Column("\"Тренер_key\"").Unique();
        }
    }
    class StadiumMap : ClassMap<Stadium>
    {
        public StadiumMap()
        {
            Schema("competitions");
            Table("\"Стадіон\"");
            Id(x => x.Id).GeneratedBy.Custom("trigger-identity");
            Map(x => x.Seats, "\"Seats number\"");
            Map(x => x.Location, "\"Location\"");
        }
    }
    class CompetitionMap: ClassMap<Competition>
    {
        public CompetitionMap()
        {
            Schema("competitions");
            Table("\"Змагання\"");
            Id(x => x.Id).GeneratedBy.Custom("trigger-identity");
            Map(x => x.Arbiter, "\"Arbiter\"");
            Map(x => x.ElapsedTime, "\"Elapsed Time\"");
            Map(x => x.Date, "\"Date\"").CustomType("Date");
            Map(x => x.Time, "\"Time\"").CustomType("Time");
            References(x => x.StadiumKey).Column("\"Стадіон_key\"");
        }
    }
    class TeamCompMap : ClassMap<TeamComp>
    {
        public TeamCompMap()
        {
            Schema("competitions");
            Table("\"Команда_Змагання\"");
            Id(x => x.Id).GeneratedBy.Custom("trigger-identity");
            Map(x => x.Place, "\"Place\"");
            Map(x => x.Points, "\"TotalPoints\"");
            References(x => x.TeamKey).Column("\"Команда_key\"");
            References(x => x.CompetitionKey).Column("\"Змагання_key\"");
        }
    }
    class ResultsMap : ClassMap<Results>
    {
        public ResultsMap()
        {
            Schema("competitions");
            Table("\"Результати_вправ\"");
            Id(x => x.Id).GeneratedBy.Custom("trigger-identity");
            Map(x => x.Exercise, "\"ExerciseName\"");
            Map(x => x.Points, "\"Points\"");
            References(x => x.TeamCompKey).Column("\"Команда_Змагання_key\"");
        }
    }
}
