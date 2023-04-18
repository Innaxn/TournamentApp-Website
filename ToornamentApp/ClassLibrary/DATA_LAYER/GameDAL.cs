using ClassLibrary.emunerators;
using ClassLibrary.Entities;
using ClassLibrary.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DATA_LAYER
{
    public class GameDAL : DB_ConnectionString, IGame
    {
        public void CreateGame(List<Game> games)
        {
            try
            {
                connection.Open();

                foreach (var item in games)
                {
                    string SQL = "INSERT INTO `game`(`id`, `tournamentId`, `participantOne_id`, `participantTwo_id`, `pointsParticipantOne`, `pointsParticipantTwo`) " +
                   "VALUES (null,@tournamentId,@participantOneID, @participantTwoID,@pointsParticipantOne,@pointsParticipantTwo)";
                    MySqlCommand cmd = new MySqlCommand(SQL, connection);
                    //cmd.Parameters.AddWithValue("@id", item.Id);
                    cmd.Parameters.AddWithValue("@tournamentId", item.IdTournament);
                    cmd.Parameters.AddWithValue("@participantOneID", item.Player1.Id);
                    cmd.Parameters.AddWithValue("@participantTwoID", item.Player2.Id);
                    cmd.Parameters.AddWithValue("@pointsParticipantOne", item.ParticipantOnePoints);
                    cmd.Parameters.AddWithValue("@pointsParticipantTwo", item.ParticipantTwoPoints);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Game> GetGamesByPlayerAndTournamentId(Tournament t, int playerId)
        {
            List<Game> currentGames = new List<Game>();
            try
            {
                connection.Open();
                string SQL = "SELECT g.*, p.username, p2.username, person.firstName, per2.firstName, person.lastName, per2.lastName, boxing.wayOfWinning  " +
                    "FROM game g LEFT JOIN player p ON g.participantOne_id = p.id " +
                    "LEFT JOIN player p2 ON g.participantTwo_id = p2.id " +
                    "INNER JOIN person ON person.id = p.id " +
                    "INNER JOIN person per2 on per2.id = p2.id " +
                    "LEFT JOIN boxing ON g.id = boxing.id " +
                    "JOIN tournament t ON g.tournamentId = t.id " +
                    "WHERE t.id = @tournamentId  AND p.id = @playerId OR t.id = @tournamentId  AND p2.id = @playerId";

                MySqlCommand cmd = new MySqlCommand(SQL, connection);
                cmd.Parameters.AddWithValue("@tournamentId", t.Id);
                cmd.Parameters.AddWithValue("@playerId", playerId);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int idG = Convert.ToInt32(reader[0]);
                    int tournamentID = Convert.ToInt32(reader[1]);
                    int playerOne = Convert.ToInt32(reader[2]);
                    int playerTwo = Convert.ToInt32(reader[3]);
                    string username1 = reader[7].ToString();
                    string username2 = reader[8].ToString();
                    string fname1 = reader[9].ToString();
                    string fname2 = reader[10].ToString();
                    string lname1 = reader[11].ToString();
                    string lname2 = reader[12].ToString();

                    Player player = new Player(playerOne, username1, fname1, lname1);
                    Player player2 = new Player(playerTwo, username2, fname2, lname2);
                    Player winner;
                    //Tournament tournament = new TournamentRoundRobin(tournamentID);

                    Game game;

                    int winnerId = -1;

                    if (!reader.IsDBNull(6))
                    {
                        winnerId = Convert.ToInt32(reader[6]);
                        if (winnerId == playerOne)
                        {
                            winner = player;
                        }
                        else
                        {
                            winner = player2;
                        }
                        
                        if (!reader.IsDBNull(4) )
                        {
                            int pointsOne = Convert.ToInt32(reader[4]);
                            int pointsTwo = Convert.ToInt32(reader[5]);
                            if (!reader.IsDBNull(13))
                            {
                                var field = reader[13] != DBNull.Value ? reader[13].ToString() : "";
                                WayOfWinning way = (WayOfWinning)Enum.Parse(typeof(WayOfWinning), field);

                                game = new GameBoxing(idG, tournamentID, player, player2, pointsOne, pointsTwo, winner, way);
                                currentGames.Add(game);

                            }
                            else
                            {
                                game = new GameBadminton(idG, tournamentID, player, player2, pointsOne, pointsTwo, winner);
                                currentGames.Add(game);
                            }

                        }
                    }
                    else if(t.SportType is Badminton)
                    {
                        game = new GameBadminton(idG, tournamentID, player, player2);
                        currentGames.Add(game);
                    }
                    else
                    {
                        game = new GameBoxing(idG, tournamentID, player, player2);
                        currentGames.Add(game);
                    }
                }
                return currentGames;
                connection.Close();
            }
            //catch (Exception)
            //{

            //    throw;
            //}
            finally
            {
                connection.Close();
            }
        }

        public int CalculateWins(int playerId, int tournamentId)
        {
            try
            {
                connection.Open();
                string SQL = "select count(game.winnerId) from game inner join player p2 on p2.id = game.participantTwo_id where game.tournamentId = @tournamentId and game.winnerId = @playerId";
                MySqlCommand cmd = new MySqlCommand(SQL, connection);
                cmd.Parameters.AddWithValue("@playerId", playerId);
                cmd.Parameters.AddWithValue("@tournamentId", tournamentId);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count;

            }
            catch (Exception)
            {
                throw;
            }
            finally { connection.Close(); }
        }

        public void InputResult(Game game)
        {
            try
            {
                if (game is GameBadminton)
                {
                    connection.Open();

                    string SQL = "UPDATE `game` SET `pointsParticipantOne`=@pointsParticipantOne,`pointsParticipantTwo`=@pointsParticipantTwo,`winnerId`=@winnerId WHERE id=@id";
                    MySqlCommand cmd = new MySqlCommand(SQL, connection);
                    cmd.Parameters.AddWithValue("@id", game.Id);
                    cmd.Parameters.AddWithValue("@pointsParticipantOne", game.ParticipantOnePoints);
                    cmd.Parameters.AddWithValue("@pointsParticipantTwo", game.ParticipantTwoPoints);
                    cmd.Parameters.AddWithValue("@winnerId", game.Winner.Id);
                    cmd.ExecuteNonQuery();
                }
                else if (game is GameBoxing)
                {
                    GameBoxing gameBoxing = (GameBoxing)game;
                    connection.Open();
                    string SQL = "BEGIN; UPDATE `game` SET `pointsParticipantOne`= @pointsParticipantOne,`pointsParticipantTwo`= @pointsParticipantTwo,`winnerId`= @winnerId " +
                        "WHERE id = @id; INSERT INTO boxing(id, wayOfWinning) VALUES(@id, @way); COMMIT; ";
                    MySqlCommand cmd = new MySqlCommand(SQL, connection);
                    cmd.Parameters.AddWithValue("@id", game.Id);
                    cmd.Parameters.AddWithValue("@winnerId", game.Winner.Id);
                    cmd.Parameters.AddWithValue("@pointsParticipantOne", gameBoxing.ParticipantOnePoints);
                    cmd.Parameters.AddWithValue("@pointsParticipantTwo", gameBoxing.ParticipantTwoPoints);
                    cmd.Parameters.AddWithValue("@way", gameBoxing.Way.ToString());
                    cmd.ExecuteNonQuery();
                }
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
