using Candidate_BusinessObjects;
using Candidate_DAOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repos
{
    public class HRAccountRepo : IHRAccountRepo
    {
        public Hraccount GetHraccountByEmail(string email) => HRAccountDAO.Instance.GetHraccountByEmail(email);

        public ArrayList GetHraccounts() => HRAccountDAO.Instance.GetHraccounts();
    }
}
