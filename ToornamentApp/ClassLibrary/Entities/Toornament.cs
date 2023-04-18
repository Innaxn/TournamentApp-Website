using ClassLibrary.DATA_LAYER;
using ClassLibrary.LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public class Toornament
    {
        private PersonServices personServices;
        private TournamentServices tournamentServices;
        private GameServices gameServices;
        public Toornament()
        {
            personServices = new PersonServices(new PersonDAL());
            tournamentServices = new TournamentServices(new TournamentDAL());
            gameServices = new GameServices(new GameDAL());
        }

        public PersonServices PersonServices
        {
            get { return personServices; }
            set { personServices = value; }
        }

        public TournamentServices TournamentServices
        {
            get { return tournamentServices; }
            set { tournamentServices = value; }
        }
        public GameServices GameServices { get { return gameServices; } set { gameServices = GameServices; } }
    }
}
