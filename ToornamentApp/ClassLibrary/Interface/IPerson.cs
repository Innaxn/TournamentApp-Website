using ClassLibrary.Entities;
using ClassLibrary.enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interface
{
    public interface IPerson
    {
        public void CreatePerson(Person person);
        public bool DeletePerson(Person person);
        public Person ReadById(int id);
        bool isEmailTaken(string email);
        bool IsTaken(string username);
        bool CompareGivenPassword(string email, string password);
        //Player ReadPlayerByUsername(string username);
        Person ReadPersonByEmail(string email);
        List<Employee> GetEmployeesByRole(EmployeeRole r);
        List<Player> GetSignedPlayersForTournament(int tournamentId);
    }
}
