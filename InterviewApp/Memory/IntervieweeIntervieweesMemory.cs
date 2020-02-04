using System;
using System.Collections.Generic;
using System.Linq;
using InterviewApp.Model;

namespace InterviewApp.Memory
{
    public class IntervieweesMemory : IIntervieweesMemory
    {
        private Dictionary<int, Interviewee> _interviewees;
        private Dictionary<string, Interview> _interviews;
        
        public IntervieweesMemory()
        {
            _interviewees = new Dictionary<int, Interviewee>();
            _interviews = new Dictionary<string, Interview>();
        }

        public void Add(Interviewee interviewee, IEnumerable<Interview> interviews)
        {
            if (interviewee is null)
            {
                throw new ArgumentException("Interviewee cannot be null");
            }
            
            if(!IntervieweeExists(interviewee))
            {
                _interviewees.Add(interviewee.GetHashCode(),interviewee);
            }
            else
            {
                interviewee = _interviewees[interviewee.GetHashCode()];
            }
            
            AddInterviews(interviewee, interviews);
        }

        private void AddInterviews(Interviewee interviewee, IEnumerable<Interview> interviews)
        {
            foreach (var interview in interviews)
            {
                if (interview is null)
                {
                    throw new ArgumentException("Interview cannot be null");
                }
                
                interview.ID = GenerateId();
                _interviews[interview.ID] = interview;
                interviewee.Interviews.Add(interview);
            }
        }

        public IEnumerable<Interviewee> GetAll()
        {
            return _interviewees.Values;
        }

        private static string GenerateId()
        {
            return new Guid().ToString();
        }

        private bool IntervieweeExists(Interviewee interviewee)
        {
            return _interviewees.ContainsKey(interviewee.GetHashCode());
        }
        
        
    }
}