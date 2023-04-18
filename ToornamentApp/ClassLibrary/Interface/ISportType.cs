using ClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interface
{
    public interface ISportType
    {
        int GetId();
        string GetName();
        bool ValidateScore(int scoreOne, int scoreTwo);
    }
}
