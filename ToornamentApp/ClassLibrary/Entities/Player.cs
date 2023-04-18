using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public class Player : Person
    {
        private string username;
       

        public string Username { get { return username; } set { username = value; } }
      
        public Player(int id, string fname, string lname, string password, string email, string phone, string username/*, int wins, int losts, int rank*/) : base(id, fname, lname, password, email, phone)
        {
            this.username = username;
        }
        public Player(int id, string fname, string lname, string password, string key, string email, string phone, string username) : base(id, fname, lname, password,key, email, phone)
        {
            this.username = username;
        }
        public Player(string fname, string lname, string password, string email, string phone, string username) : base(fname, lname, password, email, phone)
        {
            this.username = username;
        }
        public Player(int id, string username, string fname, string lname):base(id)
        {
            this.username = username;
            this.FirstName = fname;
            this.LastName = lname;
        }
        public Player() { }

        public override string ToString()
        {
            return base.ToString();
        }


        public override bool Equals(Object obj)
        {
            if (obj is Player)
            {
                var that = obj as Player;
                return this.Id.Equals(that.Id) &&
                    this.FirstName.Equals(that.FirstName) &&
                    this.LastName.Equals(that.LastName) &&
                    this.Password.Equals(that.Password) &&
                    this.Key.Equals(that.Key) &&
                    this.Email.Equals(that.Email) &&
                    this.Phone.Equals(that.Phone) &&
                    this.Username.Equals(that.Username);
            }

            return false;
        }
    }
}
