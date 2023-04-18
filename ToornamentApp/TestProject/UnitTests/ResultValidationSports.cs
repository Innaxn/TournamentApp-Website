using ClassLibrary.Entities;
using ClassLibrary.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.UnitTests
{
    [TestClass]
    public class ResultValidationSports
    {
       [TestMethod]
       public void ValidateResults_BadmintonPointsAreCorrect_IsTrue()
       {
            ISportType _sport = new Badminton();
            Tournament tournamnet = new TournamentRoundRobin(1, _sport);
            int scoreone = 15;
            int scoretwo = 21;

            bool isValid = tournamnet.Validate(scoreone, scoretwo);
            Assert.IsTrue(isValid);
       }
        [TestMethod]
        public void ValidateResults_BadmintonPointsAreIncorrect_IsFalse()
        {
            ISportType _sport = new Badminton();
            Tournament tournamnet = new TournamentRoundRobin(1, _sport);
            int scoreone = 20;
            int scoretwo = 21;

            bool isValid = tournamnet.Validate(scoreone, scoretwo);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void ValidateResults_BadmintonPointsAreIncorrect_WhenTwoPointsDifferenceMissing_IsFalse()
        {
            ISportType _sport = new Badminton();
            Tournament tournamnet = new TournamentRoundRobin(1, _sport);
            int scoreone = 22;
            int scoretwo = 25;

            bool isValid = tournamnet.Validate(scoreone, scoretwo);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void ValidateResults_BadmintonPointsAreIncorrect_WhenResultIsBiggerThan30_IsFalse()
        {
            ISportType _sport = new Badminton();
            Tournament tournamnet = new TournamentRoundRobin(1, _sport);
            int scoreone = 29;
            int scoretwo = 31;

            bool isValid = tournamnet.Validate(scoreone, scoretwo);
            Assert.IsFalse(isValid);
        }
        [TestMethod]
        public void ValidateResults_BadmintonPointsAreIncorrect_WhenResultIsLessThan21_IsFalse()
        {
            ISportType _sport = new Badminton();
            Tournament tournamnet = new TournamentRoundRobin(1, _sport);
            int scoreone = 18;
            int scoretwo = 15;

            bool isValid = tournamnet.Validate(scoreone, scoretwo);
            Assert.IsFalse(isValid);
        }
        [TestMethod]
        public void ValidateResults_BadmintonPointsAreIncorrect_WhenResultIsEqual_IsFalse()
        {
            ISportType _sport = new Badminton();
            Tournament tournamnet = new TournamentRoundRobin(1, _sport);
            int scoreone = 25;
            int scoretwo = 25;

            bool isValid = tournamnet.Validate(scoreone, scoretwo);
            Assert.IsFalse(isValid);
        }
        [TestMethod]
        public void ValidateResults_BadmintonPointsAreCorrect_WhenResultIsMeeting30_IsFalse()
        {
            ISportType _sport = new Badminton();
            Tournament tournamnet = new TournamentRoundRobin(1, _sport);
            int scoreone = 29;
            int scoretwo = 30;

            bool isValid = tournamnet.Validate(scoreone, scoretwo);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void ValidateResults_BoxingPointsAreCorrect_IsTrue()
        {
            ISportType _sport = new Boxing();
            Tournament tournamnet = new TournamentRoundRobin(1, _sport);
            int scoreone = 115;
            int scoretwo = 120;

            bool isValid = tournamnet.Validate(scoreone, scoretwo);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void ValidateResults_BoxingPointsAreIncorrect_IsFalse()
        {
            ISportType _sport = new Boxing();
            Tournament tournamnet = new TournamentRoundRobin(1, _sport);
            int scoreone = 115;
            int scoretwo = 121;

            bool isValid = tournamnet.Validate(scoreone, scoretwo);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void ValidateResults_BoxingPointsAreIncorrect_WhenBothScoresAreTheSame_IsFalse()
        {
            ISportType _sport = new Boxing();
            Tournament tournamnet = new TournamentRoundRobin(1, _sport);
            int scoreone = 115;
            int scoretwo = 115;

            bool isValid = tournamnet.Validate(scoreone, scoretwo);
            Assert.IsFalse(isValid);
        }
    }
}
