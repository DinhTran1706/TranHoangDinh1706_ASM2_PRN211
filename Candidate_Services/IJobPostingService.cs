using Candidate_BusinessObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public interface IJobPostingService
    {
        public ArrayList GetJobPostings();
        public JobPosting GetJobPosting(string id);
        public bool AddJobPosting(JobPosting jobPosting);
        public bool DeleteJobPosting(string id);
        public bool UpdateJobPosting(JobPosting jobPosting);
    }
}
