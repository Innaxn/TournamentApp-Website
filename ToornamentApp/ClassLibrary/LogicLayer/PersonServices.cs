using ClassLibrary.Entities;
using ClassLibrary.Interface;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Cryptography;
using ClassLibrary.enumerators;

namespace ClassLibrary.LogicLayer
{
    public class PersonServices 
    {
        private IPerson iperson;

        public PersonServices(IPerson dalPerson)
        {
            iperson = dalPerson;
        }

        public bool DeletePerson(Person p)
        {
            try
            {
                return iperson.DeletePerson(p);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Registration(Person person)
        {

            if (person is Player)
            {
                Player person1 = (Player)person;
                if (!person.IsEmailValid(person.Email))
                {
                    throw new InvalidEmail();
                }
                else if (IsEmailTaken(person.Email))
                {
                    throw new TakenEmail();
                }
                else if (!person.IsValidPhone(person.Phone))
                {
                    throw new InvalidPhone();
                }
                else if (IsUsernameTaken(person1.Username))
                {
                    throw new UsernameTaken();
                }
                else
                {
                    iperson.CreatePerson(person1);
                }
            }
            else if (person is Employee)
            {
                if (!person.IsEmailValid(person.Email))
                {
                    throw new InvalidEmail();
                }
                else if (IsEmailTaken(person.Email))
                {
                    throw new TakenEmail();
                }
                else if (!person.IsValidPhone(person.Phone))
                {
                    throw new InvalidPhone();
                }
                else
                {
                    iperson.CreatePerson(person);
                }
            }
        }

        public Person GetPersonById(int id)
        {
            return iperson.ReadById(id);
        }

        public Person Login(string email, string password)
        {
            Person person = ReadPersonByEmail(email);
            if (person != null)
            {
                byte[] keyBytes = Convert.FromBase64String(person.Key);
                password = GeneratePassword(keyBytes, password);
                bool validPassword = CompareGivenPassword(email, password);
                if (validPassword) return person;
                else return null;
            }
            else
            {
                return null;
            }
        }

        public Person ReadPersonByEmail(string email)
        {
            return iperson.ReadPersonByEmail(email);
        }

        public bool IsUsernameTaken(string username)
        {
            return iperson.IsTaken(username);
        }

        public bool IsEmailTaken(string email)
        {
            return iperson.isEmailTaken(email);
        }
        public byte[] KeyWord() //creating a salting
        {
            byte[] key = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(key);
            }

            return key;
        }
        public string GeneratePassword(byte[] key, string password) //hashing 
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: key,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
            return hashed;
        }
        public bool CompareGivenPassword(string email, string password)
        {
            return iperson.CompareGivenPassword(email, password);
        }
        public List<Employee> GetEmployeesByRole(EmployeeRole r)
        {
            return iperson.GetEmployeesByRole(r);
        }
        public List<Player> GetSignedPlayersForTournament(int tournamentId)
        {
            List<Player> p = iperson.GetSignedPlayersForTournament(tournamentId);
            return p;
        }
    }
}
