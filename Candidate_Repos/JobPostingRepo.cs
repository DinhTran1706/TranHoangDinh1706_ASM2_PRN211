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
    public class JobPostingRepo : IJobPostingRepo
    {
        public ArrayList GetJobPostings() => JobPostingDAO.Instance.GetJobPostings();
        public JobPosting GetJobPosting(String id) => JobPostingDAO.Instance.GetJobPosting(id);
        public bool AddJobPosting(JobPosting jobPosting) => JobPostingDAO.Instance.AddJobPostings(jobPosting);
        public bool DeleteJobPosting(String id) => JobPostingDAO.Instance.DeleteJobPostings(id);
        public bool UpdateJobPosting(JobPosting jobPosting) => JobPostingDAO.Instance.UpdateJobPostings(jobPosting);
    }
}
