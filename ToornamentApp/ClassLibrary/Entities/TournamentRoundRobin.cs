using ClassLibrary.enumerators;
using ClassLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public class TournamentRoundRobin : Tournament
    {
        public TournamentRoundRobin() { }
        public TournamentRoundRobin(int id, ISportType sportType):base(id, sportType) 
        {
        }
        public TournamentRoundRobin(int id) : base(id)
        {
        }

        public TournamentRoundRobin(int id, ISportType sportType, string description, DateTime start, DateTime end, int min, int max,
            string city, string address, TournamentStatus status) : base(id, sportType, description, start, end, min, max, city, address, status)
        {

        }
        public TournamentRoundRobin(ISportType sportType, string description, DateTime start, DateTime end, int min, int max,
             string city, string address, TournamentStatus status) : base(sportType, description, start, end, min, max, city, address, status)
        {

        }

        public override List<Game> GenerateGames(List<Player> players)
        {
            // algorithm
            //version1
            List<Game> games = new List<Game>();

            while (true)
            {
                for (int i = 1; i < players.Count; i++)
                {
                    if (_sportType is Badminton)
                    {
                        games.Add(new GameBadminton(id, players[0], players[i]));
                    }
                    else if(_sportType is Boxing)
                    {
                        games.Add(new GameBoxing(id, players[0], players[i]));
                    }
                    
                }
                if (players.Count <= 1)
                {
                    break;
                }
                players.RemoveAt(0);
            }
            return games;


            //version2
            //    for (int i = 1; i < players.Count; i++)
            //    {
            //        for (int j = i+1; j < players.Count; j++)
            //        {
            //            Game newgame = new Game(m, tId, i, j);
            //            newgame.ParticipantOneId = players[i].Id;
            //            newgame.ParticipantTwoId = players[j].Id;
            //            games.Add(newgame);
            //        }
            //    }

            //return games;
        }
        public override ISportType IdentifySportType(int nr)
        {
            switch (nr)
            {
                case 0:
                    return new Badminton();
                case 1:
                    return new Boxing();
                default: return null;
            }
        }

        //for unit tests
        public override bool Equals(Object obj)
        {
            if (obj is TournamentRoundRobin)
            {
                var that = obj as TournamentRoundRobin;
                return this.Id.Equals(that.Id) &&
                    this.SportType.Equals(that.SportType) &&
                    this.Description.Equals(that.Description) &&
                    this.StartDate.Equals(that.StartDate) &&
                    this.EndDate.Equals(that.EndDate) &&
                    this.MinParticipants.Equals(that.MinParticipants) &&
                    this.MaxParticipants.Equals(that.MaxParticipants) &&
                    this.City.Equals(that.City) &&
                    this.Address.Equals(that.Address) &&
                    this.Status.Equals(that.Status);
            }

            return false;
        }
    }
}
