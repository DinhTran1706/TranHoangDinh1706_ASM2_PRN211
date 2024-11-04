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
    public class CandidateProfileService : ICandidateProfileService
    {
        private readonly ICandidateProfileRepo profileRepo;

        public CandidateProfileService()
        {
            profileRepo = new CandidateProfileRepo();
        }

        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            return profileRepo.AddCandidateProfile(candidateProfile);
        }

        public bool DeleteCandidateProfile(string id)
        {
            return profileRepo.DeleteCandidateProfile(id);
        }

        public CandidateProfile GetCandidateProfile(string id)
        {
            return profileRepo.GetCandidateProfile(id);
        }

        public ArrayList GetCandidates()
        {
            return profileRepo.GetCandidates();
        }

        public ArrayList SearchByName(string name)
        {
            return profileRepo.SearchByName(name);
        }

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            return profileRepo.UpdateCandidateProfile(candidateProfile);
        }
    }
}
