using ClassLibrary.Entities;
using ClassLibrary.enumerators;
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
    public  class PersonServiceTests
    {
        PersonServices p = new PersonServices(new PersonMOCKDAL());
        PersonMOCKDAL personMock = new PersonMOCKDAL();
        
        [TestMethod]
        public void GetPersonById_AreEqual()
        {
            PersonMOCKDAL personMock = new PersonMOCKDAL();
            Person expectedPerson = personMock.ReadById(1);

            Person actualPerson = p.GetPersonById(1);

            Assert.AreEqual(expectedPerson, actualPerson);
        }

        [TestMethod]
        public void GetPersonById_WhenWrongId_AreNotEqual()
        {
            PersonMOCKDAL personMock = new PersonMOCKDAL();
            Person expectedPerson = personMock.ReadById(1);

            Person actualPerson = p.GetPersonById(15);

            Assert.AreNotEqual(expectedPerson, actualPerson);
        }

        [TestMethod]
        public void GetEmplyeesByRole_AreEqual()
        {
            List<Employee> expectedPerson = personMock.GetEmployeesByRole(EmployeeRole.ADMIN);

            List<Employee> actualPerson = p.GetEmployeesByRole(EmployeeRole.ADMIN);

            CollectionAssert.AreEqual(expectedPerson.Select(x => x.Id).ToList(), actualPerson.Select(x => x.Id).ToList());
        }

        [TestMethod]
        public void GetEmplyeesByRole_AreNotEqual()
        {
            List<Employee> expectedPerson = personMock.GetEmployeesByRole(EmployeeRole.ADMIN);

            List<Employee> actualPerson = p.GetEmployeesByRole(EmployeeRole.ORGANIZER);

            CollectionAssert.AreNotEqual(expectedPerson.Select(x => x.Id).ToList(), actualPerson.Select(x => x.Id).ToList());
        }

        [TestMethod]
        public void GetSignedPlayersForATournament_AreEqual()
        {
            List<Player> expected = personMock.GetSignedPlayersForTournament(1);
            List<Player> actual = p.GetSignedPlayersForTournament(1);
            CollectionAssert.AreEqual(expected.Select(x=>x.Id).ToList(), actual.Select(x => x.Id).ToList());
        }

        [TestMethod]
        public void GetSignedPlaeyrsForATournament_NotEqual()
        {
            List<Player> expected = personMock.GetSignedPlayersForTournament(1);
            List<Player> actual = p.GetSignedPlayersForTournament(2);
            CollectionAssert.AreNotEqual(expected.Select(x => x.Id).ToList(), actual.Select(x => x.Id).ToList());
        }

        [TestMethod]
        public void DeletePerson_NonExisting()
        {
            Person person = new Employee(7, "test", "test", "123", "key", "email", "0896563233", EmployeeRole.ORGANIZER);
            //non existing
            bool check = p.DeletePerson(person);

            Assert.IsFalse(check);
        }

        [TestMethod]
        public void DeletePerson_Existing()
        {
            Person person = new Player(1, "sharenda", "peeters", "5422", "key", "sharenda@gmail.com", "0897854211", "sharen");
            //existing
            bool check = p.DeletePerson(person);

            Assert.IsFalse(!check);
        }
        [TestMethod]
        public void CompareGivenPasswordEmployee_Succsess()
        {
            string email = "sharenda@gmail.com";
            string pass = "5422";

            bool check = p.CompareGivenPassword(email, pass);
            Assert.IsTrue(check);
        }
        [TestMethod]
        public void CompareGivenPasswordEmployee_False()
        {
            string email = "sharenda@gmail.com";
            string pass = "54222222";

            bool check = p.CompareGivenPassword(email, pass);
            Assert.IsFalse(check);
        }

        [TestMethod]
        public void AddEmployee_EverythingIsValid_AreEqual()///!!!!!!!!!!!
        {
            //Arrange
            Person expectedEmployee = new Employee(2, "Ivana", "Nedelkova", "1234", "key", "ivanaaa@gmail.com", "0898563325", EmployeeRole.ADMIN);
            bool IsPhoneValid = expectedEmployee.IsValidPhone(expectedEmployee.Phone);
            bool IsEmailTaken = p.IsEmailTaken(expectedEmployee.Email);
            bool IsEmailValid = expectedEmployee.IsEmailValid(expectedEmployee.Email);
            //act
            if (IsPhoneValid && IsEmailValid && !IsEmailTaken)
            {
                p.Registration(expectedEmployee);
            }
            Person actualPerson = p.GetPersonById(2);

            //Assert
            Assert.AreEqual(expectedEmployee, actualPerson);
        }

        [TestMethod]
        public void AddPlayer_EverythingIsValid_AreEqual()
        {
            //Arrange
            Player expectedPlayer = new Player(1, "sharenda", "peeters", "5422", "key", "sharenda@gmail.com", "0897854211", "sharen");
            bool IsPhoneValid = expectedPlayer.IsValidPhone(expectedPlayer.Phone);
            bool IsEmailTaken = p.IsEmailTaken(expectedPlayer.Email);
            bool IsEmailValid = expectedPlayer.IsEmailValid(expectedPlayer.Email);
            bool IsUsernameTaken = p.IsUsernameTaken(expectedPlayer.Username);
            //act
            if (IsPhoneValid && IsEmailValid && !IsEmailTaken && !IsUsernameTaken)
            {
                p.Registration(expectedPlayer);
            }
            Person actualPerson = p.GetPersonById(1);

            //Assert
            Assert.AreEqual(expectedPlayer, actualPerson);
        }

        [TestMethod]
        public void TryAddingPlayer_UsernameTaken()
        {
            Player expectedPlayer = new Player(1, "sharenda", "peeters", "5422", "key", "sharenda@gmial.com", "0897854211", "sharry2");
            bool check = p.IsUsernameTaken(expectedPlayer.Username);

            Assert.IsTrue(check);
        }
        [TestMethod]
        public void TryAddingPerson_EmailTaken()
        {
            Person expectedPerson = new Employee(1, "sharenda", "peeters", "5422", "key", "ivana@gmail.com", "0897854211", EmployeeRole.ORGANIZER);
            bool check = p.IsEmailTaken(expectedPerson.Email);

            Assert.IsTrue(check);
        }
        [TestMethod]
        public void TryAddingPerson_PhoneNumberUnvalid()
        {
            Person per = new Player();
            string phoneNumber = "0895asdd22";
            bool check = per.IsValidPhone(phoneNumber);

            Assert.IsFalse(check);
        }
        [TestMethod]
        public void TryAddingPerson_EmailAddressUnvalid()
        {
            Person per = new Player();
            string email = "unvalid@adsadasdadas";
            bool check = per.IsEmailValid(email);

            Assert.IsFalse(check);
        }

        [TestMethod]
        public void GetEmployeeByEmail_AreEqual()
        {
            Person expectedPerson = personMock.ReadPersonByEmail("sharenda@gmail.com");
            Person actualPerson = p.ReadPersonByEmail(expectedPerson.Email);

            Assert.AreEqual(expectedPerson, actualPerson);
        }

        [TestMethod]
        public void GetEmployeeByEmail_AreNotEqual()
        {
            Person expectedPerson = personMock.ReadPersonByEmail("noext");
            Person actualPerson = p.ReadPersonByEmail(expectedPerson.Email);

            Assert.AreEqual(expectedPerson, actualPerson);
        }
    }
}
