using ClassLibrary.Entities;
using ClassLibrary.enumerators;
using ClassLibrary.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DATA_LAYER
{
    public class TournamentDAL : DB_ConnectionString, ITournament
    {
        public void ChangeStatus(int id, TournamentStatus s)
        {
            try
            {
                connection.Open();
                string SQL = "UPDATE `tournament` SET `status`=@status WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(SQL, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@status", s);
                cmd.ExecuteNonQuery();
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
        public void CreateTournament(Tournament tournament)
        {
            try
            {
                connection.Open();
                string SQL = "INSERT INTO `tournament`(`id`, `sportId`, `description`, `startDate`, `endDate`, `minParticipants`, `maxParticipants`, `city`, `address`, `status`) VALUES " +
                    " (null,@sportId,@desc,@start,@end,@min,@max,@city,@address,@status)";
                MySqlCommand cmd = new MySqlCommand(SQL, connection);
                cmd.Parameters.AddWithValue("@sportId", tournament.SportType.GetId());
                //cmd.Parameters.AddWithValue("@associationid", tournament.AssociationId);
                cmd.Parameters.AddWithValue("@desc", tournament.Description);
                cmd.Parameters.AddWithValue("@start", tournament.StartDate);
                cmd.Parameters.AddWithValue("@end", tournament.EndDate);
                cmd.Parameters.AddWithValue("@min", tournament.MinParticipants);
                cmd.Parameters.AddWithValue("@max", tournament.MaxParticipants);
                cmd.Parameters.AddWithValue("@city", tournament.City);
                cmd.Parameters.AddWithValue("@address", tournament.Address);
                cmd.Parameters.AddWithValue("@status", (int)tournament.Status);
                cmd.ExecuteNonQuery();
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
        public void DeleteTournament(int id)
        {
            try
            {
                connection.Open();
                string sql = "DELETE FROM `tournament` WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
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
        public List<Tournament> GetTournamentsByStatus(TournamentStatus status)
        {
            try
            {
                connection.Open();
                List<Tournament> tournaments = new List<Tournament>();
                string sql = "SELECT * FROM `tournament` WHERE status = @status";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@status", status);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int idT = Convert.ToInt32(reader[0].ToString());
                    ISportType cSport = null;
                    if (Convert.ToInt32(reader[1]) == 1)
                    {
                        cSport = new Badminton();
                    }
                    else if (Convert.ToInt32(reader[1]) == 2)
                    {
                        cSport = new Boxing();
                    }
                    string description = reader[2].ToString();
                    DateTime startdate = Convert.ToDateTime(reader[3]);
                    DateTime enddate = Convert.ToDateTime(reader[4]);
                    int min = Convert.ToInt32(reader[5]);
                    int max = Convert.ToInt32(reader[6]);
                    string city = reader[7].ToString();
                    string address = reader[8].ToString();

                    var field = reader[9] != DBNull.Value ? reader[9].ToString() : "";
                    TournamentStatus s = (TournamentStatus)Enum.Parse(typeof(TournamentStatus), field);

                    Tournament tournament = new TournamentRoundRobin(idT, cSport, description, startdate, enddate, min, max, city, address, s);
                    tournaments.Add(tournament);
                }
                return tournaments;

            }
            catch (Exception)
            {
                throw;
            }
            finally { connection.Close(); }
        }
        public void UpdateTournament(Tournament tournament)
        {
            try
            {
                connection.Open();
                string SQL = "UPDATE `tournament` SET `description`=@desc,`startDate`=@start," +
                    "`endDate`=@end,`minParticipants`=@min,`maxParticipants`=@max,`city`=@city,`address`=@address,`status`=@status WHERE id =@id";
                MySqlCommand cmd = new MySqlCommand(SQL, connection);
                cmd.Parameters.AddWithValue("@id", tournament.Id);
                cmd.Parameters.AddWithValue("@desc", tournament.Description);
                cmd.Parameters.AddWithValue("@start", tournament.StartDate);
                cmd.Parameters.AddWithValue("@end", tournament.EndDate);
                cmd.Parameters.AddWithValue("@min", tournament.MinParticipants);
                cmd.Parameters.AddWithValue("@max", tournament.MaxParticipants);
                cmd.Parameters.AddWithValue("@city", tournament.City);
                cmd.Parameters.AddWithValue("@address", tournament.Address);
                cmd.Parameters.AddWithValue("@status", (int)tournament.Status);
                cmd.ExecuteNonQuery();
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
        public Tournament GetTournamnetById(int id)
        {
            try
            {
                connection.Open();
                string SQL = "SELECT * FROM tournament WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(SQL, connection);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //nz dali e neobhodimo
                    int idT = Convert.ToInt32(reader[0]);
                    ISportType cSport = null;
                    if (Convert.ToInt32(reader[1]) == 1)
                    {
                        cSport = new Badminton();
                    }
                    else if (Convert.ToInt32(reader[1]) == 2)
                    {
                        cSport = new Boxing();
                    }
                    string description = reader[2].ToString();
                    DateTime startdate = Convert.ToDateTime(reader[3]);
                    DateTime enddate = Convert.ToDateTime(reader[4]);
                    int min = Convert.ToInt32(reader[5]);
                    int max = Convert.ToInt32(reader[6]);
                    string city = reader[7].ToString();
                    string address = reader[8].ToString();

                    var field = reader[9] != DBNull.Value ? reader[9].ToString() : "";
                    TournamentStatus s = (TournamentStatus)Enum.Parse(typeof(TournamentStatus), field);

                    TournamentRoundRobin tournament = new TournamentRoundRobin(idT, cSport, description, startdate, enddate, min, max, city, address, s);
                    return tournament;
                }
                return null;
               
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
        public List<Tournament> GetTournamentsByPlayerId(int id)
        {
            try
            {
                connection.Open();
                List<Tournament> tournaments = new List<Tournament>();
                string sql = "select * from tournament inner join signuptournament on signuptournament.tournamentID = tournament.id where signuptournament.participantID = @id";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int idT = Convert.ToInt32(reader[0]);
                    ISportType cSport = null;
                    if (Convert.ToInt32(reader[1]) == 1)
                    {
                        cSport = new Badminton();
                    }
                    else if (Convert.ToInt32(reader[1]) == 2)
                    {
                        cSport = new Boxing();
                    }
                    string description = reader[2].ToString();
                    DateTime startdate = Convert.ToDateTime(reader[3]);
                    DateTime enddate = Convert.ToDateTime(reader[4]);
                    int min = Convert.ToInt32(reader[5]);
                    int max = Convert.ToInt32(reader[6]);
                    string city = reader[7].ToString();
                    string address = reader[8].ToString();

                    var field = reader[9] != DBNull.Value ? reader[9].ToString() : "";
                    TournamentStatus s = (TournamentStatus)Enum.Parse(typeof(TournamentStatus), field);

                    TournamentRoundRobin tournament = new TournamentRoundRobin(idT, cSport, description, startdate, enddate, min, max, city, address, s);
                    tournaments.Add(tournament);
                }
                return tournaments;

            }
            catch (Exception)
            {
                throw;
            }
            finally { connection.Close(); }
        }
        public void SignInForTournament(int tournamentId, int playerId)
        {
            try
            {
                connection.Open();
                string SQL = "INSERT INTO `signuptournament`(`tournamentID`, `participantID`) VALUES (@tournamentId,@playerId)";
                MySqlCommand cmd = new MySqlCommand(SQL, connection);
                cmd.Parameters.AddWithValue("@tournamentId", tournamentId);
                cmd.Parameters.AddWithValue("@playerId", playerId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally { connection.Close(); }

        }
        public bool IsSignedUp(int tournamentId, int playerId)
        {
            bool signed = false;
            try
            {
                connection.Open();
                string SQL = "SELECT COUNT(*) FROM `signuptournament` WHERE participantID =@playerId AND tournamentID=@tournamentId";
                MySqlCommand cmd = new MySqlCommand(SQL, connection);
                cmd.Parameters.AddWithValue("@tournamentId", tournamentId);
                cmd.Parameters.AddWithValue("@playerId", playerId);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    signed = true;
                }
                else
                {
                    signed = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { connection.Close(); }
            return signed; 
        }
        public int GetCountOfCurrent(int tournamentId)
        {
            try
            {
                connection.Open();
                string SQL = "SELECT COUNT(*) FROM `signuptournament` WHERE tournamentID=@id";
                MySqlCommand cmd = new MySqlCommand(SQL, connection);
                cmd.Parameters.AddWithValue("@id", tournamentId);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
               
                    return count;
                
            }
            catch (Exception)
            {
                throw;
            }
            finally { connection.Close(); }
        }
        public int GetCountOfGamesByTournamentId(int tournamentId)
        {
            try
            {
                connection.Open();
                string SQL = "SELECT COUNT(g.id) FROM game g WHERE tournamentId=@id";
                MySqlCommand cmd = new MySqlCommand(SQL, connection);
                cmd.Parameters.AddWithValue("@id", tournamentId);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count;
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
        public List<Tournament> GetAllAvailableTournamentsBySportId(int id)
        {
            try
            {
                connection.Open();
                List<Tournament> tournaments = new List<Tournament>();
                string sql = "select * from tournament where tournament.sportId=@id and tournament.status='AVAILABLE'";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int idT = Convert.ToInt32(reader[0]);
                    ISportType cSport = null;
                    if (Convert.ToInt32(reader[1]) == 1)
                    {
                        cSport = new Badminton();
                    }
                    else if (Convert.ToInt32(reader[1]) == 2)
                    {
                        cSport = new Boxing();
                    }
                    string description = reader[2].ToString();
                    DateTime startdate = Convert.ToDateTime(reader[3]);
                    DateTime enddate = Convert.ToDateTime(reader[4]);
                    int min = Convert.ToInt32(reader[5]);
                    int max = Convert.ToInt32(reader[6]);
                    string city = reader[7].ToString();
                    string address = reader[8].ToString();

                    var field = reader[9] != DBNull.Value ? reader[9].ToString() : "";
                    TournamentStatus s = (TournamentStatus)Enum.Parse(typeof(TournamentStatus), field);

                    TournamentRoundRobin tournament = new TournamentRoundRobin(idT, cSport, description, startdate, enddate, min, max, city, address, s);
                    tournaments.Add(tournament);
                }
                return tournaments;

            }
            catch (Exception)
            {
                throw;
            }
            finally { connection.Close(); }
        }
    }
}
