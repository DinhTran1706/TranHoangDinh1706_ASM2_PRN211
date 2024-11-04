using Candidate_BusinessObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAOs
{
    public class HRAccountDAO
    {
        private ArrayList AccountArrayList;

        private static HRAccountDAO instance = null;

        public HRAccountDAO()
        {
            AccountArrayList = new ArrayList
            {
                new Hraccount{Email= "admin@hr.com.vn", FullName="Admin HR", Password="123@", MemberRole= 1},
                new Hraccount{Email= "manager@hr.com.vn", FullName="Manager HR", Password="123@", MemberRole= 2},
                new Hraccount{Email= "staff@hr.com.vn", FullName="Staff HR", Password="123@", MemberRole= 3}
            };
        }
        public static HRAccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HRAccountDAO();
                }
                return instance;
            }
        }

        public Hraccount GetHraccountByEmail(String email)
        {
            foreach(Hraccount h in AccountArrayList)
            {
                if(h.Email == email)
                {
                    return h;
                }
            }
            return null;
        }

        public ArrayList GetHraccounts()
        {
            return AccountArrayList;
        }
    }

}

