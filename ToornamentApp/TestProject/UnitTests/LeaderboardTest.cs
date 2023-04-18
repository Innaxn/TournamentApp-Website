using ClassLibrary.Entities;
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
    public class LeaderboardTest
    {
        PersonServices p = new PersonServices(new PersonMOCKDAL());
        PersonMOCKDAL personMock = new PersonMOCKDAL();

        [TestMethod]
        public void GenerateLeaderboard()
        {
            int win1 = 10;
            int win2 = 5;
            int win3 = 2;
            Leaderboard l = new Leaderboard();
            Player player = new Player(1, "sharenda", "peeters", "5422", "key", "sharenda@gmail.com", "0897854211", "sharen");
            Player player2 = new Player(2, "ina", "nedelkova", "5422", "key", "ina@gmail.com", "0897854711", "innaxn");
            Player player3 = new Player(2, "yana", "yaneva", "5422", "key", "yana@gmail.com", "0897854111", "yana01");
            List<Player> players = new List<Player>();
            players.Add(player);
            players.Add(player2);
            players.Add(player3);
            List<int> wins = new List<int>();
            wins.Add(win1);
            wins.Add(win2);
            wins.Add(win3);
            Tuple<List<Player>, List<int>> expected = new Tuple<List<Player>, List<int>>(new List<Player>(), new List<int>());
            expected.Item1.Add(player);
            expected.Item2.Add(10);
            expected.Item1.Add(player2);
            expected.Item2.Add(5);
            expected.Item1.Add(player3);
            expected.Item2.Add(2);
            

            Tuple<List<Player>, List<int>> actual = l.SortPosition(players, wins);
            CollectionAssert.AreEqual(expected.Item1.Select(x => x.Id).ToList(), actual.Item1.Select(x => x.Id).ToList());
            CollectionAssert.AreEqual(expected.Item2.Select(x => x).ToList(), actual.Item2.Select(x => x).ToList());
        }

        //[TestMethod]
        //public void PlayerWins()
        //{
        //    List<int> playerWinsExpected = new List<int>();
        //    playerWinsExpected.Add(3);
        //    playerWinsExpected.Add(4);
        //    Tournament t = new TournamentRoundRobin(1);

        //    Leaderboard l = new Leaderboard();
        //    List<int> actualWins = l.PlayerWins(1);

        //    CollectionAssert.AreEqual(playerWinsExpected.Select(x=> x).ToList(), actualWins.Select(x => x).ToList());
        //}

    }
}
