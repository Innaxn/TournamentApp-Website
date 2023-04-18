using ClassLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public class Boxing : ISportType
    {
        //public int Id { get { return 2; } }
        //public string Name { get { return "Boxing"; } }

        public int GetId()
        {
            return 2;
        }

        public string GetName()
        {
            return "Boxing";
        }

        public bool ValidateScore(int scoreOne, int scoreTwo)
        {
            if (scoreOne != scoreTwo && scoreOne > 0 && scoreTwo > 0 && scoreTwo <= 120 && scoreOne <= 120)
            {
                return true;
            }

            return false;
        }

    }
}
