using ClassLibrary.Entities;
using ClassLibrary.Interface;
using ClassLibrary.LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.MockDATA;

namespace TestProject.UnitTests
{
    [TestClass]
    public class GameServiceTests
    {
        static IGame gameMock =  new GameMOCKDAL();
        GameServices g = new GameServices(gameMock);
        static Player player1 = new Player(1, "sharenda", "peeters", "5422", "sharen@gmail.com", "0656263315", "sherry6");
        static Player player2 = new Player(2, "ivana", "nedelkova", "5422", "ivana@gmail.com", "0689563314", "innaxn");
        Game game9 = new GameBadminton(1, 1, player1, player2, 18, 21);
        Game gameboxing = new GameBoxing(1, 1, player1, player2, 115, 119);

        static Tournament t = new TournamentRoundRobin(1);

        [TestMethod]
        public void GetAllGamesByPlayerIdAndTournamentID_WhenExisting_AreEqual()
        {
            List<Game> expextedgame = gameMock.GetGamesByPlayerAndTournamentId(t,1);
            List<Game> actualGame = g.GetGamesByPlayerAndTournamentId(t,1);
            CollectionAssert.AreEqual(expextedgame.Select(x => x.Id).ToList(), actualGame.Select(x => x.Id).ToList());
        }

        [TestMethod]
        public void GetAllGamesByPlayerIdAndTournamentID_WhenNotExisting_AreNotEqual()
        {
            List<Game> expextedgame = gameMock.GetGamesByPlayerAndTournamentId(t, 2);
            List<Game> actualGame = g.GetGamesByPlayerAndTournamentId(t, 7);
            CollectionAssert.AreNotEqual(expextedgame.Select(x => x.Id).ToList(), actualGame.Select(x => x.Id).ToList());
        }

        [TestMethod]
        public void CalculateWinsForPLayer_AreEqual()
        {
            int count = gameMock.CalculateWins(1,1);
            int actual = g.CalculateWins(1,1);
            
            Assert.AreEqual(actual, count);
        }

        [TestMethod]
        public void CalculateWinsForPLayer_AreNotEqual()
        {
            int count = gameMock.CalculateWins(1, 1);
            int actual = g.CalculateWins(1, 2);

            Assert.AreNotEqual(actual, count);
        }
    }
}
