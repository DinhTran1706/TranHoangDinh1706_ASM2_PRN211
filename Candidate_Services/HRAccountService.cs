using Candidate_BusinessObjects;
using Candidate_DAOs;
using Candidate_Repos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public class HRAccountService : IHRAccountService
    {
        private readonly IHRAccountRepo iAccountRepo;

        public HRAccountService()
        {
            iAccountRepo = new HRAccountRepo();
        }
        public Hraccount GetHraccountByEmail(string email) => HRAccountDAO.Instance.GetHraccountByEmail(email);
        public ArrayList GetHraccounts() => HRAccountDAO.Instance.GetHraccounts();
    }
}
