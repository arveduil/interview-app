using System.Collections.Generic;
using InterviewApp.Model;

namespace InterviewApp.Memory
{
    public interface IIntervieweesMemory
    {
        void Add(Interviewee interviewee, IEnumerable<Interview> interviews);
        
        IEnumerable<Interviewee> GetAll();
    }
}