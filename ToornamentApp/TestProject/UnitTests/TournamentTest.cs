using ClassLibrary.Entities;
using ClassLibrary.enumerators;
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
    public class TournamentTest
    {
        TournamentServices tournamentService = new TournamentServices(new TournamentMOCKDAL());
        TournamentMOCKDAL tournamentMock = new TournamentMOCKDAL();
        static DateTime date1 = Convert.ToDateTime("29/06/2022");
        static DateTime date2 = Convert.ToDateTime("30/07/2022");
        static ISportType _sport = new Badminton();
        Tournament t = new TournamentRoundRobin(1,_sport,"descr", date1,date2, 3,5,"eindhoven","adres",TournamentStatus.INPROGRESS);

        [TestMethod]
        public void GenerateRoundRobinAlgorithm()
        {
            Player player = new Player(1, "sharenda", "peeters", "5422", "key", "sharenda@gmail.com", "0897854211", "sharen");
            Player player2 = new Player(2, "ina", "nedelkova", "5422", "key", "ina@gmail.com", "0897854711", "innaxn");
            Player player3 = new Player(2, "yana", "yaneva", "5422", "key", "yana@gmail.com", "0897854111", "yana01");
            GameBadminton game1 = new GameBadminton(1, player, player2);
            GameBadminton game2 = new GameBadminton(1, player, player3);
            GameBadminton game3 = new GameBadminton(1, player2,player3);
            List<Player> playerList = new List<Player>();
            playerList.Add(player);
            playerList.Add(player2);
            playerList.Add(player3);
            List<Game> expectedgames = t.GenerateGames(playerList);
            List<Game> actualgames = new List<Game>();
            actualgames.Add(game1);
            actualgames.Add(game2);
            actualgames.Add(game3);


            CollectionAssert.AreEqual(expectedgames.Select(x => x.Player1).ToList(), actualgames.Select(x => x.Player1).ToList());
            CollectionAssert.AreEqual(expectedgames.Select(x => x.Player2).ToList(), actualgames.Select(x => x.Player2).ToList());
        }

        [TestMethod]
        public void CreateATournament_WrongDates()
        {
            DateTime n = new DateTime(2023, 6, 1);
            DateTime r = new DateTime(2023, 6, 29);
            TournamentRoundRobin expected = new TournamentRoundRobin(2, _sport, "descr", n, r, 3, 5, "eindhoven", "adres", TournamentStatus.AVAILABLE);
            bool IsDateCorrect = expected.IsDateCorrect();
            bool IsAmountOfPlayersCorrect = expected.IsAmountOfPlayersCorrect();

            //act
            tournamentService.CreateTournament(expected);
            Tournament actualTournament = tournamentService.GetTournamentById(2);

            //Assert
            Assert.IsTrue(IsDateCorrect);
            Assert.IsTrue(IsAmountOfPlayersCorrect);
            Assert.AreEqual(expected, actualTournament);
        }

        [TestMethod]
        public void AddTournament_MaximumNumberOfPlayersIsLessThanMinimumNumberOfPlayers_ReturnFalse()
        {
            DateTime startDate = new DateTime(2023, 5, 5);
            DateTime endDate = new DateTime(2023, 8, 8);
            ISportType _sport = new Badminton();
            Tournament tournament = new TournamentRoundRobin(1, _sport, "description", startDate, endDate, 12, 6, "Ring Road 123", "Sofia", TournamentStatus.AVAILABLE);
            
            bool IsAmountOfPlayersCorrect = tournament.IsAmountOfPlayersCorrect();

            Assert.IsFalse(IsAmountOfPlayersCorrect);
        }

        [TestMethod]
        public void AddTournament_StartingDateIsEarlierThanToday_ReturnFalse()
        {
            DateTime startDate = new DateTime(2020, 5, 5);
            DateTime endDate = new DateTime(2020, 8, 8);
            ISportType _sport = new Badminton();

            Tournament tournamnet = new TournamentRoundRobin(1,_sport, "description", startDate, endDate, 6, 12, "xdcfvg", "xcv", TournamentStatus.AVAILABLE);

            bool IsDateCorrect = tournamnet.IsDateCorrect();

            Assert.IsFalse(IsDateCorrect);
        }

        [TestMethod]
        public void AddTournament_MinimumNumberOfPlayersIsAnInvalidNumber_ThrowsExeptionIsTrue()
        {
            DateTime startDate = new DateTime(2023, 5, 5);
            DateTime endDate = new DateTime(2023, 8, 8);
            ISportType _sport = new Badminton();

            Tournament tournament = new TournamentRoundRobin(1, _sport, "description", startDate, endDate, 2, 10, "asdfgh", "zxdcgfv", TournamentStatus.AVAILABLE);
            try
            {
                tournamentService.CreateTournament(tournament);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is IsAmountOfPlayersIncorrect);
            }
           // bool IsAmountOfPlayersCorrect = tournament.IsAmountOfPlayersCorrect();

            //Assert.IsFalse(IsAmountOfPlayersCorrect);
        }

        [TestMethod]
        public void GetByTournamentId_Returns_CorrectResult_AreEqual()
        {
            //act
            var result = tournamentService.GetTournamentById(2);

            //assert
            Assert.AreEqual(2, result.Id);
        }

        [TestMethod]
        public void GetByTournamentId_Returns_InvalidResult_AreNotEqual()
        {
            //act
            var result = tournamentService.GetTournamentById(4);

            //assert
            Assert.AreNotEqual(4, result.Id);
        }

       [TestMethod]
       public void GetTournamentsByStatus_Successful_AreEqual()
       {
            DateTime n = new DateTime(2023, 6, 1);
            DateTime r = new DateTime(2023, 6, 29);
            TournamentRoundRobin expect = new TournamentRoundRobin(2, _sport, "descr", n, r, 3, 5, "eindhoven", "adres", TournamentStatus.AVAILABLE);
            TournamentRoundRobin expect2 = new TournamentRoundRobin(3, _sport, "descri", n, r, 5, 10, "eindhoven", "adres", TournamentStatus.AVAILABLE);
            List<Tournament> expectedgames = new List<Tournament>();
            expectedgames.Add(expect);
            expectedgames.Add(expect2);
            List<Tournament> gameactual = tournamentService.GetTournamentsByStatus(TournamentStatus.AVAILABLE);

            CollectionAssert.AreEqual(expectedgames.Select(x => x.Id).ToList(), gameactual.Select(x => x.Id).ToList());
            CollectionAssert.AreEqual(expectedgames.Select(x => x.Status).ToList(), gameactual.Select(x => x.Status).ToList());
        }

        [TestMethod]
        public void GetTournamentsByStatus_Unsuccessful_AreNotEqual()
        {
            DateTime n = new DateTime(2023, 6, 1);
            DateTime r = new DateTime(2023, 6, 29);
            TournamentRoundRobin expect = new TournamentRoundRobin(2, _sport, "descr", n, r, 3, 5, "eindhoven", "adres", TournamentStatus.PENDING);
            TournamentRoundRobin expect2 = new TournamentRoundRobin(3, _sport, "descri", n, r, 5, 10, "eindhoven", "adres", TournamentStatus.PENDING);
            List<Tournament> expectedtournamnts = new List<Tournament>();
            expectedtournamnts.Add(expect);
            expectedtournamnts.Add(expect2);
            List<Tournament> actual = tournamentService.GetTournamentsByStatus(TournamentStatus.AVAILABLE);

            CollectionAssert.AreNotEqual(expectedtournamnts.Select(x => x.Status).ToList(), actual.Select(x => x.Status).ToList());
        }

        [TestMethod]
        public void GetCountGamesByTournamentID_Equal()
        {
            int expectedCount = 5;
            int actualCount = tournamentService.GetCountOfGamesByTournamentId(5);

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void GetCountGamesByTournamentID_NotEqual()
        {
            int expectedCount = 5;
            int actualCount = tournamentService.GetCountOfGamesByTournamentId(1);

            Assert.AreNotEqual(expectedCount, actualCount);
        }

        [TestMethod]
        public void GetTournamentsByPlayerId_AreEqual()
        {
            DateTime n = new DateTime(2023, 6, 1);
            DateTime r = new DateTime(2023, 6, 29);
            int playerid = 6;
            TournamentRoundRobin expected = new TournamentRoundRobin(2, _sport, "descr", n, r, 3, 5, "eindhoven", "adres", TournamentStatus.AVAILABLE);
            TournamentRoundRobin expected2 = new TournamentRoundRobin(3, _sport, "descri", n, r, 5, 10, "eindhoven", "adres", TournamentStatus.AVAILABLE);
            List<Tournament> tournaments = new List<Tournament>();
            tournaments.Add(expected);
            tournaments.Add(expected2);
            List<Tournament> actual = tournamentService.GetTournamentsByPlayerId(playerid);

            CollectionAssert.AreEqual(tournaments.Select(x => x.Id).ToList(), actual.Select(x => x.Id).ToList());
        }

        [TestMethod]
        public void GetTournamentsByPlayerId_AreNotEqual()
        {
            DateTime n = new DateTime(2023, 6, 1);
            DateTime r = new DateTime(2023, 6, 29);
            int playerid = 7;
            TournamentRoundRobin expected = new TournamentRoundRobin(2, _sport, "descr", n, r, 3, 5, "eindhoven", "adres", TournamentStatus.AVAILABLE);
            TournamentRoundRobin expected2 = new TournamentRoundRobin(3, _sport, "descri", n, r, 5, 10, "eindhoven", "adres", TournamentStatus.AVAILABLE);
            List<Tournament> tournaments = new List<Tournament>();
            tournaments.Add(expected);
            tournaments.Add(expected2);
            List<Tournament> actual = tournamentService.GetTournamentsByPlayerId(playerid);

            CollectionAssert.AreNotEqual(tournaments.Select(x => x.Id).ToList(), actual.Select(x => x.Id).ToList());
        }

        [TestMethod]
        public void IsPlayerRegisteredForAtournaent_IsTrue()
        {
            int playerid = 2;
            int tournamentid = 2;

            bool check = tournamentService.IsSignedUp(tournamentid, playerid);

            Assert.IsTrue(check);
        }

        [TestMethod]
        public void IsPlayerRegisteredForAtournaent_IsFalse()
        {
            int playerid = 7;
            int tournamentid = 2;

            bool check = tournamentService.IsSignedUp(tournamentid, playerid);

            Assert.IsFalse(check);
        }

        [TestMethod]
        public void GetCountOfCurrentPlayersInATournament_WhenExisting_AreEqual()
        {
            int expected = 3;
            int tournamentid = 9;
            int actual = tournamentService.GetCountOfCurrent(tournamentid);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetCountOfCurrentPlayersInATournament_WhenExisting_AreNotEqual()
        {
            int expected = 4;
            int tournamentid = 9;
            int actual = tournamentService.GetCountOfCurrent(tournamentid);

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void CheckIfTournamentIsProgress_Correct()
        {
            DateTime startDate = new DateTime(2022, 6, 9);
            DateTime endDate = new DateTime(2023, 8, 8);
            ISportType _sport = new Badminton();

            TournamentRoundRobin tournament = new TournamentRoundRobin(9, _sport, "des", startDate, endDate, 3, 10, "ssss", "Rotterdam", TournamentStatus.AVAILABLE);
            try
            {
                tournamentService.CheckIfInprogress(tournament);
            }
            catch (Exception ex)
            {
                Assert.IsFalse(ex is InprogressNotPossible);
            }
        }

        [TestMethod]
        public void CheckIfTournamentIsProgress_Incorrect() 
        {
            DateTime startDate = new DateTime(2023, 5, 5);
            DateTime endDate = new DateTime(2023, 8, 8);
            ISportType _sport = new Badminton();

            TournamentRoundRobin tournament = new TournamentRoundRobin(7, _sport, "des", startDate, endDate, 2, 10, "ssss", "Rotterdam", TournamentStatus.AVAILABLE);
            try
            {
                tournamentService.CheckIfInprogress(tournament);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is InprogressNotPossible);
            }
        }
        [TestMethod]
        public void CheckIfTournamentIsPending_Correct_ThrowExpectionFalse()
        {
            DateTime startDate = new DateTime(2022, 6, 9);
            DateTime endDate = new DateTime(2023, 8, 8);
            ISportType _sport = new Badminton();

            TournamentRoundRobin tournament = new TournamentRoundRobin(9, _sport, "des", startDate, endDate, 3, 3, "ssss", "Rotterdam", TournamentStatus.AVAILABLE);
            try
            {
                tournamentService.CheckIfInprogress(tournament);
            }
            catch (Exception ex)
            {
                Assert.IsFalse(ex is PedingException);
            }
        }

        [TestMethod]
        public void CheckIfTournamentIsPending_Incorrect_WhenMaxPlayersNotReachered_AndStartDateIncorrect_ThrowExpectionTrue()
        {
            DateTime startDate = new DateTime(2022, 7, 9);
            DateTime endDate = new DateTime(2023, 8, 8);
            ISportType _sport = new Badminton();

            TournamentRoundRobin tournament = new TournamentRoundRobin(9, _sport, "des", startDate, endDate, 3, 9, "ssss", "Rotterdam", TournamentStatus.AVAILABLE);
            try
            {
                tournamentService.CheckIfPending(tournament);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is PedingException);
            }
        }

        [TestMethod]
        public void GenerateGames_WhenAlreadyGenerated_ThrowExeption_IsTrue()
        {
            DateTime startDate = new DateTime(2022, 7, 9);
            DateTime endDate = new DateTime(2023, 8, 8);
            ISportType _sport = new Badminton();

            TournamentRoundRobin tournament = new TournamentRoundRobin(5, _sport, "des", startDate, endDate, 3, 9, "ssss", "Rotterdam", TournamentStatus.AVAILABLE);
            try
            {
                tournamentService.GenerateCreateGamesRoundRobin(tournament);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is GenerateGamesError);
            }
        }
        [TestMethod]
        public void UpdateTournament_WithCorrectInformation_DoesntThrowAnyExeptions_IsFalse()
        {
            DateTime startDate = new DateTime(2022, 7, 9);
            DateTime endDate = new DateTime(2023, 8, 8);
            ISportType _sport = new Badminton();

            TournamentRoundRobin tournament = new TournamentRoundRobin(9, _sport, "des", startDate, endDate, 3, 9, "ssss", "Rotterdam", TournamentStatus.AVAILABLE);
            try
            {
                tournamentService.UpdateTournament(tournament);
            }
            catch (Exception ex)
            {
                Assert.IsFalse(ex is IncorrectAmountOfSignedPlayers);
                Assert.IsFalse(ex is IncorrectAmountAndDates);
                Assert.IsFalse(ex is IncorrectDateUpdate);
                Assert.IsFalse(ex is IncorrectAmountAndDates);
            }
        }
        [TestMethod]
        public void UpdateTournament_WithWrongMinimum_ThrowExeption_IsTrue()
        {
            DateTime startDate = new DateTime(2022, 7, 9);
            DateTime endDate = new DateTime(2023, 8, 8);
            ISportType _sport = new Badminton();

            TournamentRoundRobin tournament = new TournamentRoundRobin(11, _sport, "des", startDate, endDate, 3, 9, "ssss", "Rotterdam", TournamentStatus.AVAILABLE);
            try
            {
                tournamentService.UpdateTournament(tournament);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is IncorrectAmountOfSignedPlayers);
            }
        }

        [TestMethod]
        public void UpdateTournament_WithWrongDates_ThrowExeption_IsTrue()
        {
            DateTime startDate = new DateTime(2024, 7, 9);
            DateTime endDate = new DateTime(2023, 8, 8);
            ISportType _sport = new Badminton();

            TournamentRoundRobin tournament = new TournamentRoundRobin(11, _sport, "des", startDate, endDate, 3, 9, "ssss", "Rotterdam", TournamentStatus.AVAILABLE);
            try
            {
                tournamentService.UpdateTournament(tournament);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is IncorrectDateUpdate);
            }
        }

        [TestMethod]
        public void UpdateTournament_WithMinAndMaxPLayers_ThrowExeption_IsTrue()
        {
            DateTime startDate = new DateTime(2023, 7, 9);
            DateTime endDate = new DateTime(2023, 8, 8);
            ISportType _sport = new Badminton();

            TournamentRoundRobin tournament = new TournamentRoundRobin(11, _sport, "des", startDate, endDate, 8, 8, "ssss", "Rotterdam", TournamentStatus.AVAILABLE);
            try
            {
                tournamentService.UpdateTournament(tournament);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is IsAmountOfPlayersIncorrect);
            }
        }

        [TestMethod]
        public void CreateTournament_WithCorrectInformation_DoesntThrowAnyExeptions_IsFalse()
        {
            DateTime startDate = new DateTime(2022, 7, 9);
            DateTime endDate = new DateTime(2023, 8, 8);
            ISportType _sport = new Badminton();

            TournamentRoundRobin tournament = new TournamentRoundRobin(9, _sport, "des", startDate, endDate, 3, 9, "ssss", "Rotterdam", TournamentStatus.AVAILABLE);
            try
            {
                tournamentService.CreateTournament(tournament);
            }
            catch (Exception ex)
            {
                Assert.IsFalse(ex is IncorrectAmountAndDates);
                Assert.IsFalse(ex is IsAmountOfPlayersIncorrect);
                Assert.IsFalse(ex is IncorectDateException);
            }
        }
    }
}
