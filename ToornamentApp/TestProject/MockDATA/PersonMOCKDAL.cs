using ClassLibrary.Entities;
using ClassLibrary.enumerators;
using ClassLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.MockDATA
{
    public class PersonMOCKDAL : IPerson
    {
        Player player = new Player(1, "sharenda", "peeters", "5422", "key", "sharenda@gmail.com", "0897854211", "sharen");
        Player player2 = new Player(7, "kiki", "peeters", "5422", "key", "sharenda@gmail.com", "0897854211", "sharen");
        Employee emp = new Employee(2, "Ivana", "Nedelkova", "1234", "key", "ivanaaa@gmail.com", "0898563325", EmployeeRole.ADMIN);
        Employee emp2 = new Employee(3, "Kris", "Todorov", "1234", "key", "kris@gmail.com", "0898963325", EmployeeRole.ADMIN);
        Employee emp3 = new Employee(3, "Kris", "Todorov", "1234", "key", "kris@gmail.com", "0898963325", EmployeeRole.ORGANIZER);
        List<Employee> employees = new List<Employee>();
        public bool CompareGivenPassword(string email, string password)
        {
            string emailMock = "sharenda@gmail.com";
            string passwordMock = "5422";
            if (emailMock == email && passwordMock == password)
            {
                return true;
            }
            return false;
        }

        public void CreatePerson(Person person)
        {
            
        }

        public bool DeletePerson(Person person)
        {
            if (person.Id == 1)
            {
                return true;
            }
            return false;
        }

        public List<Employee> GetEmployeesByRole(EmployeeRole r)
        {
            if (EmployeeRole.ORGANIZER == r)
            {
                employees.Add(emp);
                employees.Add(emp2);
                return employees;
            }
            else if(r== EmployeeRole.ADMIN)
            {
                employees.Add(emp3);
                return employees;
            }
            List<Employee> list = new List<Employee>();
            return list;
        }

        public List<Player> GetSignedPlayersForTournament(int tournamentId)
        {
            if (tournamentId == 1)
            {
                List<Player> persons = new List<Player>();
                persons.Add(player);
                persons.Add(player2);
                return persons;
            }
           List<Player> list = new List<Player>();
            return list;
        }

        public bool IsAvailable(string username, int id)
        {
            string mockUsername = "shar";
            if (mockUsername == username && id ==2)
            {
                return false;
            }
            return true;
        }

        public bool isEmailTaken(string email)
        {
            string mockemail = "ivana@gmail.com";
            if (mockemail == email)
            {
                return true;
            }
            return false;
        }

        public bool IsTaken(string username)
        {
            string mockUsername = "sharry2";
            if (mockUsername == username)
            {
                return true;
            }
            return false;
        }

        public Person ReadById(int id)
        {
            if (id ==1)
            {
                return player;

            }
            else if(id==2)
            {
                return emp;
            }
            Player p = new Player();
            return p;
            //return null;
        }

        public Person ReadPersonByEmail(string email)
        {
            return player;
        }
    }
}
