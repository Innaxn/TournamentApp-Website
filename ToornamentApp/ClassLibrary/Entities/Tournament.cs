using ClassLibrary.enumerators;
using ClassLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public abstract class Tournament
    {
        protected int id;
        protected ISportType _sportType;
        protected string description;
        protected DateTime startDate;
        protected DateTime endDate;
        protected int minParticipants;
        protected int maxParticipants;
        protected string city;
        protected string address;
        protected TournamentStatus status;
        protected List<Game> games = new List<Game>();

        public Tournament()
        {

        }

        public int Id { get { return id; } }
        public string Description { get { return description; } set { description = value; } }
        public DateTime StartDate { get { return startDate; } set { startDate = value; } }
        public DateTime EndDate { get { return endDate; } set { endDate = value; } }
        public int MinParticipants { get { return minParticipants; } set { minParticipants = value; } }
        public int MaxParticipants { get { return maxParticipants; } set { maxParticipants = value; } }
        public string City { get { return city; } set { city = value; } }
        public string Address { get { return address; } set { address = value; } }
        public TournamentStatus Status { get { return status; } set { status = value; } }
        public ISportType SportType { get { return _sportType; } set { _sportType = value; } }

        public Tournament(int id, ISportType sportType) 
        {
            this.id = id;
            this._sportType = sportType;
        }
        public Tournament(int id)
        {
            this.id = id;
        }
        public Tournament(int id, ISportType sportType, string description, DateTime start, DateTime end, int min, int max,
            string city, string address, TournamentStatus status)
        {
            this.id = id;
            this._sportType = sportType;
            this.description = description;
            this.startDate = start;
            this.endDate = end;
            this.minParticipants = min;
            this.maxParticipants = max;
            this.city = city;
            this.address = address;
            this.status = status;

        }

        public Tournament(ISportType sportType, string description, DateTime start, DateTime end, int min, int max,
            string city, string address, TournamentStatus status)
        {
            this._sportType = sportType;
            this.description = description;
            this.startDate = start;
            this.endDate = end;
            this.minParticipants = min;
            this.maxParticipants = max;
            this.city = city;
            this.address = address;
            this.status = status;
        }
        public bool Validate(int scoreOne, int scoreTwo)
        {
            bool isValid = _sportType.ValidateScore(scoreOne, scoreTwo);
            return isValid;
        }
        public abstract List<Game> GenerateGames(List<Player> players);
        public abstract ISportType IdentifySportType(int nr);
        public int CalculateDateDifference()
        {
            TimeSpan difference = StartDate.Date - DateTime.Now;
            int days = (int)difference.TotalDays;
            return days;
        }
        public bool IsDateCorrect()
        {
            int days = CalculateDateDifference();
            if (StartDate >= EndDate || StartDate == EndDate || days < 14)
            {
                return false;
            }
            return true;
        }

        public bool IsDateCorrectForUpdate()
        {
            if (StartDate >= EndDate || StartDate == EndDate)
            {
                return false;
            }
            return true;
        }

        public bool IsAmountOfPlayersCorrect()
        {
            if (MinParticipants <= 2 || MinParticipants >= MaxParticipants)
            {
                return false;
            }
            return true;
        }

    }
}
