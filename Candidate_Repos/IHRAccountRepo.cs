using Candidate_BusinessObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repos
{
    public interface IHRAccountRepo
    {
        public Hraccount GetHraccountByEmail(string email);

        public ArrayList GetHraccounts();
    }
}
