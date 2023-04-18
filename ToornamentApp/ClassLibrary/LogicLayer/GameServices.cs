using ClassLibrary.emunerators;
using ClassLibrary.Entities;
using ClassLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.LogicLayer
{
    public class GameServices
    {
        private IGame igame;

        public GameServices(IGame dalgame)
        {
            igame = dalgame;
        }

        public void CreateGames(List<Game> games)
        {
            igame.CreateGame(games);
        }

        public List<Game> GetGamesByPlayerAndTournamentId(Tournament t, int playerId)
        {
            List<Game> games = igame.GetGamesByPlayerAndTournamentId(t, playerId);
            return games;
        }

        public void InputResult(Game game)
        {
            igame.InputResult(game);
        }

        public int CalculateWins(int playerId, int tournamentId)
        {
            return igame.CalculateWins(playerId, tournamentId);
        }

        //public void ValidateWinner(Tournament tr, Game gameholder, int pointer)
        //{
        //    if (gameholder is GameBadminton)
        //    {
        //        bool check = tr.Validate(gameholder.ParticipantOnePoints, gameholder.ParticipantTwoPoints);
        //        if (check)
        //        {
        //            gameholder.SetGameWinnerByPoints();
        //            InputResult(gameholder);
        //        }
        //        else
        //        {
        //            throw new IncorrectResult();
        //        }
        //    }
        //    else if (gameholder is GameBoxing)
        //    {
        //        bool check = tr.Validate(gameholder.ParticipantOnePoints, gameholder.ParticipantTwoPoints);
        //        if (check)
        //        {
        //            gameholder.SetGameWinnerByPoints();
        //            InputResult(gameholder);
        //        }
        //        else if (pointer >= 1)
        //        {
        //            GameBoxing game = (GameBoxing)gameholder;
        //            switch (pointer)
        //            {
        //                case 1:
        //                    game.SetGameWinnerTKO_KO(game.Player1, WayOfWinning.KO);
        //                    break;

        //                case 2:
        //                    game.SetGameWinnerTKO_KO(game.Player1, WayOfWinning.TKO);
        //                    break;

        //                case 3:
        //                    game.SetGameWinnerTKO_KO(game.Player2, WayOfWinning.KO);
        //                    break;

        //                case 4:
        //                    game.SetGameWinnerTKO_KO(game.Player2, WayOfWinning.TKO);
        //                    break;

        //                default:
        //                    throw new IncorrectResult();
        //                    break;
        //            }
        //            InputResult(game);
        //        }
        //        else
        //        {
        //            throw new IncorrectResult();
        //        }
        //    }
        //}

        public void ValidateScoreForAGame(Tournament tr, Game gameholder)
        {
            bool check = tr.Validate(gameholder.ParticipantOnePoints, gameholder.ParticipantTwoPoints);
            if (check)
            {
                ValidateWinnerForAGameByPoints(gameholder);
            }
            else
            {
                throw new IncorrectResult();
            }
        }

        public void ValidateWinnerForAGameByPoints(Game gameholder)
        {
            gameholder.SetGameWinnerByPoints();
            InputResult(gameholder);
        }

        public void ValidateWinnerForBoxing(Game gameholder, int counter)
        {
            GameBoxing game = (GameBoxing)gameholder;
            switch (counter)
            {
                case 1:
                    game.SetGameWinnerTKO_KO(game.Player1, WayOfWinning.KO);
                    break;

                case 2:
                    game.SetGameWinnerTKO_KO(game.Player1, WayOfWinning.TKO);
                    break;

                case 3:
                    game.SetGameWinnerTKO_KO(game.Player2, WayOfWinning.KO);
                    break;

                case 4:
                    game.SetGameWinnerTKO_KO(game.Player2, WayOfWinning.TKO);
                    break;

                default:
                    throw new IncorrectResult();
            }
            InputResult(game);
        }
    }
}
