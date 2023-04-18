using ClassLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public class Badminton : ISportType
    {
        //public int Id { get { return 1; } }
        //public string Name { get{ return "Badminton"; }}

        public int GetId()
        {
            return 1;
        }

        public string GetName()
        {
            return "Badminton";
        }
        public bool ValidateScore(int scoreOne, int scoreTwo)
        {
            if (scoreOne == scoreTwo)
            {
                return false;
            }

            if (scoreOne < 21 && scoreTwo < 21)
            {
                return false;
            }

            if (scoreOne > 30 | scoreTwo > 30) 
            {
                return false;
            }

            int absoluteValue = Math.Abs(scoreOne - scoreTwo);

            if (scoreOne > 20 && scoreTwo > 20)
            {
                if (absoluteValue > 2)
                {
                    return false;
                }
            }

            if (absoluteValue < 2)
            {
                if (scoreOne < 29 || scoreTwo < 29)
                {
                    if (absoluteValue == 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        
        public override bool Equals(Object obj)
        {
            if (obj is Badminton)
            {
                var that = obj as Badminton;
                return this.GetId().Equals(that.GetId()) &&
                    this.GetName().Equals(that.GetName());
            }

            return false;
        }
    }
}
