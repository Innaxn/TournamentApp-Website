using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    [Serializable]
    public class IncorectDateException : Exception
    {
        public IncorectDateException(DateTime date, DateTime date2) : base(String.Format("Incorrect dates {0} and {1}. There must be at least 14 days between the strat and todays date!", date.ToShortDateString(), date2.ToShortDateString()))
        {}
    }
    [Serializable]
    public class IsAmountOfPlayersIncorrect : Exception
    {
        public IsAmountOfPlayersIncorrect() : base(String.Format("Incorrect amount of players. You must include min more than 2"))
        {}
    }
    [Serializable]
    public class IncorrectAmountAndDates : Exception
    {
        public IncorrectAmountAndDates() : base(String.Format("Incorrect amount of players and dates"))
        { }
    }
    [Serializable]
    public class IncorrectAmountOfSignedPlayers : Exception
    {
        public IncorrectAmountOfSignedPlayers(int count) : base(String.Format("Incorrect! There are already {0} participants signed in for the tournament, you cant decrease the maximum or the minimum!", count))
        { }
    }

    [Serializable]
    public class GenerateGamesError : Exception
    {
        public GenerateGamesError() : base(String.Format("The games are already generated."))
        { }
    }

    [Serializable]
    public class IncorrectResult : Exception
    {
        public IncorrectResult() : base(String.Format("The results is not added."))
        { }
    }

    [Serializable]
    public class InvalidEmail : Exception
    {
        public InvalidEmail() : base(String.Format("The email is not valid."))
        { }
    }

    [Serializable]
    public class TakenEmail : Exception
    {
        public TakenEmail() : base(String.Format("The email is taken."))
        { }
    }
    [Serializable]
    public class InvalidPhone : Exception
    {
        public InvalidPhone() : base(String.Format("The phone number is invalid."))
        { }
    }

    [Serializable]
    public class UsernameTaken : Exception
    {
        public UsernameTaken() : base(String.Format("The username is already taken."))
        { }
    }
    
    [Serializable]
    public class PedingException : Exception
    {
        public PedingException() : base(String.Format("You cant change the status to pending."))
        { }
    }
    [Serializable]
    public class InprogressNotPossible : Exception
    {
        public InprogressNotPossible() : base(String.Format("You cant change the status to inprogress."))
        { }
    }

    [Serializable]
    public class IncorrectDateUpdate : Exception
    {
        public IncorrectDateUpdate(DateTime date, DateTime date2) : base(String.Format("Incorrect dates {0} and {1}. There must be at least 14 days between the strat and todays date!", date.ToShortDateString(), date2.ToShortDateString()))
        { }
    }
}
