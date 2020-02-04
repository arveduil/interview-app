using System.Collections.Generic;
using InterviewApp.Model;

namespace InterviewApp.Services
{
    public interface IIntervieweesService
    {
        IEnumerable<Interviewee> GetAllInterviewees();

        void SaveIntervieweeWithInterviews(Interviewee interviewee,IEnumerable<Interview> interviews);
    }
}