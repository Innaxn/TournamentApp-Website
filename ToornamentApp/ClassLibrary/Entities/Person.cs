using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public abstract class Person
    {
        private int id;
        private string firstName;
        private string lastName;
        private string password;
        private string email;
        private string phone;
        private string key;

        public int Id { get { return id; } set { id = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Phone { get { return phone; } set { phone = value; } }
        public string Key { get { return key; } }
        public Person(int id, string fname, string lname, string password, string key, string email, string phone)
        {
            this.id = id;
            this.firstName = fname;
            this.lastName = lname;
            this.password = password;
            this.key = key;
            this.email = email;
            this.phone = phone;
        }

        public Person(string fname, string lname, string password, string email, string phone)
        {
            this.firstName = fname;
            this.lastName = lname;
            this.password = password;
            this.email = email;
            this.phone = phone;
        }

        protected Person(int id, string fname, string lname, string password, string email, string phone)
        {
            this.id = id;
            this.firstName = fname;
            this.lastName = lname;
            this.password = password;
            this.email = email;
            this.phone = phone;
        }

        protected Person(int id)
        {
            this.id = id;
        }
        protected Person() { }

        public override string ToString()
        {
            return $"{FirstName} - {LastName}";
        }

        //public string GetNames()
        //{
        //    return $"{FirstName} - {LastName}";
        //}

        public bool IsValidPhone(string phone)
        {
            try
            {
                Regex regex = new Regex(@"^(^[0][1-9]\d{8}$)+$");
                Match match = regex.Match(phone);
                if (match.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool IsEmailValid(string email)
        {
            try
            {
                string checkEmail = email;
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
                if (match.Success)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }
    }
}
