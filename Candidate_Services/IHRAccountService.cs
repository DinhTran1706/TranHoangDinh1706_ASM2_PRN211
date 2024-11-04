using Candidate_BusinessObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public interface IHRAccountService 
    {
        public Hraccount GetHraccountByEmail(String email);

        public ArrayList GetHraccounts();
    }
}
