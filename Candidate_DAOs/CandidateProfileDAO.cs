using Candidate_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAOs
{
    public class CandidateProfileDAO
    {
        private ArrayList candidateArrayList;
        private static CandidateProfileDAO instance;

        public static CandidateProfileDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new CandidateProfileDAO();
                return instance;
            }
        }

        public CandidateProfileDAO()
        {
            candidateArrayList = new ArrayList { 
            new CandidateProfile
            {
                CandidateId = "CANDIDATE0001",
                Fullname = "Alan Clinton",
                Birthday = new DateTime(1990, 9, 1),
                ProfileShortDescription = "Excellent communication skills with a commitment to understanding customer requirements as well as business objectives.",
                ProfileUrl = "AlanClinton.PDF",
                PostingId = "P0002"
            },
            new CandidateProfile
            {
                CandidateId = "CANDIDATE0002",
                Fullname = "Ethelbert Harron",
                Birthday = new DateTime(1993, 4, 16),
                ProfileShortDescription = "Critical thinking skills and an analytical mind with strong problem-solving abilities.",
                ProfileUrl = "EthelbertHarron.PDF",
                PostingId = "P0002"
            },
            new CandidateProfile
            {
                CandidateId = "CANDIDATE0003",
                Fullname = "Kenneth Paul",
                Birthday = new DateTime(1980, 9, 24),
                ProfileShortDescription = "Highly experienced with various operating systems and databases.",
                ProfileUrl = "KennethPaul.PDF",
                PostingId = "P0002"
            }
        };
            }

        public ArrayList GetCandidates()
        {
            return candidateArrayList;
        }

        public CandidateProfile GetCandidateProfile(string id)
        {
            foreach (CandidateProfile candidate in candidateArrayList)
            {
                if (candidate.CandidateId.Equals(id))
                {
                    return candidate;
                }
            }
            return null;
        }

        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            if(GetCandidateProfile(candidateProfile.CandidateId) == null)
            {
                candidateArrayList.Add(candidateProfile);
                return true;
            }
            return false;
        }

        public bool DeleteCandidateProfile(string id)
        {
            CandidateProfile candidate = GetCandidateProfile(id);
            if( candidate != null)
            {
                candidateArrayList.Remove(candidate);
                return true;
            }
            return false;
        }

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            for (int i = 0; i < candidateArrayList.Count; i++)
            {
                CandidateProfile existingProfile = (CandidateProfile) candidateArrayList[i];
                if(existingProfile.CandidateId == candidateProfile.CandidateId)
                {
                    candidateArrayList[i] = candidateProfile;
                    return true;
                }
            }
            return false;
        }

        public ArrayList SearchByName(string name)
        {
            ArrayList searchArrayList = new ArrayList();
            bool matchesName = false;
            foreach (CandidateProfile candidateProfile in candidateArrayList)
            {
                if (candidateProfile.Fullname.ToLower().Contains(name) || string.IsNullOrEmpty(name))
                    searchArrayList.Add(candidateProfile);
            }
            return searchArrayList;
        }
    }
}
