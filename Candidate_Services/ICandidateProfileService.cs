using Candidate_BusinessObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Services
{
    public interface ICandidateProfileService
    {
        public ArrayList GetCandidates();
        public ArrayList SearchByName(string name);

        public CandidateProfile GetCandidateProfile(string id);

        public bool AddCandidateProfile(CandidateProfile candidateProfile);

        public bool DeleteCandidateProfile(string id);

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile);
    }
}
