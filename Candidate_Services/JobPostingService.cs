using Candidate_BusinessObjects;
using Candidate_Repos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public class JobPostingService : IJobPostingService
    {
        private readonly IJobPostingRepo jobPostingRepo;
        public JobPostingService()
        {
            jobPostingRepo = new JobPostingRepo();
        }

        public bool AddJobPosting(JobPosting jobPosting)
        {
            return jobPostingRepo.AddJobPosting(jobPosting);
        }

        public bool DeleteJobPosting(string id)
        {
            return jobPostingRepo.DeleteJobPosting(id);
        }

        public JobPosting GetJobPosting(string id)
        {
            return jobPostingRepo.GetJobPosting(id);
        }

        public ArrayList GetJobPostings()
        {
            return jobPostingRepo.GetJobPostings();
        }

        public bool UpdateJobPosting(JobPosting jobPosting)
        {
            return jobPostingRepo.UpdateJobPosting(jobPosting);
        }
    }
}
