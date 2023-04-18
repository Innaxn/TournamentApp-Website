using ClassLibrary.Entities;
using ClassLibrary.enumerators;
using ClassLibrary.Interface;
using ClassLibrary.LogicLayer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DATA_LAYER
{
    public class PersonDAL : DB_ConnectionString, IPerson
    {
        public void CreatePerson(Person person)
        {
            Toornament toornament = new Toornament();
            byte[] keyBytes = toornament.PersonServices.KeyWord();
            string _key = Convert.ToBase64String(keyBytes);
            string _password = toornament.PersonServices.GeneratePassword(keyBytes, person.Password);

            try
            {
                connection.Open();
                if (person is Player)
                {
                    string SQL = "INSERT INTO `person`(`id`, `type`, `firstName`, `lastName`, `email`, `password`, `keyValue`, `phoneNumber`) VALUES  (null,2, @fname,@lname,@email,@password,@key,@phone)";
                    MySqlCommand cmd = new MySqlCommand(SQL, connection);
                    cmd.Parameters.AddWithValue("@fname", person.FirstName);
                    cmd.Parameters.AddWithValue("@lname", person.LastName);
                    cmd.Parameters.AddWithValue("@email", person.Email);
                    cmd.Parameters.AddWithValue("@password", _password);
                    cmd.Parameters.AddWithValue("@key", _key);
                    cmd.Parameters.AddWithValue("@phone", person.Phone);
                    cmd.ExecuteNonQuery();

                    long playerID = cmd.LastInsertedId;

                    string SQL2 = "INSERT INTO `player`(`id`, `username`) VALUES (@id, @username)";
                    MySqlCommand command = new MySqlCommand(SQL2, connection);
                    command.Parameters.AddWithValue("@id", playerID);
                    command.Parameters.AddWithValue("@username", ((Player)person).Username);
                    command.ExecuteNonQuery();
                }
                else if (person is Employee)
                {
                    string SQL = "INSERT INTO `person`(`id`, `type`, `firstName`, `lastName`, `email`, `password`, `keyValue`, `phoneNumber`) VALUES  (null,1, @fname,@lname,@email,@password,@key,@phone)";
                    MySqlCommand cmd = new MySqlCommand(SQL, connection);
                    cmd.Parameters.AddWithValue("@fname", person.FirstName);
                    cmd.Parameters.AddWithValue("@lname", person.LastName);
                    cmd.Parameters.AddWithValue("@email", person.Email);
                    cmd.Parameters.AddWithValue("@password", _password);
                    cmd.Parameters.AddWithValue("@key", _key);
                    cmd.Parameters.AddWithValue("@phone", person.Phone);
                    cmd.ExecuteNonQuery();

                    long employeeID = cmd.LastInsertedId;

                    string SQL2 = "INSERT INTO `employee`(`id`, `role_id`) VALUES (@id,@role)";
                    MySqlCommand command = new MySqlCommand(SQL2, connection);
                    command.Parameters.AddWithValue("@id", employeeID);
                    command.Parameters.AddWithValue("@role", ((Employee)person).Role);
                    command.ExecuteNonQuery();
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
        public bool DeletePerson(Person person)
        {
            try
            {
                connection.Open();
                if (person is Player)
                {
                    string SQL = "DELETE a.*, b.* FROM person a LEFT JOIN player b ON b.id = a.id WHERE a.id = @id";
                    MySqlCommand cmd = new MySqlCommand(SQL, connection);
                    cmd.Parameters.AddWithValue("@id", person.Id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
                else if (person is Employee)
                {
                    string SQL = "DELETE a.*, b.* FROM person a LEFT JOIN employee b ON b.id = a.id WHERE a.id = @id";
                    MySqlCommand cmd = new MySqlCommand(SQL, connection);
                    cmd.Parameters.AddWithValue("@id", person.Id);
                    cmd.ExecuteNonQuery();
                    return true;
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

            return false;
        }
        public Person ReadById(int id)
        {
            try
            {
                connection.Open();
                string sql = "select person.*, employee.role_id, player.username FROM person LEFT JOIN employee ON person.id = employee.id LEFT JOIN player ON person.id=player.id WHERE person.id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (Convert.ToInt32(reader["type"]) == 1)
                    {
                        int idE = Convert.ToInt32(reader[0]);
                        int type = Convert.ToInt32(reader[1]);
                        string fname = reader["firstName"].ToString();
                        string lname = reader["lastName"].ToString();
                        string pass = reader["password"].ToString();
                        string key = reader["keyValue"].ToString();
                        string email = reader["email"].ToString();
                        string phone = reader["phoneNumber"].ToString();
                        var field = reader["role_id"] != DBNull.Value ? reader["role_id"].ToString() : "";
                        EmployeeRole role = (EmployeeRole)Enum.Parse(typeof(EmployeeRole), field);

                        Person newperson = new Employee(idE, fname, lname, pass, key, email, phone, role);
                    }
                    else if (Convert.ToInt32(reader["type"]) == 2)
                    {
                        int idP = Convert.ToInt32(reader[0].ToString());
                        int type = Convert.ToInt32(reader[1]);
                        string fname = reader["firstName"].ToString();
                        string lname = reader["lastName"].ToString();
                        string pass = reader["password"].ToString();
                        string email = reader["email"].ToString();
                        string phone = reader["phoneNumber"].ToString();
                        string username = reader["username"].ToString();

                        Person newperson = new Player(idP, fname, lname, pass, email, phone, username);
                    }
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
        public Person ReadPersonByEmail(string email)
        {
            try
            {
                Person person = null;
                string SQL = "select person.*, employee.role_id, player.username FROM person LEFT JOIN employee ON person.id = employee.id LEFT JOIN player ON person.id=player.id WHERE person.email = @email";
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(SQL, connection);
                cmd.Parameters.AddWithValue("@email", email);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader[1]) == 1)
                    {
                        int id = Convert.ToInt32(reader[0].ToString());
                        string fname = reader["firstName"].ToString();
                        string lname = reader["lastName"].ToString();
                        string pass = reader["password"].ToString();
                        string key = reader["keyValue"].ToString();
                        string emailE = reader["email"].ToString();
                        string phone = reader["phoneNumber"].ToString();
                        var field = reader["role_id"] != DBNull.Value ? reader["role_id"].ToString() : "";
                        EmployeeRole role = (EmployeeRole)Enum.Parse(typeof(EmployeeRole), field);

                        person = new Employee(id, fname, lname, pass, key, emailE, phone, role);
                        return person;
                    }
                    else if (Convert.ToInt32(reader[1]) == 2)
                    {
                        int idP = Convert.ToInt32(reader[0].ToString());
                        string fname = reader["firstName"].ToString();
                        string lname = reader["lastName"].ToString();
                        string pass = reader["password"].ToString();
                        string key = reader["keyValue"].ToString();
                        string emailP = reader["email"].ToString();
                        string phone = reader["phoneNumber"].ToString();
                        string usernameC = reader["username"].ToString();


                        person = new Player(idP, fname, lname, pass, key, emailP, phone, usernameC);
                        return person;
                    }
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
        public bool CompareGivenPassword(string email, string password)
        {
            bool succs = false;
            try
            {
                connection.Open();
                string SQL = "SELECT * FROM person WHERE person.email = @email AND person.password = @password";
                MySqlCommand cmd = new MySqlCommand(SQL, connection);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    succs = true;
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

            if (succs)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsTaken(string username)
        {
            try
            {
                connection.Open();
                string SQL = "SELECT * FROM player WHERE username = @username";
                MySqlCommand cmd = new MySqlCommand(SQL, connection);
                cmd.Parameters.AddWithValue("@username", username);
                if (cmd.ExecuteReader().HasRows)
                {
                    return true;
                }
                return false;
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
        public List<Employee> GetEmployeesByRole(EmployeeRole r)
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                connection.Open();
                string SQL = "SELECT * FROM person INNER JOIN employee ON person.id = employee.id WHERE employee.role_id = @role";
                MySqlCommand cmd = new MySqlCommand(SQL, connection);
                cmd.Parameters.AddWithValue("@role", r);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int idE = Convert.ToInt32(reader[0]);
                    string fname = reader["firstName"].ToString();
                    string lname = reader["lastName"].ToString();
                    string email = reader["email"].ToString();
                    string phone = reader["phoneNumber"].ToString();
                    var field = reader["role_id"] != DBNull.Value ? reader["role_id"].ToString() : "";
                    EmployeeRole role = (EmployeeRole)Enum.Parse(typeof(EmployeeRole), field);

                    Employee emp = new Employee(idE, fname, lname, null, null, email, phone, role);
                    employees.Add(emp);
                }
                return employees;
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
        public List<Player> GetSignedPlayersForTournament(int tournamentId)
        {
            List<Player> players = new List<Player>();
            try
            {
                connection.Open();
                string SQL = "SELECT* from person inner join player on person.id = player.id inner join signuptournament on signuptournament.participantID = player.id where tournamentID = @id";
                MySqlCommand cmd = new MySqlCommand(SQL, connection);
                cmd.Parameters.AddWithValue("@id", tournamentId);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int idE = Convert.ToInt32(reader[0]);
                    string fname = reader["firstName"].ToString();
                    string lname = reader["lastName"].ToString();
                    string email = reader["email"].ToString();
                    string phone = reader["phoneNumber"].ToString();
                    string username = reader["username"].ToString();

                    Player player = new Player(idE, fname, lname, null, null, email, phone, username);
                    players.Add(player);
                }
                return players;
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
        public bool isEmailTaken(string email)
        {
            try
            {
                connection.Open();
                string SQL = "SELECT * FROM person WHERE email = @email";
                MySqlCommand cmd = new MySqlCommand(SQL, connection);
                cmd.Parameters.AddWithValue("@email", email);
                if (cmd.ExecuteReader().HasRows)
                {
                    return true;
                }
                return false;
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
