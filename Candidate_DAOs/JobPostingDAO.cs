using Candidate_BusinessObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAOs
{
    public class JobPostingDAO
    {
        private ArrayList jobPostingArrayList;
        private static JobPostingDAO instance;
        public static JobPostingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JobPostingDAO();
                }
                return instance;
            }
        }
        public JobPostingDAO()
        {
            jobPostingArrayList = new ArrayList
            {
                new JobPosting
            {
                PostingId = "P0001",
                JobPostingTitle = "System Administrator Specialist (MS Exchange, AD Voice)",
                Description = "As our company is growing and we offer more service to our teams, we are looking for a Senior System engineer with a broad set of expertise in Messaging, voice systems, mail gateways, encryption (smime), etc.",
                PostedDate = DateTime.Parse("2022-07-01")
            },
            new JobPosting
            {
                PostingId = "P0002",
                JobPostingTitle = "IT Security Manager",
                Description = "Establish the Information Security Plan toward to updated ISO Framework as well as in alignment with IT Strategic Plan",
                PostedDate = DateTime.Parse("2022-07-01")
            },
            new JobPosting
            {
                PostingId = "P0003",
                JobPostingTitle = "(Senior) IT Recruitment Consultant",
                Description = "Developing and maintaining loyal business relationship with them aligning with our company and team business strategies",
                PostedDate = DateTime.Parse("2022-07-01")
            },
            new JobPosting
            {
                PostingId = "P0004",
                JobPostingTitle = "Senior Network Security Engineer",
                Description = "In this role you will provide Security Subject Matter technical and leadership, expertise, support and consultancy/advice within relevant service levels for several cyber security technology systems and services currently in use across NAB.",
                PostedDate = DateTime.Parse("2022-07-01")
            },
            new JobPosting
            {
                PostingId = "P0005",
                JobPostingTitle = "Mobile Game Developer",
                Description = "Responsible for QA phase of those large-scale projects (or multi projects) with 7-8 members. Responsibilities are to instruct the team on quality metrics and testing strategies for each project.",
                PostedDate = DateTime.Parse("2022-07-01")
            }
            };
        }
        public ArrayList GetJobPostings()
        {
            return jobPostingArrayList;
        }

        public JobPosting GetJobPosting(string id)
        {
            foreach(JobPosting job in jobPostingArrayList)
            {
                if(job.PostingId == id) 
                    return job;
            }
            return null;
        }
        
        public bool AddJobPostings(JobPosting jobPosting)
        {
            if(GetJobPosting(jobPosting.PostingId) == null)
            {
                jobPostingArrayList.Add(jobPosting);
                return true;
            }
            return false;
        }

        public bool DeleteJobPostings(string id)
        {
            if(GetJobPosting(id) != null)
            {
                jobPostingArrayList.Remove(id);
                return true;
            }
            return false;
        }

        public bool UpdateJobPostings(JobPosting jobPosting)
        {
            
            for(int i = 0; i < jobPostingArrayList.Count; i++)
            {
                JobPosting existingPost = (JobPosting)jobPostingArrayList[i];
                if (existingPost.PostingId == jobPosting.PostingId)
                {
                    jobPostingArrayList[i] = jobPosting;
                    return true;
                }
            }
            return false;
        }
    }
}
