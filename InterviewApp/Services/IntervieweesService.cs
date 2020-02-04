using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using InterviewApp.Memory;
using InterviewApp.Model;

namespace InterviewApp.Services
{
    public class IntervieweesService : IIntervieweesService
    {
        private readonly IIntervieweesMemory _memory;

        public IntervieweesService(IIntervieweesMemory memory)
        {
            _memory = memory;
        }

        public IEnumerable<Interviewee> GetAllInterviewees()
        {
           return _memory.GetAll();
        }

        public void SaveIntervieweeWithInterviews(Interviewee interviewee, IEnumerable<Interview> interviews)
        {
            Check(interviewee);
            _memory.Add(interviewee,interviews);
            
        }


        private static void Check(Interviewee interviewee)
        {
            if (interviewee is null)
            {
                throw new ArgumentException("Interviewee cannot be null or empty.");
            }
            if (string.IsNullOrEmpty(interviewee.Name))
            {
                throw new ArgumentException("Name cannot be null or empty.");
            }
            
            if (string.IsNullOrEmpty(interviewee.Surname))
            {
                throw new ArgumentException("Surname cannot be null or empty.");
            }
        }
        
        private static void Check(IEnumerable<Interview> interviews)
        {
            if (interviews is null)
            {
                throw new ArgumentException("Interviews cannot be null or empty.");
            }
        }
    }
}