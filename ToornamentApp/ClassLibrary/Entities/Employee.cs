using ClassLibrary.enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public class Employee : Person
    {
        private EmployeeRole role;
        //private int associationId;

        public EmployeeRole Role { get { return role; } set { role = value; } }
        //public int AssociationId { get { return associationId; } set { associationId = value; } }

        public Employee(int id, string fname, string lname, string password, string key, string email, string phone, EmployeeRole role/*, int associationid*/) 
            : base(id, fname, lname, password, key, email, phone)
        {
            this.role = role;
            //this.associationId = associationid;
        }

        public Employee( string fname, string lname, string password, string email, string phone, EmployeeRole role/*, int associationid*/)
            : base( fname, lname, password, email, phone)
        {
            this.role = role;
        }
        public Employee()
        {
        }

        public override bool Equals(Object obj)
        {
            if (obj is Employee)
            {
                var that = obj as Employee;
                return this.Id.Equals(that.Id) &&
                    this.FirstName.Equals(that.FirstName) &&
                    this.LastName.Equals(that.LastName) &&
                    this.Password.Equals(that.Password) &&
                    this.Key.Equals(that.Key) &&
                    this.Email.Equals(that.Email) &&
                    this.Phone.Equals(that.Phone) &&
                    this.Role.Equals(that.Role);
            }

            return false;
        }
    }
}
